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
    public partial class frmSearchEmpoyee : Form
    {
        EmployeeBUS bus = new EmployeeBUS();

        List<Employee> listEmployee = null;

        public frmSearchEmpoyee()
        {
            InitializeComponent();
        }

        private void frmSearchEmpoyee_Load(object sender, EventArgs e)
        {
            listEmployee = bus.GetAllAdvanced();
            ShowList();
        }

        private void ShowList()
        {
            lvSearchEmployee.Items.Clear();
            listEmployee.ForEach(x =>
            {
                ListViewItem lvi = new ListViewItem(x.Id);
                lvi.SubItems.Add(x.Name);
                if (x.Gender == 0)
                {
                    lvi.SubItems.Add("Nữ");
                }
                else
                {
                    lvi.SubItems.Add("Nam");
                };
                lvi.SubItems.Add(x.Age.ToString());
                lvi.SubItems.Add(x.Dob.ToString());
                lvi.SubItems.Add(x.Address);
                lvi.SubItems.Add("0" + x.Phone.ToString());
                lvSearchEmployee.Items.Add(lvi);
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
            listEmployee = bus.GetEmployeesSearch(keyword);
            RefreshData();
            ShowList();
        }

        private void cboSortAsc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSortAsc.Text.Trim() == "Họ và tên" || cboSortAsc.SelectedIndex == 0)
            {
                listEmployee = bus.SortAsc("Name");
            }
            else if (cboSortAsc.Text.Trim() == "Tuổi" || cboSortAsc.SelectedIndex == 1)
            {
                listEmployee = bus.SortAsc("Age");
            }
            else if (cboSortAsc.Text.Trim() == "Ngày sinh" || cboSortAsc.SelectedIndex == 2)
            {
                listEmployee = bus.SortAsc("Dob");
            }
            if (cboSortAsc.Text.Trim() == "Giới tính" || cboSortAsc.SelectedIndex == 3)
            {
                listEmployee = bus.SortAsc("Gender");
            }
            else if (cboSortAsc.Text.Trim() == "Địa chỉ" || cboSortAsc.SelectedIndex == 4)
            {
                listEmployee = bus.SortAsc("Address");
            }
            else if (cboSortAsc.Text.Trim() == "Số điện thoại" || cboSortAsc.SelectedIndex == 5)
            {
                listEmployee = bus.SortAsc("Phone");
            }
            ShowList();
        }

        private void cboSortDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSortDesc.Text.Trim() == "Họ và tên" || cboSortDesc.SelectedIndex == 0)
            {
                listEmployee = bus.SortDesc("Name");
            }
            else if (cboSortDesc.Text.Trim() == "Tuổi" || cboSortDesc.SelectedIndex == 1)
            {
                listEmployee = bus.SortDesc("Age");
            }
            else if (cboSortDesc.Text.Trim() == "Ngày sinh" || cboSortDesc.SelectedIndex == 2)
            {
                listEmployee = bus.SortDesc("Dob");
            }
            if (cboSortDesc.Text.Trim() == "Giới tính" || cboSortDesc.SelectedIndex == 3)
            {
                listEmployee = bus.SortDesc("Gender");
            }
            else if (cboSortDesc.Text.Trim() == "Địa chỉ" || cboSortDesc.SelectedIndex == 4)
            {
                listEmployee = bus.SortDesc("Address");
            }
            else if (cboSortDesc.Text.Trim() == "Số điện thoại" || cboSortDesc.SelectedIndex == 5)
            {
                listEmployee = bus.SortDesc("Phone");
            }
            ShowList();
        }

        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFilter.Text.Trim() == "Nam" || cboFilter.SelectedIndex == 0)
            {
                listEmployee = bus.FilterGender(1);
            }
            else if (cboFilter.Text.Trim() == "Nữ" || cboFilter.SelectedIndex == 1)
            {
                listEmployee = bus.FilterGender(0);
            }
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
