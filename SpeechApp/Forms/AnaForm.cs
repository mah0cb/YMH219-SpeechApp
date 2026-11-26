using SpeechApp.Models;
using SpeechApp.Services;

namespace SpeechApp.Forms;

/// <summary>Sesli okuma ve konuşmayı metne çevirme ana penceresi. Yalnızca arayüz ve olay bağlama yapar.</summary>
public partial class AnaForm : Form
{
    private ITextToSpeechService? _tts;

    public AnaForm()
    {
        InitializeComponent();
    }

    private void AnaForm_Load(object? sender, EventArgs e)
    {
        try
        {
            _tts = new SystemSpeechTtsService();
            _tts.StatusChanged += (_, status) => RunOnUi(() => ShowTtsStatus(status));
            _tts.ErrorOccurred += (_, message) => RunOnUi(() => ShowError(message));
        }
        catch (Exception ex)
        {
            ShowError("Sesli okuma başlatılamadı. Hoparlör veya ses aygıtı bulunamadı.\n\nAyrıntı: " + ex.Message);
        }
        ShowTtsStatus(SpeechStatus.Bosta);
    }

    private void btnOku_Click(object? sender, EventArgs e)
    {
        if (_tts == null) return;
        if (string.IsNullOrWhiteSpace(rtbMetin.Text))
        {
            MessageBox.Show("Okunacak metin yok. Önce metin alanına bir şeyler yazın.", "Bilgi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        try
        {
            _tts.Speak(rtbMetin.Text);
        }
        catch (Exception ex)
        {
            ShowError("Metin okunamadı: " + ex.Message);
        }
    }

    /// <summary>Okunuyorsa duraklatır, duraklatılmışsa devam ettirir.</summary>
    private void btnDuraklat_Click(object? sender, EventArgs e)
    {
        if (_tts?.Status == SpeechStatus.Okunuyor) _tts.Pause();
        else if (_tts?.Status == SpeechStatus.Duraklatildi) _tts.Resume();
    }

    private void btnDurdur_Click(object? sender, EventArgs e) => _tts?.Stop();

    private void btnTemizle_Click(object? sender, EventArgs e)
    {
        _tts?.Stop();
        rtbMetin.Clear();
        rtbMetin.Focus();
    }

    private void ShowTtsStatus(SpeechStatus status)
    {
        ShowStatus(status);
        bool ready = _tts != null;
        btnOku.Enabled = ready;
        btnDuraklat.Enabled = status != SpeechStatus.Bosta;
        btnDuraklat.Text = status == SpeechStatus.Duraklatildi ? "Devam Et" : "Duraklat";
        btnDurdur.Enabled = status != SpeechStatus.Bosta;
    }

    private void ShowStatus(SpeechStatus status) => lblDurum.Text = "Durum: " + status.ToDisplayText();

    private void ShowError(string message) =>
        MessageBox.Show(message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

    /// <summary>Servis olayları arka plan iş parçacığından gelebilir; arayüz işini form iş parçacığına aktarır.</summary>
    private void RunOnUi(Action action)
    {
        if (IsDisposed) return;
        if (InvokeRequired) BeginInvoke(action);
        else action();
    }

    /// <summary>Form kapanırken konuşma kaynaklarını serbest bırakır.</summary>
    private void AnaForm_FormClosed(object? sender, FormClosedEventArgs e)
    {
        _tts?.Dispose();
    }
}
