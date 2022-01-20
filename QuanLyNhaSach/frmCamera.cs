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

namespace QuanLyNhaSach
{
    public partial class frmCamera : Form
    {

        private FilterInfoCollection cameras;
        private VideoCaptureDevice camera;

        public frmCamera()
        {
            InitializeComponent();
            cameras = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo info in cameras)
            {
                cboCamera.Items.Add(info.Name);
            }
            cboCamera.SelectedIndex = 0;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (camera != null && camera.IsRunning)
            {
                camera.Stop();
            }
            else
            {
                camera = new VideoCaptureDevice(cameras[cboCamera.SelectedIndex].MonikerString);
                camera.NewFrame += Cam_NewFrame;
                camera.Start();
            }
        }

        private void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = bitmap;
        }

        private void btnTakePicture_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = @"F:\TongHop\HK2034\PhatTrienUngDungPhanMem\QuanLyNhaSach\Images\";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog1.FileName);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (camera != null && camera.IsRunning)
            {
                camera.Stop();
                this.Close();
            }
        }

        private void ToolStripExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng máy ảnh không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (camera != null && camera.IsRunning)
                {
                    camera.Stop();
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
        }
    }
}
