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
using Windows.ApplicationModel.Background;

namespace BtC
{
    partial class Settings_and_About : Form
    {
        private string Btn1 = btc.Properties.Settings.Default.Btn1;
        private string Btn2 = btc.Properties.Settings.Default.Btn2;
        private string Btn3 = btc.Properties.Settings.Default.Btn3;
        private string Btn4 = btc.Properties.Settings.Default.Btn4;
        private string Btn5 = btc.Properties.Settings.Default.Btn5;
        private string Btn6 = btc.Properties.Settings.Default.Btn6;
        private string Btn7 = btc.Properties.Settings.Default.Btn7;
        private string Btn8 = btc.Properties.Settings.Default.Btn8;
        private int nameschanged = 0;
        public Settings_and_About()
        {
            InitializeComponent();
            this.labelProductName.Text = ("Bluetooth Control (BtC)");
            this.labelVersion.Text = String.Format("Version : 1.0.0");
            this.labelCompanyName.Text = "By SANEX (Sanshray)";
        }
        private void Settings_and_About_Load(object sender, EventArgs e)
        {
            NewNameOf1.Text = Btn1;
            NewNameOf2.Text = Btn2;
            NewNameOf3.Text = Btn3;
            NewNameOf4.Text = Btn4;
            NewNameOf5.Text = Btn5;
            NewNameOf6.Text = Btn6;
            NewNameOf7.Text = Btn7;
            NewNameOf8.Text = Btn8;
        }

        private void ClearNamesBtn_Click(object sender, EventArgs e)
        {
            NewNameOf1.Text = null;
            NewNameOf2.Text = null;
            NewNameOf3.Text = null;
            NewNameOf4.Text = null;
            NewNameOf5.Text = null;
            NewNameOf6.Text = null;
            NewNameOf7.Text = null;
            NewNameOf8.Text = null;
            SaveAllMods();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (nameschanged > 0)
            {
                SaveAllMods();
                btc.Properties.Settings.Default.Save();
                MessageBox.Show("All Settings have been saved successfully.", "Settings Panel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void SaveAllMods()
        {
            Btn1 = Btn1 switch
            {
                null => "",
                _ => (NewNameOf1.Text),
            };
            Btn2 = Btn2 switch
            {
                null => "",
                _ => (NewNameOf2.Text),
            };
            Btn3 = Btn3 switch
            {
                null => "",
                _ => (NewNameOf3.Text),
            };
            Btn4 = Btn4 switch
            {
                null => "",
                _ => (NewNameOf4.Text),
            };
            Btn5 = Btn5 switch
            {
                null => "",
                _ => (NewNameOf5.Text),
            };
            Btn6 = Btn6 switch
            {
                null => "",
                _ => (NewNameOf6.Text),
            };
            Btn7 = Btn7 switch
            {
                null => "",
                _ => (NewNameOf7.Text),
            };
            Btn8 = Btn8 switch
            {
                null => "",
                _ => (NewNameOf8.Text),
            };
            btc.Properties.Settings.Default.Btn1 = Btn1;
            btc.Properties.Settings.Default.Btn2 = Btn2;
            btc.Properties.Settings.Default.Btn3 = Btn3;
            btc.Properties.Settings.Default.Btn4 = Btn4;
            btc.Properties.Settings.Default.Btn5 = Btn5;
            btc.Properties.Settings.Default.Btn6 = Btn6;
            btc.Properties.Settings.Default.Btn7 = Btn7;
            btc.Properties.Settings.Default.Btn8 = Btn8;
        }
        private void NewNameOf1_TextChanged(object sender, EventArgs e)
        {
            if (Btn1 != NewNameOf1.Text)
            {
                nameschanged++;
            }
        }
        private void NewNameOf2_TextChanged(object sender, EventArgs e)
        {
            if (Btn2 != NewNameOf2.Text)
            {
                nameschanged++;
            }
        }
        private void NewNameOf3_TextChanged(object sender, EventArgs e)
        {
            if (Btn3 != NewNameOf3.Text)
            {
                nameschanged++;
            }
        }
        private void NewNameOf4_TextChanged(object sender, EventArgs e)
        {
            if (Btn4 != NewNameOf4.Text)
            {
                nameschanged++;
            }
        }
        private void NewNameOf5_TextChanged(object sender, EventArgs e)
        {
            if (Btn5 != NewNameOf5.Text)
            {
                nameschanged++;
            }
        }
        private void NewNameOf6_TextChanged(object sender, EventArgs e)
        {
            if (Btn6 != NewNameOf6.Text)
            {
                nameschanged++;
            }
        }
        private void NewNameOf7_TextChanged(object sender, EventArgs e)
        {
            if (Btn7 != NewNameOf7.Text)
            {
                nameschanged++;
            }
        }
        private void NewNameOf8_TextChanged(object sender, EventArgs e)
        {
            if (Btn8 != NewNameOf8.Text)
            {
                nameschanged++;
            }
        }

        private void Settings_and_About_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveAllMods();
        }
    }
}