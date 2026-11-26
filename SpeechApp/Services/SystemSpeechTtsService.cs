using System.Speech.Synthesis;
using SpeechApp.Models;

namespace SpeechApp.Services;

/// <summary>Windows SAPI (System.Speech SpeechSynthesizer) ile metin okuma servisi.</summary>
public sealed class SystemSpeechTtsService : ITextToSpeechService
{
    private readonly SpeechSynthesizer _synthesizer;
    private SpeechStatus _status = SpeechStatus.Bosta;

    public SystemSpeechTtsService()
    {
        _synthesizer = new SpeechSynthesizer();
        _synthesizer.SetOutputToDefaultAudioDevice();
        _synthesizer.StateChanged += Synthesizer_StateChanged;
        _synthesizer.SpeakCompleted += Synthesizer_SpeakCompleted;
    }

    public event EventHandler<SpeechStatus>? StatusChanged;
    public event EventHandler<string>? ErrorOccurred;

    public SpeechStatus Status => _status;

    public int Rate
    {
        get => _synthesizer.Rate;
        set => _synthesizer.Rate = Math.Clamp(value, -10, 10);
    }

    public IReadOnlyList<string> VoiceNames =>
        _synthesizer.GetInstalledVoices().Where(v => v.Enabled).Select(v => v.VoiceInfo.Name).ToList();

    public void SelectVoice(string voiceName) => _synthesizer.SelectVoice(voiceName);

    /// <summary>Önceki okumayı iptal edip yeni metni asenkron okur.</summary>
    public void Speak(string text)
    {
        Stop();
        _synthesizer.SpeakAsync(text);
    }

    public void Pause()
    {
        if (_synthesizer.State == SynthesizerState.Speaking)
            _synthesizer.Pause();
    }

    public void Resume()
    {
        if (_synthesizer.State == SynthesizerState.Paused)
            _synthesizer.Resume();
    }

    /// <summary>Okumayı tamamen durdurur. Duraklatılmış sentezleyici iptali işlemediği için önce devam ettirilir.</summary>
    public void Stop()
    {
        Resume();
        _synthesizer.SpeakAsyncCancelAll();
    }

    private void Synthesizer_StateChanged(object? sender, StateChangedEventArgs e)
    {
        _status = e.State switch
        {
            SynthesizerState.Speaking => SpeechStatus.Okunuyor,
            SynthesizerState.Paused => SpeechStatus.Duraklatildi,
            _ => SpeechStatus.Bosta
        };
        StatusChanged?.Invoke(this, _status);
    }

    private void Synthesizer_SpeakCompleted(object? sender, SpeakCompletedEventArgs e)
    {
        if (e.Error != null)
            ErrorOccurred?.Invoke(this, "Metin okunurken hata oluştu: " + e.Error.Message);
    }

    public void Dispose()
    {
        _synthesizer.StateChanged -= Synthesizer_StateChanged;
        _synthesizer.SpeakCompleted -= Synthesizer_SpeakCompleted;
        _synthesizer.SpeakAsyncCancelAll();
        _synthesizer.Dispose();
    }
}
