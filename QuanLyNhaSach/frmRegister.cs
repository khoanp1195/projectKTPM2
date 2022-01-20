using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaSach.BUS;
using QuanLyNhaSach.Data;

namespace QuanLyNhaSach
{
    public partial class frmRegister : Form
    {
        Library library = new Library();

        AdminBUS bus = new AdminBUS();

        public frmRegister()
        {
            InitializeComponent();
        }

        private void RefreshData()
        {
            txtHoVaTen.Clear();
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            txtXacNhanMk.Clear();
            txtHoVaTen.Focus();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string name = "";
            if (txtHoVaTen.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập họ và tên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoVaTen.Focus();
                return;
            }
            else if (txtHoVaTen.Text.Trim().Length < 2 || txtHoVaTen.Text.Trim().Length > 255)
            {
                MessageBox.Show("Độ dài tối thiểu của họ và tên là 2 và tối đa là 255 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoVaTen.Focus();
                return;
            }
            else
            {
                name = txtHoVaTen.Text.Trim();
            };

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

            string confirm_pw = txtXacNhanMk.Text.Trim();

            if (password != confirm_pw)
            {
                MessageBox.Show("Mật khẩu không trùng khớp. Vui lòng kiểm tra lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtXacNhanMk.Focus();
                return;
            }

            if (bus.GetAdminDetail(usreName) != null)
            {
                MessageBox.Show("Tài khoản này đã tồn tại. Vui lòng tạo tài khoản khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Focus();
                return;
            }

            byte[] image = {  };

            Admin admin = new Admin();
            admin.Name = name;
            admin.Username = usreName;
            admin.Password = library.MD5Hash(password);
            admin.Image = image;
            admin.Rule = "";

            try
            {
                bool result = bus.InsertAdmin(admin);
                if (result)
                {
                    RefreshData();
                    MessageBox.Show("Đăng ký tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    frmLogin frm = new frmLogin();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Đăng ký tài khoản thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.Show();
        }
    }
}
