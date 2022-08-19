﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemakeWatts
{
    public partial class Download : Form
    {
        WebClient client;

        public Download()
        {
            InitializeComponent();
            string url = "https://github.com/BONK220/Watykanczyk/blob/master/RemakeWatts/bagno.txt";
            Thread thread = new Thread(() =>
            {
                client = new WebClient();
                Uri uri = new Uri(url);
                string filename = System.IO.Path.GetFileName(uri.AbsolutePath);
                client.Headers.Add("a", "a");
                client.DownloadProgressChanged += Client_DownloadProgressChanged;
                client.DownloadStringCompleted += Client_DownloadProgressCompleted;
                client.DownloadFileAsync(uri, Application.StartupPath + "/" + filename);
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void Client_DownloadProgressCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            MessageBox.Show("Download complete!", "New orders!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Value = e.ProgressPercentage;
        }
    }
}
