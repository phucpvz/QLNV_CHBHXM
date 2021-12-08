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
    public partial class FReportEmployee : Form
    {
        private List<ReportParameter> parameters;
        Dictionary<string, object> filters;
        public Dictionary<string, object> Filters { get => filters; set => filters = value; }
        public List<ReportParameter> Parameters { get => parameters; set => parameters = value; }

        public FReportEmployee(Dictionary<string, object> filters)
        {
            InitializeComponent();
            Filters = filters;

            Parameters = new List<ReportParameter>();
            Parameters.Add(new ReportParameter("Title", Filters["Title"].ToString()));
        }

        private void FReportEmployee_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLNV_CHBHXMDataSet.USP_TimKiemVaSapXepNhanVien' table. You can move, or remove it, as needed.
            uSP_TimKiemVaSapXepNhanVienTableAdapter.Fill(qLNV_CHBHXMDataSet.USP_TimKiemVaSapXepNhanVien,
                Filters["MaNV"].ToString(),
                Filters["HoTen"].ToString(),
                Filters["GioiTinh"].ToString(),
                (DateTime)Filters["TuNgay"],
                (DateTime)Filters["DenNgay"],
                Filters["DiaChi"].ToString(),
                Filters["SoDT"].ToString(),
                Filters["Email"].ToString(),
                (decimal)Filters["TuLuong"],
                (decimal)Filters["DenLuong"],
                Filters["TenLoai"].ToString(),
                Filters["TrangThai"].ToString(),
                Filters["TenCot"].ToString(),
                Filters["HuongSapXep"].ToString());

            rvEmployee.LocalReport.SetParameters(Parameters);
            rvEmployee.RefreshReport();
        }
    }
}
