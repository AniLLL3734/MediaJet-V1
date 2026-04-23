using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO.Compression;

namespace MediaJet_V1
{
    /// <summary>
    /// MediaJet V1 - Evrensel Video İndirici
    /// yt-dlp motorunu kullanarak sosyal medya platformlarından video indirir.
    /// </summary>
    public partial class MainForm : Form
    {
        // yt-dlp.exe dosyasının yolu
        private string ytDlpPath;
        // ffmpeg.exe dosyasının yolu
        private string ffmpegPath;
        // İndirilen dosyaların kaydedileceği klasör
        private string downloadFolder;
        // İndirme işlemi devam ediyor mu?
        private bool isDownloading = false;
        // Geçerli dil İngilizce mi?
        private bool isEnglish = false;

        public MainForm()
        {
            InitializeComponent();
            KurulumYap();
        }

        /// <summary>
        /// Uygulama başlangıcında gerekli klasör ve yolları ayarlar.
        /// </summary>
        private void KurulumYap()
        {
            // Uygulama klasörünü al
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // yt-dlp.exe yolunu ayarla (exe'nin yanında olmalı)
            ytDlpPath = Path.Combine(appDirectory, "yt-dlp.exe");

            // Downloads klasörünü oluştur (yoksa)
            downloadFolder = Path.Combine(appDirectory, "Downloads");
            if (!Directory.Exists(downloadFolder))
            {
                Directory.CreateDirectory(downloadFolder);
                LogYaz("[BİLGİ] Downloads klasörü oluşturuldu: " + downloadFolder, System.Drawing.Color.Cyan);
            }

            // yt-dlp.exe varlığını kontrol et
            if (!File.Exists(ytDlpPath))
            {
                Task.Run(() => YtDlpIndirVeKur());
            }
            else
            {
                LogYaz("[HAZIR] MediaJet V1 başlatıldı!", System.Drawing.Color.LimeGreen);
                LogYaz("[BİLGİ] yt-dlp.exe bulundu: " + ytDlpPath, System.Drawing.Color.Cyan);
            }

            // FFmpeg kontrolü ve indirme
            ffmpegPath = Path.Combine(appDirectory, "ffmpeg.exe");
            if (!File.Exists(ffmpegPath))
            {
                Task.Run(() => FFmpegIndirVeKur(appDirectory));
            }
            else
            {
                LogYaz("[BİLGİ] FFmpeg algılandı (Yüksek Kalite İndirme Aktif)", System.Drawing.Color.Cyan);
            }

            LogYaz("[BİLGİ] İndirme klasörü: " + downloadFolder, System.Drawing.Color.Cyan);
            LogYaz("----------------------------------------", System.Drawing.Color.DimGray);
        }

        /// <summary>
        /// Log kutusuna renkli mesaj yazar.
        /// </summary>
        private void LogYaz(string mesaj, System.Drawing.Color renk)
        {
            // UI thread-safe erişim
            if (richTextBoxLog.InvokeRequired)
            {
                richTextBoxLog.Invoke(new Action(() => LogYaz(mesaj, renk)));
                return;
            }

            richTextBoxLog.SelectionStart = richTextBoxLog.TextLength;
            richTextBoxLog.SelectionLength = 0;
            richTextBoxLog.SelectionColor = renk;
            richTextBoxLog.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + mesaj + Environment.NewLine);
            richTextBoxLog.SelectionColor = richTextBoxLog.ForeColor;
            richTextBoxLog.ScrollToCaret();
        }

        /// <summary>
        /// İlerleme çubuğunu günceller.
        /// </summary>
        private void IlerlemeGuncelle(int deger)
        {
            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke(new Action(() => IlerlemeGuncelle(deger)));
                return;
            }

