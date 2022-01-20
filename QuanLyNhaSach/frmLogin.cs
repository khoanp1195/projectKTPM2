using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaSach.BUS;
using QuanLyNhaSach.Data;

namespace QuanLyNhaSach
{
    public partial class frmLogin : Form
    {
        Library library = new Library();

        AdminBUS bus = new AdminBUS();

        public frmLogin()
        {
            InitializeComponent();
        }

        public void RefreshData()
        {
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            txtTaiKhoan.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usreName = "";
            if (txtTaiKhoan.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tài khoản !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Focus();
                return;
            }
            else if (txtTaiKhoan.Text.Trim().Length < 6 || txtTaiKhoan.Text.Trim().Length > 255)
            {
                MessageBox.Show("Độ dài tối thiểu của tài khoản là 6 và tối đa là 255 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Focus();
                return;
            }
            else
            {
                usreName = txtTaiKhoan.Text.Trim();
            };

            string password = "";
            if (txtMatKhau.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }
            else if (txtMatKhau.Text.Trim().Length < 6 || txtTaiKhoan.Text.Trim().Length > 255)
            {
                MessageBox.Show("Độ dài tối thiểu của mật khẩu là 6 và tối đa là 255 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }
            else
            {
                password = txtMatKhau.Text.Trim();
            };

            try
            {
                Admin admin = bus.Login(usreName, library.MD5Hash(password));
                if (admin != null)
                {
                    RefreshData();
                    MessageBox.Show("Đăng nhập tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    frnMain frm = new frnMain(admin.Name,admin.Username,admin.Rule);
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Đăng nhập tài khoản thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng form không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    this.Hide();
        //    frmRegister frm = new frmRegister();
        //    frm.Show();
        //}
    }
}
