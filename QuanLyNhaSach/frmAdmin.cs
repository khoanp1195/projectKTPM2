using QuanLyNhaSach.BUS;
using QuanLyNhaSach.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    public partial class frmAdmin : Form
    {
        public string Name = "";
        public string Username = "";
        public string Rule = "";
        public string imageLocation = "";

        Library library = new Library();

        AdminBUS bus = new AdminBUS();

        public frmAdmin()
        {
            InitializeComponent();
        }

        public frmAdmin(string name, string username,string rule)
        {
            InitializeComponent();
            this.Name = name;
            this.Username = username;
            this.Rule = rule;
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            txtHoVaTen.Text = Name;
            txtTaiKhoan.Text = Username;
            txtTaiKhoan.Enabled = false;
            Admin admin = bus.GetAdminDetail(Username);
            if (admin != null)
            {
                byte[] b = null;
                if (admin.Image != null)
                {
                    b = admin.Image.ToArray();
                    pictureBox1.Image = ByteArrayToImage(b);
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
        }

        private byte[] ImageToByteArray()
        {
            byte[] b = null;
            FileStream stream = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(stream);
            b = brs.ReadBytes((int)stream.Length);
            return b;
        }

        private Image ByteArrayToImage(byte[] b)
        {
            using (MemoryStream m = new MemoryStream(b))
            {
                Image img = Image.FromStream(m);
                return img;
            }
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*", Multiselect = false };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
                imageLocation = ofd.FileName.ToString();
                pictureBox1.ImageLocation = imageLocation;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtHoVaTen.Text.Trim().Length < 6 || txtHoVaTen.Text.Trim().Length > 255)
            {
                MessageBox.Show("Độ dài tối thiểu của họ và tên là 6 và tối đa là 255 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Focus();
                return;
            }
            string name = txtHoVaTen.Text.Trim();
            string username = txtTaiKhoan.Text.Trim();
            string password = txtMatKhau.Text.Trim();
            string password_cf = txtXacNhanMk.Text.Trim();
            byte[] b = null;
            if (imageLocation != null || imageLocation != "")
            {
                b = ImageToByteArray();
            }
            else
            {
                b = null;
            }


            if (password != password_cf)
            {
                MessageBox.Show("Mật khẩu không trùng khớp. Vui lòng kiểm tra lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtXacNhanMk.Focus();
                return;
            }
          
            Admin admin = bus.GetAdminDetail(username);
            if (admin != null)
            {
                if (password != "")
                {
                    admin.Name = name;
                    admin.Password = library.MD5Hash(password);
                    admin.Image = b;
                }
                else
                {
                    admin.Name = name;
                    admin.Image = b;
                }
                try
                {
                    DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn cập nhật tài khoản không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirm == DialogResult.Yes)
                    {
                        bool result = bus.UpdateAdmin(admin,Username);
                        if (result)
                        {
                            MessageBox.Show("Cập nhật tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            frnMain frm = new frnMain(admin.Name, admin.Username,admin.Rule);
                            frm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật tài khoản thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng form không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                frnMain frm = new frnMain(Name, Username, Rule);
                frm.Show();
            }
        }

        private void ToolStripColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = this.BackColor;
            colorDialog1.AllowFullOpen = true;
            colorDialog1.FullOpen = true;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
            }
        }

        private void ToolStripFont_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = this.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Font = fontDialog1.Font;
            }
        }

        private void ToolStripExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng form không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                frnMain frm = new frnMain(Name, Username, Rule);
                frm.Show();
            }
        }
    }
}
