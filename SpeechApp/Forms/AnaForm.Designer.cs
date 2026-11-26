namespace SpeechApp.Forms;

partial class AnaForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        tabAna = new TabControl();
        tabSesliOkuma = new TabPage();
        rtbMetin = new RichTextBox();
        btnOku = new Button();
        btnDuraklat = new Button();
        btnDurdur = new Button();
        btnTemizle = new Button();
        tabKonusma = new TabPage();
        lblTaniyici = new Label();
        cmbTaniyici = new ComboBox();
        btnDinle = new Button();
        btnDinlemeyiDurdur = new Button();
        btnMetniTemizle = new Button();
        rtbTaninan = new RichTextBox();
        lblTaniyiciBilgi = new Label();
        btnKaydet = new Button();
        lblSes = new Label();
        cmbSes = new ComboBox();
        lblHiz = new Label();
        trkHiz = new TrackBar();
        lblHizDegeri = new Label();
        lblCumleler = new Label();
        lstCumleler = new ListBox();
        btnTaninaniKaydet = new Button();
        stsDurum = new StatusStrip();
        lblDurum = new ToolStripStatusLabel();
        tabAna.SuspendLayout();
        tabSesliOkuma.SuspendLayout();
        tabKonusma.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)trkHiz).BeginInit();
        stsDurum.SuspendLayout();
        SuspendLayout();
        // 
        // tabAna
        // 
        tabAna.Controls.Add(tabSesliOkuma);
        tabAna.Controls.Add(tabKonusma);
        tabAna.Dock = DockStyle.Fill;
        tabAna.Location = new Point(0, 0);
        tabAna.Name = "tabAna";
        tabAna.SelectedIndex = 0;
        tabAna.Size = new Size(760, 498);
        tabAna.TabIndex = 0;
        // 
        // tabSesliOkuma
        // 
        tabSesliOkuma.Controls.Add(rtbMetin);
        tabSesliOkuma.Controls.Add(btnOku);
        tabSesliOkuma.Controls.Add(btnDuraklat);
        tabSesliOkuma.Controls.Add(btnDurdur);
        tabSesliOkuma.Controls.Add(btnTemizle);
        tabSesliOkuma.Controls.Add(btnKaydet);
        tabSesliOkuma.Controls.Add(lblSes);
        tabSesliOkuma.Controls.Add(cmbSes);
        tabSesliOkuma.Controls.Add(lblHiz);
        tabSesliOkuma.Controls.Add(trkHiz);
        tabSesliOkuma.Controls.Add(lblHizDegeri);
        tabSesliOkuma.Location = new Point(4, 24);
        tabSesliOkuma.Name = "tabSesliOkuma";
        tabSesliOkuma.Padding = new Padding(3);
        tabSesliOkuma.Size = new Size(752, 470);
        tabSesliOkuma.TabIndex = 0;
        tabSesliOkuma.Text = "Sesli Okuma";
        tabSesliOkuma.UseVisualStyleBackColor = true;
        // 
        // rtbMetin
        // 
        rtbMetin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        rtbMetin.Font = new Font("Segoe UI", 11F);
        rtbMetin.Location = new Point(12, 12);
        rtbMetin.Name = "rtbMetin";
        rtbMetin.Size = new Size(728, 320);
        rtbMetin.TabIndex = 0;
        rtbMetin.Text = "";
        // 
        // btnOku
        // 
        btnOku.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnOku.Location = new Point(12, 344);
        btnOku.Name = "btnOku";
        btnOku.Size = new Size(90, 30);
        btnOku.TabIndex = 1;
        btnOku.Text = "Oku";
        btnOku.UseVisualStyleBackColor = true;
        btnOku.Click += btnOku_Click;
        // 
        // btnDuraklat
        // 
        btnDuraklat.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnDuraklat.Location = new Point(108, 344);
        btnDuraklat.Name = "btnDuraklat";
        btnDuraklat.Size = new Size(90, 30);
        btnDuraklat.TabIndex = 2;
        btnDuraklat.Text = "Duraklat";
        btnDuraklat.UseVisualStyleBackColor = true;
        btnDuraklat.Click += btnDuraklat_Click;
        // 
        // btnDurdur
        // 
        btnDurdur.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnDurdur.Location = new Point(204, 344);
        btnDurdur.Name = "btnDurdur";
        btnDurdur.Size = new Size(90, 30);
        btnDurdur.TabIndex = 3;
        btnDurdur.Text = "Durdur";
        btnDurdur.UseVisualStyleBackColor = true;
        btnDurdur.Click += btnDurdur_Click;
        // 
        // btnTemizle
        // 
        btnTemizle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnTemizle.Location = new Point(300, 344);
        btnTemizle.Name = "btnTemizle";
        btnTemizle.Size = new Size(90, 30);
        btnTemizle.TabIndex = 4;
        btnTemizle.Text = "Temizle";
        btnTemizle.UseVisualStyleBackColor = true;
        btnTemizle.Click += btnTemizle_Click;
        // 
        // tabKonusma
        // 
        tabKonusma.Controls.Add(lblTaniyici);
        tabKonusma.Controls.Add(cmbTaniyici);
        tabKonusma.Controls.Add(btnDinle);
        tabKonusma.Controls.Add(btnDinlemeyiDurdur);
        tabKonusma.Controls.Add(btnMetniTemizle);
        tabKonusma.Controls.Add(rtbTaninan);
        tabKonusma.Controls.Add(lblTaniyiciBilgi);
        tabKonusma.Controls.Add(lblCumleler);
        tabKonusma.Controls.Add(lstCumleler);
        tabKonusma.Controls.Add(btnTaninaniKaydet);
        tabKonusma.Location = new Point(4, 24);
        tabKonusma.Name = "tabKonusma";
        tabKonusma.Padding = new Padding(3);
        tabKonusma.Size = new Size(752, 470);
        tabKonusma.TabIndex = 1;
        tabKonusma.Text = "Konuşmayı Metne Çevir";
        tabKonusma.UseVisualStyleBackColor = true;
        // 
        // lblTaniyici
        // 
        lblTaniyici.AutoSize = true;
        lblTaniyici.Location = new Point(12, 17);
        lblTaniyici.Name = "lblTaniyici";
        lblTaniyici.Size = new Size(52, 15);
        lblTaniyici.TabIndex = 0;
        lblTaniyici.Text = "Tanıyıcı:";
        // 
        // cmbTaniyici
        // 
        cmbTaniyici.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbTaniyici.Location = new Point(80, 13);
        cmbTaniyici.Name = "cmbTaniyici";
        cmbTaniyici.Size = new Size(300, 23);
        cmbTaniyici.TabIndex = 1;
        // 
        // btnDinle
        // 
        btnDinle.Location = new Point(390, 10);
        btnDinle.Name = "btnDinle";
        btnDinle.Size = new Size(130, 30);
        btnDinle.TabIndex = 2;
        btnDinle.Text = "Dinlemeye Başla";
        btnDinle.UseVisualStyleBackColor = true;
        btnDinle.Click += btnDinle_Click;
        // 
        // btnDinlemeyiDurdur
        // 
        btnDinlemeyiDurdur.Location = new Point(526, 10);
        btnDinlemeyiDurdur.Name = "btnDinlemeyiDurdur";
        btnDinlemeyiDurdur.Size = new Size(100, 30);
        btnDinlemeyiDurdur.TabIndex = 3;
        btnDinlemeyiDurdur.Text = "Durdur";
        btnDinlemeyiDurdur.UseVisualStyleBackColor = true;
        btnDinlemeyiDurdur.Click += btnDinlemeyiDurdur_Click;
        // 
        // btnMetniTemizle
        // 
        btnMetniTemizle.Location = new Point(632, 10);
        btnMetniTemizle.Name = "btnMetniTemizle";
        btnMetniTemizle.Size = new Size(100, 30);
        btnMetniTemizle.TabIndex = 4;
        btnMetniTemizle.Text = "Temizle";
        btnMetniTemizle.UseVisualStyleBackColor = true;
        btnMetniTemizle.Click += btnMetniTemizle_Click;
        // 
        // rtbTaninan
        // 
        rtbTaninan.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        rtbTaninan.Font = new Font("Segoe UI", 11F);
        rtbTaninan.Location = new Point(12, 72);
        rtbTaninan.Name = "rtbTaninan";
        rtbTaninan.Size = new Size(728, 200);
        rtbTaninan.TabIndex = 6;
        rtbTaninan.Text = "";
        // 
        // lblTaniyiciBilgi
        // 
        lblTaniyiciBilgi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        lblTaniyiciBilgi.ForeColor = Color.DarkRed;
        lblTaniyiciBilgi.Location = new Point(12, 46);
        lblTaniyiciBilgi.Name = "lblTaniyiciBilgi";
        lblTaniyiciBilgi.Size = new Size(728, 20);
        lblTaniyiciBilgi.TabIndex = 5;
        // 
        // btnKaydet
        // 
        btnKaydet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnKaydet.Location = new Point(396, 344);
        btnKaydet.Name = "btnKaydet";
        btnKaydet.Size = new Size(100, 30);
        btnKaydet.TabIndex = 5;
        btnKaydet.Text = "Kaydet (.txt)";
        btnKaydet.UseVisualStyleBackColor = true;
        btnKaydet.Click += btnKaydet_Click;
        // 
        // lblSes
        // 
        lblSes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblSes.AutoSize = true;
        lblSes.Location = new Point(12, 394);
        lblSes.Name = "lblSes";
        lblSes.Size = new Size(26, 15);
        lblSes.TabIndex = 6;
        lblSes.Text = "Ses:";
        // 
        // cmbSes
        // 
        cmbSes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        cmbSes.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbSes.Location = new Point(50, 390);
        cmbSes.Name = "cmbSes";
        cmbSes.Size = new Size(280, 23);
        cmbSes.TabIndex = 7;
        cmbSes.SelectedIndexChanged += cmbSes_SelectedIndexChanged;
        // 
        // lblHiz
        // 
        lblHiz.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblHiz.AutoSize = true;
        lblHiz.Location = new Point(350, 394);
        lblHiz.Name = "lblHiz";
        lblHiz.Size = new Size(28, 15);
        lblHiz.TabIndex = 8;
        lblHiz.Text = "Hız:";
        // 
        // trkHiz
        // 
        trkHiz.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        trkHiz.LargeChange = 2;
        trkHiz.Location = new Point(385, 384);
        trkHiz.Minimum = -10;
        trkHiz.Name = "trkHiz";
        trkHiz.Size = new Size(200, 45);
        trkHiz.TabIndex = 9;
        trkHiz.TickFrequency = 2;
        trkHiz.Scroll += trkHiz_Scroll;
        // 
        // lblHizDegeri
        // 
        lblHizDegeri.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblHizDegeri.AutoSize = true;
        lblHizDegeri.Location = new Point(590, 394);
        lblHizDegeri.Name = "lblHizDegeri";
        lblHizDegeri.Size = new Size(13, 15);
        lblHizDegeri.TabIndex = 10;
        lblHizDegeri.Text = "0";
        // 
        // lblCumleler
        // 
        lblCumleler.AutoSize = true;
        lblCumleler.Location = new Point(12, 284);
        lblCumleler.Name = "lblCumleler";
        lblCumleler.Size = new Size(190, 15);
        lblCumleler.TabIndex = 7;
        lblCumleler.Text = "Tanınan cümleler (zaman damgalı):";
        // 
        // lstCumleler
        // 
        lstCumleler.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lstCumleler.HorizontalScrollbar = true;
        lstCumleler.Location = new Point(12, 312);
        lstCumleler.Name = "lstCumleler";
        lstCumleler.Size = new Size(728, 139);
        lstCumleler.TabIndex = 8;
        // 
        // btnTaninaniKaydet
        // 
        btnTaninaniKaydet.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnTaninaniKaydet.Location = new Point(640, 278);
        btnTaninaniKaydet.Name = "btnTaninaniKaydet";
        btnTaninaniKaydet.Size = new Size(100, 28);
        btnTaninaniKaydet.TabIndex = 9;
        btnTaninaniKaydet.Text = "Kaydet (.txt)";
        btnTaninaniKaydet.UseVisualStyleBackColor = true;
        btnTaninaniKaydet.Click += btnTaninaniKaydet_Click;
        // 
        // stsDurum
        // 
        stsDurum.Items.AddRange(new ToolStripItem[] { lblDurum });
        stsDurum.Location = new Point(0, 498);
        stsDurum.Name = "stsDurum";
        stsDurum.Size = new Size(760, 22);
        stsDurum.TabIndex = 1;
        // 
        // lblDurum
        // 
        lblDurum.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblDurum.Name = "lblDurum";
        lblDurum.Size = new Size(85, 17);
        lblDurum.Text = "Durum: Boşta";
        // 
        // AnaForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(760, 520);
        Controls.Add(tabAna);
        Controls.Add(stsDurum);
        MinimumSize = new Size(640, 480);
        Name = "AnaForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Konuşma Uygulaması";
        FormClosed += AnaForm_FormClosed;
        Load += AnaForm_Load;
        tabAna.ResumeLayout(false);
        tabSesliOkuma.ResumeLayout(false);
        tabSesliOkuma.PerformLayout();
        tabKonusma.ResumeLayout(false);
        tabKonusma.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)trkHiz).EndInit();
        stsDurum.ResumeLayout(false);
        stsDurum.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TabControl tabAna;
    private TabPage tabSesliOkuma;
    private RichTextBox rtbMetin;
    private Button btnOku;
    private Button btnDuraklat;
    private Button btnDurdur;
    private Button btnTemizle;
    private TabPage tabKonusma;
    private Label lblTaniyici;
    private ComboBox cmbTaniyici;
    private Button btnDinle;
    private Button btnDinlemeyiDurdur;
    private Button btnMetniTemizle;
    private RichTextBox rtbTaninan;
    private Label lblTaniyiciBilgi;
    private Button btnKaydet;
    private Label lblSes;
    private ComboBox cmbSes;
    private Label lblHiz;
    private TrackBar trkHiz;
    private Label lblHizDegeri;
    private Label lblCumleler;
    private ListBox lstCumleler;
    private Button btnTaninaniKaydet;
    private StatusStrip stsDurum;
    private ToolStripStatusLabel lblDurum;
}
