using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverlayShortcut
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int realPositionX = startLocationX - this.Size.Width / 2;
            int realPositionY = startLocationY - this.Size.Height / 2;
            this.SetDesktopLocation(realPositionX, realPositionY);
        }

        public Form1(int x, int y):this()
        {
            this.startLocationX = x;
            this.startLocationY = y;
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        private const int WS_EX_TOPMOST = 0x00000008;
        private int startLocationX;
        private int startLocationY;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= WS_EX_TOPMOST;
                return createParams;
            }
        }
        void fensterSchliessen() {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("stuff");
            fensterSchliessen();
        }
    }
}
