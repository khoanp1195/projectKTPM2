using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaSach.BUS;
using QuanLyNhaSach.Data;

namespace QuanLyNhaSach
{
    public partial class frmCustomer : Form
    {
        Library library = new Library();

        CustomerBUS bus = new CustomerBUS();

        public string Rule = "";

        List<Customer> listCustomer = null;

        private int Skip = 0;
        private int Take = 5;

        public frmCustomer()
        {
            InitializeComponent();
        }

        public frmCustomer(string rule)
        {
            InitializeComponent();
            this.Rule = rule;
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            ShowList();
        }

        private void ShowList()
        {
            string keyword = txtName.Text.Trim();
            
            //DataSet ds = bus.GetAll(keyword);
            //BindingSource bs = new BindingSource();
            //bs.DataSource = ds.Tables["Customer"];
            //dgvCustomer.DataSource = bs;

            listCustomer = bus.GetCustomersSearch(keyword);
            List<Customer> newlistCustomer = listCustomer.Skip(Skip).Take(Take).ToList();
            dgvCustomer.DataSource = newlistCustomer;
            lbCount.Text = (Skip + 5) + "/" + listCustomer.Count;
            FormatDisplay();
        }

        private void FormatDisplay()
        {
            // Định dạng tên cột hiển thị
            dgvCustomer.Columns["Id"].HeaderText = "Mã";
            dgvCustomer.Columns["Name"].HeaderText = "Họ và tên";
            dgvCustomer.Columns["Gender"].HeaderText = "Giới tính";
            dgvCustomer.Columns["Age"].HeaderText = "Tuổi";
            dgvCustomer.Columns["Dob"].HeaderText = "Ngày sinh";
            dgvCustomer.Columns["Address"].HeaderText = "Địa chỉ";
            dgvCustomer.Columns["Phone"].HeaderText = "SĐT";

            // Định dạng độ rộng cột
            dgvCustomer.Columns["Id"].Width = 80;
            dgvCustomer.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCustomer.Columns["Gender"].Width = 100;
            dgvCustomer.Columns["Age"].Width = 60;
            dgvCustomer.Columns["Dob"].Width = 100;
            dgvCustomer.Columns["Address"].Width = 180;
            dgvCustomer.Columns["Phone"].Width = 100;

            // Định dạng căn chỉnh cột
            dgvCustomer.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCustomer.Columns["Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCustomer.Columns["Gender"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCustomer.Columns["Age"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCustomer.Columns["Dob"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCustomer.Columns["Address"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCustomer.Columns["Phone"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            
            // Không cho phép người dùng thêm, sửa trực tiếp trên datagridView
            dgvCustomer.AllowUserToAddRows = false;
            dgvCustomer.EditMode = DataGridViewEditMode.EditProgrammatically;

            txtMaKH.Enabled = false;
            txtTuoiKH.Enabled = false;
            btnSaveKH.Enabled = false;
            btnRefreshKH.Enabled = false;
            btnAddKH.Enabled = true;
            btnUpdateKH.Enabled = false;
            btnDeleteKH.Enabled = false;
        }

        private void dgvCustomer_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvCustomer.Columns[e.ColumnIndex].Name == "Gender")
            {
                if (e.Value != null)
                {
                    int gender = int.Parse(e.Value.ToString());
                    if (gender == 1)
                    {
                        e.Value = "Nam";
                    }
                    else
                    {
                        e.Value = "Nữ";
                    }
                    e.FormattingApplied = true;
                }
            }
            else if (dgvCustomer.Columns[e.ColumnIndex].Name == "Phone")
            {
                    e.Value = "0" + e.Value.ToString();
                    e.FormattingApplied = true;
            }
        }
        
