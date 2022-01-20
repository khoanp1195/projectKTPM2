using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    public partial class frnMain : Form
    {
        Library library = new Library();

        public string Name = "";
        public string Username = "";
        public string Rule = "";

        public frnMain()
        {
            InitializeComponent();
        }

        public frnMain(string name, string username, string rule)
        {
            InitializeComponent();
            this.Name = name;
            this.Username = username;
            this.Rule = rule;
        }

        private void frnMain_Load(object sender, EventArgs e)
        {
            lblDate.Text = library.changeDate(DateTime.Now.DayOfWeek.ToString()) + " " + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            if (Name != null && Name != "")
            {
                mnuAdmin.Text = "Xin chào " + Name;
                mnuCapNhat.Text = "Cập nhật";
                mnuDangXuat.Text = "Đăng xuất";
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = "Bây giờ là: " + DateTime.Now.Hour.ToString() + " : " + DateTime.Now.Minute.ToString() + " : " + DateTime.Now.Second.ToString();
        }

        private void mnuCategoryProduct_Click(object sender, EventArgs e)
        {
            frmCategory frm = new frmCategory(Rule);
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuHangHoa_Click(object sender, EventArgs e)
        {
            frmProduct frm = new frmProduct(Rule);
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            frmEmployee frm = new frmEmployee(Rule);
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            frmCustomer frm = new frmCustomer(Rule);
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không ?", "Thoát chương trình !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Thoát chương trình thành công !");
                Application.Exit();
            }
        }

        private void mnuTimDMHangHoa_Click(object sender, EventArgs e)
        {
            frmSearchCategory frm = new frmSearchCategory();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuTimHangHoa_Click(object sender, EventArgs e)
        {
            frmSearchProduct frm = new frmSearchProduct();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuTimKhachHang_Click(object sender, EventArgs e)
        {
            frmSearchCustomer frm = new frmSearchCustomer();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuTimNhanVien_Click(object sender, EventArgs e)
        {
            frmSearchEmpoyee frm = new frmSearchEmpoyee();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuThemHoaDon_Click(object sender, EventArgs e)
        {
            frmAddBill frm = new frmAddBill(Rule);
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuQuanLyHoaDon_Click(object sender, EventArgs e)
        {
            frmBill frm = new frmBill(Rule);
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuCapNhat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAdmin frm = new frmAdmin(Name, Username, Rule);
            frm.Show();
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.Show();
        }

        private void mnuGuiEmail_Click(object sender, EventArgs e)
        {
            frmEmail frm = new frmEmail();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuReportProduct(object sender, EventArgs e)
        {
            frmReport frm = new frmReport();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuMayAnh_Click(object sender, EventArgs e)
        {
            frmCamera frm = new frmCamera();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuMayTinh_Click(object sender, EventArgs e)
        {
            frmCaculator frm = new frmCaculator();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuViewArrangeIcons_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void mnuViewCasade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuViewTH_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuViewTV_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void ToolStripExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng form không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
