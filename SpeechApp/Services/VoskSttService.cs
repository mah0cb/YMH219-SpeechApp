using System.Text.Json;
using NAudio.Wave;
using Vosk;

namespace SpeechApp.Services;

/// <summary>Vosk (çevrimdışı) ile Türkçe konuşma tanıma. Mikrofon sesi NAudio ile 16 kHz mono alınır.</summary>
public sealed class VoskSttService : ISpeechToTextService
{
    public const int SampleRate = 16000;

    private readonly string _modelPath;
    private readonly object _lock = new();
    private Model? _model;
    private VoskRecognizer? _recognizer;
    private WaveIn? _waveIn;

    public VoskSttService(string modelPath)
    {
        _modelPath = modelPath;
        Vosk.Vosk.SetLogLevel(-1);
    }

    /// <summary>Modelin beklendiği klasör: uygulama klasörü\VoskModels\vosk-model-small-tr-0.3</summary>
    public static string DefaultModelPath =>
        Path.Combine(AppContext.BaseDirectory, "VoskModels", "vosk-model-small-tr-0.3");

    public event EventHandler<string>? SpeechRecognized;
    public event EventHandler<string>? ErrorOccurred;

    public string Name => "Vosk: Türkçe (çevrimdışı)";

    public bool IsListening { get; private set; }

    public void Start()
    {
        if (IsListening) return;
        BeginRecognition();

        _waveIn = new WaveIn { WaveFormat = new WaveFormat(SampleRate, 16, 1), BufferMilliseconds = 100 };
        _waveIn.DataAvailable += (_, e) => ProcessAudio(e.Buffer, e.BytesRecorded);
        _waveIn.RecordingStopped += WaveIn_RecordingStopped;
        _waveIn.StartRecording();
        IsListening = true;
    }

    public void Stop()
    {
        if (!IsListening) return;
        IsListening = false;
        _waveIn?.StopRecording();
    }

    /// <summary>Modeli (ilk seferde) yükler ve yeni bir tanıyıcı oluşturur.</summary>
    public void BeginRecognition()
    {
        _model ??= new Model(_modelPath);
        lock (_lock)
        {
            _recognizer?.Dispose();
            _recognizer = new VoskRecognizer(_model, SampleRate);
        }
    }

    /// <summary>16 kHz, 16 bit, mono PCM ses parçasını tanıyıcıya verir; cümle bittiyse olayı tetikler.</summary>
    public void ProcessAudio(byte[] buffer, int count)
    {
        string? text = null;
        lock (_lock)
        {
            if (_recognizer != null && _recognizer.AcceptWaveform(buffer, count))
                text = ReadText(_recognizer.Result());
        }
        RaiseIfNotEmpty(text);
    }

    /// <summary>Yarım kalan son cümleyi de bildirir ve tanıyıcıyı kapatır.</summary>
    public void EndRecognition()
    {
        string? text = null;
        lock (_lock)
        {
            if (_recognizer != null)
            {
                text = ReadText(_recognizer.FinalResult());
                _recognizer.Dispose();
                _recognizer = null;
            }
        }
        RaiseIfNotEmpty(text);
    }

    private void WaveIn_RecordingStopped(object? sender, StoppedEventArgs e)
    {
        IsListening = false;
        _waveIn?.Dispose();
        _waveIn = null;
        EndRecognition();
        if (e.Exception != null)
            ErrorOccurred?.Invoke(this, "Mikrofon kaydı kesildi: " + e.Exception.Message);
    }

    /// <summary>Vosk sonucu {"text": "..."} biçiminde JSON döndürür.</summary>
    private static string ReadText(string json) =>
        JsonDocument.Parse(json).RootElement.GetProperty("text").GetString() ?? "";

    private void RaiseIfNotEmpty(string? text)
    {
        if (!string.IsNullOrWhiteSpace(text))
            SpeechRecognized?.Invoke(this, text);
    }

    public void Dispose()
    {
        _waveIn?.Dispose();
        _waveIn = null;
        IsListening = false;
        lock (_lock)
        {
            _recognizer?.Dispose();
            _recognizer = null;
        }
        _model?.Dispose();
        _model = null;
    }
}
