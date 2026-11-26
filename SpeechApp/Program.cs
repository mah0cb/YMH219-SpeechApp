using SpeechApp.Forms;

namespace SpeechApp;

static class Program
{
    /// <summary>Konuşma uygulamasının giriş noktası.</summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new AnaForm());
    }
}
