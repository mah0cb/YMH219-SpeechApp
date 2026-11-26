using System.Speech.Recognition;

namespace SpeechApp.Services;

/// <summary>Bilgisayarda kullanılabilecek konuşma tanıma servislerini listeler.</summary>
public static class SpeechToTextProviders
{
    /// <summary>Yüklü her System.Speech tanıyıcısı için bir servis ve her zaman Vosk servisini döndürür.</summary>
    public static List<ISpeechToTextService> GetAll()
    {
        var services = SpeechRecognitionEngine.InstalledRecognizers()
            .Select(info => (ISpeechToTextService)new SystemSpeechSttService(info))
            .ToList();
        services.Add(new VoskSttService(VoskSttService.DefaultModelPath));
        return services;
    }
}
