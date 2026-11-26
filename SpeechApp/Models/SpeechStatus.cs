namespace SpeechApp.Models;

/// <summary>Uygulamada o anda yürüyen konuşma işlemi.</summary>
public enum SpeechStatus
{
    Bosta,
    Okunuyor,
    Duraklatildi,
    Dinleniyor
}

/// <summary>Durumların arayüzde gösterilecek Türkçe karşılıkları.</summary>
public static class SpeechStatusExtensions
{
    public static string ToDisplayText(this SpeechStatus status) => status switch
    {
        SpeechStatus.Okunuyor => "Okunuyor",
        SpeechStatus.Duraklatildi => "Duraklatıldı",
        SpeechStatus.Dinleniyor => "Dinleniyor",
        _ => "Boşta"
    };
}
