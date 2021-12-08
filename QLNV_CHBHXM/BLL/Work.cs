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
        #region Công việc
        //===================================================== Công việc =====================================================
        // LƯU Ý: TRIGGER => Dữ liệu ở trên không được cập nhật (VD: TongTien)

        private void AddWorkBinding()
        {
            txbWorkID_Work.DataBindings.Add(new Binding("Text", dgrvWorks.DataSource, "MaCV", true, DataSourceUpdateMode.Never));
        }

        private void AddDetailBinding()
        {
            txbPriceID_Work.DataBindings.Add(new Binding("Text", dgrvDetails.DataSource, "MaDG", true, DataSourceUpdateMode.Never));
            nmrAmount.DataBindings.Add(new Binding("Value", dgrvDetails.DataSource, "SoLuong", true, DataSourceUpdateMode.Never));
        }

        private void ShowWorks()
        {
            txbFindEmpID_Work.Clear();
            txbFindName_Work.Clear();
            cbSortWork.SelectedIndex = 0;
            rbtnAscWork.Checked = true;
        }

        private void ShowYourWorkInfo()
        {
            txbFindEmpID_Work.Text = Account.MaNV;
            txbFindName_Work.Clear();
            cbSortWork.SelectedIndex = 0;
            rbtnAscWork.Checked = true;
        }

        private void ShowDetails()
        {
            txbFindServiceName_Work.Clear();
            txbFindVehicleName_Work.Clear();
            cbSortDetail.SelectedIndex = 0;
            rbtnAscWorkDetail.Checked = true;
        }

        private void LoadWorks()
        {
            /* 
             * Tìm kiếm công việc
             */
            string empID = txbFindEmpID_Work.Text;
            string name = txbFindName_Work.Text;
            DateTime workDay = dtpWorkDay.Value.Date;

            /* 
             * Sắp xếp công việc
             */
            int idx = cbSortWork.SelectedIndex;
            if (idx == -1)
            {
                return;
            }
            string columnName = Constants.WORK_COLUMN[idx];

            string sortDirection = (rbtnAscWork.Checked) ? "ASC" : "DESC";

            try
            {
                works.DataSource = DataProvider.Instance.DB.USP_TimKiemVaSapXepCongViec(empID, name, workDay, columnName, sortDirection);

                if (DataProvider.Instance.DB.CongViecs.Any(w => w.NgayLam == workDay))
                {
                    txbTotalRevenue.Text = string.Format("{0:#,##0}", DataProvider.Instance.DB.CongViecs.Where(w => w.NgayLam == workDay).Sum(w => w.TongTien));
                }
                else
                {
                    txbTotalRevenue.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm và sắp xếp công việc!\n\n",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            bool isFuture = dtpWorkDay.Value.Date > DateTime.Now.Date;
            nmrAmount.Enabled = btnEditWork.Enabled = btnDeleteWork.Enabled = !isFuture && (dgrvDetails.RowCount > 0);
            btnAddWork.Enabled = !isFuture;
        }

        private void LoadDetails()
        {
            /* 
             * Tìm kiếm chi tiết công việc
             */
            int workID = -1;
            if (!string.IsNullOrEmpty(txbWorkID_Work.Text))
            {
                workID = Convert.ToInt32(txbWorkID_Work.Text);
            }

            string serviceName = txbFindServiceName_Work.Text;
            string vehicleName = txbFindVehicleName_Work.Text;

            /* 
             * Sắp xếp chi tiết công việc
             */
            int idx = cbSortDetail.SelectedIndex;
            if (idx == -1)
            {
                return;
            }
            string columnName = Constants.DETAIL_COLUMN[idx];

            string sortDirection = (rbtnAscWorkDetail.Checked) ? "ASC" : "DESC";

            try
            {
                details.DataSource = DataProvider.Instance.DB.USP_TimKiemVaSapXepChiTietCV(workID, serviceName, vehicleName, columnName, sortDirection);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm và sắp xếp chi tiết công việc!",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            bool isFuture = dtpWorkDay.Value.Date > DateTime.Now.Date;
            nmrAmount.Enabled = btnEditWork.Enabled = btnDeleteWork.Enabled = !isFuture && (dgrvDetails.RowCount > 0);
        }

        private void EditWorkDetail()
        {
            if (MessageBox.Show("Bạn có chắc muốn sửa chi tiết công việc đã chọn không?",
                    "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
            {
                return;
            }

            int workID = Convert.ToInt32(txbWorkID_Work.Text);
            int priceID = Convert.ToInt32(txbPriceID_Work.Text);
            int amount = (int)nmrAmount.Value;

            try
            {
                ChiTietCV detail = DataProvider.Instance.DB.ChiTietCVs.Find(new object[] { workID, priceID });
                detail.Soluong = amount;
                DataProvider.Instance.DB.SaveChanges();

                // Có trigger => Phải load lại
                RefreshAll();

                LoadWorks();
                LoadDetails();
                LoadSalaries();

                MessageBox.Show("Đã sửa chi tiết công việc thành công!",
                   "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi sửa chi tiết công việc!",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteWorkDetail()
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa chi tiết công việc đã chọn không?",
                    "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
            {
                return;
            }

            int workID = Convert.ToInt32(txbWorkID_Work.Text);
            int priceID = Convert.ToInt32(txbPriceID_Work.Text);

            try
            {
                ChiTietCV workDetail = DataProvider.Instance.DB.ChiTietCVs.Find(new object[] { workID, priceID });

                DataProvider.Instance.DB.ChiTietCVs.Remove(workDetail);
                DataProvider.Instance.DB.SaveChanges();

                // Có trigger => Phải load lại
                RefreshAll();

                LoadWorks();
                LoadDetails();
                LoadSalaries();

                MessageBox.Show("Đã xóa chi tiết công việc thành công!",
                   "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa chi tiết công việc!",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ------------------------------------- Events -------------------------------------
        private void dtpWorkDay_ValueChanged(object sender, EventArgs e)
        {
            LoadWorks();
        }

        private void txbEmpIDName_TextChanged(object sender, EventArgs e)
        {
            LoadWorks();
        }

        private void cbSortWork_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadWorks();
        }

        private void rbtnSortWork_CheckedChanged(object sender, EventArgs e)
        {
            LoadWorks();
        }

        private void btnShowWorks_Click(object sender, EventArgs e)
        {
            ShowWorks();
        }

        private void txbWorkID_TextChanged(object sender, EventArgs e)
        {
            LoadDetails();
        }

        private void txbSearchWorkDetail_TextChanged(object sender, EventArgs e)
        {
            LoadDetails();
        }

        private void cbSortWorkDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDetails();
        }

        private void rbtnSortWorkDetail_CheckedChanged(object sender, EventArgs e)
        {
            LoadDetails();
        }

        private void btnAddWork_Click(object sender, EventArgs e)
        {
            FAddWork f = new FAddWork(dtpWorkDay.Value);
            f.WorkAdded += F_WorkAdded;
            f.ShowDialog();
        }

        private void F_WorkAdded(object sender, EventArgs e)
        {
            LoadWorks();
            LoadDetails();
            LoadSalaries();
        }

        private void btnEditWork_Click(object sender, EventArgs e)
        {
            EditWorkDetail();
        }

        private void btnDeleteWork_Click(object sender, EventArgs e)
        {
            DeleteWorkDetail();
        }

        private void btnYourWorkInfo_Click(object sender, EventArgs e)
        {
            ShowYourWorkInfo();
        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            ShowDetails();
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            dtpWorkDay.Value = DateTime.Now.Date;
        }

        private void btnPreviousDay_Click(object sender, EventArgs e)
        {
            dtpWorkDay.Value = dtpWorkDay.Value.AddDays(-1);
        }

        private void btnNextDay_Click(object sender, EventArgs e)
        {
            dtpWorkDay.Value = dtpWorkDay.Value.AddDays(1);
        }

        #endregion
    }
}