            if (deger < 0) deger = 0;
            if (deger > 100) deger = 100;
            progressBar.Value = deger;
        }

        /// <summary>
        /// İNDİR butonuna tıklandığında çalışır.
        /// </summary>
        private async void btnIndir_Click(object sender, EventArgs e)
        {
            // Zaten indirme yapılıyor mu?
            if (isDownloading)
            {
                LogYaz("[UYARI] Zaten bir indirme işlemi devam ediyor!", System.Drawing.Color.Orange);
                return;
            }

            // URL kontrolü
            string url = txtUrl.Text.Trim();
            if (string.IsNullOrEmpty(url))
            {
                LogYaz("[HATA] Lütfen bir video URL'si girin!", System.Drawing.Color.Red);
                MessageBox.Show("Lütfen bir video URL'si girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // URL geçerliliği basit kontrol
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                LogYaz("[HATA] Geçersiz URL formatı! URL http:// veya https:// ile başlamalı.", System.Drawing.Color.Red);
                return;
            }

            // yt-dlp.exe kontrolü
            if (!File.Exists(ytDlpPath))
            {
                LogYaz("[HATA] yt-dlp.exe bulunamadı! Lütfen exe'nin yanına yerleştirin.", System.Drawing.Color.Red);
                MessageBox.Show("yt-dlp.exe bulunamadı!\n\nLütfen yt-dlp.exe dosyasını uygulamanın yanına koyun.",
                    "Dosya Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Seçilen format
            string format = comboBoxFormat.SelectedItem?.ToString() ?? "MP4 (En İyi Kalite)";

            // UI'ı indirme moduna al
            isDownloading = true;
            btnIndir.Enabled = false;
            btnIndir.Text = isEnglish ? "DOWNLOADING..." : "İNDİRİLİYOR...";
            progressBar.Value = 0;

            LogYaz("----------------------------------------", System.Drawing.Color.DimGray);
            LogYaz(isEnglish ? "[STARTED] Download starting..." : "[BAŞLADI] İndirme başlıyor...", System.Drawing.Color.LimeGreen);
            LogYaz("[URL] " + url, System.Drawing.Color.White);
            LogYaz("[FORMAT] " + format, System.Drawing.Color.Cyan);

            // Seçenekleri al (UI thread'den okuyup değişkene atıyoruz, thread güvenliği için)
            bool isPlaylist = chkPlaylist.Checked;
            bool embedMetadata = chkMetadata.Checked;
            bool writeSubs = chkSubtitles.Checked;

            try
            {
                // İndirme işlemini ayrı thread'de çalıştır (UI donmasın)
                await Task.Run(() => IndirmeIsleminiBaslat(url, format, isPlaylist, embedMetadata, writeSubs));
            }
            catch (Exception ex)
            {
                LogYaz("[HATA] Beklenmeyen bir hata oluştu: " + ex.Message, System.Drawing.Color.Red);
            }
            finally
            {
                // UI'ı normale döndür
                isDownloading = false;
                btnIndir.Invoke(new Action(() =>
                {
                    btnIndir.Enabled = true;
                    btnIndir.Text = isEnglish ? "⬇️ DOWNLOAD" : "⬇️ İNDİR / DOWNLOAD";
                }));
            }
        }

        /// <summary>
        /// yt-dlp ile indirme işlemini başlatır.
        /// </summary>
        private void IndirmeIsleminiBaslat(string url, string format, bool isPlaylist, bool embedMetadata, bool writeSubs)
        {
            try
            {
                // Format argümanlarını belirle
                string formatArgs = FormatArgumanlariAl(format);

                // yt-dlp komut satırı argümanları
                // -o : Çıktı şablonu
                // --no-playlist : Sadece tek video indir
                // --progress : İlerleme bilgisi göster
                // yt-dlp komut satırı argümanları
                string arguments = $"{formatArgs} --progress ";

                // Playlist ayarı
                if (isPlaylist)
                    arguments += "--yes-playlist ";
                else
                    arguments += "--no-playlist ";

                // Metadata ve Küçük Resim
                if (embedMetadata)
                    arguments += "--embed-thumbnail --add-metadata ";

                // Altyazı
                if (writeSubs)
                    arguments += "--write-subs --sub-langs all ";

                // Çıktı şablonu ve URL
                arguments += $"-o \"{Path.Combine(downloadFolder, "%(title)s.%(ext)s")}\" \"{url}\"";

                LogYaz("[KOMUT] yt-dlp " + arguments, System.Drawing.Color.DimGray);

                // Process başlat
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = ytDlpPath,
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true, // Konsol penceresi gösterme
                    StandardOutputEncoding = System.Text.Encoding.UTF8,
                    StandardErrorEncoding = System.Text.Encoding.UTF8
                };

                using (Process process = new Process())
                {
                    process.StartInfo = startInfo;

                    // Çıktıyı yakala
                    process.OutputDataReceived += (s, e) =>
                    {
                        if (!string.IsNullOrEmpty(e.Data))
                        {
                            CiktiIsle(e.Data);
                        }
                    };

                    process.ErrorDataReceived += (s, e) =>
                    {
                        if (!string.IsNullOrEmpty(e.Data))
                        {
                            // Hata çıktılarını da işle (bazen ilerleme buradan gelir)
                            CiktiIsle(e.Data);
                        }
                    };

                    process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();
                    process.WaitForExit();

                    // İşlem sonucu
                    if (process.ExitCode == 0)
                    {
                        IlerlemeGuncelle(100);
                        LogYaz("[TAMAMLANDI] İndirme başarıyla tamamlandı!", System.Drawing.Color.LimeGreen);
                        LogYaz("[KONUM] " + downloadFolder, System.Drawing.Color.Cyan);
                    }
                    else
                    {
                        LogYaz($"[HATA] İndirme başarısız oldu. Çıkış kodu: {process.ExitCode}", System.Drawing.Color.Red);
                    }
                }
            }
            catch (Exception ex)
            {
                LogYaz("[HATA] İndirme sırasında hata: " + ex.Message, System.Drawing.Color.Red);
            }

            LogYaz("----------------------------------------", System.Drawing.Color.DimGray);
        }

        /// <summary>
        /// Seçilen formata göre yt-dlp argümanlarını döndürür.
        /// </summary>
        private string FormatArgumanlariAl(string format)
        {
            switch (format)
            {
                case "MP4 (En İyi Kalite)":
                case "MP4 (Best Quality)":
                    // En iyi video + en iyi ses, mp4 formatında
                    return "-f \"bestvideo[ext=mp4]+bestaudio[ext=m4a]/best[ext=mp4]/best\" --merge-output-format mp4";

                case "MP4 (1080p)":
                    // 1080p video + en iyi ses
                    return "-f \"bestvideo[height<=1080][ext=mp4]+bestaudio[ext=m4a]/best[height<=1080][ext=mp4]/best\" --merge-output-format mp4";

                case "MP3 (Sadece Ses)":
                case "MP3 (Audio Only)":
                    // Sadece ses, mp3 olarak çıkar
                    return "-x --audio-format mp3 --audio-quality 0";

                default:
                    return "-f best";
            }
        }

        /// <summary>
        /// yt-dlp çıktısını işler ve log'a yazar.
        /// </summary>
        private void CiktiIsle(string satir)
        {
            // İlerleme yüzdesini çıkar (%XX.X% formatında)
            if (satir.Contains("%"))
            {
                try
                {
                    // Örnek: "[download]  45.2% of 10.00MiB"
                    int startIndex = satir.IndexOf(' ') + 1;
                    int endIndex = satir.IndexOf('%');
                    if (startIndex > 0 && endIndex > startIndex)
                    {
                        string percentStr = satir.Substring(startIndex, endIndex - startIndex).Trim();
                        if (double.TryParse(percentStr, System.Globalization.NumberStyles.Any,
                            System.Globalization.CultureInfo.InvariantCulture, out double percent))
                        {
                            IlerlemeGuncelle((int)percent);
                        }
                    }
                }
                catch { }
            }

            // Önemli mesajları logla
            if (satir.Contains("[download]") || satir.Contains("[info]") ||
                satir.Contains("[error]") || satir.Contains("ERROR") ||
                satir.Contains("Destination") || satir.Contains("Merging"))
            {
                System.Drawing.Color renk = System.Drawing.Color.White;

                if (satir.Contains("ERROR") || satir.Contains("[error]"))
                    renk = System.Drawing.Color.Red;
                else if (satir.Contains("100%") || satir.Contains("Merging") || satir.Contains("Destination"))
                    renk = System.Drawing.Color.LimeGreen;
                else if (satir.Contains("[info]"))
                    renk = System.Drawing.Color.Cyan;

                LogYaz(satir, renk);
            }
        }

        /// <summary>
        /// URL temizle butonuna tıklandığında.
        /// </summary>
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtUrl.Clear();
            txtUrl.Focus();
        }

        /// <summary>
        /// Log temizle butonuna tıklandığında.
        /// </summary>
        private void btnLogTemizle_Click(object sender, EventArgs e)
        {
            richTextBoxLog.Clear();
            LogYaz("[BİLGİ] Log temizlendi.", System.Drawing.Color.Cyan);
        }

        /// <summary>
        /// Downloads klasörünü aç butonuna tıklandığında.
        /// </summary>
        private void btnKlasorAc_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(downloadFolder))
            {
                Process.Start("explorer.exe", downloadFolder);
            }
            else
            {
                MessageBox.Show("Downloads klasörü bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Form yüklendiğinde varsayılan format seçimi.
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Varsayılan olarak ilk formatı seç
            if (comboBoxFormat.Items.Count > 0)
            {
                comboBoxFormat.SelectedIndex = 0;
            }
            // Başlangıç dil ayarı
            UpdateLanguage();
        }


        /// <summary>
        /// FFmpeg indirip kuran metod.
        /// </summary>
        private void FFmpegIndirVeKur(string appDir)
        {
            try
            {
                LogYaz("[SİSTEM] FFmpeg eksik, otomatik indiriliyor... (Lütfen bekleyin)", System.Drawing.Color.Orange);

                string zipPath = Path.Combine(appDir, "ffmpeg.zip");
                // Daha küçük ve hızlı bir build (gyan.dev essentials)
                string downloadUrl = "https://www.gyan.dev/ffmpeg/builds/ffmpeg-release-essentials.zip";

                using (WebClient client = new WebClient())
                {
                    // İndirme yüzdesini göstermek biraz zor olabilir WebClient ile basitçe, ama bittiğinde uyarı veririz
                    client.DownloadFile(downloadUrl, zipPath);
                }

                LogYaz("[SİSTEM] FFmpeg indirildi, ayıklanıyor...", System.Drawing.Color.Yellow);

                // Zip'i aç
                string extractPath = Path.Combine(appDir, "ffmpeg_temp");
                if (Directory.Exists(extractPath)) Directory.Delete(extractPath, true);
                Directory.CreateDirectory(extractPath);

                ZipFile.ExtractToDirectory(zipPath, extractPath);

                // ffmpeg.exe'yi bul ve ana dizine taşı
                string[] files = Directory.GetFiles(extractPath, "ffmpeg.exe", SearchOption.AllDirectories);
                if (files.Length > 0)
                {
                    File.Copy(files[0], Path.Combine(appDir, "ffmpeg.exe"), true);
                    LogYaz("[BAŞARILI] FFmpeg kurulumu tamamlandı!", System.Drawing.Color.LimeGreen);
                }
                else
                {
                    LogYaz("[HATA] Zip içinde ffmpeg.exe bulunamadı.", System.Drawing.Color.Red);
                }

                // Temizlik
                if (File.Exists(zipPath)) File.Delete(zipPath);
                if (Directory.Exists(extractPath)) Directory.Delete(extractPath, true);
            }
            catch (Exception ex)
            {
                LogYaz(isEnglish ? "[ERROR] Failed to download FFmpeg: " + ex.Message : "[HATA] FFmpeg indirilemedi: " + ex.Message, System.Drawing.Color.Red);
            }
        }

        /// <summary>
        /// yt-dlp indirip kuran metod.
        /// </summary>
        private void YtDlpIndirVeKur()
        {
            try
            {
                LogYaz(isEnglish ? "[SYSTEM] yt-dlp missing, downloading automatically... (Please wait)" : "[SİSTEM] yt-dlp eksik, otomatik indiriliyor... (Lütfen bekleyin)", System.Drawing.Color.Orange);

                string downloadUrl = "https://github.com/yt-dlp/yt-dlp/releases/download/2026.03.17/yt-dlp.exe";
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(downloadUrl, ytDlpPath);
                }

                LogYaz(isEnglish ? "[SUCCESS] yt-dlp installed successfully!" : "[BAŞARILI] yt-dlp kurulumu tamamlandı!", System.Drawing.Color.LimeGreen);
            }
            catch (Exception ex)
            {
                LogYaz(isEnglish ? "[ERROR] Failed to download yt-dlp: " + ex.Message : "[HATA] yt-dlp indirilemedi: " + ex.Message, System.Drawing.Color.Red);
            }
        }

        private void chkOtoPanoyaBak_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOtoPanoyaBak.Checked)
                tmrPano.Start();
            else
                tmrPano.Stop();
        }

        private string sonPanoMetni = "";
        private void tmrPano_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Clipboard.ContainsText())
                {
                    string text = Clipboard.GetText().Trim();
                    if (text != sonPanoMetni && (text.StartsWith("http://") || text.StartsWith("https://")))
                    {
                        // Sadece desteklenen sitelerden basit kontrol (opsiyonel, şimdilik hepsini al)
                        txtUrl.Text = text;
                        sonPanoMetni = text;
                        // Kullanıcıya hafif bir geri bildirim (Log yerine Textbox focus)
                        // LogYaz("[PANO] URL yapıştırıldı.", System.Drawing.Color.Gray);
                    }
                }
            }
            catch { }
        }

        private async void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (!File.Exists(ytDlpPath))
            {
                LogYaz("[HATA] yt-dlp.exe yok, güncellenemez.", System.Drawing.Color.Red);
                return;
            }

            btnGuncelle.Enabled = false;
            btnGuncelle.Text = "Bekleyin...";
            LogYaz("[GÜNCELLEME] yt-dlp güncellemesi denetleniyor...", System.Drawing.Color.Cyan);

            await Task.Run(() =>
            {
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = ytDlpPath,
                        Arguments = "-U", // Update komutu
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true,
                        StandardOutputEncoding = System.Text.Encoding.UTF8 // Türkçe karakter desteği için
                    };

                    using (Process process = new Process())
                    {
                        process.StartInfo = startInfo;

                        process.OutputDataReceived += (s, args) => { if (!string.IsNullOrEmpty(args.Data)) LogYaz(args.Data, System.Drawing.Color.White); };
                        process.ErrorDataReceived += (s, args) => { if (!string.IsNullOrEmpty(args.Data)) LogYaz(args.Data, System.Drawing.Color.Orange); };

                        process.Start();
                        process.BeginOutputReadLine();
                        process.BeginErrorReadLine();
                        process.WaitForExit();
                    }
                }
                catch (Exception ex)
                {
                    LogYaz("[HATA] Güncelleme hatası: " + ex.Message, System.Drawing.Color.Red);
                }
            });

            btnGuncelle.Enabled = true;
            btnGuncelle.Text = isEnglish ? "Update (yt-dlp)" : "Güncelle (yt-dlp)";
        }

        private void btnLanguage_Click(object sender, EventArgs e)
        {
            isEnglish = !isEnglish;
            UpdateLanguage();
        }

        private void btnGithub_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://github.com/AniLLL3734"); // Kullanıcının gerçek GitHub hesabı
            }
            catch (Exception ex)
            {
                LogYaz(isEnglish ? "[ERROR] Could not open GitHub link: " + ex.Message : "[HATA] GitHub bağlantısı açılamadı: " + ex.Message, System.Drawing.Color.Red);
            }
        }

        private void UpdateLanguage()
        {
            if (isEnglish)
            {
                lblBaslik.Text = "🎬 MediaJet V1 - Universal Downloader";
                lblAltBaslik.Text = "YouTube, Instagram, TikTok, Twitter and more...";
                lblUrl.Text = "📎 Video URL:";
                btnTemizle.Text = "CLEAR";
                lblFormat.Text = "🎯 Download Format:";
                btnIndir.Text = "⬇️ DOWNLOAD";
                lblLog.Text = "📋 Operation Logs:";
                btnLogTemizle.Text = "🗑️ Clear Log";
                btnKlasorAc.Text = "📂 Downloads Folder";
                grpSecenekler.Text = "Extra Options";
                chkPlaylist.Text = "Download Playlist";
                chkMetadata.Text = "Embed Thumbnail";
                chkSubtitles.Text = "Download Subtitles";
                chkOtoPanoyaBak.Text = "Auto Paste";
                btnGuncelle.Text = "Update (yt-dlp)";
                btnLanguage.Text = "EN";
                
                int selectedIndex = comboBoxFormat.SelectedIndex;
                comboBoxFormat.Items.Clear();
                comboBoxFormat.Items.AddRange(new object[] {
                    "MP4 (Best Quality)",
                    "MP4 (1080p)",
                    "MP3 (Audio Only)"
                });
                comboBoxFormat.SelectedIndex = selectedIndex >= 0 ? selectedIndex : 0;
            }
            else
            {
                lblBaslik.Text = "🎬 MediaJet V1 - Evrensel İndirici";
                lblAltBaslik.Text = "YouTube, Instagram, TikTok, Twitter ve daha fazlası...";
                lblUrl.Text = "📎 Video URL'si:";
                btnTemizle.Text = "TEMİZLE";
                lblFormat.Text = "🎯 İndirme Formatı:";
                btnIndir.Text = "⬇️ İNDİR / DOWNLOAD";
                lblLog.Text = "📋 İşlem Kayıtları:";
                btnLogTemizle.Text = "🗑️ Logu Temizle";
                btnKlasorAc.Text = "📂 Downloads Klasörü";
                grpSecenekler.Text = "Ekstra Seçenekler";
                chkPlaylist.Text = "Çalma Listesi İndir";
                chkMetadata.Text = "Küçük Resim Ekle";
                chkSubtitles.Text = "Altyazı İndir";
                chkOtoPanoyaBak.Text = "Otomatik Yapıştır";
                btnGuncelle.Text = "Güncelle (yt-dlp)";
                btnLanguage.Text = "TR";

                int selectedIndex = comboBoxFormat.SelectedIndex;
                comboBoxFormat.Items.Clear();
                comboBoxFormat.Items.AddRange(new object[] {
                    "MP4 (En İyi Kalite)",
                    "MP4 (1080p)",
                    "MP3 (Sadece Ses)"
                });
                comboBoxFormat.SelectedIndex = selectedIndex >= 0 ? selectedIndex : 0;
            }
        }
    }
}
