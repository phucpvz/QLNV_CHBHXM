using QLNV_CHBHXM.DAO;
using QLNV_CHBHXM.DTO;
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
        #region Năng lực
        //===================================================== Năng lực =====================================================
        private void AddTalentBinding()
        {
            txbEmpID_Talent.DataBindings.Add(new Binding("Text", dgrvTalent.DataSource, "MaNV", true, DataSourceUpdateMode.Never));
            txbServiceID_Talent.DataBindings.Add(new Binding("Text", dgrvTalent.DataSource, "MaDV", true, DataSourceUpdateMode.Never));
        }

        private void LoadTalents()
        {
            /* 
             * Tìm kiếm năng lực 
             */
            string empID = txbFindEmpID_Talent.Text;
            string name = txbFindName_Talent.Text;
            string serviceName = txbFindSerName_Talent.Text;

            /* 
             * Sắp xếp dịch vụ
             */
            int idx = cbSortTalent.SelectedIndex;
            if (idx == -1)
            {
                return;
            }
            string columnName = Constants.TALENT_COLUMN[idx];

            string sortDirection = (rbtnAscTalent.Checked) ? "ASC" : "DESC";

            try
            {
                talents.DataSource = DataProvider.Instance.DB.USP_TimKiemVaSapXepNangLuc(empID, name, serviceName, columnName, sortDirection);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm và sắp xếp năng lực!\n\n",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteTalent()
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa năng lực đã chọn?",
                    "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
            {
                return;
            }

            string empID = txbEmpID_Talent.Text;
            int serviceID = Convert.ToInt32(txbServiceID_Talent.Text);

            try
            {
                NhanVien employee = DataProvider.Instance.DB.NhanViens.Find(empID);
                DichVu service = DataProvider.Instance.DB.DichVus.Find(serviceID);
                employee.DichVus.Remove(service);
                DataProvider.Instance.DB.SaveChanges();

                LoadTalents();
                MessageBox.Show("Đã xóa năng lực!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa năng lực!\n\n",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowTalents()
        {
            txbFindEmpID_Talent.Clear();
            txbFindName_Talent.Clear();
            txbFindSerName_Talent.Clear();
        }

        private void ShowYourTalent()
        {
            txbFindEmpID_Talent.Text = Account.MaNV;
            txbFindName_Talent.Clear();
            txbFindSerName_Talent.Clear();
        }

        private void CheckTalentIDs()
        {
            btnDeleteTalent.Enabled = !string.IsNullOrEmpty(txbEmpID_Talent.Text);
            //btnDeleteTalent.Enabled = !string.IsNullOrEmpty(txbEmpID_Talent.Text) && !string.IsNullOrEmpty(txbServiceID_Talent.Text);
        }

        // ------------------------------------- Events -------------------------------------
        private void txbEmpID_Talent_TextChanged(object sender, EventArgs e)
        {
            CheckTalentIDs();
        }

        private void cbSortTalent_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTalents();
        }

        private void txbFindEmpID_Talent_TextChanged(object sender, EventArgs e)
        {
            LoadTalents();
        }

        private void rbtnAscTalent_CheckedChanged(object sender, EventArgs e)
        {
            LoadTalents();
        }

        private void btnAddTalent_Click(object sender, EventArgs e)
        {
            FAddTalent f = new FAddTalent();
            f.TalentAdded += F_TalentAdded;
            f.ShowDialog();
        }

        private void F_TalentAdded(object sender, EventArgs e)
        {
            LoadTalents();
        }

        private void btnDeleteTalent_Click(object sender, EventArgs e)
        {
            DeleteTalent();
        }

        private void btnShowTalent_Click(object sender, EventArgs e)
        {
            ShowTalents();
        }

        private void btnShowYourTalent_Click(object sender, EventArgs e)
        {
            ShowYourTalent();
        }
        
        #endregion
    }
}
