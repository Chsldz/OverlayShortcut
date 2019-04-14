using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;
using WindowsInput.Native;
using WindowsInput;

namespace OverlayShortcut
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);
        enum GetWindow_Cmd : uint
        {
            GW_HWNDFIRST = 0,
            GW_HWNDLAST = 1,
            GW_HWNDNEXT = 2,
            GW_HWNDPREV = 3,
            GW_OWNER = 4,
            GW_CHILD = 5,
            GW_ENABLEDPOPUP = 6
        }
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetParent(IntPtr hWnd);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);



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
                button.Name = "button"+i.ToString();
                button.Size = new System.Drawing.Size(75, 75);
                button.TabIndex = i;
                button.Text = PropertyHandler.getNameboxProperties(i).ToString();
                button.Tag = i;
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

        void fensterSchliessen()
        { 
            switchFensterFocus();
            this.Close();
        }


        void switchFensterFocus()
        {
            IntPtr lastWindowHandle = GetWindow(Process.GetCurrentProcess().MainWindowHandle, (uint)GetWindow_Cmd.GW_HWNDPREV);
            while (true)
            {
                IntPtr temp = GetParent(lastWindowHandle);
                if (temp.Equals(IntPtr.Zero)) break;
                lastWindowHandle = temp;
            }
            SetForegroundWindow(lastWindowHandle);
        }

        object output;
        private void button1_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            output = button.Tag;
            Console.Write("Button: ");
            Console.WriteLine(button.Text);
            fensterSchliessen();
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            Program.setClosed();
            List<string> list = PropertyHandler.getTextboxProperties(output).Split(',').ToList();
            List<Keys> intList = new List<Keys>();
            InputSimulator sim = new InputSimulator();
            if (list.Count != 0)
            {
                foreach (String strng in list)
                {
                    sim.Keyboard.KeyPress((VirtualKeyCode)Int32.Parse(strng));
                    Thread.Sleep(200);
                }
            }
        }
    }
}