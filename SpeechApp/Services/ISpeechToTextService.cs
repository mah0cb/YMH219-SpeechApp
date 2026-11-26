namespace SpeechApp.Services;

/// <summary>Mikrofondan gelen konuşmayı metne çeviren servislerin ortak sözleşmesi.</summary>
public interface ISpeechToTextService : IDisposable
{
    /// <summary>Listede görünecek ad, örn. "Vosk (Türkçe, çevrimdışı)".</summary>
    string Name { get; }

    bool IsListening { get; }

    /// <summary>Mikrofonu açıp dinlemeye başlar. Sorun olursa SpeechServiceException fırlatır.</summary>
    void Start();

    void Stop();

    /// <summary>Bir cümle tanındığında metniyle tetiklenir (arka plan iş parçacığından gelebilir).</summary>
    event EventHandler<string>? SpeechRecognized;

    /// <summary>Dinleme sırasında hata oluşursa Türkçe mesajla tetiklenir.</summary>
    event EventHandler<string>? ErrorOccurred;
}