        private void dgvCustomer_Click(object sender, EventArgs e)
        {
            if(dgvCustomer.SelectedRows.Count > 0)
            {
                if (btnAddKH.Enabled == false)
                {
                    MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    return;
                }
                if (dgvCustomer.Rows.Count == 0)
                {
                    MessageBox.Show("Dữ liệu trống. Vui lòng thêm dữ liệu !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    return;
                }
                txtMaKH.Text = dgvCustomer.CurrentRow.Cells["Id"].Value.ToString();
                txtHoTenKH.Text = dgvCustomer.CurrentRow.Cells["Name"].Value.ToString();
                txtTuoiKH.Text = dgvCustomer.CurrentRow.Cells["Age"].Value.ToString();
                txtDiaChiKH.Text = dgvCustomer.CurrentRow.Cells["Address"].Value.ToString();
                if (int.Parse(dgvCustomer.CurrentRow.Cells["Gender"].Value.ToString()) == 0) 
                {
                    cboGenderKH.Text = "Nữ";
                }
                else
                {
                    cboGenderKH.Text = "Nam";
                }
                dtpDobKH.Value = (DateTime)dgvCustomer.CurrentRow.Cells["Dob"].Value;
                mtbSdtKH.Text = "0" + dgvCustomer.CurrentRow.Cells["Phone"].Value.ToString();
                btnUpdateKH.Enabled = true;
                btnDeleteKH.Enabled = true;
                btnRefreshKH.Enabled = true;
            }
        }

        private void RefreshData()
        {
            txtMaKH.Clear();
            txtHoTenKH.Clear();
            txtTuoiKH.Clear();
            txtDiaChiKH.Clear();
            cboGenderKH.SelectedIndex = 0;
            dtpDobKH.Value = DateTime.Now;
            mtbSdtKH.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmCustomer_Load(sender, e);
        }

        private void btnCloseKH_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng form không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnRefreshKH_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnAddKH_Click(object sender, EventArgs e)
        {
            if(Rule == "Admin")
            {
                btnUpdateKH.Enabled = false;
                btnDeleteKH.Enabled = false;
                btnAddKH.Enabled = false;
                btnRefreshKH.Enabled = true;
                btnSaveKH.Enabled = true;
                txtMaKH.Enabled = true;
                RefreshData();
            }
            else
            {
                MessageBox.Show("Chỉ có quyền quản trị viên mới được phép thực hiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private int GetAge(DateTime dt)
        {
            int age = DateTime.Now.Year - dt.Year;
            return age;
        }

        private void btnSaveKH_Click(object sender, EventArgs e)
        {
            if(Rule == "Admin")
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    string id = txtMaKH.Text.Trim();
                    string name = txtHoTenKH.Text.Trim();
                    string address = txtDiaChiKH.Text.Trim();
                    int gender = 0;
                    if (cboGenderKH.Text.Trim() == "Nữ" || cboGenderKH.SelectedIndex == 0)
                    {
                        gender = 0;
                    }
                    else
                    {
                        gender = 1;
                    };
                    DateTime dob = dtpDobKH.Value;
                    int phone = int.Parse(mtbSdtKH.Text.Trim());
                    int age = GetAge(dob);

                    if (bus.GetCustomerDetail(id) != null)
                    {
                        MessageBox.Show("Mã KH này đã tồn tại. Vui lòng nhập mã khách hàng khác !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Customer customer = new Customer();
                        customer.Id = id;
                        customer.Name = name;
                        customer.Age = age;
                        customer.Dob = dob;
                        customer.Gender = gender;
                        customer.Address = address;
                        customer.Phone = phone;

                        try
                        {
                            bool result = bus.InsertCustomer(customer);
                            if (result)
                            {
                                MessageBox.Show("Thêm khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                RefreshData();
                                frmCustomer_Load(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("Thêm khách hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnUpdateKH_Click(object sender, EventArgs e)
        {
           if(Rule == "Admin")
           {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    string name = txtHoTenKH.Text.Trim();
                    string address = txtDiaChiKH.Text.Trim();
                    int gender = 0;
                    if (cboGenderKH.Text.Trim() == "Nữ" || cboGenderKH.SelectedIndex == 0)
                    {
                        gender = 0;
                    }
                    else
                    {
                        gender = 1;
                    };
                    DateTime dob = dtpDobKH.Value;
                    int phone = int.Parse(mtbSdtKH.Text.Trim());
                    int age = GetAge(dob);

                    string id = dgvCustomer.CurrentRow.Cells["Id"].Value.ToString();

                    Customer customer = bus.GetCustomerDetail(id);

                    if (customer != null)
                    {
                        customer.Name = name;
                        customer.Age = age;
                        customer.Gender = gender;
                        customer.Address = address;
                        customer.Dob = dob;
                        customer.Phone = phone;

                        try
                        {
                            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn cập nhật khách hàng " + customer.Name + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (confirm == DialogResult.Yes)
                            {
                                bool result = bus.UpdateCustomer(customer, id);
                                if (result)
                                {
                                    MessageBox.Show("Cập nhật khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    RefreshData();
                                    frmCustomer_Load(sender, e);
                                }
                                else
                                {
                                    MessageBox.Show("Cập nhật khách hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Chỉ có quyền quản trị viên mới được phép thực hiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteKH_Click(object sender, EventArgs e)
        {
            if(Rule == "Admin")
            {
                try
                {
                    string id = dgvCustomer.CurrentRow.Cells["Id"].Value.ToString();
                    DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xoá khách hàng này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirm == DialogResult.Yes)
                    {
                        bool result = bus.DeleteCustomer(id);
                        if (result)
                        {
                            MessageBox.Show("Xoá khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshData();
                            frmCustomer_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Xoá khách hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            TextWriter writer = new StreamWriter(library.pathFiletxt + "Customer.txt");
            for (int i = 0; i < dgvCustomer.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dgvCustomer.Columns.Count; j++)
                {
                    if (j == dgvCustomer.Columns.Count - 1)
                    {
                        writer.Write(dgvCustomer.Rows[i].Cells[j].Value.ToString());
                    }
                    else
                    {
                        writer.Write(dgvCustomer.Rows[i].Cells[j].Value.ToString() + ",");
                    }
                }
                writer.WriteLine("");
            }
            writer.Close();
            MessageBox.Show("Xuất dữ liệu ra file txt thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtMaKH_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtHoTenKH_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTuoiKH_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDiaChiKH_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboGenderKH_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dtpDobKH_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void mtbSdtKH_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtMaKH_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaKH.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtMaKH, "Vui lòng nhập mã khách hàng !");
            }
            else if (!txtMaKH.Text.StartsWith("KH"))
            {
                e.Cancel = true;
                errorProvider.SetError(txtMaKH, "Mã khách hàng phải bắt đầu bằng KH !");
            }
            else if (txtMaKH.Text.Trim().Length < 4 || txtMaKH.Text.Trim().Length > 64)
            {
                e.Cancel = true;
                errorProvider.SetError(txtMaKH, "Độ dài tối thiểu của mã khách hàng là 4 và tối đa là 64 ký tự");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtMaKH, null);
            }
        }

        private void txtHoTenKH_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtHoTenKH.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtHoTenKH, "Vui lòng nhập họ và tên khách hàng !");
            }
            else if (txtHoTenKH.Text.Trim().Length < 6 || txtHoTenKH.Text.Trim().Length > 255)
            {
                e.Cancel = true;
                errorProvider.SetError(txtHoTenKH, "Độ dài tối thiểu của họ và tên khách hàng là 6 và tối đa là 255 ký tự");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtHoTenKH, null);
            }
        }

        private void txtDiaChiKH_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtDiaChiKH.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtDiaChiKH, "Vui lòng nhập địa chỉ khách hàng !");
            }
            else if (txtDiaChiKH.Text.Trim().Length < 6 || txtDiaChiKH.Text.Trim().Length > 255)
            {
                e.Cancel = true;
                errorProvider.SetError(txtDiaChiKH, "Độ dài tối thiểu của địa chỉ khách hàng là 6 và tối đa là 255 ký tự");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtDiaChiKH, null);
            }
        }

        private void cboGenderKH_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(cboGenderKH.Text.Trim()) || cboGenderKH.SelectedIndex == -1)
            {
                e.Cancel = true;
                errorProvider.SetError(cboGenderKH, "Vui lòng chọn giới tính phù hợp !");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(cboGenderKH, null);
            }
        }

        private void dtpDobKH_Validating(object sender, CancelEventArgs e)
        {
            if (dtpDobKH.Value.Date > DateTime.Now.Date)
            {
                e.Cancel = true;
                errorProvider.SetError(dtpDobKH, "Ngày sinh phải nhỏ hơn hoặc bằng ngày hiện tại !");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(dtpDobKH, null);
            }
        }

        private void mtbSdtKH_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(mtbSdtKH.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(mtbSdtKH, "Vui lòng nhập số điện thoại khách hàng !");
            }
            else if (Regex.IsMatch(mtbSdtKH.Text.Trim(), "^[a-zA-Z]"))
            {
                e.Cancel = true;
                errorProvider.SetError(mtbSdtKH, "Vui lòng chỉ nhập số. Không nhập chữ");
            }
            else if (mtbSdtKH.Text.Trim().Length != 10)
            {
                e.Cancel = true;
                errorProvider.SetError(mtbSdtKH, "Số điện thoại phải gồm 10 số");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(mtbSdtKH, null);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowList();
            txtName.Clear();
        }

        private void btnGoFirst_Click(object sender, EventArgs e)
        {
            Skip = 0;
            if (Skip <= 0)
            {
                btnGoFirst.Enabled = false;
                btnPrevious.Enabled = false;
                btnNext.Enabled = true;
                btnGoToLast.Enabled = true;
            }
            else
            {
                btnGoFirst.Enabled = true;
                btnPrevious.Enabled = true;
            }
            frmCustomer_Load(sender, e);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            Skip -= Take;
            if (Skip <= 0)
            {
                btnGoFirst.Enabled = false;
                btnPrevious.Enabled = false;
                btnNext.Enabled = true;
                btnGoToLast.Enabled = true;
            }
            else
            {
                btnGoFirst.Enabled = true;
                btnPrevious.Enabled = true;
            }
            frmCustomer_Load(sender, e);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Skip += Take;
            if (Skip + 5 >= listCustomer.Count)
            {
                btnGoToLast.Enabled = false;
                btnNext.Enabled = false;
                btnPrevious.Enabled = true;
                btnGoFirst.Enabled = true;
            }
            else
            {
                btnGoToLast.Enabled = true;
                btnNext.Enabled = true;
            }
            frmCustomer_Load(sender, e);
        }

        private void btnGoToLast_Click(object sender, EventArgs e)
        {
            Skip = listCustomer.Count - Take;
            if (Skip + 5 >= listCustomer.Count)
            {
                btnGoToLast.Enabled = false;
                btnNext.Enabled = false;
                btnPrevious.Enabled = true;
                btnGoFirst.Enabled = true;
            }
            else
            {
                btnGoToLast.Enabled = true;
                btnNext.Enabled = true;
            }
            frmCustomer_Load(sender, e);
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
                this.Close();
            }
        }
    }
}
