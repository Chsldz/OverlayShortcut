﻿using GlobalHotKey;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;

namespace OverlayShortcut
{
    static class Program
    {
        private static NotifyIcon notico;

        //==========================================================================
        [STAThread]
        public static void Main(string[] astrArg)
        {
            ContextMenu cm;
            MenuItem miCurr;
            int iIndex = 0;

            // Kontextmenü erzeugen
            cm = new ContextMenu();

            // Kontextmenüeinträge erzeugen
            miCurr = new MenuItem();
            miCurr.Index = iIndex++;
            miCurr.Text = "&Einstellungen";           // Eigenen Text einsetzen
            miCurr.Click += new System.EventHandler(Action1Click);
            cm.MenuItems.Add(miCurr);

            // Kontextmenüeinträge erzeugen
            miCurr = new MenuItem();
            miCurr.Index = iIndex++;
            miCurr.Text = "&Beenden";
            miCurr.Click += new System.EventHandler(ExitClick);
            cm.MenuItems.Add(miCurr);

            // NotifyIcon selbst erzeugen
            notico = new NotifyIcon();
            notico.Icon = new Icon("icon.ico"); // Eigenes Icon einsetzen
            notico.Text = "Doppelklick mich!";   // Eigenen Text einsetzen
            notico.Visible = true;
            notico.ContextMenu = cm;
            notico.DoubleClick += new EventHandler(NotifyIconDoubleClick);

            // Create the hotkey manager.
            HotKeyManager hotKeyManager = new HotKeyManager();

            // Register Ctrl+Alt+F5 hotkey. Save this variable somewhere for the further unregistering.
            var hotKey = hotKeyManager.Register(Key.F1, ModifierKeys.Control | ModifierKeys.Alt);

            // Handle hotkey presses.
            hotKeyManager.KeyPressed += HotKeyManagerPressed;


            // Ohne Appplication.Run geht es nicht
            Application.Run();
        }

        private static void HotKeyManagerPressed(object sender, KeyPressedEventArgs e)
        {
            if (e.HotKey.Key == Key.F1)
            {
                //MessageBox.Show("Hot key pressed!");
                startForms();
            }
        }

        //==========================================================================
        private static void ExitClick(Object sender, EventArgs e)
        {
            notico.Dispose();
            Application.Exit();
        }

        //==========================================================================
        private static void Action1Click(Object sender, EventArgs e)
        {
            PropertieSettings settings = new PropertieSettings();
            settings.ShowDialog();
        }

        //==========================================================================
        private static void NotifyIconDoubleClick(Object sender, EventArgs e)
        {
            startForms();
        }


        private static void startForms()
        {
            Form1 form = new Form1(Cursor.Position.X, Cursor.Position.Y);
            form.ShowDialog();
        }
    }
}
