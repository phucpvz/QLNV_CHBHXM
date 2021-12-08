using MyControlLibrary;
using QLNV_CHBHXM.DAO;
using QLNV_CHBHXM.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNV_CHBHXM.GUI
{
    public partial class FStaff : Form
    {
        private TaiKhoan account;
        public TaiKhoan Account { get => account; set => account = value; }

        private Dictionary<Control, bool> infoFlags;
        public Dictionary<Control, bool> InfoFlags { get => infoFlags; private set => infoFlags = value; }

        private BindingSource services;
        private BindingSource vehicles;
        private BindingSource talents;
        private BindingSource prices;
        private BindingSource details;
        private BindingSource prices_Work;
        private BindingSource salaries;

        public FStaff(TaiKhoan account)
        {
            InitializeComponent();
            Account = account;

            // Thông tin cá nhân
            InitInfoFlags();
            cbEmpStatus.DataSource = new List<string>() { Constants.DANG_LAM, Constants.NGHI };
            LoadYourInfo();
            btnAccept.Enabled = btnCancel.Enabled = false;

            // Dịch vụ
            services = new BindingSource();
            dgrvServices.DataSource = services;
            cbSortServices.DataSource = Constants.SERVICE_HEADER;
            ChangeTitle(dgrvServices, Constants.SERVICE_HEADER);

            // Loại xe
            vehicles = new BindingSource();
            dgrvVehicles.DataSource = vehicles;
            cbSortVehicles.DataSource = Constants.VEHICLE_HEADER;
            ChangeTitle(dgrvVehicles, Constants.VEHICLE_HEADER);

            // Năng lực
            talents = new BindingSource();
            dgrvTalent.DataSource = talents;
            cbSortTalent.DataSource = Constants.TALENT_HEADER;

            AddTalentBinding();
            ChangeTitle(dgrvTalent, Constants.TALENT_HEADER);
            //CheckTalentIDs();

            // Bảng giá
            prices = new BindingSource();
            dgrvPrices.DataSource = prices;
            cbFindPriceStatus.DataSource = new List<string>() { Constants.TAT_CA, Constants.DANG_DUNG, Constants.NGUNG };
            cbSortPrice.DataSource = Constants.PRICE_HEADER;    // LoadPrices()

            ChangeTitle(dgrvPrices, Constants.PRICE_HEADER);
            dgrvPrices.Columns["DonGia"].DefaultCellStyle.Format = "#,##0";

            // Chi tiết công việc
            details = new BindingSource();
            dgrvDetails.DataSource = details;
            cbSortDetail.DataSource = Constants.DETAIL_HEADER;
            AddDetailBinding();
            ChangeTitle(dgrvDetails, Constants.DETAIL_HEADER);
            dgrvDetails.Columns["DonGia"].DefaultCellStyle.Format = "#,##0";
            dgrvDetails.Columns["Tong"].DefaultCellStyle.Format = "#,##0";
            pnlEditDelDetail.Visible = Account.NhanVien.TrangThai == Constants.DANG_LAM;

            // Đơn giá chi tiết công việc
            prices_Work = new BindingSource();
            dgrvPrices_Work.DataSource = prices_Work;
            cbSortPrices_Work.DataSource = Constants.PRICE_HEADER;
            AddYourPricesBinding();
            ChangeTitle(dgrvPrices_Work, Constants.PRICE_HEADER);
            dgrvPrices_Work.Columns["DonGia"].DefaultCellStyle.Format = "#,##0";
            pnlAddDetail.Visible = Account.NhanVien.TrangThai == Constants.DANG_LAM;

            //// Lương
            salaries = new BindingSource();
            dgrvSalaries.DataSource = salaries;
            cbSortSalary.DataSource = Constants.SORT_YOUR_SALARY_HEADER;
            DateTime now = DateTime.Now;
            nmrFromMonth.Value = nmrToMonth.Value = now.Month;
            nmrFromYear.Value = nmrToYear.Value = now.Year;
            ChangeTitle(dgrvSalaries, Constants.SALARY_HEADER);
            dgrvSalaries.Columns["TongDoanhThu"].DefaultCellStyle.Format = "#,##0";
            dgrvSalaries.Columns["LuongThucLanh"].DefaultCellStyle.Format = "#,##0";
            // Ẩn thông tin thừa
            dgrvSalaries.Columns["MaNV"].Visible = false;
            dgrvSalaries.Columns["HoTen"].Visible = false;

            // Khác
            tsmiHello.Text = string.Format("Xin chảo, {0}!", Account.NhanVien.HoTen);
            tcStaff.SelectedTab = tpWork;
        }

        private void AddYourPricesBinding()
        {
            txbPriceID_Work.DataBindings.Add(new Binding("Text", dgrvPrices_Work.DataSource, "MaDG", true, DataSourceUpdateMode.Never));
        }

        #region Chung
        private void ShowMessage_Info(Control control, Label lblError, string message = null)
        {
            if (control is MyTextBox)
            {
                MyTextBox txb = control as MyTextBox;
                // Nhập thông tin đúng
                if (message == null)
                {
                    InfoFlags[txb] = true;
                    lblError.Text = message;
                    lblError.Visible = false;
                    txb.BorderColor = Color.GreenYellow;

                }
                // Nhập thông tin không hợp lệ
                else
                {
                    InfoFlags[txb] = false;
                    lblError.Text = message;
                    lblError.Visible = true;
                    txb.BorderColor = Color.Red;
                }
            }
            else
            {
                // Nhập thông tin đúng
                if (message == null)
                {
                    InfoFlags[control] = true;
                    lblError.Text = message;
                    lblError.Visible = false;
                }
                // Nhập thông tin không hợp lệ
                else
                {
                    InfoFlags[control] = false;
                    lblError.Text = message;
                    lblError.Visible = true;
                }
            }

            Review_Info(InfoFlags, btnAccept);
        }

        private void Review_Info(Dictionary<Control, bool> flags, Button btn)
        {
            btn.Enabled = CheckChanged() && flags.All(f => f.Value == true);
        }

        private void ChangeTitle(DataGridView dgrv, string[] headers)
        {
            int columnCount = headers.Length;
            for (int i = 0; i < columnCount; i++)
            {
                dgrv.Columns[i].HeaderText = headers[i];
            }
        }

        public void RefreshAll()
        {
            foreach (var entity in DataProvider.Instance.DB.ChangeTracker.Entries())
            {
                entity.Reload();
            }
        }

        private void Paging<T>(BindingSource employees, List<T> list, NumericUpDown nmrLineNumber, TextBox txbTotalPages, NumericUpDown nmrPageNumber)
        {
            //------------------------------------------- Phân trang ---------------------------------------------
            // Tìm số bản ghi
            int records = list.Count;
            // Số dòng hiển thị trên 1 trang
            int lineNumber = (int)nmrLineNumber.Value;

            // => Tổng số trang = Số bản ghi / Số dòng hiển thị trên 1 trang
            int totalPages = (int)Math.Ceiling((double)records / lineNumber);
            txbTotalPages.Text = totalPages.ToString();

            // Tạo số trang khép kín
            if (nmrPageNumber.Value > totalPages)
            {
                nmrPageNumber.Value = 1;
            }
            else if (nmrPageNumber.Value < 1)
            {
                nmrPageNumber.Value = (totalPages == 0) ? 1 : totalPages;
            }
            int pageNumber = (int)nmrPageNumber.Value;

            if (totalPages == 0)
            {
                employees.DataSource = list;
            }
            else
            {
                employees.DataSource = list.Skip(lineNumber * (pageNumber - 1)).Take(lineNumber);
            }
        }

        private void tsmiLogOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsmiChangePassword_Click(object sender, EventArgs e)
        {
            FChangePassword f = new FChangePassword(Account);
            f.ShowDialog();
        }

        private void tsmiTutorial_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + @"\..\..\Hướng dẫn sử dụng - Phần mềm quản lý nhân viên cửa hàng bảo hành xe máy.docx");
        }

        #endregion


        #region Thông tin cá nhân
        //===================================================== Thông tin cá nhân =====================================================
        private void LoadYourInfo()
        {
            NhanVien you = Account.NhanVien;
            txbEmpID.Text = you.MaNV;
            txbName.Text = you.HoTen;
            switch (you.GioiTinh)
            {
                case "Nam":
                    rbtnMale.Checked = true;
                    break;
                case "Nữ":
                    rbtnFemale.Checked = true;
                    break;
            }
            dtpBirthday.Value = you.NgaySinh;
            txbAddress.Text = you.DiaChi;
            txbPhone.Text = you.SoDT;
            txbEmail.Text = you.Email;
            txbTypeName.Text = you.LoaiNV.TenLoai;
            cbEmpStatus.SelectedIndex = cbEmpStatus.Items.IndexOf(you.TrangThai);
        }

        private void InitInfoFlags()
        {
            InfoFlags = new Dictionary<Control, bool>
            {
                { txbName, true },
                { dtpBirthday, true },
                { txbAddress, true },
                { txbPhone, true },
                { txbEmail, true },
            };
        }

        private bool CheckChanged()
        {
            NhanVien you = Account.NhanVien;
            string name = txbName.Text;
            string gender = (rbtnMale.Checked) ? "Nam" : "Nữ";
            DateTime birthday = dtpBirthday.Value;
            string address = txbAddress.Text;
            string phone = txbPhone.Text;
            string email = txbEmail.Text;
            string status = cbEmpStatus.SelectedItem.ToString();

            return btnCancel.Enabled = name != you.HoTen || gender != you.GioiTinh || birthday != you.NgaySinh 
                || address != you.DiaChi || phone != you.SoDT || email != you.Email || status != you.TrangThai;
        }

        private void CheckName()
        {
            string name = txbName.Text;
            if (string.IsNullOrEmpty(name))
            {
                ShowMessage_Info(txbName, lblName, "Họ tên nhân viên không được để trống!");
                return;
            }

            if (!Regex.IsMatch(name, @"^[a-zA-Z\sàáãạảăắằẳẵặâấầẩẫậèéẹẻẽêềếểễệđìíĩỉịòóõọỏôốồổỗộơớờởỡợùúũụủưứừửữựỳỵỷỹý
                                            ÀÁÃẠẢĂẮẰẲẴẶÂẤẦẨẪẬÈÉẸẺẼÊỀẾỂỄỆĐÌÍĨỈỊÒÓÕỌỎÔỐỒỔỖỘƠỚỜỞỠỢÙÚŨỤỦƯỨỪỬỮỰỲỴỶỸÝ]+$"))
            {
                ShowMessage_Info(txbName, lblName, "Họ tên nhân viên chỉ được bao gồm các chữ cái a-z, A-Z\n" +
                    "(có hoặc không dấu) và khoảng trắng giữa các từ!");
                return;
            }

            ShowMessage_Info(txbName, lblName);
        }

        private void CheckBirthday()
        {
            if (dtpBirthday.Value > DateTime.Now.AddYears(-18))
            {
                ShowMessage_Info( dtpBirthday, lblBirthday, "Nhân viên phải từ đủ 18 tuổi trở lên!");
                ptbBirthday.Image = imlTickCross.Images[1];
            }
            else
            {
                ShowMessage_Info(dtpBirthday, lblBirthday);
                ptbBirthday.Image = imlTickCross.Images[0];
            }
        }

        private void CheckAddress()
        {
            string address = txbAddress.Text;
            if (string.IsNullOrEmpty(address))
            {
                ShowMessage_Info(txbAddress, lblAddress, "Địa chỉ không được để trống!");
                return;
            }

            ShowMessage_Info(txbAddress, lblAddress);
        }

        private void CheckPhone()
        {
            string phone = txbPhone.Text;
            if (string.IsNullOrEmpty(phone))
            {
                ShowMessage_Info(txbPhone, lblPhone, "Số điện thoại không được để trống!");
                return;
            }

            if (!Regex.IsMatch(phone, @"^0{1}\d{9}$"))
            {
                ShowMessage_Info(txbPhone, lblPhone, "Số điện thoại phải là số 10 chữ số và bắt đầu bằng chữ số 0!");
                return;
            }

            ShowMessage_Info(txbPhone, lblPhone);
        }

        private void CheckEmail()
        {
            string email = txbEmail.Text;
            if (string.IsNullOrEmpty(email))
            {
                ShowMessage_Info(txbEmail, lblEmail, "Email không được để trống!");
                return;
            }

            if (!Regex.IsMatch(email, @"^[a-zA-Z]+[a-zA-Z0-9]*@[a-zA-Z]+(\.{1}[a-zA-Z]+)+$"))
            {
                ShowMessage_Info(txbEmail, lblEmail, "Định dạng email không hợp lệ!");
                return;
            }

            ShowMessage_Info(txbEmail, lblEmail);
        }

        private void SaveChanges()
        {
            if (MessageBox.Show("Bạn có chắc muốn thay đổi thông tin cá nhân của mình không?",
                    "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
            {
                return;
            }

            try
            {
                NhanVien you = Account.NhanVien;
                you.HoTen = txbName.Text;
                you.GioiTinh = (rbtnMale.Checked) ? "Nam" : "Nữ";
                you.NgaySinh = dtpBirthday.Value;
                you.DiaChi = txbAddress.Text;
                you.SoDT = txbPhone.Text;
                you.Email = txbEmail.Text;
                you.TrangThai = cbEmpStatus.SelectedItem.ToString();

                DataProvider.Instance.DB.SaveChanges();
                btnAccept.Enabled = btnCancel.Enabled = false;

                tsmiHello.Text = string.Format("Xin chảo, {0}!", Account.NhanVien.HoTen);
                LoadTalents();
                pnlAddDetail.Visible = pnlEditDelDetail.Visible = you.TrangThai == Constants.DANG_LAM;

                MessageBox.Show("Đã thay đổi thông tin cá nhân của bạn thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi thay đổi thông tin cá nhân của bạn!\n\n",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ------------------------------------- Events -------------------------------------
        private void btnAccept_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void txbName_TextChanged(object sender, EventArgs e)
        {
            CheckName();
        }

        private void rbtnMale_CheckedChanged(object sender, EventArgs e)
        {
            Review_Info(InfoFlags, btnAccept);
        }

        private void cbEmpStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Review_Info(InfoFlags, btnAccept);
        }

        private void dtpBirthday_ValueChanged(object sender, EventArgs e)
        {
            CheckBirthday();
        }

        private void txbAddress_TextChanged(object sender, EventArgs e)
        {
            CheckAddress();
        }

        private void txbPhone_TextChanged(object sender, EventArgs e)
        {
            CheckPhone();
        }

        private void txbEmail_TextChanged(object sender, EventArgs e)
        {
            CheckEmail();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadYourInfo();
        }
        
        #endregion


        #region Dịch vụ
        //===================================================== Dịch vụ =====================================================
        private void LoadServices()
        {
            /* 
             * Tìm kiếm dịch vụ 
             */
            string serviceName = txbFindServiceName.Text.Trim();

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
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm và sắp xếp dịch vụ!",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowServices()
        {
            txbFindServiceName.Clear();
            cbSortServices.SelectedIndex = 0;
            rbtnAscService.Checked = true;
        }
        // ------------------------------------- Events -------------------------------------
        private void txbFindServiceName_TextChanged(object sender, EventArgs e)
        {
            LoadServices();
        }

        private void cbSortServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadServices();
        }

        private void rbtnAscService_CheckedChanged(object sender, EventArgs e)
        {
            LoadServices();
        }

        private void btnShowService_Click(object sender, EventArgs e)
        {
            ShowServices();
        }
        #endregion


        #region Loại xe
        //===================================================== Loại xe =====================================================
        private void LoadVehicles()
        {
            /* 
             * Tìm kiếm loại xe
             */
            string vehicleName = txbFindVehicleName.Text.Trim();

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
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm và sắp xếp loại xe!",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowVehicles()
        {
            txbFindVehicleName.Clear();
            cbSortVehicles.SelectedIndex = 0;
            rbtnAscVehicle.Checked = true;
        }

        // ------------------------------------- Events -------------------------------------
        private void txbFindVehicleName_TextChanged(object sender, EventArgs e)
        {
            LoadVehicles();
        }

        private void cbSortVehicles_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadVehicles();
        }

        private void rbtnAscVehicle_CheckedChanged(object sender, EventArgs e)
        {
            LoadVehicles();
        }

        private void btnShowVehicles_Click(object sender, EventArgs e)
        {
            ShowVehicles();
        }
        #endregion


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
                LoadPrices_Work();

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
            string empID = txbEmpID_Talent.Text;
            lblError_Talent.Visible = !(btnDeleteTalent.Enabled = !string.IsNullOrEmpty(empID) && empID == Account.MaNV);
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
            FAddYourTalent f = new FAddYourTalent(Account);
            f.TalentAdded += F_TalentAdded;
            f.ShowDialog();
        }

        private void F_TalentAdded(object sender, EventArgs e)
        {
            LoadTalents();
            LoadPrices_Work();
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


        #region Bảng giá
        //===================================================== Bảng giá =====================================================
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

        private void ShowPrices()
        {
            txbFindServiceName_Price.Clear();
            txbFindVehicleName_Price.Clear();
            cbFindPriceStatus.SelectedIndex = 0;

            cbSortPrice.SelectedIndex = 0;
            rbtnAscPrice.Checked = true;
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


        #region Công việc
        //===================================================== Công việc =====================================================
        private void AddDetailBinding()
        {
            nmrEditAmount.DataBindings.Add(new Binding("Value", dgrvDetails.DataSource, "SoLuong", true, DataSourceUpdateMode.Never));
        }

        private void LoadDetails()
        {
            // Tìm mã công việc theo mã nhân viên và ngày làm
            string empID = Account.MaNV;

            // Chú ý: Chỉ lấy phần ngày
            DateTime workDay = dtpWorkDay.Value.Date;
            CongViec work;
            try
            {
                work = DataProvider.Instance.DB.CongViecs.Find(empID, workDay);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm công việc trong ngày của bạn!\n\n",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hiển thị tổng doanh thu trong ngày
            int workID;
            if (work == null)
            {
                workID = -1;
                txbTotalRevenue.Text = "0";
            }
            else
            {
                workID = work.MaCV;
                txbTotalRevenue.Text = string.Format("{0:#,###}", work.TongTien);
            }

            /* 
             * Tìm kiếm chi tiết công việc
             */
            string serviceName = txbFindServiceName_Detail.Text.Trim();
            string vehicleName = txbFindVehicleName_Detail.Text.Trim();

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

            bool isToday = dtpWorkDay.Value.Date == DateTime.Now.Date;
            nmrEditAmount.Enabled = btnEditDetail.Enabled = btnDeleteDetail.Enabled = isToday && (dgrvDetails.RowCount > 0);
            nmrAddAmount.Enabled = btnAddDetail.Enabled = isToday && (dgrvPrices_Work.RowCount > 0);

            lblNotTodayError.Visible = !isToday;
            lblEditDelError.Visible = dgrvDetails.RowCount == 0;
        }

        private void LoadPrices_Work()
        {
            /* 
             * Tìm kiếm đơn giá
             */
            string empID = Account.MaNV;
            string serviceName = txbFindServiceName_AddDetail.Text.Trim();
            string vehicleName = txbFindVehicleName_AddDetail.Text.Trim();

            /* 
             * Sắp xếp đơn giá
             */
            int idx = cbSortPrices_Work.SelectedIndex;
            if (idx == -1)
            {
                return;
            }
            string columnName = Constants.PRICE_COLUMN[idx];

            string sortDirection = rbtnAscPrice_Work.Checked ? "ASC" : "DESC";

            try
            {
                prices_Work.DataSource = DataProvider.Instance.DB.USP_TimKiemVaSapXepDonGiaTheoNhanVien(empID, serviceName, vehicleName, columnName, sortDirection);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm và sắp xếp thông tin đơn giá của bạn!",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            bool isToday = dtpWorkDay.Value.Date == DateTime.Now.Date;
            nmrAddAmount.Enabled = btnAddDetail.Enabled = isToday && (dgrvPrices_Work.RowCount > 0);

            lblNotTodayError.Visible = !isToday;
            lblAddPricesWorkError.Visible = dgrvPrices_Work.RowCount == 0;
        }

        private void AddWorkDetail()
        {
            if (MessageBox.Show("Bạn có chắc muốn thêm đơn giá với số lượng tương ứng vào danh sách chi tiết công việc của mình?",
                    "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
            {
                return;
            }

            bool isNew = false;

            string empID = Account.MaNV;
            DateTime workDay = dtpWorkDay.Value.Date;
            int priceID = Convert.ToInt32(txbPriceID_Work.Text);
            int addAmount = (int)nmrAddAmount.Value;

            // Xác định đã có bản ghi công việc trong ngày của nhân viên chưa
            // Nếu chưa có thì tạo công việc trong ngày mới trước khi thêm chi tiết công việc
            int workID;
            try
            {
                NhanVien employee = DataProvider.Instance.DB.NhanViens.Find(empID);
                CongViec work = employee.CongViecs.FirstOrDefault(w => w.NgayLam == workDay);

                if (work == null)
                {
                    // Thêm mới công việc
                    work = new CongViec() { MaNV = empID, NgayLam = workDay, TongTien = 0 };
                    employee.CongViecs.Add(work);
                    DataProvider.Instance.DB.SaveChanges();

                    // Có TRIGGER => Tải lại
                    RefreshAll();

                    // Lấy mã của công việc vừa thêm vào
                    workID = work.MaCV;
                }
                else
                {
                    workID = work.MaCV;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm công việc trong ngày của bạn!",
                        "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            // Xác định đã có chi tiết công việc tương ứng trong ngày của nhân viên
            try
            {
                ChiTietCV detail = DataProvider.Instance.DB.ChiTietCVs.Find(new object[] { workID, priceID });

                // Nếu chưa có thì thêm mới chi tiết công việc
                if (detail == null)
                {
                    detail = new ChiTietCV() { MaCV = workID, MaDG = priceID, Soluong = addAmount };
                    DataProvider.Instance.DB.ChiTietCVs.Add(detail);
                    isNew = true;
                }
                // Nếu đã có thì cộng thêm số lượng mới
                else
                {
                    detail.Soluong += addAmount;
                }

                DataProvider.Instance.DB.SaveChanges();

                // Có TRIGGER => Reload
                RefreshAll();

                LoadDetails();
                LoadSalaries();
                if (isNew)
                {
                    MessageBox.Show("Đã thêm chi tiết công việc mới của bạn thành công!",
                   "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đã cập nhật số lượng của chi tiết công việc của bạn thành công!",
                   "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi thêm hoặc cập nhật số lượng chi tiết công việc của bạn!",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowWorkDetail()
        {
            txbFindServiceName_Detail.Clear();
            txbFindVehicleName_Detail.Clear();
            cbSortDetail.SelectedIndex = 0;
            rbtnAscWorkDetail.Checked = true;
        }

        private void EditWorkDetail()
        {
            if (MessageBox.Show("Bạn có chắc muốn sửa chi tiết công việc đã chọn không?",
                     "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
            {
                return;
            }

            try
            {
                DateTime workDay = dtpWorkDay.Value.Date;
                NhanVien employee = Account.NhanVien;
                CongViec work = employee.CongViecs.FirstOrDefault(w => w.NgayLam == workDay);

                int workID = work.MaCV;
                int priceID = (int)dgrvDetails.SelectedCells[0].OwningRow.Cells["MaDG"].Value;
                int amount = (int)nmrEditAmount.Value;

                ChiTietCV detail = DataProvider.Instance.DB.ChiTietCVs.Find(new object[] { workID, priceID });
                detail.Soluong = amount;
                DataProvider.Instance.DB.SaveChanges();

                // Có trigger => Phải load lại
                RefreshAll();

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

            try
            {
                DateTime workDay = dtpWorkDay.Value.Date;
                NhanVien employee = Account.NhanVien;
                CongViec work = employee.CongViecs.FirstOrDefault(w => w.NgayLam == workDay);

                int workID = work.MaCV;
                int priceID = (int)dgrvDetails.SelectedCells[0].OwningRow.Cells["MaDG"].Value;

                ChiTietCV detail = DataProvider.Instance.DB.ChiTietCVs.Find(new object[] { workID, priceID });
                DataProvider.Instance.DB.ChiTietCVs.Remove(detail);
                DataProvider.Instance.DB.SaveChanges();

                // Có trigger => Phải load lại
                RefreshAll();

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

        private void ShowPrices_Work()
        {
            txbFindServiceName_AddDetail.Clear();
            txbFindVehicleName_AddDetail.Clear();
            cbSortPrices_Work.SelectedIndex = 0;
            rbtnAscPrice_Work.Checked = true;
        }
        // ------------------------------------- Events -------------------------------------
        private void dtpWorkDay_ValueChanged(object sender, EventArgs e)
        {
            LoadDetails();
        }

        private void txbFindServiceName_Detail_TextChanged(object sender, EventArgs e)
        {
            LoadDetails();
        }

        private void cbSortWorkDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDetails();
        }

        private void rbtnAscWorkDetail_CheckedChanged(object sender, EventArgs e)
        {
            LoadDetails();
        }

        private void txbFindServiceName_AddDetail_TextChanged(object sender, EventArgs e)
        {
            LoadPrices_Work();
        }

        private void btnAddWorkDetail_Click(object sender, EventArgs e)
        {
            AddWorkDetail();
        }

        private void btnShowWorkDetail_Click(object sender, EventArgs e)
        {
            ShowWorkDetail();
        }

        private void btnShowPrices_Detail_Click(object sender, EventArgs e)
        {
            ShowPrices_Work();
        }

        private void btnEditWorkDetail_Click(object sender, EventArgs e)
        {
            EditWorkDetail();
        }

        private void btnDeleteWorkDetail_Click(object sender, EventArgs e)
        {
            DeleteWorkDetail();
        }

        private void cbSortPrices_Work_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPrices_Work();
        }

        private void rbtnAscPrice_Work_CheckedChanged(object sender, EventArgs e)
        {
            LoadPrices_Work();
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            dtpWorkDay.Value = DateTime.Now;
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


        #region Lương
        //===================================================== Lương =====================================================
        private void LoadSalaries()
        {
            string empID = Account.MaNV;
            string name = "";

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

            string columnName = Constants.SORT_YOUR_SALARY_COLUMN[idx];

            string sortDirection = rbtnAscSalary.Checked ? "ASC" : "DESC";

            try
            {
                var list = DataProvider.Instance.DB.USP_TimKiemVaSapXepLuong
                    (empID, name, fromNums, toNums, fromMonth, toMonth, fromYear, toYear, columnName, sortDirection).ToList();

                Paging(salaries, list, nmrLineNumber_Salary, txbTotalPage_Salary, nmrPageNumber_Salary);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm và sắp xếp lương của bạn!\n\n",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowYou_ThisMonth()
        {
            nmrFromNums.Value = nmrFromNums.Minimum;
            nmrToNums.Value = nmrToNums.Maximum;

            DateTime now = DateTime.Now;
            nmrFromMonth.Value = nmrToMonth.Value = now.Month;
            nmrFromYear.Value = nmrToYear.Value = now.Year;
        }

        private void ShowYou_AllTime()
        {
            nmrFromNums.Value = nmrFromNums.Minimum;
            nmrToNums.Value = nmrToNums.Maximum;

            nmrFromMonth.Value = nmrFromMonth.Minimum;
            nmrToMonth.Value = nmrToMonth.Maximum;
            nmrFromYear.Value = nmrFromYear.Minimum;
            nmrToYear.Value = nmrToYear.Maximum;
        }

        // ------------------------------------- Events -------------------------------------
        private void btnYou_ThisMonth_Click(object sender, EventArgs e)
        {
            ShowYou_ThisMonth();
        }

        private void btnYou_AllTime_Click(object sender, EventArgs e)
        {
            ShowYou_AllTime();
        }

        private void nmrFromNums_ValueChanged(object sender, EventArgs e)
        {
            LoadSalaries();
        }

        private void cbSortSalary_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSalaries();
        }

        private void rbtnAscSalary_CheckedChanged(object sender, EventArgs e)
        {
            LoadSalaries();
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

        #endregion

        
    }
}
