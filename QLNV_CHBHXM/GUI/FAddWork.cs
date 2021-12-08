using QLNV_CHBHXM.DAO;
using QLNV_CHBHXM.DTO;
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
    public partial class FAddWork : Form
    {
        private DateTime workDay;
        public DateTime WorkDay { get => workDay; set => workDay = value; }

        private event EventHandler workAdded;
        public event EventHandler WorkAdded
        {
            add { workAdded += value; }
            remove { workAdded -= value; }
        }

        private BindingSource employees;
        private BindingSource prices;


        public FAddWork(DateTime workDay)
        {
            InitializeComponent();
            WorkDay = workDay.Date; //WorkDay = workDay

            Begin();
        }

        private void Begin()
        {
            employees = new BindingSource();
            dgrvEmployees.DataSource = employees;
            prices = new BindingSource();
            dgrvPrices.DataSource = prices;
            AddBindings();

            LoadEmployees();
            LoadPricesByEmployee();
            ChangeTitle(dgrvEmployees, Constants.EMP_HEADER);
            ChangeTitle(dgrvPrices, Constants.PRICE_HEADER);
            dgrvPrices.Columns["DonGia"].DefaultCellStyle.Format = "#,##0";

            txbWorkDay.Text = WorkDay.ToString("dd/MM/yyyy");
        }

        private void ChangeTitle(DataGridView dgrv, string[] headers)
        {
            int columnCount = headers.Length;
            for (int i = 0; i < columnCount; i++)
            {
                dgrv.Columns[i].HeaderText = headers[i];
            }
        }

        private void ShowWorkID()
        {
            string empID = txbEmpID.Text;
            var query = from cv in DataProvider.Instance.DB.CongViecs
                        where cv.MaNV == txbEmpID.Text && cv.NgayLam == WorkDay
                        select cv.MaCV;

            int workID = query.FirstOrDefault();
            txbWorkID.Text = (workID == 0) ? "" : workID.ToString();
        }

        private void CheckAddWorkIDs()
        {
            btnAccept.Enabled = nmrAmount.Enabled = !string.IsNullOrEmpty(txbEmpID.Text) && !string.IsNullOrEmpty(txbPriceID.Text);
            lblError.Visible = !btnAccept.Enabled;
        }

        private void LoadPricesByEmployee()
        {
            /* 
             * Tìm kiếm đơn giá
             */
            string empID = txbEmpID.Text;
            string serviceName = txbSearchServiceName.Text;
            string vehicleName = txbSearchVehicleName.Text;

            string columnName = "TenDV, TenLX";
            string sortDirection = "ASC";

            try
            {
                prices.DataSource = DataProvider.Instance.DB.USP_TimKiemVaSapXepDonGiaTheoNhanVien(empID, serviceName, vehicleName, columnName, sortDirection);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm thông tin đơn giá!\n\n",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEmployees()
        {
            string empID = txbSearchEmpID.Text;
            string name = txbSearchName.Text;

            try
            {
                employees.DataSource = DataProvider.Instance.DB.USP_TimKiemNhanVienRutGon(empID, name);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm nhân viên!\n\n",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnWorkAdded()
        {
            if (workAdded != null)
            {
                workAdded(this, new EventArgs());
            }
        }

        private void AddBindings()
        {
            txbEmpID.DataBindings.Add(new Binding("Text", dgrvEmployees.DataSource, "MaNV", true, DataSourceUpdateMode.Never));
            txbPriceID.DataBindings.Add(new Binding("Text", dgrvPrices.DataSource, "MaDG", true, DataSourceUpdateMode.Never));
        }

        public void RefreshAll()
        {
            foreach (var entity in DataProvider.Instance.DB.ChangeTracker.Entries())
            {
                entity.Reload();
            }
        }

        private void AddWorkDetail()
        {
            bool isNew = false;

            // Đã kiểm tra ngoại lệ trước đó
            string empID = txbEmpID.Text;
            int priceID = Convert.ToInt32(txbPriceID.Text);
            int amount = (int)nmrAmount.Value;

            int workID;
            // Xác định đã có bản ghi công việc trong ngày của nhân viên
            if (string.IsNullOrEmpty(txbWorkID.Text))
            {
                try
                {
                    // Thêm mới công việc
                    CongViec work = new CongViec() { MaNV = empID, NgayLam = WorkDay, TongTien = 0 };
                    DataProvider.Instance.DB.CongViecs.Add(work);
                    DataProvider.Instance.DB.SaveChanges();

                    // Có trigger => Phải load lại
                    RefreshAll();

                    // Xác nhận lại có công việc
                    ShowWorkID();
                    // Lấy mã của công việc vừa thêm vào
                    workID = work.MaCV;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi thêm công việc mới!\n\n",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                workID = Convert.ToInt32(txbWorkID.Text);
            }

            // Xác định đã có chi tiết công việc tương ứng trong ngày của nhân viên
            try
            {
                ChiTietCV workDetail = DataProvider.Instance.DB.ChiTietCVs.Find(new object[] { workID, priceID });

                // Nếu chưa có thì thêm mới chi tiết công việc
                if (workDetail == null)
                {
                    workDetail = new ChiTietCV() { MaCV = workID, MaDG = priceID, Soluong = amount };
                    DataProvider.Instance.DB.ChiTietCVs.Add(workDetail);
                    isNew = true;
                }
                // Nếu đã có thì cộng thêm số lượng mới
                else
                {
                    workDetail.Soluong += amount;
                }

                DataProvider.Instance.DB.SaveChanges();
                // Có trigger => Phải load lại
                RefreshAll();
                OnWorkAdded();
                
                if (isNew)
                {
                    MessageBox.Show("Đã thêm chi tiết công việc mới thành công!",
                   "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đã cập nhật số lượng của chi tiết công việc thành công!",
                   "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi thêm hoặc cập nhật số lượng chi tiết công việc!\n\n",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txbEmpID_TextChanged(object sender, EventArgs e)
        {
            ShowWorkID();
            LoadPricesByEmployee();
            CheckAddWorkIDs();
        }

        private void txbPriceID_TextChanged(object sender, EventArgs e)
        {
            CheckAddWorkIDs();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            AddWorkDetail();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txbSearchEmpIDName_TextChanged(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void txbSearchServiceVehicleName_TextChanged(object sender, EventArgs e)
        {
            LoadPricesByEmployee();
        }

    }
}
