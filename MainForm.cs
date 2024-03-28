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
        private Color OnBack = Color.FromArgb(113, 82, 255);
        private Color OffBack = Color.FromArgb(24, 24, 24);
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
            LoadNames();
        }

        public void LoadNames()
        {
            string ONEtext = btc.Properties.Settings.Default.Btn1;
            string TWOtext = btc.Properties.Settings.Default.Btn2;
            string THREEtext = btc.Properties.Settings.Default.Btn3;
            string FOURtext = btc.Properties.Settings.Default.Btn4;
            string FIVEtext = btc.Properties.Settings.Default.Btn5;
            string SIXtext = btc.Properties.Settings.Default.Btn6;
            string SEVENtext = btc.Properties.Settings.Default.Btn7;
            string EIGHTtext = btc.Properties.Settings.Default.Btn8;

            ONE.Text = ONEtext switch
            {
                "" => "1",
                _ => btc.Properties.Settings.Default.Btn1,
            };
            TWO.Text = TWOtext switch
            {
                "" => "2",
                _ => btc.Properties.Settings.Default.Btn2,
            };
            THREE.Text = THREEtext switch
            {
                "" => "3",
                _ => btc.Properties.Settings.Default.Btn3,
            };
            FOUR.Text = FOURtext switch
            {
                "" => "4",
                _ => btc.Properties.Settings.Default.Btn4,
            };
            FIVE.Text = FIVEtext switch
            {
                "" => "5",
                _ => btc.Properties.Settings.Default.Btn5,
            };
            SIX.Text = SIXtext switch
            {
                "" => "6",
                _ => btc.Properties.Settings.Default.Btn6,
            };
            SEVEN.Text = SEVENtext switch
            {
                "" => "7",
                _ => btc.Properties.Settings.Default.Btn7,
            };
            EIGHT.Text = EIGHTtext switch
            {
                "" => "8",
                _ => btc.Properties.Settings.Default.Btn8,
            };
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
                    this.Text = "BtC • " + serialPort.PortName;
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
            switch (btn)
            {
                case 1:
                    ONE.TextColor = Color.WhiteSmoke;
                    ONE.ButtonColor = OnBack;
                    ONE.BorderColor = OnBack;
                    break;
                case 2:
                    TWO.TextColor = Color.WhiteSmoke;
                    TWO.ButtonColor = OnBack;
                    TWO.BorderColor = OnBack;
                    break;
                case 3:
                    THREE.TextColor = Color.WhiteSmoke;
                    THREE.ButtonColor = OnBack;
                    THREE.BorderColor = OnBack;
                    break;
                case 4:
                    FOUR.TextColor = Color.WhiteSmoke;
                    FOUR.ButtonColor = OnBack;
                    FOUR.BorderColor = OnBack;
                    break;
                case 5:
                    FIVE.TextColor = Color.WhiteSmoke;
                    FIVE.ButtonColor = OnBack;
                    FIVE.BorderColor = OnBack;
                    break;
                case 6:
                    SIX.TextColor = Color.WhiteSmoke;
                    SIX.ButtonColor = OnBack;
                    SIX.BorderColor = OnBack;
                    break;
                case 7:
                    SEVEN.TextColor = Color.WhiteSmoke;
                    SEVEN.ButtonColor = OnBack;
                    SEVEN.BorderColor = OnBack;
                    break;
                case 8:
                    EIGHT.TextColor = Color.WhiteSmoke;
                    EIGHT.ButtonColor = OnBack;
                    EIGHT.BorderColor = OnBack;
                    break;
            }
        }

        private void OffBtn(int btn)
        {
            switch (btn)
            {
                case 1:
                    ONE.TextColor = Color.WhiteSmoke;
                    ONE.ButtonColor = OffBack;
                    ONE.BorderColor = Color.WhiteSmoke;
                    break;
                case 2:
                    TWO.TextColor = Color.WhiteSmoke;
                    TWO.ButtonColor = OffBack;
                    TWO.BorderColor = Color.WhiteSmoke;
                    break;
                case 3:
                    THREE.TextColor = Color.WhiteSmoke;
                    THREE.ButtonColor = OffBack;
                    THREE.BorderColor = Color.WhiteSmoke;
                    break;
                case 4:
                    FOUR.TextColor = Color.WhiteSmoke;
                    FOUR.ButtonColor = OffBack;
                    FOUR.BorderColor = Color.WhiteSmoke;
                    break;
                case 5:
                    FIVE.TextColor = Color.WhiteSmoke;
                    FIVE.ButtonColor = OffBack;
                    FIVE.BorderColor = Color.WhiteSmoke;
                    break;
                case 6:
                    SIX.TextColor = Color.WhiteSmoke;
                    SIX.ButtonColor = OffBack;
                    SIX.BorderColor = Color.WhiteSmoke;
                    break;
                case 7:
                    SEVEN.TextColor = Color.WhiteSmoke;
                    SEVEN.ButtonColor = OffBack;
                    SEVEN.BorderColor = Color.WhiteSmoke;
                    break;
                case 8:
                    EIGHT.TextColor = Color.WhiteSmoke;
                    EIGHT.ButtonColor = OffBack;
                    EIGHT.BorderColor = Color.WhiteSmoke;
                    break;
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
            switch (is1on)
            {
                case true:
                    is1on = false;
                    SendByte("a");
                    OffBtn(1);
                    break;
                case false:
                    is1on = true;
                    SendByte("A");
                    OnBtn(1);
                    break;
            }
        }

        private void TWO_Click(object sender, EventArgs e)
        {
            switch (is2on)
            {
                case true:
                    is2on = false;
                    SendByte("b");
                    OffBtn(2);
                    break;
                case false:
                    is2on = true;
                    SendByte("B");
                    OnBtn(2);
                    break;
            }
        }

        private void THREE_Click(object sender, EventArgs e)
        {
            switch (is3on)
            {
                case true:
                    is3on = false;
                    SendByte("c");
                    OffBtn(3);
                    break;
                case false:
                    is3on = true;
                    SendByte("C");
                    OnBtn(3);
                    break;
            }
        }

        private void FOUR_Click(object sender, EventArgs e)
        {
            switch (is4on)
            {
                case true:
                    is4on = false;
                    SendByte("d");
                    OffBtn(4);
                    break;
                case false:
                    is4on = true;
                    SendByte("D");
                    OnBtn(4);
                    break;
            }
        }

        private void FIVE_Click(object sender, EventArgs e)
        {
            switch (is5on)
            {
                case true:
                    is5on = false;
                    SendByte("e");
                    OffBtn(5);
                    break;
                case false:
                    is5on = true;
                    SendByte("E");
                    OnBtn(5);
                    break;
            }
        }

        private void SIX_Click(object sender, EventArgs e)
        {
            switch (is6on)
            {
                case true:
                    is6on = false;
                    SendByte("f");
                    OffBtn(6);
                    break;
                case false:
                    is6on = true;
                    SendByte("F");
                    OnBtn(6);
                    break;
            }
        }

        private void SEVEN_Click(object sender, EventArgs e)
        {
            switch (is7on)
            {
                case true:
                    is7on = false;
                    SendByte("g");
                    OffBtn(7);
                    break;
                case false:
                    is7on = true;
                    SendByte("G");
                    OnBtn(7);
                    break;
            }
        }

        private void EIGHT_Click(object sender, EventArgs e)
        {
            switch (is8on)
            {
                case true:
                    is8on = false;
                    SendByte("h");
                    OffBtn(8);
                    break;
                case false:
                    is8on = true;
                    SendByte("H");
                    OnBtn(8);
                    break;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form settings = new Settings_and_About();
            settings.FormClosed += delegate
            {
                LoadNames();
            };
            settings.ShowDialog();
        }
        private void BtC_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
                COMconnect.Value = 0;
            }
        }
    }
}
