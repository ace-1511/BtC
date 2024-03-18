using ePOSOne.btnProduct;
using System.Drawing.Text;
using System.IO.Ports;
using System.Runtime.InteropServices;
using Windows.ApplicationModel.Background;
using Windows.Networking;

namespace BtC
{
    public partial class BtC : Form
    {
        private SerialPort serialPort = new SerialPort();
        public static string COM = "";
        bool is1on = false;
        bool is2on = false;
        bool is3on = false;
        bool is4on = false;
        bool is5on = false;
        bool is6on = false;
        bool is7on = false;
        bool is8on = false;
        public BtC()
        {
            int ScrWidth = Screen.PrimaryScreen.Bounds.Size.Width;
            int ScrHeight = Screen.PrimaryScreen.Bounds.Size.Height;
            int BtCWidth = this.Width;
            int BtCHeight = this.Height;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(ScrWidth - BtCWidth, (ScrHeight - BtCHeight) / 6);
            InitializeComponent();
            GetAvailablePorts();
        }
        private void BtC_Load(object sender, EventArgs e)
        {
            if (btc.Properties.Settings.Default.Btn1 != "")
            {
                ONE.Text = btc.Properties.Settings.Default.Btn1;
            }
            else if (btc.Properties.Settings.Default.Btn1 == "")
            {
                ONE.Text = "1";
            }
            if (btc.Properties.Settings.Default.Btn2 != "")
            {
                TWO.Text = btc.Properties.Settings.Default.Btn2;
            }
            else if (btc.Properties.Settings.Default.Btn2 == "")
            {
                TWO.Text = "2";
            }
            if (btc.Properties.Settings.Default.Btn3 != "")
            {
                THREE.Text = btc.Properties.Settings.Default.Btn3;
            }
            else if (btc.Properties.Settings.Default.Btn3 == "")
            {
                THREE.Text = "3";
            }
            if (btc.Properties.Settings.Default.Btn4 != "")
            {
                FOUR.Text = btc.Properties.Settings.Default.Btn4;
            }
            else if (btc.Properties.Settings.Default.Btn4 == "")
            {
                FOUR.Text = "4";
            }
            if (btc.Properties.Settings.Default.Btn5 != "")
            {
                FIVE.Text = btc.Properties.Settings.Default.Btn5;
            }
            else if (btc.Properties.Settings.Default.Btn5 == "")
            {
                FIVE.Text = "5";
            }
            if (btc.Properties.Settings.Default.Btn6 != "")
            {
                SIX.Text = btc.Properties.Settings.Default.Btn6;
            }
            else if (btc.Properties.Settings.Default.Btn6 == "")
            {
                SIX.Text = "6";
            }
            if (btc.Properties.Settings.Default.Btn7 != "")
            {
                SEVEN.Text = btc.Properties.Settings.Default.Btn7;
            }
            else if (btc.Properties.Settings.Default.Btn7 == "")
            {
                SEVEN.Text = "7";
            }
            if (btc.Properties.Settings.Default.Btn8 != "")
            {
                EIGHT.Text = btc.Properties.Settings.Default.Btn8;
            }
            else if (btc.Properties.Settings.Default.Btn8 == "")
            {
                EIGHT.Text= "8";
            }
        }

        void GetAvailablePorts()
        {
            string[] ports = SerialPort.GetPortNames();
            SPDropdown.Items.AddRange(ports);
        }
        private void SPDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            COM = this.SPDropdown.GetItemText(this.SPDropdown.SelectedItem);
            if (!serialPort.IsOpen)
            {
                serialPort.Close();
                Selection();
            }
            else
            {
                serialPort.Close();
            }
        }

