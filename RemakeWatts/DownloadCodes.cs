using System;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace RemakeWatts
{
    public partial class DownloadCodes : Form
    {
        WebClient client;
        public DownloadCodes()
        {
            InitializeComponent();
            string url = "https://raw.githubusercontent.com/BONK220/Watykanczyk/master/maxresdefault.jpg";
            new Thread(() =>
            {
                client = new WebClient();
                Uri uri = new Uri(url);
                string filename = System.IO.Path.GetFileName(uri.AbsolutePath);
                client.DownloadProgressChanged += Client_DownloadProgressChanged;
                client.DownloadStringCompleted += Client_DownloadProgressCompleted;
                client.DownloadFileAsync(uri, $"{Application.StartupPath}/{filename}");
                Thread.Sleep(3000);
                Wallpaper wallpaper = new Wallpaper();
                wallpaper.SetWallpaper($"{Application.StartupPath}/maxresdefault.jpg");
            }).Start();
        }
        private void Client_DownloadProgressCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            MessageBox.Show("Download complete!", "New orders!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Value = e.ProgressPercentage;
            label1.Text = $"Downloading nuclear codes. Please wait... {e.ProgressPercentage}%";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
