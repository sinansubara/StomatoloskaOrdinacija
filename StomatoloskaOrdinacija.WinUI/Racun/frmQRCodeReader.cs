using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace StomatoloskaOrdinacija.WinUI.Racun
{
    public partial class frmQRCodeReader : Form
    {
        public frmQRCodeReader()
        {
            InitializeComponent();
        }

        private FilterInfoCollection filterInfoCollection;
        private VideoCaptureDevice captureDevice;

        private void frmQRCodeReader_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                cmbKamera.Items.Add(filterInfo.Name);
            if (cmbKamera.Items.Count > 0)
            {
                cmbKamera.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbKamera.SelectedIndex == -1)
            {
                MessageBox.Show("Ne mozete pokrenut kameru, jer nije detektovana ni jedna!");
            }
            else
            {
                captureDevice = new VideoCaptureDevice(filterInfoCollection[cmbKamera.SelectedIndex].MonikerString);
                captureDevice.NewFrame += CaptureDevice_NewFrame;
                captureDevice.Start();
                timer1.Start();
            }
        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                pbPrikaz.Image = (Bitmap) eventArgs.Frame.Clone();
            }
            catch (Exception)
            {
                
            }
        }

        private void frmQRCodeReader_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (captureDevice != null)
            {
                if (captureDevice.IsRunning)
                    captureDevice.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pbPrikaz.Image != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                Result result = barcodeReader.Decode((Bitmap) pbPrikaz.Image);
                if (result != null)
                {
                    txtQRReader.Text = result.ToString();
                    timer1.Stop();
                    if (captureDevice.IsRunning)
                        captureDevice.Stop();
                }
            }
        }
    }
}
