using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaSach.BUS;
using QuanLyNhaSach.Data;

namespace QuanLyNhaSach
{
    public partial class frmCategory : Form
    {
        Library library = new Library();

        CategoryBUS bus = new CategoryBUS();

        public string Rule = "";

        List<Category> listCategory = null;

        private int Skip = 0;
        private int Take = 5;

        public frmCategory()
        {
            InitializeComponent();
        }

        public frmCategory(string rule)
        {
            InitializeComponent();
            this.Rule = rule;
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            ShowList();
        }

        private void ShowList()
        {
            string keyword = txtName.Text.Trim();

            //DataSet ds = bus.GetAll(keyword);
            //BindingSource bs = new BindingSource();
            //bs.DataSource = ds.Tables["Category"];
            //dgvCategory.DataSource = bs;

            listCategory = bus.GetCategoriesSearch(keyword);
            List<Category> newlistCategory = listCategory.Skip(Skip).Take(Take).ToList();
            dgvCategory.DataSource = newlistCategory;
            lbCount.Text = (Skip + 5) + "/" + listCategory.Count;
            FormatDisplay();
        }

        private void FormatDisplay()
        {
            // Định dạng tên cột hiển thị
            dgvCategory.Columns["Id"].HeaderText = "Mã";
            dgvCategory.Columns["Name"].HeaderText = "Danh mục";

            // Định dạng độ rộng cột
            dgvCategory.Columns["Id"].Width = 100;
            dgvCategory.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Định dạng căn chỉnh cột
            dgvCategory.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCategory.Columns["Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            // Không cho phép người dùng thêm, sửa trực tiếp trên datagridView
            dgvCategory.AllowUserToAddRows = false;
            dgvCategory.EditMode = DataGridViewEditMode.EditProgrammatically;

            txtMaDM.Enabled = false;
            btnSaveDM.Enabled = false;
            btnRefreshDM.Enabled = false;
            btnAddDM.Enabled = true;
            btnUpdateDM.Enabled = false;
            btnDeleteDM.Enabled = false;
        }

        private void dgvCategory_Click(object sender, EventArgs e)
        {
            if(dgvCategory.SelectedRows.Count > 0)
            {
                if (btnAddDM.Enabled == false)
                {
                    MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    return;
                }
                if (dgvCategory.Rows.Count == 0)
                {
                    MessageBox.Show("Dữ liệu trống. Vui lòng thêm dữ liệu !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    txtTenDM.Focus();
                    return;
                }
                txtMaDM.Text = dgvCategory.CurrentRow.Cells["Id"].Value.ToString();
                txtTenDM.Text = dgvCategory.CurrentRow.Cells["Name"].Value.ToString();
                btnUpdateDM.Enabled = true;
                btnDeleteDM.Enabled = true;
                btnRefreshDM.Enabled = true;
            }
        }

        private void RefreshData()
        {
            txtMaDM.Clear();
            txtTenDM.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmCategory_Load(sender, e);
        }
       
        private void btnCloseDM_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng form không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnRefreshDM_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnAddDM_Click(object sender, EventArgs e)
        {
            if(Rule == "Admin")
            {
                btnUpdateDM.Enabled = false;
                btnDeleteDM.Enabled = false;
                btnAddDM.Enabled = false;
                btnRefreshDM.Enabled = true;
                btnSaveDM.Enabled = true;
                RefreshData();
            }
            else
            {
                MessageBox.Show("Chỉ có quyền quản trị viên mới được phép thực hiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSaveDM_Click(object sender, EventArgs e)
        {
            if(Rule == "Admin")
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    string name = txtTenDM.Text.Trim();

                    if (bus.GetCategoryDetail(name) != null)
                    {
                        MessageBox.Show("Danh mục sản phẩm này đã tồn tại. Vui lòng nhập danh mục nhập sản phẩm khác !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Category category = new Category();
                        category.Id = 0;
                        category.Name = name;

                        try
                        {
                            bool result = bus.InsertCategory(category);
                            if (result)
                            {
                                MessageBox.Show("Thêm danh mục sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                RefreshData();
                                frmCategory_Load(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("Thêm danh mục sản phẩm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnUpdateDM_Click(object sender, EventArgs e)
        {
            if(Rule == "Admin")
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    string name = txtTenDM.Text.Trim();

                    if(bus.GetCategoryDetail(name) != null)
                    {
                        MessageBox.Show("Danh mục sản phẩm này đã tồn tại. Vui lòng nhập danh mục nhập sản phẩm khác !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        int id = int.Parse(dgvCategory.CurrentRow.Cells["Id"].Value.ToString());

                        Category category = bus.GetCategoryDetail(id);

                        if (category != null)
                        {
                            category.Name = name;

                            try
                            {
                                DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn cập nhật danh mục sản phẩm " + category.Name + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (confirm == DialogResult.Yes)
                                {
                                    bool result = bus.UpdateCategory(category, id);
                                    if (result)
                                    {
                                        MessageBox.Show("Cập nhật danh mục sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        RefreshData();
                                        frmCategory_Load(sender, e);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Cập nhật danh mục sản phẩm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            }
            else
            {
                MessageBox.Show("Chỉ có quyền quản trị viên mới được phép thực hiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteDM_Click(object sender, EventArgs e)
        {
            if(Rule == "Admin")
            {
                try
                {
                    int id = int.Parse(dgvCategory.CurrentRow.Cells["Id"].Value.ToString());
                    DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xoá danh mục sản phẩm này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirm == DialogResult.Yes)
                    {
                        bool result = bus.DeleteCategory(id);
                        if (result)
                        {
                            MessageBox.Show("Xoá danh mục sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshData();
                            frmCategory_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Xoá danh mục sản phẩm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            TextWriter writer = new StreamWriter(library.pathFiletxt + "Category.txt");
            for (int i = 0; i < dgvCategory.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dgvCategory.Columns.Count; j++)
                {
                    if (j == dgvCategory.Columns.Count - 1)
                    {
                        writer.Write(dgvCategory.Rows[i].Cells[j].Value.ToString());
                    }
                    else
                    {
                        writer.Write(dgvCategory.Rows[i].Cells[j].Value.ToString() + ",");
                    }
                }
                writer.WriteLine("");
            }
            writer.Close();
            MessageBox.Show("Xuất dữ liệu ra file txt thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtMaDM_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTenDM_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTenDM_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtTenDM.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtTenDM, "Vui lòng nhập tên danh mục !");
            }
            else if (txtTenDM.Text.Trim().Length < 2 || txtTenDM.Text.Trim().Length > 64)
            {
                e.Cancel = true;
                errorProvider.SetError(txtTenDM, "Độ dài tối thiểu của tên danh mục là 2 và tối đa là 64 ký tự");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtTenDM, null);
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
            frmCategory_Load(sender, e);
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
            frmCategory_Load(sender, e);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Skip += Take;
            if (Skip + 5 >= listCategory.Count)
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
            frmCategory_Load(sender, e);
        }

        private void btnGoToLast_Click(object sender, EventArgs e)
        {
            Skip = listCategory.Count - Take;
            if (Skip + 5 >= listCategory.Count)
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
            frmCategory_Load(sender, e);
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
