using Payloads.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Payloads
{
    public class Downloader
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();
        public void DownloadConsole(string[] urls, string filename = "")
        {
            int total = 100;
            int progress = 10;
            AllocConsole();
            //ProgressBar.ProgressBarConsole(progress, total);
            foreach(string url in urls)
            {
                Console.WriteLine(url);
                Uri uri = new Uri(url);
                Console.WriteLine(uri.AbsolutePath);
            }
            
            Thread.Sleep(10000);
        }
    }
}
