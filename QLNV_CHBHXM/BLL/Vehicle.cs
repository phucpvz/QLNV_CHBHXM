using QLNV_CHBHXM.DAO;
using QLNV_CHBHXM.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNV_CHBHXM.GUI
{
    public partial class FAdmin
    {
        #region Loại xe
        //===================================================== Loại xe =====================================================
        private void LoadVehicles()
        {
            /* 
             * Tìm kiếm loại xe
             */
            string vehicleName = txbFindVehicleName.Text;

            /* 
             * Sắp xếp loại xe
             */
            int idx = cbSortVehicles.SelectedIndex;
            if (idx == -1)
            {
                return;
            }
            string columnName = Constants.VEHICLE_COLUMN[idx];

            string sortDirection = (rbtnAscVehicle.Checked) ? "ASC" : "DESC";

            try
            {
                vehicles.DataSource = DataProvider.Instance.DB.USP_TimKiemVaSapXepLoaiXe(vehicleName, columnName, sortDirection);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm và sắp xếp loại xe!\n\n",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowVehicles()
        {
            txbFindVehicleName.Clear();
            cbSortVehicles.SelectedIndex = 0;
            rbtnAscVehicle.Checked = true;
        }

        private void AddVehiclesBinding()
        {
            txbVehicleID.DataBindings.Add(new Binding("Text", dgrvVehicles.DataSource, "MaLX", true, DataSourceUpdateMode.Never));
            txbVehicleName.DataBindings.Add(new Binding("Text", dgrvVehicles.DataSource, "TenLX", true, DataSourceUpdateMode.Never));
        }

        private void InitVehicleFlags()
        {
            VehicleFlags = new Dictionary<Control, bool>()
            {
                {txbVehicleName, false }
            };
        }

        private void CheckVehicleID()
        {
            pnlVehicleInfo.Visible = (dgrvVehicles.RowCount > 0) || pnlAddingVehicle.Visible;
            btnEditVehicle.Enabled = btnDeleteVehicle.Enabled = !string.IsNullOrEmpty(txbVehicleID.Text);
            CheckVehicleName();
        }

        private void CheckVehicleName()
        {
            string vehicleName = txbVehicleName.Text;
            if (string.IsNullOrEmpty(vehicleName))
            {
                ShowMessage(VehicleFlags, new List<Button>() { btnEditVehicle, btnAcceptAddVeh }, txbVehicleName, lblVehicleName, "Tên loại xe không được để trống!");
                return;
            }

            int vehicleID = string.IsNullOrEmpty(txbVehicleID.Text) ? -1 : Convert.ToInt32(txbVehicleID.Text);
            if (DataProvider.Instance.DB.LoaiXes.Any(lx => lx.TenLX == vehicleName && lx.MaLX != vehicleID))
            {
                ShowMessage(VehicleFlags, new List<Button>() { btnEditVehicle, btnAcceptAddVeh }, txbVehicleName, lblVehicleName, "Tên loại xe đã tồn tại!\nVui lòng nhập tên loại xe khác!");
                return;
            }

            ShowMessage(VehicleFlags, new List<Button>() { btnEditVehicle, btnAcceptAddVeh }, txbVehicleName, lblVehicleName);
        }

        private void ChangeModeAddingVehicle()
        {
            pnlAddingVehicle.Visible = true;
            pnlAddEditDeleteVehicle.Visible = false;

            RemoveVehicleBinding();
            ClearVehicleInfo();
        }

        private void ClearVehicleInfo()
        {
            txbVehicleID.Text = GetNextVehicleID().ToString();
            txbVehicleName.Clear();
        }

        private int GetNextVehicleID()
        {
            try
            {
                return Convert.ToInt32(DataProvider.Instance.DB.USP_LayMaTiepTheo("LoaiXe").FirstOrDefault());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm mã loại xe tiếp theo!\n\n",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private void RemoveVehicleBinding()
        {
            txbVehicleID.DataBindings.Clear();
            txbVehicleName.DataBindings.Clear();
        }

        private void ChangeModeEditingVehicle()
        {
            pnlAddingVehicle.Visible = false;
            pnlAddEditDeleteVehicle.Visible = true;

            AddVehiclesBinding();
            if (dgrvVehicles.RowCount == 0)
            {
                txbVehicleID.Clear();
            }
        }

        private void AddVehicle()
        {
            string vehicleName = txbVehicleName.Text;

            try
            {
                if (DataProvider.Instance.DB.LoaiXes.Any(lx => lx.TenLX == vehicleName))
                {
                    MessageBox.Show("Tên loại xe đã tồn tại! Vui lòng chọn tên loại xe khác!",
                        "Lỗi: Tên đã tồn tại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LoaiXe vehicle = new LoaiXe() { TenLX = vehicleName };
                DataProvider.Instance.DB.LoaiXes.Add(vehicle);
                DataProvider.Instance.DB.SaveChanges();

                LoadVehicles();
                MessageBox.Show("Đã thêm thông tin loại xe mới thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi thêm thông tin loại xe mới!\n\n",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ClearVehicleInfo();
        }

        private void EditVehicle()
        {
            if (MessageBox.Show("Bạn có chắc muốn sửa thông tin của loại xe đã chọn?",
                    "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
            {
                return;
            }

            int vehicleID = Convert.ToInt32(txbVehicleID.Text);
            string vehicleName = txbVehicleName.Text;

            try
            {
                LoaiXe vehicle = DataProvider.Instance.DB.LoaiXes.Find(vehicleID);
                vehicle.TenLX = vehicleName;
                DataProvider.Instance.DB.SaveChanges();

                LoadVehicles();
                LoadPrices();
                LoadDetails();

                MessageBox.Show("Đã sửa thông tin loại xe thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi sửa thông tin loại xe!\n\n",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteVehicle()
        {
            int vehicleID = Convert.ToInt32(txbVehicleID.Text);
            try
            {
                LoaiXe vehicle = DataProvider.Instance.DB.LoaiXes.Find(vehicleID);

                // Kiểm tra loại xe này đã có thông tin trong bảng đơn giá?
                if (vehicle.BangGias.Any())
                {
                    int count = vehicle.BangGias.Count;
                    MessageBox.Show(string.Format("Không thê xóa loại xe này vì đang có {0} thông tin đơn giá liên quan đến loại xe này!\n\n" +
                        "Hãy xóa tất cả đơn giá có liên quan đến loại xe này rồi thử lại!", count),
                    "Lỗi: Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa loại xe đã chọn?",
                    "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                {
                    return;
                }

                DataProvider.Instance.DB.LoaiXes.Remove(vehicle);
                DataProvider.Instance.DB.SaveChanges();

                LoadVehicles();
                CheckVehicleID();

                MessageBox.Show("Đã xóa loại xe!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa loại xe này!",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ------------------------------------- Events -------------------------------------
        private void txbVehicleName_TextChanged(object sender, EventArgs e)
        {
            CheckVehicleName();
        }

        private void txbVehicleID_TextChanged(object sender, EventArgs e)
        {
            CheckVehicleID();
        }

        private void btnAddVehicle_Click(object sender, EventArgs e)
        {
            ChangeModeAddingVehicle();
        }

        private void btnEditVehicle_Click(object sender, EventArgs e)
        {
            EditVehicle();
        }

        private void btnDeleteVehicle_Click(object sender, EventArgs e)
        {
            DeleteVehicle();
        }

        private void btnShowVehicle_Click(object sender, EventArgs e)
        {
            ShowVehicles();
        }

        private void txbFindVehicleName_TextChanged(object sender, EventArgs e)
        {
            LoadVehicles();
        }

        private void cbSortVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadVehicles();
        }

        private void rbtnSortDirectionVehicle_CheckedChanged(object sender, EventArgs e)
        {
            LoadVehicles();
        }

        private void btnAcceptAddVeh_Click(object sender, EventArgs e)
        {
            AddVehicle();
        }

        private void btnCancelAddVeh_Click(object sender, EventArgs e)
        {
            ChangeModeEditingVehicle();
        }

        private void tcVehicle_Click(object sender, EventArgs e)
        {
            CheckVehicleID();
        }

        #endregion

    }
}
