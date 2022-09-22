using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Payloads
{
    public class Downloader
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();
        public void DownloadConsole(string url, string filename)
        {
            AllocConsole();
            Console.WriteLine();
        }
    }
}
