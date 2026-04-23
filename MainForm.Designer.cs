namespace MediaJet_V1
{
    partial class MainForm
    {
        /// <summary>
        /// Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        /// <param name="disposing">Yönetilen kaynaklar dispose edilmeliyse true.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        /// içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.lblUrl = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.lblFormat = new System.Windows.Forms.Label();
            this.comboBoxFormat = new System.Windows.Forms.ComboBox();
            this.btnIndir = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.btnLogTemizle = new System.Windows.Forms.Button();
            this.btnKlasorAc = new System.Windows.Forms.Button();
            this.btnGithub = new System.Windows.Forms.Button();
            this.btnLanguage = new System.Windows.Forms.Button();
            // Yeni kontroller
            this.grpSecenekler = new System.Windows.Forms.GroupBox();
            this.chkPlaylist = new System.Windows.Forms.CheckBox();
            this.chkMetadata = new System.Windows.Forms.CheckBox();
            this.chkSubtitles = new System.Windows.Forms.CheckBox();
            this.chkOtoPanoyaBak = new System.Windows.Forms.CheckBox();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.tmrPano = new System.Windows.Forms.Timer(this.components);
            this.grpSecenekler.SuspendLayout();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblAltBaslik = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader - Üst başlık paneli
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(25)))));
            this.panelHeader.Controls.Add(this.btnLanguage);
            this.panelHeader.Controls.Add(this.btnGithub);
            this.panelHeader.Controls.Add(this.lblBaslik);
            this.panelHeader.Controls.Add(this.lblAltBaslik);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(700, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // lblBaslik - Ana başlık
            // 
            this.lblBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.lblBaslik.Location = new System.Drawing.Point(0, 0);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(700, 50);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "🎬 MediaJet V1 - Evrensel İndirici";
            this.lblBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAltBaslik - Alt başlık
            // 
            this.lblAltBaslik.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAltBaslik.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAltBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.lblAltBaslik.Location = new System.Drawing.Point(0, 55);
            this.lblAltBaslik.Name = "lblAltBaslik";
            this.lblAltBaslik.Size = new System.Drawing.Size(700, 25);
            this.lblAltBaslik.TabIndex = 1;
            this.lblAltBaslik.Text = "YouTube, Instagram, TikTok, Twitter ve daha fazlası...";
            this.lblAltBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUrl - URL etiketi
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUrl.ForeColor = System.Drawing.Color.White;
            this.lblUrl.Location = new System.Drawing.Point(20, 95);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(110, 19);
            this.lblUrl.TabIndex = 1;
            this.lblUrl.Text = "📎 Video URL'si:";
            // 
            // txtUrl - URL giriş kutusu
            // 
            this.txtUrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this.txtUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUrl.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUrl.ForeColor = System.Drawing.Color.White;
            this.txtUrl.Location = new System.Drawing.Point(20, 120);
            this.txtUrl.Multiline = true;
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(580, 50);
            this.txtUrl.TabIndex = 2;
            // 
            // btnTemizle - URL temizle butonu
            // 
            this.btnTemizle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.btnTemizle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTemizle.FlatAppearance.BorderSize = 0;
            this.btnTemizle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemizle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTemizle.ForeColor = System.Drawing.Color.White;
            this.btnTemizle.Location = new System.Drawing.Point(610, 120);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(70, 50);
            this.btnTemizle.TabIndex = 3;
            this.btnTemizle.Text = "TEMİZLE";
            this.btnTemizle.UseVisualStyleBackColor = false;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // lblFormat - Format etiketi
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblFormat.ForeColor = System.Drawing.Color.White;
            this.lblFormat.Location = new System.Drawing.Point(20, 185);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(127, 19);
            this.lblFormat.TabIndex = 4;
            this.lblFormat.Text = "🎯 İndirme Formatı:";
            // 
            // comboBoxFormat - Format seçici
            // 
            this.comboBoxFormat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this.comboBoxFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxFormat.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxFormat.ForeColor = System.Drawing.Color.White;
            this.comboBoxFormat.FormattingEnabled = true;
            this.comboBoxFormat.Items.AddRange(new object[] {
            "MP4 (En İyi Kalite)",
            "MP4 (1080p)",
            "MP3 (Sadece Ses)"});
            this.comboBoxFormat.Location = new System.Drawing.Point(20, 210);
            this.comboBoxFormat.Name = "comboBoxFormat";
            this.comboBoxFormat.Size = new System.Drawing.Size(250, 28);
            this.comboBoxFormat.TabIndex = 5;
            // 
            // btnIndir - Ana indirme butonu
            // 
            this.btnIndir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.btnIndir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIndir.FlatAppearance.BorderSize = 0;
            this.btnIndir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIndir.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnIndir.ForeColor = System.Drawing.Color.White;
            this.btnIndir.Location = new System.Drawing.Point(300, 195);
            this.btnIndir.Name = "btnIndir";
            this.btnIndir.Size = new System.Drawing.Size(380, 50);
            this.btnIndir.TabIndex = 6;
            this.btnIndir.Text = "⬇️ İNDİR / DOWNLOAD";
            this.btnIndir.UseVisualStyleBackColor = false;
            this.btnIndir.Click += new System.EventHandler(this.btnIndir_Click);
            // 
            // progressBar - İlerleme çubuğu
            // 
            this.progressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(35)))));
            this.progressBar.Location = new System.Drawing.Point(20, 260);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(660, 25);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 7;
            // 
            // lblLog - Log etiketi
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblLog.ForeColor = System.Drawing.Color.White;
            this.lblLog.Location = new System.Drawing.Point(20, 300);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(123, 19);
            this.lblLog.TabIndex = 8;
            this.lblLog.Text = "📋 İşlem Kayıtları:";
            // 
            // richTextBoxLog - Log gösterici
            // 
            this.richTextBoxLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(25)))));
            this.richTextBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richTextBoxLog.ForeColor = System.Drawing.Color.White;
            this.richTextBoxLog.Location = new System.Drawing.Point(20, 325);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.ReadOnly = true;
            this.richTextBoxLog.Size = new System.Drawing.Size(660, 180);
            this.richTextBoxLog.TabIndex = 9;
            this.richTextBoxLog.Text = "";
            // 
            // btnLogTemizle - Log temizle butonu
            // 
            this.btnLogTemizle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.btnLogTemizle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogTemizle.FlatAppearance.BorderSize = 0;
            this.btnLogTemizle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogTemizle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLogTemizle.ForeColor = System.Drawing.Color.White;
            this.btnLogTemizle.Location = new System.Drawing.Point(20, 515);
            this.btnLogTemizle.Name = "btnLogTemizle";
            this.btnLogTemizle.Size = new System.Drawing.Size(120, 35);
            this.btnLogTemizle.TabIndex = 10;
            this.btnLogTemizle.Text = "🗑️ Logu Temizle";
            this.btnLogTemizle.UseVisualStyleBackColor = false;
            this.btnLogTemizle.Click += new System.EventHandler(this.btnLogTemizle_Click);
            // 
            // btnKlasorAc - Klasör aç butonu
            // 
            this.btnKlasorAc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnKlasorAc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKlasorAc.FlatAppearance.BorderSize = 0;
            this.btnKlasorAc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKlasorAc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKlasorAc.ForeColor = System.Drawing.Color.White;
            this.btnKlasorAc.Location = new System.Drawing.Point(520, 515);
            this.btnKlasorAc.Name = "btnKlasorAc";
            this.btnKlasorAc.Size = new System.Drawing.Size(160, 35);
            this.btnKlasorAc.TabIndex = 11;
            this.btnKlasorAc.Text = "📂 Downloads Klasörü";
            this.btnKlasorAc.UseVisualStyleBackColor = false;
            this.btnKlasorAc.Click += new System.EventHandler(this.btnKlasorAc_Click);
            // 
            // btnGithub
            // 
            this.btnGithub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.btnGithub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGithub.FlatAppearance.BorderSize = 0;
            this.btnGithub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGithub.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGithub.ForeColor = System.Drawing.Color.White;
            this.btnGithub.Location = new System.Drawing.Point(20, 20);
            this.btnGithub.Name = "btnGithub";
            this.btnGithub.Size = new System.Drawing.Size(80, 30);
            this.btnGithub.TabIndex = 12;
            this.btnGithub.Text = "GitHub";
            this.btnGithub.UseVisualStyleBackColor = false;
            this.btnGithub.Click += new System.EventHandler(this.btnGithub_Click);
            // 
            // btnLanguage
            // 
            this.btnLanguage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.btnLanguage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLanguage.FlatAppearance.BorderSize = 0;
            this.btnLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLanguage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLanguage.ForeColor = System.Drawing.Color.White;
            this.btnLanguage.Location = new System.Drawing.Point(600, 20);
            this.btnLanguage.Name = "btnLanguage";
            this.btnLanguage.Size = new System.Drawing.Size(80, 30);
            this.btnLanguage.TabIndex = 13;
            this.btnLanguage.Text = "TR / EN";
            this.btnLanguage.UseVisualStyleBackColor = false;
            this.btnLanguage.Click += new System.EventHandler(this.btnLanguage_Click);
            // 
            // MainForm - Ana form ayarları
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(700, 565);
            // 
            // grpSecenekler
            // 
            this.grpSecenekler.Controls.Add(this.chkPlaylist);
            this.grpSecenekler.Controls.Add(this.chkMetadata);
            this.grpSecenekler.Controls.Add(this.chkSubtitles);
            this.grpSecenekler.Controls.Add(this.chkOtoPanoyaBak);
            this.grpSecenekler.Controls.Add(this.btnGuncelle);
            this.grpSecenekler.ForeColor = System.Drawing.Color.White;
            this.grpSecenekler.Location = new System.Drawing.Point(300, 95);
            this.grpSecenekler.Name = "grpSecenekler";
            this.grpSecenekler.Size = new System.Drawing.Size(380, 90);
            this.grpSecenekler.TabIndex = 12;
            this.grpSecenekler.TabStop = false;
            this.grpSecenekler.Text = "Ekstra Seçenekler";
            // 
            // chkPlaylist
            // 
            this.chkPlaylist.AutoSize = true;
            this.chkPlaylist.Location = new System.Drawing.Point(15, 25);
            this.chkPlaylist.Name = "chkPlaylist";
            this.chkPlaylist.Size = new System.Drawing.Size(113, 17);
            this.chkPlaylist.TabIndex = 0;
            this.chkPlaylist.Text = "Çalma Listesi İndir";
            this.chkPlaylist.UseVisualStyleBackColor = true;
            // 
            // chkMetadata
            // 
            this.chkMetadata.AutoSize = true;
            this.chkMetadata.Checked = true;
            this.chkMetadata.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMetadata.Location = new System.Drawing.Point(15, 55);
            this.chkMetadata.Name = "chkMetadata";
            this.chkMetadata.Size = new System.Drawing.Size(124, 17);
            this.chkMetadata.TabIndex = 1;
            this.chkMetadata.Text = "Küçük Resim Ekle";
            this.chkMetadata.UseVisualStyleBackColor = true;
            // 
            // chkSubtitles
            // 
            this.chkSubtitles.AutoSize = true;
            this.chkSubtitles.Location = new System.Drawing.Point(140, 25);
            this.chkSubtitles.Name = "chkSubtitles";
            this.chkSubtitles.Size = new System.Drawing.Size(89, 17);
            this.chkSubtitles.TabIndex = 2;
            this.chkSubtitles.Text = "Altyazı İndir";
            this.chkSubtitles.UseVisualStyleBackColor = true;
            // 
            // chkOtoPanoyaBak
            // 
            this.chkOtoPanoyaBak.AutoSize = true;
            this.chkOtoPanoyaBak.Location = new System.Drawing.Point(140, 55);
            this.chkOtoPanoyaBak.Name = "chkOtoPanoyaBak";
            this.chkOtoPanoyaBak.Size = new System.Drawing.Size(118, 17);
            this.chkOtoPanoyaBak.TabIndex = 3;
            this.chkOtoPanoyaBak.Text = "Otomatik Yapıştır";
            this.chkOtoPanoyaBak.UseVisualStyleBackColor = true;
            this.chkOtoPanoyaBak.CheckedChanged += new System.EventHandler(this.chkOtoPanoyaBak_CheckedChanged);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuncelle.Location = new System.Drawing.Point(280, 20);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(90, 55);
            this.btnGuncelle.TabIndex = 4;
            this.btnGuncelle.Text = "Güncelle (yt-dlp)";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // tmrPano
            // 
            this.tmrPano.Interval = 1000;
            this.tmrPano.Tick += new System.EventHandler(this.tmrPano_Tick);
            // 
            // MainForm
            // 
            this.Controls.Add(this.grpSecenekler);
            this.Controls.Add(this.btnKlasorAc);
            this.Controls.Add(this.btnLogTemizle);
            this.Controls.Add(this.richTextBoxLog);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnIndir);
            this.Controls.Add(this.comboBoxFormat);
            this.Controls.Add(this.lblFormat);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MediaJet V1 - Evrensel Video İndirici";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.grpSecenekler.ResumeLayout(false);
            this.grpSecenekler.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Label lblAltBaslik;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Label lblFormat;
        private System.Windows.Forms.ComboBox comboBoxFormat;
        private System.Windows.Forms.Button btnIndir;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.Button btnLogTemizle;
        private System.Windows.Forms.Button btnKlasorAc;
        private System.Windows.Forms.GroupBox grpSecenekler;
        private System.Windows.Forms.CheckBox chkPlaylist;
        private System.Windows.Forms.CheckBox chkMetadata;
        private System.Windows.Forms.CheckBox chkSubtitles;
        private System.Windows.Forms.CheckBox chkOtoPanoyaBak;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Timer tmrPano;
        private System.Windows.Forms.Button btnGithub;
        private System.Windows.Forms.Button btnLanguage;
    }
}
