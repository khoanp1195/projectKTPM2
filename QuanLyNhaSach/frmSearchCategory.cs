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
    public partial class frmSearchCategory : Form
    {
        CategoryBUS bus = new CategoryBUS();

        List<Category> listCategory = null;

        public frmSearchCategory()
        {
            InitializeComponent();
        }

        private void frmSearchCategory_Load(object sender, EventArgs e)
        {
            listCategory = bus.GetAllAdvanced();
            ShowList();
        }

        private void ShowList()
        {
            lvSearchCategory.Items.Clear();
            listCategory.ForEach(x =>
            {
                ListViewItem lvi = new ListViewItem(x.Id.ToString());
                lvi.SubItems.Add(x.Name);
                lvSearchCategory.Items.Add(lvi);
            });
        }

        private void RefreshData()
        {
            txtName.Clear();
            txtName.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtName.Text.Trim();
            listCategory = bus.GetCategoriesSearch(keyword);
            RefreshData();
            ShowList();
        }

        private void cboSortAsc_SelectedIndexChanged(object sender, EventArgs e)
        {
            listCategory = bus.SortASC();
            ShowList();
        }

        private void cboSortDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            listCategory = bus.SortDESC();
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
