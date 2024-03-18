using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;
using BtC;

namespace BtC
{
    partial class Settings_and_About : Form
    {
        
        public Settings_and_About()
        {
            InitializeComponent();
            this.labelProductName.Text = ("Bluetooth Control (BtC)");
            this.labelVersion.Text = String.Format("Version : 1.0.0");
            this.labelCompanyName.Text = "By SANEX (Sanshray)";
        }
        private void Settings_and_About_Load(object sender, EventArgs e)
        {
            NewNameOf1.Text = btc.Properties.Settings.Default.Btn1;
            NewNameOf2.Text = btc.Properties.Settings.Default.Btn2;
            NewNameOf3.Text = btc.Properties.Settings.Default.Btn3;
            NewNameOf4.Text = btc.Properties.Settings.Default.Btn4;
            NewNameOf5.Text = btc.Properties.Settings.Default.Btn5;
            NewNameOf6.Text = btc.Properties.Settings.Default.Btn6;
            NewNameOf7.Text = btc.Properties.Settings.Default.Btn7;
            NewNameOf8.Text = btc.Properties.Settings.Default.Btn8;
        }
        private void SaveAllMods()
        {
            if (btc.Properties.Settings.Default.Btn1 != null)
            {
                btc.Properties.Settings.Default.Btn1 = (NewNameOf1.Text);
            }
            else if (btc.Properties.Settings.Default.Btn1 == null)
            {
                btc.Properties.Settings.Default.Btn1 = "";
            }

            if (btc.Properties.Settings.Default.Btn2 != null)
            {
                btc.Properties.Settings.Default.Btn2 = (NewNameOf2.Text);
            }
            else if (btc.Properties.Settings.Default.Btn2 == null)
            {
                btc.Properties.Settings.Default.Btn2 = "";
            }

            if (btc.Properties.Settings.Default.Btn3 != null)
            {
                btc.Properties.Settings.Default.Btn3 = (NewNameOf3.Text);
            }
            else if (btc.Properties.Settings.Default.Btn3 == null)
            {
                btc.Properties.Settings.Default.Btn3 = "";
            }

            if (btc.Properties.Settings.Default.Btn4 != null)
            {
                btc.Properties.Settings.Default.Btn4 = (NewNameOf4.Text);
            }
            else if (btc.Properties.Settings.Default.Btn4 == null)
            {
                btc.Properties.Settings.Default.Btn4 = "";
            }

            if (btc.Properties.Settings.Default.Btn5 != null)
            {
                btc.Properties.Settings.Default.Btn5 = (NewNameOf5.Text);
            }
            else if (btc.Properties.Settings.Default.Btn5 == null)
            {
                btc.Properties.Settings.Default.Btn5 = "";
            }

            if (btc.Properties.Settings.Default.Btn6 != null)
            {
                btc.Properties.Settings.Default.Btn6 = (NewNameOf6.Text);
            }
            else if (btc.Properties.Settings.Default.Btn6 == null)
            {
                btc.Properties.Settings.Default.Btn6 = "";
            }

            if (btc.Properties.Settings.Default.Btn7 != null)
            {
                btc.Properties.Settings.Default.Btn7 = (NewNameOf7.Text);
            }
            else if (btc.Properties.Settings.Default.Btn1 == null)
            {
                btc.Properties.Settings.Default.Btn7 = "";
            }

            if (btc.Properties.Settings.Default.Btn8 != null)
            {
                btc.Properties.Settings.Default.Btn8 = (NewNameOf8.Text);
            }
            else if (btc.Properties.Settings.Default.Btn8 == null)
            {
                btc.Properties.Settings.Default.Btn8 = "";
            }
        }

        private void Settings_and_About_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveAllMods();
            btc.Properties.Settings.Default.Save();
            MessageBox.Show("All Settings have been saved successfully. \n Changes will appear after you reopen this App.", "Thanks for Reading !!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
