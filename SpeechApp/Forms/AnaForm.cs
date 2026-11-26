using SpeechApp.Models;
using SpeechApp.Services;

namespace SpeechApp.Forms;

/// <summary>Sesli okuma ve konuşmayı metne çevirme ana penceresi. Yalnızca arayüz ve olay bağlama yapar.</summary>
public partial class AnaForm : Form
{
    private ITextToSpeechService? _tts;
    private List<ISpeechToTextService> _sttServices = new();

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
        if (_tts?.VoiceNames.Count == 0)
            ShowError("Bilgisayarda yüklü bir okuma sesi bulunamadı. Windows Ayarlar > Saat ve dil > Konuşma bölümünden ses ekleyin.");
        if (_tts != null)
        {
            cmbSes.DataSource = _tts.VoiceNames;
            trkHiz.Value = _tts.Rate;
            lblHizDegeri.Text = _tts.Rate.ToString();
        }
        ShowTtsStatus(SpeechStatus.Bosta);
        LoadSpeechToTextServices();
    }

    private void LoadSpeechToTextServices()
    {
        _sttServices = SpeechToTextProviders.GetAll();
        foreach (var service in _sttServices)
        {
            service.SpeechRecognized += (_, text) => RunOnUi(() => AddRecognizedText(text));
            service.ErrorOccurred += (_, message) => RunOnUi(() => { ShowSttState(); ShowError(message); });
        }
        cmbTaniyici.DisplayMember = nameof(ISpeechToTextService.Name);
        cmbTaniyici.DataSource = _sttServices;
        ShowSttState();
    }

    private ISpeechToTextService? SelectedStt => cmbTaniyici.SelectedItem as ISpeechToTextService;

    private void btnDinle_Click(object? sender, EventArgs e)
    {
        if (SelectedStt == null) return;
        Cursor = Cursors.WaitCursor;
        try
        {
            SelectedStt.Start();
        }
        catch (SpeechServiceException ex)
        {
            ShowError(ex.Message);
        }
        catch (Exception ex)
        {
            ShowError("Dinleme başlatılamadı: " + ex.Message);
        }
        finally
        {
            Cursor = Cursors.Default;
        }
        ShowSttState();
    }

    private void btnDinlemeyiDurdur_Click(object? sender, EventArgs e)
    {
        SelectedStt?.Stop();
        ShowSttState();
    }

    private void btnMetniTemizle_Click(object? sender, EventArgs e)
    {
        rtbTaninan.Clear();
        lstCumleler.Items.Clear();
    }

    private void AddRecognizedText(string text)
    {
        rtbTaninan.AppendText(text + " ");
        rtbTaninan.ScrollToCaret();
        lstCumleler.Items.Add(new RecognizedSentence(DateTime.Now, text));
        lstCumleler.TopIndex = lstCumleler.Items.Count - 1;
    }

    /// <summary>Seçilen ses bir sonraki okumada kullanılır.</summary>
    private void cmbSes_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_tts == null || cmbSes.SelectedItem is not string voiceName) return;
        try
        {
            _tts.SelectVoice(voiceName);
        }
        catch (Exception ex)
        {
            ShowError($"\"{voiceName}\" sesi seçilemedi: " + ex.Message);
        }
    }

    private void trkHiz_Scroll(object? sender, EventArgs e)
    {
        if (_tts == null) return;
        _tts.Rate = trkHiz.Value;
        lblHizDegeri.Text = trkHiz.Value.ToString();
    }

    private void btnKaydet_Click(object? sender, EventArgs e) => SaveText(rtbMetin.Text, "metin.txt");

    private void btnTaninaniKaydet_Click(object? sender, EventArgs e)
    {
        var lines = lstCumleler.Items.Cast<RecognizedSentence>().Select(s => s.ToString());
        SaveText(string.Join(Environment.NewLine, lines), "taninan_cumleler.txt");
    }

    private void SaveText(string text, string defaultFileName)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            MessageBox.Show("Kaydedilecek metin yok.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        using var dialog = new SaveFileDialog
        {
            Filter = "Metin dosyası (*.txt)|*.txt",
            FileName = defaultFileName
        };
        if (dialog.ShowDialog(this) != DialogResult.OK) return;
        try
        {
            File.WriteAllText(dialog.FileName, text);
            lblDurum.Text = "Kaydedildi: " + dialog.FileName;
        }
        catch (Exception ex)
        {
            ShowError("Dosya kaydedilemedi: " + ex.Message);
        }
    }

    private void ShowSttState()
    {
        bool listening = SelectedStt?.IsListening == true;
        btnDinle.Enabled = SelectedStt != null && !listening;
        btnDinlemeyiDurdur.Enabled = listening;
        cmbTaniyici.Enabled = !listening;
        lblTaniyiciBilgi.Text = SpeechToTextProviders.GetWarnings(_sttServices);
        RefreshStatus();
    }

    private void btnOku_Click(object? sender, EventArgs e)
    {
        if (_tts == null)
        {
            ShowError("Sesli okuma kullanılamıyor: ses aygıtı başlatılamadı.");
            return;
        }
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
        RefreshStatus();
        bool ready = _tts != null;
        btnOku.Enabled = ready;
        btnDuraklat.Enabled = status != SpeechStatus.Bosta;
        btnDuraklat.Text = status == SpeechStatus.Duraklatildi ? "Devam Et" : "Duraklat";
        btnDurdur.Enabled = status != SpeechStatus.Bosta;
    }

    /// <summary>Okuma sürüyorsa onu, yoksa dinleme durumunu durum çubuğunda gösterir.</summary>
    private void RefreshStatus()
    {
        var status = _tts?.Status ?? SpeechStatus.Bosta;
        if (status == SpeechStatus.Bosta && SelectedStt?.IsListening == true)
            status = SpeechStatus.Dinleniyor;
        lblDurum.Text = "Durum: " + status.ToDisplayText();
    }

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
        foreach (var service in _sttServices)
            service.Dispose();
    }
}
