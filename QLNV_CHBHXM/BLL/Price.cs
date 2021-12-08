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
        #region Bảng giá
        //===================================================== Bảng giá =====================================================

        // Kiểm tra mã đơn giá => Nếu trống => Không có đơn giá => Không sửa, xóa
        private void CheckPriceID()
        {
            if (string.IsNullOrEmpty(txbPriceID.Text))
            {
                btnEditPrice.Enabled = btnDeletePrice.Enabled = false;

                btnActivePrice.Enabled = false;

                return;
            }
            else
            {
                btnEditPrice.Enabled = btnDeletePrice.Enabled = true;

                btnActivePrice.Enabled = true;
            }

            int priceID = Convert.ToInt32(txbPriceID.Text);

            BangGia priceList;
            try
            {
                priceList = DataProvider.Instance.DB.BangGias.FirstOrDefault(p => p.MaDG == priceID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi kiểm tra mã đơn giá!",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cbPriceStatus.SelectedIndex = cbPriceStatus.Items.IndexOf(priceList.TrangThai);

            // Tìm xem đơn giá này có lịch đặt kích hoạt không
            PlanItem priceInfo = Plan.Prices.FirstOrDefault(p => p.PriceID == priceID);
            if (priceInfo != null)
            {
                txbActiveTime.Text = priceInfo.ActivateTime.ToString("dddd, dd/MM/yyyy hh:mm:ss tt");
            }
            else
            {
                txbActiveTime.Text = "";
            }

            btnCancelActivePrice.Enabled = !string.IsNullOrEmpty(txbActiveTime.Text);
        }

        private void LoadPrices()
        {
            /* 
             * Tìm kiếm đơn giá
             */
            string serviceName = txbFindServiceName_Price.Text;
            string vehicleName = txbFindVehicleName_Price.Text;

            object obj = cbFindPriceStatus.SelectedItem;
            if (obj == null)
            {
                return;
            }
            string status = obj.ToString();
            if (status == Constants.TAT_CA)
            {
                status = "";
            }

            /* 
             * Sắp xếp đơn giá
             */
            int idx = cbSortPrice.SelectedIndex;
            if (idx == -1)
            {
                return;
            }
            string columnName = Constants.PRICE_COLUMN[idx];
            string sortDirection = (rbtnAscPrice.Checked) ? "ASC" : "DESC";

            try
            {
                prices.DataSource = DataProvider.Instance.DB.USP_TimKiemVaSapXepDonGia(serviceName, vehicleName, status, columnName, sortDirection);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm và sắp xếp thông tin đơn giá!\n\n",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddPricesBinding()
        {
            txbPriceID.DataBindings.Add(new Binding("Text", dgrvPrices.DataSource, "MaDG", true, DataSourceUpdateMode.Never));
            txbServiceName_Price.DataBindings.Add(new Binding("Text", dgrvPrices.DataSource, "TenDV", true, DataSourceUpdateMode.Never));
            txbVehicleName_Price.DataBindings.Add(new Binding("Text", dgrvPrices.DataSource, "TenLX", true, DataSourceUpdateMode.Never));
            nmrPrice.DataBindings.Add(new Binding("Value", dgrvPrices.DataSource, "DonGia", true, DataSourceUpdateMode.Never));
        }

        private void ShowPrices()
        {
            txbFindServiceName_Price.Clear();
            txbFindVehicleName_Price.Clear();
            cbFindPriceStatus.SelectedIndex = 0;

            cbSortPrice.SelectedIndex = 0;
            rbtnAscPrice.Checked = true;
        }

        private void EditPrice()
        {
            if (MessageBox.Show("Bạn có chắc muốn sửa đơn giá đã chọn không?",
                    "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
            {
                return;
            }

            int priceID = Convert.ToInt32(txbPriceID.Text);

            try
            {
                BangGia priceList = DataProvider.Instance.DB.BangGias.FirstOrDefault(p => p.MaDG == priceID);
                priceList.TrangThai = cbPriceStatus.SelectedItem.ToString();
                DataProvider.Instance.DB.SaveChanges();

                // Có trigger => Phải load lại
                RefreshAll();
                LoadPrices();

                MessageBox.Show("Đã sửa đơn giá thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi sửa thông tin đơn giá!\n\n",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeletePrice()
        {
            int priceID = Convert.ToInt32(txbPriceID.Text);
            try
            {
                BangGia priceList = DataProvider.Instance.DB.BangGias.FirstOrDefault(p => p.MaDG == priceID);
                int count = DataProvider.Instance.DB.ChiTietCVs.Where(d => d.MaDG == priceID).Count();
                if (count > 0)
                {
                    MessageBox.Show(string.Format("Không thể xóa đơn giá đã chọn vì đang có {0} chi tiết công việc liên quan đến đơn giá này!\n\n" +
                        "Hãy xóa tất cả chi tiết công việc có liên quan đến đơn giá này rồi thử lại!", count),
                    "Lỗi: Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa đơn giá đã chọn không?",
                    "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                {
                    return;
                }

                DataProvider.Instance.DB.BangGias.Remove(priceList);
                DataProvider.Instance.DB.SaveChanges();

                // Có trigger => Phải load lại
                RefreshAll();
                LoadPrices();

                MessageBox.Show("Đã xóa đơn giá thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa đơn giá này!",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowUsingPrice()
        {
            txbFindServiceName_Price.Clear();
            txbFindVehicleName_Price.Clear();
            cbFindPriceStatus.SelectedIndex = cbFindPriceStatus.Items.IndexOf(Constants.DANG_DUNG);

            cbSortPrice.SelectedIndex = 0;
            rbtnAscPrice.Checked = true;
        }

        // ------------------------------------- Events -------------------------------------
        private void txbSearchPrice_TextChanged(object sender, EventArgs e)
        {
            LoadPrices();
        }

        private void cbSortPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPrices();
        }

        private void rbtnSortDirectionPrice_CheckedChanged(object sender, EventArgs e)
        {
            LoadPrices();
        }

        private void btnAddPrice_Click(object sender, EventArgs e)
        {
            FAddPrice f = new FAddPrice();
            f.PriceAdded += F_PriceAdded;
            f.ShowDialog();
        }

        private void F_PriceAdded(object sender, EventArgs e)
        {
            LoadPrices();
        }

        private void txbPriceID_TextChanged(object sender, EventArgs e)
        {
            CheckPriceID();
        }

        private void btnEditPrice_Click(object sender, EventArgs e)
        {
            EditPrice();
        }

        private void btnDeletePrice_Click(object sender, EventArgs e)
        {
            DeletePrice();
        }

        private void btnShowPrice_Click(object sender, EventArgs e)
        {
            ShowPrices();
        }

        private void cbFindPriceStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPrices();
        }

        private void btnShowUsingPrice_Click(object sender, EventArgs e)
        {
            ShowUsingPrice();
        }

        private void btnReport_Price_Click(object sender, EventArgs e)
        {
            ReportPrices();
        }

        private void ReportPrices()
        {
            FReportPrice f = new FReportPrice();
            f.ShowDialog();
        }

        #endregion
    }
}
