﻿using System;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace OverlayShortcut
{
    static class PropertyHandler
    {

        public static void setTextboxProperties(object i, String text)
        {
            switch (i)
            {
                case 0:
                    Properties.Settings.Default.btnShortcut1 = text;
                    break;

                case 1:
                    Properties.Settings.Default.btnShortcut2 = text;
                    break;

                case 2:
                    Properties.Settings.Default.btnShortcut3 = text;
                    break;

                case 3:
                    Properties.Settings.Default.btnShortcut4 = text;
                    break;

                case 4:
                    Properties.Settings.Default.btnShortcut5 = text;
                    break;

                case 5:
                    Properties.Settings.Default.btnShortcut6 = text;
                    break;

                case 6:
                    Properties.Settings.Default.btnShortcut7 = text;
                    break;

                case 7:
                    Properties.Settings.Default.btnShortcut8 = text;
                    break;
                default:
                    break;
            }
            Properties.Settings.Default.Save();
        }

        internal static String getTextboxProperties(object i)
        {
            switch (i)
            {
                case 0:
                    return Properties.Settings.Default.btnShortcut1;

                case 1:
                    return Properties.Settings.Default.btnShortcut2;

                case 2:
                    return Properties.Settings.Default.btnShortcut3;

                case 3:
                    return Properties.Settings.Default.btnShortcut4;

                case 4:
                    return Properties.Settings.Default.btnShortcut5;

                case 5:
                    return Properties.Settings.Default.btnShortcut6;

                case 6:
                    return Properties.Settings.Default.btnShortcut7;

                case 7:
                    return Properties.Settings.Default.btnShortcut8;
               
                default:
                    return "Error: Cant read Property from " + i.ToString();
            }
        }

        internal static object getNameboxProperties(int i)
        {
            switch (i)
            {
                case 0:
                    return Properties.Settings.Default.btnName1;

                case 1:
                    return Properties.Settings.Default.btnName2;

                case 2:
                    return Properties.Settings.Default.btnName3;

                case 3:
                    return Properties.Settings.Default.btnName4;

                case 4:
                    return Properties.Settings.Default.btnName5;

                case 5:
                    return Properties.Settings.Default.btnName6;

                case 6:
                    return Properties.Settings.Default.btnName7;

                case 7:
                    return Properties.Settings.Default.btnName8;

                default:
                    return "Error: Cant read Property from " + i.ToString();
            }
        }


        public static void setNameboxProperties(object i, String text)
        {
            switch (i)
            {
                case 0:
                    Properties.Settings.Default.btnName1 = text;
                    break;

                case 1:
                    Properties.Settings.Default.btnName2 = text;
                    break;

                case 2:
                    Properties.Settings.Default.btnName3 = text;
                    break;

                case 3:
                    Properties.Settings.Default.btnName4 = text;
                    break;

                case 4:
                    Properties.Settings.Default.btnName5 = text;
                    break;

                case 5:
                    Properties.Settings.Default.btnName6 = text;
                    break;

                case 6:
                    Properties.Settings.Default.btnName7 = text;
                    break;

                case 7:
                    Properties.Settings.Default.btnName8 = text;
                    break;
                default:
                    break;
            }
            Properties.Settings.Default.Save();
        }
    }
}
