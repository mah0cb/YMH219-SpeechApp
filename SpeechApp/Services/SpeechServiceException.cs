namespace SpeechApp.Services;

/// <summary>Mikrofon, tanıyıcı veya model sorunlarını kullanıcıya gösterilecek Türkçe mesajla taşır.</summary>
public class SpeechServiceException : Exception
{
    public SpeechServiceException(string message, Exception? innerException = null)
        : base(message, innerException)
    {
    }
}
