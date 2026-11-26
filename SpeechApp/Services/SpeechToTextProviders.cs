using System.Speech.Recognition;

namespace SpeechApp.Services;

/// <summary>Bilgisayarda kullanılabilecek konuşma tanıma servislerini listeler.</summary>
public static class SpeechToTextProviders
{
    /// <summary>Yüklü her System.Speech tanıyıcısı için bir servis ve her zaman Vosk servisini döndürür.</summary>
    public static List<ISpeechToTextService> GetAll()
    {
        var services = new List<ISpeechToTextService>();
        try
        {
            services.AddRange(SpeechRecognitionEngine.InstalledRecognizers()
                .Select(info => new SystemSpeechSttService(info)));
        }
        catch (Exception)
        {
            // Tanıyıcılar okunamazsa yalnızca Vosk sunulur; durum GetWarnings ile kullanıcıya bildirilir.
        }
        services.Add(new VoskSttService(VoskSttService.DefaultModelPath));
        return services;
    }

    /// <summary>Eksik tanıyıcı, model veya mikrofon için kullanıcıya gösterilecek Türkçe uyarılar.</summary>
    public static string GetWarnings(IEnumerable<ISpeechToTextService> services)
    {
        var warnings = new List<string>();
        if (!services.OfType<SystemSpeechSttService>().Any())
            warnings.Add("System.Speech tanıyıcısı yüklü değil, Vosk kullanılabilir.");
        if (services.OfType<VoskSttService>().Any(v => !v.IsModelAvailable))
            warnings.Add("Vosk modeli bulunamadı (README'ye bakın).");
        if (!VoskSttService.IsMicrophoneAvailable)
            warnings.Add("Mikrofon algılanmadı.");
        return string.Join(" ", warnings);
    }
}
