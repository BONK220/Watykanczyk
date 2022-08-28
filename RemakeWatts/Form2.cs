using System;
using System.Drawing;
using System.Windows.Forms;

namespace RemakeWatts
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            Random random = new Random();
            int x = random.Next(0, 1270);
            int y = random.Next(0, 920);

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(x, y);
            this.ShowInTaskbar = false;
        }
    }
}
