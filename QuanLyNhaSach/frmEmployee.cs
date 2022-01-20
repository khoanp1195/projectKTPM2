using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class frmEmployee : Form
    {
        Library library = new Library();

        EmployeeBUS bus = new EmployeeBUS();

        public string Rule = "";

        List<Employee> listEmployee = null;

        private int Skip = 0;
        private int Take = 5;

        public frmEmployee()
        {
            InitializeComponent();
        }

        public frmEmployee(string rule)
        {
            InitializeComponent();
            this.Rule = rule;
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            ShowList();
        }

        private void ShowList()
        {
            string keyword = txtName.Text.Trim();

            //DataSet ds = bus.GetAll(keyword);
            //BindingSource bs = new BindingSource();
            //bs.DataSource = ds.Tables["Employee"];
            //dgvEmployee.DataSource = bs;

            listEmployee = bus.GetEmployeesSearch(keyword);
            List<Employee> newlistEmployee = listEmployee.Skip(Skip).Take(Take).ToList();
            dgvEmployee.DataSource = newlistEmployee;
            lbCount.Text = (Skip + 5) + "/" + listEmployee.Count;
            FormatDisplay();
        }

        private void FormatDisplay()
        {
            // Định dạng tên cột hiển thị
            dgvEmployee.Columns["Id"].HeaderText = "Mã";
            dgvEmployee.Columns["Name"].HeaderText = "Họ và tên";
            dgvEmployee.Columns["Gender"].HeaderText = "Giới tính";
            dgvEmployee.Columns["Age"].HeaderText = "Tuổi";
            dgvEmployee.Columns["Dob"].HeaderText = "Ngày sinh";
            dgvEmployee.Columns["Address"].HeaderText = "Địa chỉ";
            dgvEmployee.Columns["Phone"].HeaderText = "SĐT";

            // Định dạng độ rộng cột
            dgvEmployee.Columns["Id"].Width = 80;
            dgvEmployee.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEmployee.Columns["Gender"].Width = 100;
            dgvEmployee.Columns["Age"].Width = 60;
            dgvEmployee.Columns["Dob"].Width = 100;
            dgvEmployee.Columns["Address"].Width = 180;
            dgvEmployee.Columns["Phone"].Width = 100;

            // Định dạng căn chỉnh cột
            dgvEmployee.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvEmployee.Columns["Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvEmployee.Columns["Gender"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvEmployee.Columns["Age"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvEmployee.Columns["Dob"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvEmployee.Columns["Address"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvEmployee.Columns["Phone"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Không cho phép người dùng thêm, sửa trực tiếp trên datagridView
            dgvEmployee.AllowUserToAddRows = false;
            dgvEmployee.EditMode = DataGridViewEditMode.EditProgrammatically;

            txtMaNV.Enabled = false;
            txtTuoiNV.Enabled = false;
            btnSaveNV.Enabled = false;
            btnRefreshNV.Enabled = false;
            btnAddNV.Enabled = true;
            btnUpdateNV.Enabled = false;
            btnDeleteNV.Enabled = false;
        }

        private void dgvEmployee_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvEmployee.Columns[e.ColumnIndex].Name == "Gender")
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
            else if (dgvEmployee.Columns[e.ColumnIndex].Name == "Phone")
            {
                e.Value = "0" + e.Value.ToString();
                e.FormattingApplied = true;
            }
        }

        private void dgvEmployee_Click(object sender, EventArgs e)
        {
            if(dgvEmployee.SelectedRows.Count > 0)
            {
                if (btnAddNV.Enabled == false)
                {
                    MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    return;
                }
                if (dgvEmployee.Rows.Count == 0)
                {
                    MessageBox.Show("Dữ liệu trống. Vui lòng thêm dữ liệu !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    return;
                }
                txtMaNV.Text = dgvEmployee.CurrentRow.Cells["Id"].Value.ToString();
                txtHoTenNV.Text = dgvEmployee.CurrentRow.Cells["Name"].Value.ToString();
                txtTuoiNV.Text = dgvEmployee.CurrentRow.Cells["Age"].Value.ToString();
                txtDiaChiNV.Text = dgvEmployee.CurrentRow.Cells["Address"].Value.ToString();
                if (int.Parse(dgvEmployee.CurrentRow.Cells["Gender"].Value.ToString()) == 0)
                {
                    cboGenderNV.Text = "Nữ";
                }
                else
                {
                    cboGenderNV.Text = "Nam";
                }
                dtpDobNV.Value = (DateTime)dgvEmployee.CurrentRow.Cells["Dob"].Value;
                mtbSdtNV.Text = "0" + dgvEmployee.CurrentRow.Cells["Phone"].Value.ToString();
                btnUpdateNV.Enabled = true;
                btnDeleteNV.Enabled = true;
                btnRefreshNV.Enabled = true;
            }
        }

        private void RefreshData()
        {
            txtMaNV.Clear();
            txtHoTenNV.Clear();
            txtTuoiNV.Clear();
            txtDiaChiNV.Clear();
            cboGenderNV.SelectedIndex = 0;
            dtpDobNV.Value = DateTime.Now;
            mtbSdtNV.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmEmployee_Load(sender, e);
        }

        private void btnCloseNV_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng form không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnRefreshNV_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnAddNV_Click(object sender, EventArgs e)
        {
            if(Rule  == "Admin")
            {
                btnUpdateNV.Enabled = false;
                btnDeleteNV.Enabled = false;
                btnAddNV.Enabled = false;
                btnRefreshNV.Enabled = true;
                btnSaveNV.Enabled = true;
                txtMaNV.Enabled = true;
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

        private void btnSaveNV_Click(object sender, EventArgs e)
        {
            if(Rule == "Admin")
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    string id = txtMaNV.Text.Trim();
                    string name = txtHoTenNV.Text.Trim();
                    string address = txtDiaChiNV.Text.Trim();
                    int gender = 0;
                    if (cboGenderNV.Text.Trim() == "Nữ" || cboGenderNV.SelectedIndex == 0)
                    {
                        gender = 0;
                    }
                    else
                    {
                        gender = 1;
                    };
                    DateTime dob = dtpDobNV.Value;
                    int phone = int.Parse(mtbSdtNV.Text.Trim());
                    int age = GetAge(dob);

                    if (bus.GetEmployeeDetail(id) != null)
                    {
                        MessageBox.Show("Mã NV này đã tồn tại. Vui lòng nhập mã nhân viên khác !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Employee employee = new Employee();
                        employee.Id = id;
                        employee.Name = name;
                        employee.Age = age;
                        employee.Dob = dob;
                        employee.Gender = gender;
                        employee.Address = address;
                        employee.Phone = phone;

                        try
                        {
                            bool result = bus.InsertEmployee(employee);
                            if (result)
                            {
                                MessageBox.Show("Thêm nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                RefreshData();
                                frmEmployee_Load(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("Thêm nhân viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnUpdateNV_Click(object sender, EventArgs e)
        {
            if(Rule == "Admin")
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    string name = txtHoTenNV.Text.Trim();
                    string address = txtDiaChiNV.Text.Trim();
                    int gender = 0;
                    if (cboGenderNV.Text.Trim() == "Nữ" || cboGenderNV.SelectedIndex == 0)
                    {
                        gender = 0;
                    }
                    else
                    {
                        gender = 1;
                    };
                    DateTime dob = dtpDobNV.Value;
                    int phone = int.Parse(mtbSdtNV.Text.Trim());
                    int age = GetAge(dob);

                    string id = dgvEmployee.CurrentRow.Cells["Id"].Value.ToString();

                    Employee employee = bus.GetEmployeeDetail(id);

                    if (employee != null)
                    {
                        employee.Name = name;
                        employee.Age = age;
                        employee.Gender = gender;
                        employee.Address = address;
                        employee.Dob = dob;
                        employee.Phone = phone;

                        try
                        {
                            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn cập nhật nhân viên " + employee.Name + " không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (confirm == DialogResult.Yes)
                            {
                                bool result = bus.UpdateEmployee(employee, id);
                                if (result)
                                {
                                    MessageBox.Show("Cập nhật nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    RefreshData();
                                    frmEmployee_Load(sender, e);
                                }
                                else
                                {
                                    MessageBox.Show("Cập nhật nhân viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnDeleteNV_Click(object sender, EventArgs e)
        {
           if(Rule == "Admin")
            {
                try
                {
                    string id = dgvEmployee.CurrentRow.Cells["Id"].Value.ToString();
                    DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xoá nhân viên này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirm == DialogResult.Yes)
                    {
                        bool result = bus.DeleteEmployee(id);
                        if (result)
                        {
                            MessageBox.Show("Xoá nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshData();
                            frmEmployee_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Xoá nhân viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            TextWriter writer = new StreamWriter(library.pathFiletxt + "Employee.txt");
            for (int i = 0; i < dgvEmployee.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dgvEmployee.Columns.Count; j++)
                {
                    if (j == dgvEmployee.Columns.Count - 1)
                    {
                        writer.Write(dgvEmployee.Rows[i].Cells[j].Value.ToString());
                    }
                    else
                    {
                        writer.Write(dgvEmployee.Rows[i].Cells[j].Value.ToString() + ",");
                    }
                }
                writer.WriteLine("");
            }
            writer.Close();
            MessageBox.Show("Xuất dữ liệu ra file txt thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtMaNV_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtHoTenNV_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTuoiNV_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDiaChiNV_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboGenderNV_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dtpDobNV_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void mtbSdtNV_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtMaNV_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaNV.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtMaNV, "Vui lòng nhập mã nhân viên !");
            }
            else if (!txtMaNV.Text.StartsWith("NV"))
            {
                e.Cancel = true;
                errorProvider.SetError(txtMaNV, "Mã nhân viên phải bắt đầu bằng NV !");
            }
            else if (txtMaNV.Text.Trim().Length < 4 || txtMaNV.Text.Trim().Length > 64)
            {
                e.Cancel = true;
                errorProvider.SetError(txtMaNV, "Độ dài tối thiểu của mã nhân viên là 4 và tối đa là 64 ký tự");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtMaNV, null);
            }
        }

        private void txtHoTenNV_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtHoTenNV.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtHoTenNV, "Vui lòng nhập họ và tên nhân viên !");
            }
            else if (txtHoTenNV.Text.Trim().Length < 6 || txtHoTenNV.Text.Trim().Length > 255)
            {
                e.Cancel = true;
                errorProvider.SetError(txtHoTenNV, "Độ dài tối thiểu của họ và tên nhân viên là 6 và tối đa là 255 ký tự");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtHoTenNV, null);
            }
        }

        private void txtDiaChiNV_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtDiaChiNV.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtDiaChiNV, "Vui lòng nhập địa chỉ nhân viên !");
            }
            else if (txtDiaChiNV.Text.Trim().Length < 6 || txtDiaChiNV.Text.Trim().Length > 255)
            {
                e.Cancel = true;
                errorProvider.SetError(txtDiaChiNV, "Độ dài tối thiểu của địa chỉ nhân viên là 6 và tối đa là 255 ký tự");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtDiaChiNV, null);
            }
        }

        private void cboGenderNV_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(cboGenderNV.Text.Trim()) || cboGenderNV.SelectedIndex == -1)
            {
                e.Cancel = true;
                errorProvider.SetError(cboGenderNV, "Vui lòng chọn giới tính phù hợp !");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(cboGenderNV, null);
            }
        }

        private void dtpDobNV_Validating(object sender, CancelEventArgs e)
        {
            if ((DateTime.Now.Year - dtpDobNV.Value.Year) < 18)
            {
                e.Cancel = true;
                errorProvider.SetError(dtpDobNV, "Nhân viên chưa đủ 18 tuổi");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(dtpDobNV, null);
            }
        }

        private void mtbSdtNV_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(mtbSdtNV.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(mtbSdtNV, "Vui lòng nhập số điện thoại nhân viên !");
            }
            else if (Regex.IsMatch(mtbSdtNV.Text.Trim(), "^[a-zA-Z]"))
            {
                e.Cancel = true;
                errorProvider.SetError(mtbSdtNV, "Vui lòng chỉ nhập số. Không nhập chữ");
            }
            else if (mtbSdtNV.Text.Trim().Length != 10)
            {
                e.Cancel = true;
                errorProvider.SetError(mtbSdtNV, "Số điện thoại phải gồm 10 số");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(mtbSdtNV, null);
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
            frmEmployee_Load(sender, e);
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
            frmEmployee_Load(sender, e);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Skip += Take;
            if (Skip + 5 >= listEmployee.Count)
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
            frmEmployee_Load(sender, e);
        }

        private void btnGoToLast_Click(object sender, EventArgs e)
        {
            Skip = listEmployee.Count - Take;
            if (Skip + 5 >= listEmployee.Count)
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
            frmEmployee_Load(sender, e);
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
