using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaSach.Data;
using QuanLyNhaSach.BUS;

namespace QuanLyNhaSach
{
    public partial class frmSearchProduct : Form
    {
        ProductBUS bus = new ProductBUS();

        List<Product> listProduct = null;

        public frmSearchProduct()
        {
            InitializeComponent();
        }

        private void frmSearchProduct_Load(object sender, EventArgs e)
        {
            LoadComboFilter();
            cboFilter.SelectedIndex = -1;
            string keyword = txtName.Text.Trim();
            listProduct = bus.GetAllProducts(keyword);
            ShowList();
        }

        private void ShowList()
        {
            lvSearchProduct.Items.Clear();
            listProduct.ForEach(x =>
            {
                ListViewItem lvi = new ListViewItem(x.Id);
                lvi.SubItems.Add(x.Name);
                lvi.SubItems.Add(x.Price.ToString());
                lvi.SubItems.Add(x.Description);
                lvi.SubItems.Add(x.Unit);
                lvi.SubItems.Add(x.Origin);
                lvi.SubItems.Add(x.CategoryId.ToString());
                lvSearchProduct.Items.Add(lvi);
            });
        }

        private void RefreshData()
        {
            txtName.Clear();
            txtName.Focus();
        }

        private void LoadComboFilter()
        {
            DataSet ds = bus.GetAllOrigin();
            BindingSource bs = new BindingSource();
            bs.DataSource = ds.Tables["Origin"];
            cboFilter.ValueMember = "Origin";
            cboFilter.DisplayMember = "Origin";
            cboFilter.DataSource = bs;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtName.Text.Trim();
            listProduct = bus.GetProductsSearch(keyword);
            RefreshData();
            ShowList();
        }

        private void cboSortAsc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string keyword = txtName.Text.Trim();
            if (cboSortAsc.Text.Trim() == "Tên sản phẩm" || cboSortAsc.SelectedIndex == 0)
            {
                listProduct = bus.SortAsc("Name", keyword);
            }
            else if (cboSortAsc.Text.Trim() == "Giá" || cboSortAsc.SelectedIndex == 1)
            {
                listProduct = bus.SortAsc("Price", keyword);
            }
            else if (cboSortAsc.Text.Trim() == "Mô tả" || cboSortAsc.SelectedIndex == 2)
            {
                listProduct = bus.SortAsc("Description", keyword);
            }
            if (cboSortAsc.Text.Trim() == "Đơn vị" || cboSortAsc.SelectedIndex == 3)
            {
                listProduct = bus.SortAsc("Unit", keyword);
            }
            else if (cboSortAsc.Text.Trim() == "Nguồn gốc" || cboSortAsc.SelectedIndex == 4)
            {
                listProduct = bus.SortAsc("Origin", keyword);
            }
            else if (cboSortAsc.Text.Trim() == "Danh mục" || cboSortAsc.SelectedIndex == 5)
            {
                listProduct = bus.SortAsc("CategoryId", keyword);
            }
            ShowList();
        }

        private void cboSortDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string keyword = txtName.Text.Trim();
            if (cboSortDesc.Text.Trim() == "Tên sản phẩm" || cboSortDesc.SelectedIndex == 0)
            {
                listProduct = bus.SortDesc("Name", keyword);
            }
            else if (cboSortDesc.Text.Trim() == "Giá" || cboSortDesc.SelectedIndex == 1)
            {
                listProduct = bus.SortDesc("Price", keyword);
            }
            else if (cboSortDesc.Text.Trim() == "Mô tả" || cboSortDesc.SelectedIndex == 2)
            {
                listProduct = bus.SortDesc("Description", keyword);
            }
            if (cboSortDesc.Text.Trim() == "Đơn vị" || cboSortDesc.SelectedIndex == 3)
            {
                listProduct = bus.SortDesc("Unit", keyword);
            }
            else if (cboSortDesc.Text.Trim() == "Nguồn gốc" || cboSortDesc.SelectedIndex == 4)
            {
                listProduct = bus.SortDesc("Origin", keyword);
            }
            else if (cboSortDesc.Text.Trim() == "Danh mục" || cboSortDesc.SelectedIndex == 5)
            {
                listProduct = bus.SortDesc("CategoryId", keyword);
            }
            ShowList();
        }

        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string keyword = txtName.Text.Trim();
            listProduct = bus.FilterOrigin(cboFilter.Text.Trim(),keyword);
            ShowList();
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
                this.Close();
            }
        }
    }
}
