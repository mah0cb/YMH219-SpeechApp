using SpeechApp.Models;

namespace SpeechApp.Services;

/// <summary>Metni sesli okuyan servislerin ortak sözleşmesi.</summary>
public interface ITextToSpeechService : IDisposable
{
    /// <summary>Okuma durumu: Boşta, Okunuyor veya Duraklatıldı.</summary>
    SpeechStatus Status { get; }

    /// <summary>Okuma hızı, -10 (yavaş) ile 10 (hızlı) arası.</summary>
    int Rate { get; set; }

    /// <summary>Bilgisayarda kullanılabilen seslerin adları.</summary>
    IReadOnlyList<string> VoiceNames { get; }

    void SelectVoice(string voiceName);
    void Speak(string text);
    void Pause();
    void Resume();
    void Stop();

    /// <summary>Okuma durumu değiştiğinde tetiklenir.</summary>
    event EventHandler<SpeechStatus>? StatusChanged;

    /// <summary>Okuma sırasında hata oluşursa Türkçe mesajla tetiklenir.</summary>
    event EventHandler<string>? ErrorOccurred;
}
