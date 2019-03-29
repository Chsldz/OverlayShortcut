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
        int row = -1;
        int column = 0;
        Button[] buttons = new Button[8];
        private void Form1_Load(object sender, EventArgs e)
        {
            int realPositionX = startLocationX - this.Size.Width / 2;
            int realPositionY = startLocationY - this.Size.Height / 2;
            for (int i = 0; i < 8; i++)
            {
                Button button = new Button();
                if (i % 2 == 0) row++;
                button.Location = new System.Drawing.Point(12 + (81 * column), 12 + 81 * row);
                column++;
                if (column == 2) column = 0;
                button.Name = "button1";
                button.Size = new System.Drawing.Size(75, 75);
                button.TabIndex = i;
                button.Text = i.ToString();
                button.UseVisualStyleBackColor = true;
                button.Click += new System.EventHandler(this.button1_Click);
                this.Controls.Add(button);
                buttons[i] = button;
            }

            this.SetDesktopLocation(realPositionX, realPositionY);
            Program.setOpened();
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
            //Program.setClosed();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.Write("Button: ");
            Console.WriteLine(button.Text);
            fensterSchliessen();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.setClosed();
        }
    }
}
