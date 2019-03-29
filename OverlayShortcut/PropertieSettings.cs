using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        private void ActionShortcut(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.KeyCode);
            if (!code.Contains(e.KeyCode))
            {
                code.Add(e.KeyCode);
            }
        }

        private void ActionShortcutUp(object sender, KeyEventArgs e)
        {
            if (code.Count != 0)
            {
                TextBox textBox = sender as TextBox;
                StringBuilder builder = new StringBuilder();
                foreach (Keys keys in code)
                {
                    builder.Append(keys.ToString());
                    if (!keys.Equals(code.Last()))
                    {
                        builder.Append(" + ");
                    }
                }
                textBox.Text = null;
                textBox.Text = builder.ToString();
                PropertyHandler.setTextboxProperties(textBox, builder.ToString());
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
                textBox.Text = PropertyHandler.getTextboxProperties(i);
                textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ActionShortcut);
                textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ActionShortcutUp);
                this.Controls.Add(textBox);
                textBoxes[i] = textBox;
            }
        }
    }
}
