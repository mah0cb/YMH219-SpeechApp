namespace SpeechApp.Models;

/// <summary>Tanınan bir cümle ve tanındığı an. Listede "[14:02:31] metin" biçiminde görünür.</summary>
public record RecognizedSentence(DateTime Time, string Text)
{
    public override string ToString() => $"[{Time:HH:mm:ss}] {Text}";
}
