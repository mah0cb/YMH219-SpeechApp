using System.Speech.Recognition;

namespace SpeechApp.Services;

/// <summary>Windows'un yüklü System.Speech tanıyıcısıyla serbest dikte (DictationGrammar) servisi.</summary>
public sealed class SystemSpeechSttService : ISpeechToTextService
{
    private readonly RecognizerInfo _recognizerInfo;
    private SpeechRecognitionEngine? _engine;

    public SystemSpeechSttService(RecognizerInfo recognizerInfo)
    {
        _recognizerInfo = recognizerInfo;
    }

    public event EventHandler<string>? SpeechRecognized;
    public event EventHandler<string>? ErrorOccurred;

    public string Name => $"System.Speech: {_recognizerInfo.Description} ({_recognizerInfo.Culture.Name})";

    public bool IsListening { get; private set; }

    public void Start()
    {
        if (IsListening) return;
        try
        {
            _engine ??= CreateEngine();
        }
        catch (Exception ex)
        {
            throw new SpeechServiceException("Konuşma tanıyıcısı başlatılamadı. Windows konuşma dil paketi eksik olabilir.\n\nAyrıntı: " + ex.Message, ex);
        }
        try
        {
            _engine.SetInputToDefaultAudioDevice();
            _engine.RecognizeAsync(RecognizeMode.Multiple);
            IsListening = true;
        }
        catch (Exception ex)
        {
            throw new SpeechServiceException("Mikrofon bulunamadı veya kullanılamıyor. Bir mikrofon takın ve Windows Ses ayarlarında varsayılan kayıt aygıtı olarak seçin.\n\nAyrıntı: " + ex.Message, ex);
        }
    }

    public void Stop()
    {
        if (!IsListening) return;
        _engine?.RecognizeAsyncCancel();
        IsListening = false;
    }

    /// <summary>Motoru bir kez oluşturur; dikte dilbilgisi yüklemek birkaç saniye sürebilir.</summary>
    private SpeechRecognitionEngine CreateEngine()
    {
        var engine = new SpeechRecognitionEngine(_recognizerInfo);
        engine.LoadGrammar(new DictationGrammar());
        engine.SpeechRecognized += Engine_SpeechRecognized;
        engine.RecognizeCompleted += Engine_RecognizeCompleted;
        return engine;
    }

    private void Engine_SpeechRecognized(object? sender, SpeechRecognizedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(e.Result.Text))
            SpeechRecognized?.Invoke(this, e.Result.Text);
    }

    private void Engine_RecognizeCompleted(object? sender, RecognizeCompletedEventArgs e)
    {
        IsListening = false;
        if (e.Error != null)
            ErrorOccurred?.Invoke(this, "Dinleme sırasında hata oluştu: " + e.Error.Message);
    }

    public void Dispose()
    {
        Stop();
        _engine?.Dispose();
        _engine = null;
    }
}
