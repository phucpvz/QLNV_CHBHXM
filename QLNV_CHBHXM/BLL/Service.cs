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
        #region Dịch vụ
        //===================================================== Dịch vụ =====================================================
        private void LoadServices()
        {
            /* 
             * Tìm kiếm dịch vụ 
             */
            string serviceName = txbFindServiceName.Text;

            /* 
             * Sắp xếp dịch vụ
             */
            int idx = cbSortServices.SelectedIndex;
            if (idx == -1)
            {
                return;
            }
            string columnName = Constants.SERVICE_COLUMN[idx];

            string sortDirection = (rbtnAscService.Checked) ? "ASC" : "DESC";

            try
            {
                services.DataSource = DataProvider.Instance.DB.USP_TimKiemVaSapXepDichVu(serviceName, columnName, sortDirection);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm và sắp xếp dịch vụ!\n\n",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowServices()
        {
            txbFindServiceName.Clear();
            cbSortServices.SelectedIndex = 0;
            rbtnAscService.Checked = true;
        }

        private void AddServiceBinding()
        {
            txbServiceID.DataBindings.Add(new Binding("Text", dgrvServices.DataSource, "MaDV", true, DataSourceUpdateMode.Never));
            txbServiceName.DataBindings.Add(new Binding("Text", dgrvServices.DataSource, "TenDV", true, DataSourceUpdateMode.Never));
        }

        private void InitServiceFlags()
        {
            ServiceFlags = new Dictionary<Control, bool>()
            {
                { txbServiceName, false }
            };
        }

        // Kiểm tra mã dịch vụ trống? => Không cho phép sửa, xóa
        private void CheckServiceID()
        {
            pnlServiceInfo.Visible =  pnlAddingService.Visible || (dgrvServices.RowCount > 0);
            btnEditService.Enabled = btnDeleteService.Enabled = !string.IsNullOrEmpty(txbServiceID.Text);
            CheckServiceName();
        }

        private void CheckServiceName()
        {
            string serviceName = txbServiceName.Text;
            if (string.IsNullOrEmpty(serviceName))
            {
                ShowMessage(ServiceFlags, new List<Button>() { btnEditService, btnAcceptAddSer }, txbServiceName, lblServiceName, "Tên dịch vụ không được để trống!");
                return;
            }

            int serviceID = string.IsNullOrEmpty(txbServiceID.Text) ? -1 : Convert.ToInt32(txbServiceID.Text);
            if (DataProvider.Instance.DB.DichVus.Any(dv => dv.TenDV == serviceName && dv.MaDV != serviceID))
            {
                ShowMessage(ServiceFlags, new List<Button>() { btnEditService, btnAcceptAddSer }, txbServiceName, lblServiceName, "Tên dịch vụ đã tồn tại!\nVui lòng nhập tên dịch vụ khác!");
                return;
            }

            ShowMessage(ServiceFlags, new List<Button>() { btnEditService, btnAcceptAddSer }, txbServiceName, lblServiceName);
        }

        private void ChangeModeAddingSer()
        {
            pnlAddingService.Visible = true;
            pnlAddEditDeleteService.Visible = false;

            RemoveSerBinding();
            ClearSerInfo();
        }

        private void ClearSerInfo()
        {
            txbServiceID.Text = GetNextSerID().ToString();
            txbServiceName.Clear();
        }

        private int GetNextSerID()
        {
            try
            {
                return Convert.ToInt32(DataProvider.Instance.DB.USP_LayMaTiepTheo("DichVu").FirstOrDefault());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm mã dịch vụ tiếp theo!\n\n",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private void RemoveSerBinding()
        {
            txbServiceID.DataBindings.Clear();
            txbServiceName.DataBindings.Clear();
        }

        private void ChangeModeEditingSer()
        {
            pnlAddingService.Visible = false;
            pnlAddEditDeleteService.Visible = true;

            AddServiceBinding();
            if (dgrvServices.RowCount == 0)
            {
                txbServiceID.Clear();
            }
        }

        private void AddService()
        {
            string serviceName = txbServiceName.Text;

            try
            {
                if (DataProvider.Instance.DB.DichVus.Any(dv => dv.TenDV == serviceName))
                {
                    MessageBox.Show("Tên dịch vụ đã tồn tại! Vui lòng chọn tên dịch vụ khác!",
                        "Lỗi: Tên đã tồn tại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DichVu service = new DichVu() { TenDV = serviceName };
                DataProvider.Instance.DB.DichVus.Add(service);
                DataProvider.Instance.DB.SaveChanges();

                LoadServices();
                MessageBox.Show("Đã thêm thông tin dịch vụ mới thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi thêm thông tin dịch vụ mới!",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ClearSerInfo();
        }

        private void EditService()
        {
            if (MessageBox.Show("Bạn có chắc muốn sửa thông tin của dịch vụ đã chọn?",
                    "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
            {
                return;
            }

            int serviceID = Convert.ToInt32(txbServiceID.Text);
            string serviceName = txbServiceName.Text;

            try
            {
                DichVu service = DataProvider.Instance.DB.DichVus.Find(serviceID);
                service.TenDV = serviceName;
                DataProvider.Instance.DB.SaveChanges();

                LoadServices();
                LoadTalents();
                LoadPrices();
                LoadDetails();

                MessageBox.Show("Đã sửa thông tin dịch vụ thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi sửa thông tin dịch vụ!\n\n",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteService()
        {
            int serviceID = Convert.ToInt32(txbServiceID.Text);
            try
            {
                DichVu service = DataProvider.Instance.DB.DichVus.Find(serviceID);

                // Kiểm tra dịch vụ này đã có thông tin trong phân công năng lực?
                if (service.NhanViens.Any())
                {
                    int count = service.NhanViens.Count;
                    MessageBox.Show(string.Format("Không thê xóa dịch vụ này vì đang có {0} thông tin phân công năng lực liên quan đến dịch vụ này!\n\n" +
                        "Hãy xóa tất cả phân công năng lực có liên quan đến dịch vụ này rồi thử lại!", count),
                    "Lỗi: Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra dịch vụ này đã có thông tin trong bảng đơn giá?
                if (service.BangGias.Any())
                {
                    int count = service.BangGias.Count;
                    MessageBox.Show(string.Format("Không thê xóa dịch vụ này vì đang có {0} thông tin đơn giá liên quan đến dịch vụ này!\n\n" +
                        "Hãy xóa tất cả đơn giá có liên quan đến dịch vụ này rồi thử lại!", count),
                    "Lỗi: Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Xóa đơn giá => Kiểm tra chi tiết công việc

                if (MessageBox.Show("Bạn có chắc muốn xóa dịch vụ đã chọn?",
                    "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                {
                    return;
                }

                DataProvider.Instance.DB.DichVus.Remove(service);
                DataProvider.Instance.DB.SaveChanges();

                LoadServices();
                CheckServiceID();

                MessageBox.Show("Đã xóa dịch vụ!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa dịch vụ này!",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ------------------------------------- Events -------------------------------------
        private void txbServiceID_TextChanged(object sender, EventArgs e)
        {
            CheckServiceID();
        }

        private void txbServiceName_TextChanged(object sender, EventArgs e)
        {
            CheckServiceName();
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            ChangeModeAddingSer();
        }

        private void btnEditService_Click(object sender, EventArgs e)
        {
            EditService();
        }

        private void btnDeleteService_Click(object sender, EventArgs e)
        {
            DeleteService();
        }

        private void btnShowService_Click(object sender, EventArgs e)
        {
            ShowServices();
        }

        private void txbFindServiceName_TextChanged(object sender, EventArgs e)
        {
            LoadServices();
        }

        private void cbSortService_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadServices();
        }

        private void rbtnSortService_CheckedChanged(object sender, EventArgs e)
        {
            LoadServices();
        }

        private void btnAcceptAddSer_Click(object sender, EventArgs e)
        {
            AddService();
        }

        private void btnCancelAddSer_Click(object sender, EventArgs e)
        {
            ChangeModeEditingSer();
        }

        private void pnlAddingService_VisibleChanged(object sender, EventArgs e)
        {
            CheckServiceName();
        }

        private void tcService_Click(object sender, EventArgs e)
        {
            CheckServiceID();
        }

        #endregion

    }
}
