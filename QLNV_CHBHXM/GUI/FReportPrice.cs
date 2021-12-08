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
    public partial class FReportPrice : Form
    {
        public FReportPrice()
        {
            InitializeComponent();
        }

        private void FReportPrice_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLNV_CHBHXMDataSet.USP_TimKiemVaSapXepDonGia' table. You can move, or remove it, as needed.
            uSP_TimKiemVaSapXepDonGiaTableAdapter.Fill(qLNV_CHBHXMDataSet.USP_TimKiemVaSapXepDonGia, "", "", Constants.DANG_DUNG, "TenDV, TenLX", "ASC");

            rvPrice.RefreshReport();
        }
    }
}