        private void Selection()
        {
            if (SPDropdown != null)
            {
                if (SPDropdown.SelectedIndex > -1)
                {
                    Connect();
                    Enable();
                }
                else
                {
                    Disable();
                }
            }
            else
            {
                MessageBox.Show("Select HC05 COM port to Continue.", "Warning !!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void Connect()
        {
            try
            {
                if (!serialPort.IsOpen)
                {
                    serialPort.PortName = COM;
                    serialPort.BaudRate = 9600;
                    serialPort.Parity = Parity.None;
                    serialPort.DataBits = 8;
                    serialPort.StopBits = StopBits.One;
                    serialPort.Open();
                    COMconnect.Value = 100;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "There seems to be a PROBLEM !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                serialPort.Close();
            }
        }
        private void Enable()
        {
            ONE.Enabled = true;
            TWO.Enabled = true;
            THREE.Enabled = true;
            FOUR.Enabled = true;
            FIVE.Enabled = true;
            SIX.Enabled = true;
            SEVEN.Enabled = true;
            EIGHT.Enabled = true;
        }

        private void Disable()
        {
            ONE.Enabled = false;
            TWO.Enabled = false;
            THREE.Enabled = false;
            FOUR.Enabled = false;
            FIVE.Enabled = false;
            SIX.Enabled = false;
            SEVEN.Enabled = false;
            EIGHT.Enabled = false;
        }
        private void OnBtn(int btn)
        {
            if (btn == 1)
            {
                ONE.TextColor = Color.WhiteSmoke;
                ONE.ButtonColor = Color.FromArgb(133, 82, 255);
                ONE.BorderColor = Color.FromArgb(113, 82, 255);
            }
            else if (btn == 2)
            {
                TWO.TextColor = Color.WhiteSmoke;
                TWO.ButtonColor = Color.FromArgb(133, 82, 255);
                TWO.BorderColor = Color.FromArgb(113, 82, 255);
            }
            else if (btn == 3)
            {
                THREE.TextColor = Color.WhiteSmoke;
                THREE.ButtonColor = Color.FromArgb(133, 82, 255);
                THREE.BorderColor = Color.FromArgb(113, 82, 255);
            }
            else if (btn == 4)
            {
                FOUR.TextColor = Color.WhiteSmoke;
                FOUR.ButtonColor = Color.FromArgb(133, 82, 255);
                FOUR.BorderColor = Color.FromArgb(113, 82, 255);
            }
            else if (btn == 5)
            {
                FIVE.TextColor = Color.WhiteSmoke;
                FIVE.ButtonColor = Color.FromArgb(133, 82, 255);
                FIVE.BorderColor = Color.FromArgb(113, 82, 255);
            }
            else if (btn == 6)
            {
                SIX.TextColor = Color.WhiteSmoke;
                SIX.ButtonColor = Color.FromArgb(133, 82, 255);
                SIX.BorderColor = Color.FromArgb(113, 82, 255);
            }
            else if (btn == 7)
            {
                SEVEN.TextColor = Color.WhiteSmoke;
                SEVEN.ButtonColor = Color.FromArgb(133, 82, 255);
                SEVEN.BorderColor = Color.FromArgb(113, 82, 255);
            }
            else if (btn == 8)
            {
                EIGHT.TextColor = Color.WhiteSmoke;
                EIGHT.ButtonColor = Color.FromArgb(133, 82, 255);
                EIGHT.BorderColor = Color.FromArgb(113, 82, 255);
            }
        }

        private void OffBtn(int btn)
        {
            if (btn == 1)
            {
                ONE.TextColor = Color.WhiteSmoke;
                ONE.ButtonColor = Color.FromArgb(24, 24, 24);
                ONE.BorderColor = Color.WhiteSmoke;
            }
            else if (btn == 2)
            {
                TWO.TextColor = Color.WhiteSmoke;
                TWO.ButtonColor = Color.FromArgb(24, 24, 24);
                TWO.BorderColor = Color.WhiteSmoke;
            }
            else if (btn == 3)
            {
                THREE.TextColor = Color.WhiteSmoke;
                THREE.ButtonColor = Color.FromArgb(24, 24, 24);
                THREE.BorderColor = Color.WhiteSmoke;
            }
            else if (btn == 4)
            {
                FOUR.TextColor = Color.WhiteSmoke;
                FOUR.ButtonColor = Color.FromArgb(24, 24, 24);
                FOUR.BorderColor = Color.WhiteSmoke;
            }
            else if (btn == 5)
            {
                FIVE.TextColor = Color.WhiteSmoke;
                FIVE.ButtonColor = Color.FromArgb(24, 24, 24);
                FIVE.BorderColor = Color.WhiteSmoke;
            }
            else if (btn == 6)
            {
                SIX.TextColor = Color.WhiteSmoke;
                SIX.ButtonColor = Color.FromArgb(24, 24, 24);
                SIX.BorderColor = Color.WhiteSmoke;
            }
            else if (btn == 7)
            {
                SEVEN.TextColor = Color.WhiteSmoke;
                SEVEN.ButtonColor = Color.FromArgb(24, 24, 24);
                SEVEN.BorderColor = Color.WhiteSmoke;
            }
            else if (btn == 8)
            {
                EIGHT.TextColor = Color.WhiteSmoke;
                EIGHT.ButtonColor = Color.FromArgb(24, 24, 24);
                EIGHT.BorderColor = Color.WhiteSmoke;
            }
        }

        private void SendByte(string message)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Write(message.ToString());
            }
            else
            {
                MessageBox.Show("Try selecting COM port again.", "There seems to be a PROBLEM !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ONE_Click(object sender, EventArgs e)
        {
            if (is1on == false)
            {
                is1on = true;
                SendByte("A");
                OnBtn(1);
            }
            else if (is1on == true)
            {
                is1on = false;
                SendByte("a");
                OffBtn(1);
            }

        }

        private void TWO_Click(object sender, EventArgs e)
        {
            if (is2on == false)
            {
                is2on = true;
                SendByte("B");
                OnBtn(2);
            }
            else if (is2on == true)
            {
                is2on = false;
                SendByte("b");
                OffBtn(2);
            }
        }

        private void THREE_Click(object sender, EventArgs e)
        {
            if (is3on == false)
            {
                is3on = true;
                SendByte("C");
                OnBtn(3);
            }
            else if (is3on == true)
            {
                is3on = false;
                SendByte("c");
                OffBtn(3);
            }
        }

        private void FOUR_Click(object sender, EventArgs e)
        {
            if (is4on == false)
            {
                is4on = true;
                SendByte("D");
                OnBtn(4);
            }
            else if (is4on == true)
            {
                is4on = false;
                SendByte("d");
                OffBtn(4);
            }
        }

        private void FIVE_Click(object sender, EventArgs e)
        {
            if (is5on == false)
            {
                is5on = true;
                SendByte("E");
                OnBtn(5);
            }
            else if (is5on == true)
            {
                is5on = false;
                SendByte("e");
                OffBtn(5);
            }
        }

        private void SIX_Click(object sender, EventArgs e)
        {
            if (is6on == false)
            {
                is6on = true;
                SendByte("F");
                OnBtn(6);
            }
            else if (is6on == true)
            {
                is6on = false;
                SendByte("f");
                OffBtn(6);
            }
        }

        private void SEVEN_Click(object sender, EventArgs e)
        {
            if (is7on == false)
            {
                is7on = true;
                SendByte("G");
                OnBtn(7);
            }
            else if (is7on == true)
            {
                is7on = false;
                SendByte("g");
                OffBtn(7);
            }
        }

        private void EIGHT_Click(object sender, EventArgs e)
        {
            if (is8on == false)
            {
                is8on = true;
                SendByte("H");
                OnBtn(8);
            }
            else if (is8on == true)
            {
                is8on = false;
                SendByte("h");
                OffBtn(8);
            }
        }

        private void BtC_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("You are about to exit !!", "Bye ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                    COMconnect.Value = 0;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form settings = new Settings_and_About();
            settings.ShowDialog();
        }
    }
}
