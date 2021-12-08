using QLNV_CHBHXM.DAO;
using QLNV_CHBHXM.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNV_CHBHXM.GUI
{
    public partial class FAddPrice : Form
    {
        private event EventHandler priceAdded;
        public event EventHandler PriceAdded
        {
            add { priceAdded += value; }
            remove { priceAdded -= value; }
        }

        private BindingSource services;
        private BindingSource vehicles;

        public FAddPrice()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            services = new BindingSource();
            dgrvServices.DataSource = services;
            vehicles = new BindingSource();
            dgrvVehicles.DataSource = vehicles;
            cbPriceStatus.DataSource = new List<string>() { Constants.DANG_DUNG, Constants.NGUNG };
            AddBindings();

            LoadServices();
            LoadVehicles();
            ChangeTitle(dgrvServices, Constants.SERVICE_HEADER);
            ChangeTitle(dgrvVehicles, Constants.VEHICLE_HEADER);
        }

        private void ChangeTitle(DataGridView dgrv, string[] headers)
        {
            int columnCount = headers.Length;
            for (int i = 0; i < columnCount; i++)
            {
                dgrv.Columns[i].HeaderText = headers[i];
            }
        }

        private void CheckAddPriceIDs()
        {
            btnAccept.Enabled = nmrPrice.Enabled = !string.IsNullOrEmpty(txbServiceID.Text) && !string.IsNullOrEmpty(txbVehicleID.Text);
            lblError.Visible = !btnAccept.Enabled;
        }

        private void AddBindings()
        {
            txbServiceID.DataBindings.Add(new Binding("Text", dgrvServices.DataSource, "MaDV", true, DataSourceUpdateMode.Never));
            txbVehicleID.DataBindings.Add(new Binding("Text", dgrvVehicles.DataSource, "MaLX", true, DataSourceUpdateMode.Never));
        }

        private void OnPriceAdded()
        {
            if (priceAdded != null)
            {
                priceAdded(this, new EventArgs());
            }
        }

        private void LoadVehicles()
        {
            /* 
             * Tìm kiếm loại xe
             */
            string vehicleName = txbLikeVehicleName.Text;

            string columnName = Constants.VEHICLE_COLUMN[0];

            string sortDirection = "ASC";

            try
            {
                vehicles.DataSource = DataProvider.Instance.DB.USP_TimKiemVaSapXepLoaiXe(vehicleName, columnName, sortDirection);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm loại xe!",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadServices()
        {
            /* 
              * Tìm kiếm dịch vụ 
              */
            string serviceName = txbLikeServiceName.Text;

            string columnName = Constants.SERVICE_COLUMN[0];

            string sortDirection = "ASC";

            try
            {
                services.DataSource = DataProvider.Instance.DB.USP_TimKiemVaSapXepDichVu(serviceName, columnName, sortDirection);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm dịch vụ!",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefreshAll()
        {
            foreach (var entity in DataProvider.Instance.DB.ChangeTracker.Entries())
            {
                entity.Reload();
            }
        }

        private void AddPrice()
        {
            int serviceID = Convert.ToInt32(txbServiceID.Text);
            int vehicleID = Convert.ToInt32(txbVehicleID.Text);
            int price = (int)nmrPrice.Value;
            string status = cbPriceStatus.SelectedItem.ToString();

            try
            {
                // Kiểm tra xem đã tồn tại đơn giá có cùng mã dịch vụ, mã loại xe và giá trị đơn giá chưa?
                if (DataProvider.Instance.DB.BangGias.Any(p => p.MaDV == serviceID && p.MaLX == vehicleID && p.DonGia == price))
                {
                    MessageBox.Show("Đã tồn tại đơn giá có cùng mã dịch vụ, mã loại xe và giá trị đơn giá với đơn giá bạn muốn thêm!",
                        "Lỗi: Trùng lặp dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                BangGia priceList = new BangGia() { MaDV = serviceID, MaLX = vehicleID, DonGia = price, TrangThai = status };
                DataProvider.Instance.DB.BangGias.Add(priceList);
                DataProvider.Instance.DB.SaveChanges();

                // Có trigger => Phải load lại
                RefreshAll();
                OnPriceAdded();

                MessageBox.Show("Đã thêm đơn giá mới!",
                   "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi thêm đơn giá mới!",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            AddPrice();
        }

        private void txbFindVehicleID_TextChanged(object sender, EventArgs e)
        {
            CheckAddPriceIDs();
        }

        private void txbFindServiceName_TextChanged(object sender, EventArgs e)
        {
            LoadServices();
        }

        private void txbFindVehicleName_TextChanged(object sender, EventArgs e)
        {
            LoadVehicles();
        }
    }
}
