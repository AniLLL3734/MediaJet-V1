using System;
using System.Windows.Forms;

namespace MediaJet_V1
{
    /// <summary>
    /// MediaJet V1 - Ana Uygulama Giriş Noktası
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana giriş noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // MainForm'u başlat
            Application.Run(new MainForm());
        }
    }
}
