using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNV_CHBHXM.GUI
{
    public partial class FReportSalary : Form
    {
        Dictionary<string, object> filters;
        private List<ReportParameter> parameters;

        public Dictionary<string, object> Filters { get => filters; set => filters = value; }
        public List<ReportParameter> Parameters { get => parameters; set => parameters = value; }

        public FReportSalary(Dictionary<string, object> filters)
        {
            InitializeComponent();
            Filters = filters;

            Parameters = new List<ReportParameter>();
            Parameters.Add(new ReportParameter("Title", Filters["Title"].ToString()));
        }

        private void FReportSalary_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLNV_CHBHXMDataSet.USP_TimKiemVaSapXepLuong' table. You can move, or remove it, as needed.
            uSP_TimKiemVaSapXepLuongTableAdapter.Fill(qLNV_CHBHXMDataSet.USP_TimKiemVaSapXepLuong,
                Filters["MaNV"].ToString(),
                Filters["HoTen"].ToString(),
                (int)Filters["TuSoNgay"],
                (int)Filters["DenSoNgay"],
                (int)Filters["TuThang"],
                (int)Filters["DenThang"],
                (int)Filters["TuNam"],
                (int)Filters["DenNam"],
                Filters["TenCot"].ToString(),
                Filters["HuongSapXep"].ToString());

            rvSalary.LocalReport.SetParameters(Parameters);
            rvSalary.RefreshReport();
        }
    }
}
