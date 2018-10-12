using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;

namespace CadastroPasseCerto
{
    public partial class Form2 : Form
    {

        private VideoCaptureDevice videoSource;

        private FilterInfoCollection videoSources = new FilterInfoCollection(FilterCategory.VideoInputDevice);

        public Form2()
        {

            InitializeComponent();

            if(videoSources != null && videoSources.Count > 0)
            {
                for(int i =0; i < videoSources.Count; i++)
                {
                    comboBox1.Items.Add(videoSources[i].Name);
                }
                videoSource = new VideoCaptureDevice(videoSources[0].MonikerString);
                videoSource.NewFrame += VideoSource_NewFrame;
            }

        }

        private void VideoSource_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            if(pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
            pictureBox1.Image = (Bitmap) eventArgs.Frame.Clone();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                try
                {
                    videoSource.NewFrame -= VideoSource_NewFrame;
                    using(var ms = new System.IO.MemoryStream())
                    {
                        pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        Form1.fotoAluno = ms.ToArray();
                    }
                    
                    /*pictureBox1.Image.Save(Environment.GetFolderPath(Environment.SpecialFolder.Personal)
                + "\\teste.png", System.Drawing.Imaging.ImageFormat.Png);*/
                }
                finally
                {
                    videoSource.NewFrame += VideoSource_NewFrame;
                }
                
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            videoSource = new VideoCaptureDevice(videoSources[comboBox1.SelectedIndex].MonikerString);
            videoSource.NewFrame += VideoSource_NewFrame;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (videoSource.IsRunning)
            {
                videoSource.Stop();
            }
            base.OnFormClosed(e);
        }
    }
}
