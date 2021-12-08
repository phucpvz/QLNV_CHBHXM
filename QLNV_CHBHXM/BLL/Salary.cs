using QLNV_CHBHXM.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNV_CHBHXM.GUI
{
    public partial class FAdmin
    {
        #region Lương
        //===================================================== Lương =====================================================
        private void LoadSalaries()
        {
            string empID = txbFindEmpID_Salary.Text;
            string name = txbFindName_Salary.Text;

            int fromNums = (int)nmrFromNums.Value;
            int toNums = (int)nmrToNums.Value;

            int fromMonth = (int)nmrFromMonth.Value;
            int toMonth = (int)nmrToMonth.Value;

            int fromYear = (int)nmrFromYear.Value;
            int toYear = (int)nmrToYear.Value;

            int idx = cbSortSalary.SelectedIndex;
            if (idx == -1)
            {
                return;
            }

            string columnName = Constants.SORT_SALARY_COLUMN[idx];

            string sortDirection = (rbtnAscSalary.Checked) ? "ASC" : "DESC";

            try
            {
                var list = DataProvider.Instance.DB.USP_TimKiemVaSapXepLuong
                    (empID, name, fromNums, toNums, fromMonth, toMonth, fromYear, toYear, columnName, sortDirection).ToList();

                txbSalaryAmount.Text = list.Count.ToString();

                Paging(salaries, list, nmrLineNumber_Salary, txbTotalPage_Salary, nmrPageNumber_Salary);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm và sắp xếp lương nhân viên!\n\n",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowYou_ThisMonth()
        {
            txbFindEmpID_Salary.Text = Account.MaNV;
            txbFindName_Salary.Clear();

            nmrFromNums.Value = nmrFromNums.Minimum;
            nmrToNums.Value = nmrToNums.Maximum;

            DateTime now = DateTime.Now;
            nmrFromMonth.Value = nmrToMonth.Value = now.Month;
            nmrFromYear.Value = nmrToYear.Value = now.Year;
        }

        private void ShowAllEmps_ThisMonth()
        {
            txbFindEmpID_Salary.Clear();
            txbFindName_Salary.Clear();

            nmrFromNums.Value = nmrFromNums.Minimum;
            nmrToNums.Value = nmrToNums.Maximum;

            DateTime now = DateTime.Now;
            nmrFromMonth.Value = nmrToMonth.Value = now.Month;
            nmrFromYear.Value = nmrToYear.Value = now.Year;
        }

        private void ShowYou_AllTime()
        {
            txbFindEmpID_Salary.Text = Account.MaNV;
            txbFindName_Salary.Clear();

            nmrFromNums.Value = nmrFromNums.Minimum;
            nmrToNums.Value = nmrToNums.Maximum;

            nmrFromMonth.Value = nmrFromMonth.Minimum;
            nmrToMonth.Value = nmrToMonth.Maximum;
            nmrFromYear.Value = nmrFromYear.Minimum;
            nmrToYear.Value = nmrToYear.Maximum;
        }

        private void ShowAllEmps_AllTime()
        {
            txbFindEmpID_Salary.Clear();
            txbFindName_Salary.Clear();

            nmrFromNums.Value = nmrFromNums.Minimum;
            nmrToNums.Value = nmrToNums.Maximum;

            nmrFromMonth.Value = nmrFromMonth.Minimum;
            nmrToMonth.Value = nmrToMonth.Maximum;
            nmrFromYear.Value = nmrFromYear.Minimum;
            nmrToYear.Value = nmrToYear.Maximum;
        }

        private void ReportSalary()
        {
            string title = txbTitle_Salary.Text;

            string empID = txbFindEmpID_Salary.Text;
            string name = txbFindName_Salary.Text;

            int fromNums = (int)nmrFromNums.Value;
            int toNums = (int)nmrToNums.Value;

            int fromMonth = (int)nmrFromMonth.Value;
            int toMonth = (int)nmrToMonth.Value;

            int fromYear = (int)nmrFromYear.Value;
            int toYear = (int)nmrToYear.Value;

            int idx = cbSortSalary.SelectedIndex;
            if (idx == -1)
            {
                return;
            }

            string columnName = Constants.SORT_SALARY_COLUMN[idx];

            string sortDirection = (rbtnAscSalary.Checked) ? "ASC" : "DESC";

            // Xuất báo cáo lương
            Dictionary<string, object> filters = new Dictionary<string, object>()
            {
                {"Title", title },
                {"MaNV", empID },
                {"HoTen", name },
                {"TuSoNgay", fromNums },
                {"DenSoNgay", toNums },
                {"TuThang", fromMonth },
                {"DenThang", toMonth },
                {"TuNam", fromYear },
                {"DenNam", toYear },
                {"TenCot", columnName },
                {"HuongSapXep", sortDirection },
            };

            FReportSalary f = new FReportSalary(filters);
            f.ShowDialog();
        }

        // ------------------------------------- Events -------------------------------------
        private void txbFindSalaries_Salary_TextChanged(object sender, EventArgs e)
        {
            LoadSalaries();
        }

        private void cbSortSalary_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSalaries();
        }

        private void rbtnSortSalary_CheckedChanged(object sender, EventArgs e)
        {
            LoadSalaries();
        }

        private void nmrFromNums_ValueChanged(object sender, EventArgs e)
        {
            LoadSalaries();
        }

        private void btnYou_ThisMonth_Click(object sender, EventArgs e)
        {
            ShowYou_ThisMonth();
        }

        private void btnAllEmps_ThisMonth_Click(object sender, EventArgs e)
        {
            ShowAllEmps_ThisMonth();
        }

        private void btnYou_AllTime_Click(object sender, EventArgs e)
        {
            ShowYou_AllTime();
        }

        private void btnAllEmps_AllTime_Click(object sender, EventArgs e)
        {
            ShowAllEmps_AllTime();
        }

        private void btnFirstPage_Salary_Click(object sender, EventArgs e)
        {
            nmrPageNumber_Salary.Value = 1;
        }

        private void btnPreviousPage_Salary_Click(object sender, EventArgs e)
        {
            --nmrPageNumber_Salary.Value;
        }

        private void btnNextPage_Salary_Click(object sender, EventArgs e)
        {
            ++nmrPageNumber_Salary.Value;
        }

        private void btnLastPage_Salary_Click(object sender, EventArgs e)
        {
            int totalPages = Convert.ToInt32(txbTotalPage_Salary.Text);
            nmrPageNumber_Salary.Value = (totalPages == 0) ? 1 : totalPages;
        }

        private void nmrPageNumber_Salary_ValueChanged(object sender, EventArgs e)
        {
            LoadSalaries();
        }

        private void nmrLineNumber_Salary_ValueChanged(object sender, EventArgs e)
        {
            LoadSalaries();
        }

        private void btnReportSalary_Click(object sender, EventArgs e)
        {
            ReportSalary();
        }

        #endregion
    }
}
