using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaSach.Data;
using QuanLyNhaSach.BUS;

namespace QuanLyNhaSach
{
    public partial class frmAddBill : Form
    {
        Library library = new Library();

        BillBUS bus = new BillBUS();

        public string Rule = "";
        bool flag = true;

        List<DetailBill> cart = new List<DetailBill>();

        public frmAddBill()
        {
            InitializeComponent();
        }

        public frmAddBill(string rule)
        {
            InitializeComponent();
            this.Rule = rule;
        }

        private void frmBill_Load(object sender, EventArgs e)
        {
            LoadComboCodeNV();
            LoadComboCodeKH();
            LoadComboCodeSP();
            FormatDisplay();
        }

        private void FormatDisplay()
        { 
            txtMaHD.Enabled = false;
            btnSave.Enabled = false;
            btnCheckOut.Enabled = false;
            btnRefresh.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void LoadComboCodeNV()
        {
            DataSet ds = bus.GetAllEmployee();
            BindingSource bs = new BindingSource();
            bs.DataSource = ds.Tables["Employee"];
            cboMaNV.ValueMember = "Id";
            cboMaNV.DisplayMember = "Id";
            cboMaNV.DataSource = bs;
            txtTenNV.DataBindings.Clear();
            txtTenNV.DataBindings.Add("Text", cboMaNV.DataSource, "Name");
        }

        private void LoadComboCodeKH()
        {
            DataSet ds = bus.GetAllCustomer();
            BindingSource bs = new BindingSource();
            bs.DataSource = ds.Tables["Customer"];
            cboMaKH.ValueMember = "Id";
            cboMaKH.DisplayMember = "Id";
            cboMaKH.DataSource = bs;
            txtTenKH.DataBindings.Clear();
            txtTenKH.DataBindings.Add("Text", cboMaKH.DataSource, "Name");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", cboMaKH.DataSource, "Address");
            txtSoDT.DataBindings.Clear();
            txtSoDT.DataBindings.Add("Text", cboMaKH.DataSource, "Phone");
        }

        private void LoadComboCodeSP()
        {
            DataSet ds = bus.GetAllProduct();
            BindingSource bs = new BindingSource();
            bs.DataSource = ds.Tables["Product"];
            cboMaSP.ValueMember = "Id";
            cboMaSP.DisplayMember = "Id";
            cboMaSP.DataSource = bs;
            txtTenHang.DataBindings.Clear();
            txtTenHang.DataBindings.Add("Text", cboMaSP.DataSource, "Name");
            txtGia.DataBindings.Clear();
            txtGia.DataBindings.Add("Text", cboMaSP.DataSource, "Price");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmBill_Load(sender, e);
        }

        private void txtMaHD_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaHD.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtMaHD, "Vui lòng nhập mã hoá đơn !");
            }
            else if (!txtMaHD.Text.StartsWith("HD"))
            {
                e.Cancel = true;
                errorProvider.SetError(txtMaHD, "Mã hoá đơn phải bắt đầu bằng HD !");
            }
            else if (txtMaHD.Text.Trim().Length < 4 || txtMaHD.Text.Trim().Length > 64)
            {
                e.Cancel = true;
                errorProvider.SetError(txtMaHD, "Độ dài tối thiểu của mã hoá đơn là 4 và tối đa là 64 ký tự");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtMaHD, null);
            }
        }

        private void txtSoLuong_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtSoLuong.Value.ToString()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtSoLuong, "Vui lòng nhập số lượng !");
            }
            else if (txtSoLuong.Value <= 0)
            {
                e.Cancel = true;
                errorProvider.SetError(txtSoLuong, "Số lượng phải tối thiểu lớn hơn 1");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtSoLuong, null);
            }

        }

        private decimal CaculatePrice()
        {
            int quantity = int.Parse(txtSoLuong.Value.ToString());
            decimal price = decimal.Parse(txtGia.Text.Trim());
            float sale = 0;
            if (txtGiamGia.Text.Trim() != "")
            {
                sale = (100 - float.Parse(txtGiamGia.Text.Trim())) / 100;
            }
            else
            {
                sale = 0;
            }
            decimal total = 0;
            if (sale != 0)
            {
                total = price * quantity * (decimal)sale;
            }
            else if (sale == 0)
            {
                total = price * quantity;
            }
            return total;
        }

        private void ShowTotalPriceBill()
        {
            decimal total = CaculatePrice();
            txtThanhTien.Text = total.ToString() + " VNĐ";
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (flag)
            {
                ShowTotalPriceBill();
            }
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            if (flag)
            {
                ShowTotalPriceBill();
            }
        }

        private void RefreshData()
        {
            txtSoLuong.Value = 1;
            txtMaHD.Clear();
            txtGiamGia.Clear();
            txtThanhTien.Clear();
            txtTongTien.Clear();
            lbTongTien.Text = "";
            txtMaHD.Enabled = true;
            cboMaNV.Enabled = true;
            cboMaKH.Enabled = true;
            dtpNgayBan.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Rule == "Admin")
            {
                txtMaHD.Enabled = true;
                btnRefresh.Enabled = true;
                btnSave.Enabled = true;
                btnCheckOut.Enabled = true;
                btnAdd.Enabled = false;
                RefreshData();
            }
            else
            {
                MessageBox.Show("Chỉ có quyền quản trị viên mới được phép thực hiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Rule == "Admin")
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    string codeHD = txtMaHD.Text.Trim();
                    string codeSP = cboMaSP.SelectedValue.ToString();
                    int quantity = int.Parse(txtSoLuong.Value.ToString());
                    decimal price = decimal.Parse(txtGia.Text.Trim());
                    float sale = 0;
                    if (txtGiamGia.Text.Trim() != "")
                    {
                        sale = (100 - float.Parse(txtGiamGia.Text.Trim())) / 100;
                    }
                    else
                    {
                        sale = 0;
                    }
                    decimal total = 0;
                    if (sale != 0)
                    {
                        total = price * quantity * (decimal)sale;
                    }
                    else if (sale == 0)
                    {
                        total = price * quantity;
                    }

                    if (bus.GetBillDetail(codeHD) != null)
                    {
                        MessageBox.Show("Mã hoá đơn này đã tồn tại. Vui lòng nhập mã hoá đơn khác !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        DetailBill detailBill = new DetailBill();
                        detailBill.Id = codeHD;
                        detailBill.CodeMH = codeSP;
                        detailBill.Quantity = quantity;
                        detailBill.Price = price;
                        if (txtGiamGia.Text.Trim() != "" && txtGiamGia.Text.Trim() != null)
                        {
                            detailBill.Sale = float.Parse(txtGiamGia.Text.Trim());
                        }
                        else
                        {
                            detailBill.Sale = 0;
                        }
                        detailBill.Total = total;

                        try
                        {
                            if (detailBill != null)
                            {
                                cart.Add(detailBill);
                                decimal totalBill = 0;
                                foreach (DetailBill item in cart)
                                {
                                    totalBill += item.Total;
                                }
                                txtTongTien.Text = totalBill.ToString() + " VNĐ";
                                lbTongTien.Text = library.ConvertNumberToString((double)totalBill) + " việt nam đồng";
                                MessageBox.Show("Thêm sản phẩm vào giỏ hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtMaHD.Enabled = false;
                                cboMaNV.Enabled = false;
                                cboMaKH.Enabled = false;
                                dtpNgayBan.Enabled = false;
                                flag = false;
                                cboMaSP.SelectedIndex = -1;
                                txtTenHang.Clear();
                                txtGia.Clear();
                                txtSoLuong.Value = 1;
                                txtGiamGia.Clear();
                                txtThanhTien.Clear();
                                cboMaSP.Focus();
                                flag = true;
                            }
                            else
                            {
                                MessageBox.Show("Thêm sản phẩm vào giỏ hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Chỉ có quyền quản trị viên mới được phép thực hiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (Rule == "Admin")
            {
                if (cart.Count > 0)
                {
                    if (ValidateChildren(ValidationConstraints.Enabled))
                    {
                        string codeHD = txtMaHD.Text.Trim();
                        DateTime sellDay = dtpNgayBan.Value;
                        string codeNV = cboMaNV.SelectedValue.ToString();
                        string codeKH = cboMaKH.SelectedValue.ToString();

                        if (bus.GetBillDetail(codeHD) != null)
                        {
                            MessageBox.Show("Mã hoá đơn này đã tồn tại. Vui lòng nhập mã hoá đơn khác !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            Bill bill = new Bill();
                            bill.CodeHD = codeHD;
                            bill.CodeNV = codeNV;
                            bill.SellDay = sellDay;
                            bill.CodeKH = codeKH;
                            decimal total = 0;
                            foreach (DetailBill item in cart)
                            {
                                total += item.Total;
                            }
                            bill.Total = total;

                            try
                            {
                                if (bill != null)
                                {
                                    bool result = bus.InsertBill(bill);
                                    try
                                    {
                                        if (result)
                                        {
                                            foreach (DetailBill item in cart)
                                            {
                                                DetailBill detailBill = new DetailBill()
                                                {
                                                    Id = item.Id,
                                                    CodeMH = item.CodeMH,
                                                    Quantity = item.Quantity,
                                                    Price = item.Price,
                                                    Sale = item.Sale,
                                                    Total = item.Total
                                                };
                                                bool answer = bus.InsertDetailBill(detailBill);
                                                if (answer)
                                                {
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Thêm hoá đơn thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                }
                                            }
                                            MessageBox.Show("Thêm hoá đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            RefreshData();
                                            cart.Clear();
                                            frmBill_Load(sender, e);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Giỏ hàng trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Chỉ có quyền quản trị viên mới được phép thực hiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
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
            colorDialog1.Color = panel2.BackColor;
            colorDialog1.AllowFullOpen = true;
            colorDialog1.FullOpen = true;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                panel2.BackColor = colorDialog1.Color;
            }
        }

        private void ToolStripFont_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = panel2.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                panel2.Font = fontDialog1.Font;
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
