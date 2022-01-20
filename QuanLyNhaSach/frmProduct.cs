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
    public partial class frmProduct : Form
    {
        Library library = new Library();

        ProductBUS bus = new ProductBUS();

        List<Product> listProduct = null;

        private int Skip = 0;
        private int Take = 5;

        public string Rule = "";

        public frmProduct()
        {
            InitializeComponent();
        }

        public frmProduct(string rule)
        {
            InitializeComponent();
            this.Rule = rule;
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            ShowList();
            LoadComboBoxCategory();
            ShowTreeView();
        }

        private void ShowList()
        {
            string keyword = txtName.Text.Trim();
            listProduct = bus.GetAllProducts(keyword);
            List<Product> newlistProduct = listProduct.Skip(Skip).Take(Take).ToList();
            lvProduct.Items.Clear();
            newlistProduct.ForEach(x =>
            {
                ListViewItem lvi = new ListViewItem(x.Id);
                lvi.SubItems.Add(x.Name);
                lvi.SubItems.Add(x.Price.ToString());
                lvi.SubItems.Add(x.Description);
                lvi.SubItems.Add(x.Unit);
                lvi.SubItems.Add(x.Origin);
                lvi.SubItems.Add(x.CategoryId.ToString());
                lvProduct.Items.Add(lvi);
            });
            lbCount.Text = (Skip + 5) + "/" + listProduct.Count;
            txtMaSP.Enabled = false;
            btnSaveSP.Enabled = false;
            btnRefreshSP.Enabled = false;
            btnAddSP.Enabled = true;
            btnUpdateSP.Enabled = false;
            btnDeleteSP.Enabled = false;
        }

        private void ShowTreeView()
        {
            List<Category> categories = bus.GetAllCategorys();
            tvProduct.Nodes.Clear();
            foreach (Category category in categories)
            {
                TreeNode nodeDM = new TreeNode(category.Name);
                nodeDM.Tag = category.Id;
                tvProduct.Nodes.Add(nodeDM);

                List<Product> products = bus.GetAllProductsByCategoryId(category.Id);

                foreach (Product product in products)
                {
                    TreeNode nodeSP = new TreeNode(product.Name);
                    nodeSP.Tag = product.Id;
                    nodeDM.Nodes.Add(nodeSP);
                }
            }
        }

        private void LoadComboBoxCategory()
        {
            DataSet ds = bus.GetAllCategory();
            BindingSource bs = new BindingSource();
            bs.DataSource = ds.Tables["Category"];
            cboLoaiSP.ValueMember = "Id";
            cboLoaiSP.DisplayMember = "Name";
            cboLoaiSP.DataSource = bs;
        }

        private void lvProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvProduct.SelectedItems.Count > 0)
            {
                if (btnAddSP.Enabled == false)
                {
                    MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    return;
                }
                string codeSP = lvProduct.SelectedItems[0].SubItems[0].Text;
                int id = int.Parse(lvProduct.SelectedItems[0].SubItems[6].Text);
                Product product = bus.GetNameCategory(codeSP ,id);
                if (product != null)
                {
                    txtMaSP.Text = product.Id;
                    txtTenSP.Text = product.Name;
                    txtGiaSP.Text = product.Price.ToString();
                    txtMoTaSP.Text = product.Description;
                    txtDonViSP.Text = product.Unit;
                    txtXuatXuSP.Text = product.Origin;
                    cboLoaiSP.Text = product.CategoryName;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                btnUpdateSP.Enabled = true;
                btnDeleteSP.Enabled = true;
                btnRefreshSP.Enabled = true;
            }
        }

        private void RefreshData()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtGiaSP.Clear();
            txtMoTaSP.Clear();
            txtDonViSP.Clear();
            txtXuatXuSP.Clear();
            cboLoaiSP.SelectedIndex = 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmProduct_Load(sender, e);
        }

        private void btnCloseSP_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng form không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnRefreshSP_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnAddSP_Click(object sender, EventArgs e)
        {
            if(Rule == "Admin")
            {
                btnUpdateSP.Enabled = false;
                btnDeleteSP.Enabled = false;
                btnAddSP.Enabled = false;
                btnRefreshSP.Enabled = true;
                btnSaveSP.Enabled = true;
                txtMaSP.Enabled = true;
                RefreshData();
            }
            else
            {
                MessageBox.Show("Chỉ có quyền quản trị viên mới được phép thực hiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSaveSP_Click(object sender, EventArgs e)
        {
            if(Rule == "Admin")
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    string id = txtMaSP.Text.Trim();
                    string name = txtTenSP.Text.Trim();
                    double price = double.Parse(txtGiaSP.Text.Trim());
                    string description = txtMoTaSP.Text.Trim();
                    string unit = txtDonViSP.Text.Trim();
                    string origin = txtXuatXuSP.Text.Trim();
                    int categoryId = int.Parse(cboLoaiSP.SelectedValue.ToString());

                    if (bus.GetProductDetail(id) != null)
                    {
                        MessageBox.Show("Mã SP này đã tồn tại. Vui lòng nhập mã sản phẩm khác !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Product product = new Product();
                        product.Id = id;
                        product.Name = name;
                        product.Price = price;
                        product.Description = description;
                        product.Unit = unit;
                        product.Origin = origin;
                        product.CategoryId = categoryId;

                        try
                        {
                            bool result = bus.InsertProduct(product);
                            if (result)
                            {
                                MessageBox.Show("Thêm sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                RefreshData();
                                frmProduct_Load(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("Thêm sản phẩm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnUpdateSP_Click(object sender, EventArgs e)
        {
           if(Rule == "Admin")
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    string name = txtTenSP.Text.Trim();
                    double price = double.Parse(txtGiaSP.Text.Trim());
                    string description = txtMoTaSP.Text.Trim();
                    string unit = txtDonViSP.Text.Trim();
                    string origin = txtXuatXuSP.Text.Trim();
                    int categoryId = int.Parse(cboLoaiSP.SelectedValue.ToString());

                    string id = lvProduct.SelectedItems[0].SubItems[0].Text;

                    Product product = bus.GetProductDetail(id);

                    if (product != null)
                    {
                        product.Name = name;
                        product.Price = price;
                        product.Description = description;
                        product.Unit = unit;
                        product.Origin = origin;
                        product.CategoryId = categoryId;

                        try
                        {
                            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn cập nhật sản phẩm " + product.Name + " không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (confirm == DialogResult.Yes)
                            {
                                bool result = bus.UpdateProduct(product, id);
                                if (result)
                                {
                                    MessageBox.Show("Cập nhật sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    RefreshData();
                                    frmProduct_Load(sender, e);
                                }
                                else
                                {
                                    MessageBox.Show("Cập nhật sản phẩm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnDeleteSP_Click(object sender, EventArgs e)
        {
            if(Rule == "Admin")
            {
                try
                {
                    string id = lvProduct.SelectedItems[0].SubItems[0].Text;
                    DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xoá sản phẩm này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirm == DialogResult.Yes)
                    {
                        bool result = bus.DeleteProduct(id);
                        if (result)
                        {
                            MessageBox.Show("Xoá sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshData();
                            frmProduct_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Xoá sản phẩm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "(*.txt)|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;
                for (int i = 0; i < lvProduct.Items.Count; i++)
                {
                    File.AppendAllText(
                    path,
                    lvProduct.Items[i].SubItems[0].Text + "," + lvProduct.Items[i].SubItems[1].Text + "," +
                    lvProduct.Items[i].SubItems[2].Text + "," + lvProduct.Items[i].SubItems[3].Text + "," +
                    lvProduct.Items[i].SubItems[4].Text + "," + lvProduct.Items[i].SubItems[5].Text + "," +
                    lvProduct.Items[i].SubItems[6].Text +
                    Environment.NewLine
                    );
                }
                MessageBox.Show("Xuất dữ liệu ra file txt thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtMaSP_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaSP.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtMaSP, "Vui lòng nhập mã sản phẩm !");
            }
            else if (!txtMaSP.Text.StartsWith("SP"))
            {
                e.Cancel = true;
                errorProvider.SetError(txtMaSP, "Mã sản phẩm phải bắt đầu bằng SP !");
            }
            else if (txtMaSP.Text.Trim().Length < 4 || txtMaSP.Text.Trim().Length > 64)
            {
                e.Cancel = true;
                errorProvider.SetError(txtMaSP, "Độ dài tối thiểu của mã sản phẩm là 4 và tối đa là 64 ký tự");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtMaSP, null);
            }
        }

        private void txtTenSP_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtTenSP.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtTenSP, "Vui lòng nhập tên sản phẩm !");
            }
            else if (txtTenSP.Text.Trim().Length < 3 || txtTenSP.Text.Trim().Length > 255)
            {
                e.Cancel = true;
                errorProvider.SetError(txtTenSP, "Độ dài tối thiểu của tên sản phẩm là 3 và tối đa là 255 ký tự");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtTenSP, null);
            }
        }

        private void txtGiaSP_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtGiaSP.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtGiaSP, "Vui lòng nhập giá sản phẩm !");
            }
            else if (Regex.IsMatch(txtGiaSP.Text.Trim(), "^[a-zA-Z]"))
            {
                e.Cancel = true;
                errorProvider.SetError(txtGiaSP, "Vui lòng chỉ nhập số. Không nhập chữ");
            }
            else if (decimal.Parse(txtGiaSP.Text.Trim()) <= 0)
            {
                e.Cancel = true;
                errorProvider.SetError(txtGiaSP, "Giá của sản phẩm phải lớn hơn 0");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtGiaSP, null);
            }
        }

        private void txtMoTaSP_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtMoTaSP.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtMoTaSP, "Vui lòng nhập mô tả sản phẩm !");
            }
            else if (txtMoTaSP.Text.Trim().Length < 1 || txtMoTaSP.Text.Trim().Length > 255)
            {
                e.Cancel = true;
                errorProvider.SetError(txtMoTaSP, "Độ dài tối thiểu của mô tả sản phẩm là 1 và tối đa là 255 ký tự");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtMoTaSP, null);
            }
        }

        private void txtDonViSP_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtDonViSP.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtDonViSP, "Vui lòng nhập đơn vị sản phẩm !");
            }
            else if (txtDonViSP.Text.Trim().Length < 1 || txtDonViSP.Text.Trim().Length > 255)
            {
                e.Cancel = true;
                errorProvider.SetError(txtMoTaSP, "Độ dài tối thiểu của đơn vị sản phẩm là 1 và tối đa là 255 ký tự");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtDonViSP, null);
            }
        }

        private void txtXuatXuSP_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtXuatXuSP.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtXuatXuSP, "Vui lòng nhập xuất xứ sản phẩm !");
            }
            else if (txtXuatXuSP.Text.Trim().Length < 1 || txtXuatXuSP.Text.Trim().Length > 255)
            {
                e.Cancel = true;
                errorProvider.SetError(txtXuatXuSP, "Độ dài tối thiểu của xuất xứ sản phẩm là 1 và tối đa là 255 ký tự");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtXuatXuSP, null);
            }
        }

        private void cboLoaiSP_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(cboLoaiSP.Text.Trim()) || cboLoaiSP.SelectedIndex == -1)
            {
                e.Cancel = true;
                errorProvider.SetError(cboLoaiSP, "Vui lòng chọn danh mục sản phẩm !");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(cboLoaiSP, null);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowList();
            txtName.Clear();
        }

        private void tvProduct_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
            {
                return;
            }
            if (e.Node.Level == 1)
            {
                string id = e.Node.Tag.ToString();
                Product product = bus.GetProductDetail(id);
                if (product != null)
                {
                    txtMaSP.Text = product.Id;
                    txtTenSP.Text = product.Name;
                    txtGiaSP.Text = product.Price.ToString();
                    txtMoTaSP.Text = product.Description;
                    txtDonViSP.Text = product.Unit;
                    txtXuatXuSP.Text = product.Origin;
                    cboLoaiSP.Text = product.CategoryId.ToString();
                }
            }
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
            frmProduct_Load(sender, e);
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
            frmProduct_Load(sender, e);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Skip += Take;
            if (Skip + 5 >= listProduct.Count)
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
            frmProduct_Load(sender, e);
        }

        private void btnGoToLast_Click(object sender, EventArgs e)
        {
            Skip = listProduct.Count - Take;
            if (Skip + 5 >= listProduct.Count)
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
            frmProduct_Load(sender, e);
        }

        private void ToolStripColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = groupBox1.BackColor;
            colorDialog1.AllowFullOpen = true;
            colorDialog1.FullOpen = true;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                groupBox1.BackColor = colorDialog1.Color;
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
