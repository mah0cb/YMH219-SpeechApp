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
        stsDurum = new StatusStrip();
        lblDurum = new ToolStripStatusLabel();
        tabAna.SuspendLayout();
        tabSesliOkuma.SuspendLayout();
        stsDurum.SuspendLayout();
        SuspendLayout();
        //
        // tabAna
        //
        tabAna.Controls.Add(tabSesliOkuma);
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
        rtbMetin.Size = new Size(728, 360);
        rtbMetin.TabIndex = 0;
        rtbMetin.Text = "";
        //
        // btnOku
        //
        btnOku.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnOku.Location = new Point(12, 384);
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
        btnDuraklat.Location = new Point(108, 384);
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
        btnDurdur.Location = new Point(204, 384);
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
        btnTemizle.Location = new Point(300, 384);
        btnTemizle.Name = "btnTemizle";
        btnTemizle.Size = new Size(90, 30);
        btnTemizle.TabIndex = 4;
        btnTemizle.Text = "Temizle";
        btnTemizle.UseVisualStyleBackColor = true;
        btnTemizle.Click += btnTemizle_Click;
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
    private StatusStrip stsDurum;
    private ToolStripStatusLabel lblDurum;
}
