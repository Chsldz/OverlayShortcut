using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;
using WindowsInput.Native;

namespace OverlayShortcut
{
    public partial class PropertieSettings : Form
    {
        public PropertieSettings()
        {
            InitializeComponent();
        }

        private void ActionShortcut(object sender, PreviewKeyDownEventArgs e)
        {
            Console.WriteLine(e.KeyCode);
        }
        List<Keys> code = new List<Keys>();
        private void ActionKeyDown(object sender, KeyEventArgs e)
        {
            //VirtualKeyCode CodeOfKeyToEmulate = (VirtualKeyCode)KeyInterop.VirtualKeyFromKey(e.Key);
            Console.WriteLine(e.KeyData);
            if (!code.Contains(e.KeyData))
            {
                code.Add(e.KeyData);
            }
        }

        private void ActionKeyUp(object sender, KeyEventArgs e)
        {
            if (code.Count != 0)
            {
                TextBox textBox = sender as TextBox;
                StringBuilder builder = new StringBuilder();
                foreach (Keys keys in code)
                {
                    builder.Append((Int32)keys);
                    if (keys != code.Last())
                    {
                        builder.Append(",");
                    }
                }
                textBox.Text = null;
                textBox.Text = builder.ToString();
                PropertyHandler.setTextboxProperties(textBox.Tag, builder.ToString());
                code.Clear();
            }
        }

        TextBox[] textBoxes = new TextBox[8];
        private void PropertieSettings_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                TextBox textBox = new TextBox();
                textBox.Location = new System.Drawing.Point(12, 12+26*i);
                textBox.Name = "textBox"+i.ToString();
                textBox.Size = new System.Drawing.Size(220, 20);
                textBox.TabIndex = i;
                textBox.Tag = i;
                textBox.Text = PropertyHandler.getTextboxProperties(i).ToString();
                textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ActionKeyDown);
                textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ActionKeyUp);
                this.Controls.Add(textBox);
                textBoxes[i] = textBox;
            }

        }
    }
}
