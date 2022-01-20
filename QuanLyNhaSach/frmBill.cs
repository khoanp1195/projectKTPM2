using QuanLyNhaSach.BUS;
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
    public partial class frmBill : Form
    {
        BillBUS bus = new BillBUS();

        public string Rule = "";

        public frmBill()
        {
            InitializeComponent();
        }

        public frmBill(string rule)
        {
            InitializeComponent();
            this.Rule = rule;
        }

        private void frmBill_Load(object sender, EventArgs e)
        {
            LoadBills();
            btnDelete.Enabled = false;
        }

        private void LoadBills()
        {
            dgvBills.Columns.Clear();
            dgvBills.AutoGenerateColumns = false;

            DataGridViewComboBoxColumn col_codeHD = new DataGridViewComboBoxColumn();
            col_codeHD.HeaderText = "Mã hoá đơn";
            col_codeHD.Width = 120;
            col_codeHD.Name = "CodeHD";
            col_codeHD.DataPropertyName = "CodeHD";
            col_codeHD.DataSource = bus.GetAllBills();
            col_codeHD.ValueMember = "CodeHD";
            col_codeHD.DisplayMember = "CodeHD";
            col_codeHD.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;

            DataGridViewTextBoxColumn col_nameNV = new DataGridViewTextBoxColumn();
            col_nameNV.HeaderText = "Tên nhân viên";
            col_nameNV.Width = 350;
            col_nameNV.Name = "Employee";
            col_nameNV.DataPropertyName = "Employee";


            DataGridViewTextBoxColumn col_nameKH = new DataGridViewTextBoxColumn();
            col_nameKH.HeaderText = "Tên khách hàng";
            col_nameKH.Width = 350;
            col_nameKH.Name = "Customer";
            col_nameKH.DataPropertyName = "Customer";

            DataGridViewTextBoxColumn col_sellDay = new DataGridViewTextBoxColumn();
            col_sellDay.HeaderText = "Ngày bán";
            col_sellDay.Width = 100;
            col_sellDay.Name = "SellDay";
            col_sellDay.DataPropertyName = "SellDay";

            DataGridViewTextBoxColumn col_total = new DataGridViewTextBoxColumn();
            col_total.HeaderText = "Tổng tiền";
            col_total.Width = 100;
            col_total.Name = "Total";
            col_total.DataPropertyName = "Total";

            dgvBills.Columns.Add(col_codeHD);
            dgvBills.Columns.Add(col_nameNV);
            dgvBills.Columns.Add(col_nameKH);
            dgvBills.Columns.Add(col_sellDay);
            dgvBills.Columns.Add(col_total);

            BindingSource bs = new BindingSource();
            bs.DataSource = bus.GetDetailInformationBillByID().Tables[0];
            dgvBills.DataSource = bs;
        }

        private void LoadDetailBills()
        {
            dgvDetailBills.Columns.Clear();
            dgvDetailBills.AutoGenerateColumns = false;

            DataGridViewComboBoxColumn col_codeSP = new DataGridViewComboBoxColumn();
            col_codeSP.HeaderText = "Mã sản phẩm";
            col_codeSP.Width = 120;
            col_codeSP.Name = "CodeMH";
            col_codeSP.DataPropertyName = "CodeMH";
            col_codeSP.DataSource = bus.GetAllDetailBills();
            col_codeSP.ValueMember = "CodeMH";
            col_codeSP.DisplayMember = "CodeMH";
            col_codeSP.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;

            DataGridViewTextBoxColumn col_price = new DataGridViewTextBoxColumn();
            col_price.HeaderText = "Giá";
            col_price.Width = 100;
            col_price.Name = "Price";
            col_price.DataPropertyName = "Price";

            DataGridViewTextBoxColumn col_quantity = new DataGridViewTextBoxColumn();
            col_quantity.HeaderText = "Số lượng";
            col_quantity.Width = 100;
            col_quantity.Name = "Quantity";
            col_quantity.DataPropertyName = "Quantity";

            DataGridViewTextBoxColumn col_sale = new DataGridViewTextBoxColumn();
            col_sale.HeaderText = "Giảm giá";
            col_sale.Width = 100;
            col_sale.Name = "Sale";
            col_sale.DataPropertyName = "Sale";

            DataGridViewTextBoxColumn col_total = new DataGridViewTextBoxColumn();
            col_total.HeaderText = "Thành tiền";
            col_total.Width = 100;
            col_total.Name = "Total";
            col_total.DataPropertyName = "Total";

            dgvDetailBills.Columns.Add(col_codeSP);
            dgvDetailBills.Columns.Add(col_price);
            dgvDetailBills.Columns.Add(col_quantity);
            dgvDetailBills.Columns.Add(col_sale);
            dgvDetailBills.Columns.Add(col_total);

            string id = dgvBills.SelectedRows[0].Cells["CodeHD"].Value.ToString();

            BindingSource bs = new BindingSource();
            bs.DataSource = bus.GetAllDetailBill(id).Tables[0];
            dgvDetailBills.DataSource = bs;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmBill_Load(sender, e);
        }

        private void dgvBills_Click(object sender, EventArgs e)
        {
            if (dgvBills.SelectedRows.Count > 0)
            {
                LoadDetailBills();
            }
            btnDelete.Enabled = true;
        }

        private void dgvBills_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dgvDetailBills_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (Rule == "Admin")
            {
                try
                {
                    string codeHD = dgvBills.CurrentRow.Cells["CodeHD"].Value.ToString();
                    string codeSP = dgvDetailBills.CurrentRow.Cells["CodeMH"].Value.ToString();
                    DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xoá sản phẩm này ra khỏi hoá đơn này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirm == DialogResult.Yes)
                    {
                        bool result = bus.DeleteDetailBill(codeHD,codeSP);
                        if (result)
                        {
                            MessageBox.Show("Xoá sản phẩm này ra khỏi hoá đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvDetailBills.Columns.Clear();
                            frmBill_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Xoá sản phẩm này ra khỏi hoá đơn thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Chỉ có quyền quản trị viên mới được phép thực hiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Rule == "Admin")
            {
                try
                {
                    string codeHD = dgvBills.CurrentRow.Cells["CodeHD"].Value.ToString();
                    DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xoá hoá đơn này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirm == DialogResult.Yes)
                    {
                        bool result = bus.DeleteDetailBill(codeHD) && bus.DeleteBill(codeHD);
                        if (result)
                        {
                            MessageBox.Show("Xoá hoá đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvDetailBills.Columns.Clear();
                            frmBill_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Xoá hoá đơn thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Chỉ có quyền quản trị viên mới được phép thực hiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng form không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void ToolStripColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = panel1.BackColor;
            colorDialog1.AllowFullOpen = true;
            colorDialog1.FullOpen = true;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                panel1.BackColor = colorDialog1.Color;
            }
        }

        private void ToolStripFont_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = panel1.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                panel1.Font = fontDialog1.Font;
            }
        }

        private void ToolStripExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng form không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
