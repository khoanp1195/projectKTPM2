using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using QuanLyNhaSach.BUS;

namespace QuanLyNhaSach
{
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }

        ProductBUS bus = new ProductBUS();

        private void frmReport_Load(object sender, EventArgs e)
        {
            this.reportViewer.LocalReport.ReportEmbeddedResource = "QuanLyNhaSach.ReportProduct.rdlc";
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = bus.GetNameCategory().Tables[0];
            this.reportViewer.LocalReport.DataSources.Add(rds);
            this.reportViewer.RefreshReport();
        }
    }
}
