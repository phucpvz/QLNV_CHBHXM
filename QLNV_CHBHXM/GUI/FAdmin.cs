using MyControlLibrary;
using QLNV_CHBHXM.DAO;
using QLNV_CHBHXM.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNV_CHBHXM.GUI
{
    public partial class FAdmin : Form
    {
        private TaiKhoan account;
        public TaiKhoan Account { get => account; set => account = value; }

        // Lưu trạng thái đúng/sai của các trường dữ liệu
        private Dictionary<Control, bool> employeeFlags;
        public Dictionary<Control, bool> EmployeeFlags { get => employeeFlags; private set => employeeFlags = value; }

        private Dictionary<Control, bool> serviceFlags;
        public Dictionary<Control, bool> ServiceFlags { get => serviceFlags; private set => serviceFlags = value; }

        private Dictionary<Control, bool> vehicleFlags;
        public Dictionary<Control, bool> VehicleFlags { get => vehicleFlags; set => vehicleFlags = value; }

        private BindingSource employees;
        private BindingSource services;
        private BindingSource vehicles;
        private BindingSource talents;
        private BindingSource prices;
        private BindingSource works;
        private BindingSource details;
        private BindingSource salaries;

        // Kích hoạt đơn giá
        private PlanData plan;
        public PlanData Plan { get => plan; set => plan = value; }

        public FAdmin(TaiKhoan account)
        {
            InitializeComponent();
            Account = account;
            SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);

            LoadData();
        }

        private void LoadData()
        {
            // Nhân viên
            employees = new BindingSource();
            dgrvEmployees.DataSource = employees;
            InitEmployeeFlags();
            LoadComboType(cbType);
            cbEmpStatus.DataSource = new List<string>() { Constants.DANG_LAM, Constants.NGHI };
            cbFindType.DataSource = new List<string>() { Constants.TAT_CA, Constants.NHAN_VIEN, Constants.QUAN_LY };
            cbFindEmpStatus.DataSource = new List<string>() { Constants.TAT_CA, Constants.DANG_LAM, Constants.NGHI };
            cbSortEmployees.DataSource = Constants.EMPLOYEE_HEADER; // LoadEmployees()

            AddEmpBinding();
            ChangeTitle(dgrvEmployees, Constants.EMPLOYEE_HEADER);
            dgrvEmployees.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgrvEmployees.Columns["LuongCoBan"].DefaultCellStyle.Format = "#,##0";
            dgrvEmployees.Columns["LuongCoBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            CheckEmpID();

            AddAccountBinding();
            CheckUsername();

            SetOpenExcelFileDlg();

            // Dịch vụ
            services = new BindingSource();
            dgrvServices.DataSource = services;
            InitServiceFlags();
            cbSortServices.DataSource = Constants.SERVICE_HEADER;

            AddServiceBinding();
            ChangeTitle(dgrvServices, Constants.SERVICE_HEADER);
            CheckServiceID();

            // Loại xe
            vehicles = new BindingSource();
            dgrvVehicles.DataSource = vehicles;
            InitVehicleFlags();
            cbSortVehicles.DataSource = Constants.VEHICLE_HEADER;

            AddVehiclesBinding();
            ChangeTitle(dgrvVehicles, Constants.VEHICLE_HEADER);
            CheckVehicleID();

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
            AddPricesBinding();

            cbPriceStatus.DataSource = new List<string>() { Constants.DANG_DUNG, Constants.NGUNG };
            cbFindPriceStatus.DataSource = new List<string>() { Constants.TAT_CA, Constants.DANG_DUNG, Constants.NGUNG };
            cbSortPrice.DataSource = Constants.PRICE_HEADER;    // LoadPrices()

            ChangeTitle(dgrvPrices, Constants.PRICE_HEADER);
            dgrvPrices.Columns["DonGia"].DefaultCellStyle.Format = "#,##0";
            CheckPriceID();

            // Công việc
            works = new BindingSource();
            dgrvWorks.DataSource = works;
            AddWorkBinding();
            cbSortWork.DataSource = Constants.WORK_HEADER;
            ChangeTitle(dgrvWorks, Constants.WORK_HEADER);
            dgrvWorks.Columns["TongTien"].DefaultCellStyle.Format = "#,##0";

            // Chi tiết công việc
            details = new BindingSource();
            dgrvDetails.DataSource = details;
            AddDetailBinding();
            cbSortDetail.DataSource = Constants.DETAIL_HEADER;
            ChangeTitle(dgrvDetails, Constants.DETAIL_HEADER);
            dgrvDetails.Columns["DonGia"].DefaultCellStyle.Format = "#,##0";
            dgrvDetails.Columns["Tong"].DefaultCellStyle.Format = "#,##0";

            // Lương
            salaries = new BindingSource();
            dgrvSalaries.DataSource = salaries;
            cbSortSalary.DataSource = Constants.SORT_SALARY_HEADER;
            DateTime now = DateTime.Now;
            nmrFromMonth.Value = nmrToMonth.Value = now.Month;
            nmrFromYear.Value = nmrToYear.Value = now.Year;
            ChangeTitle(dgrvSalaries, Constants.SALARY_HEADER);
            dgrvSalaries.Columns["TongDoanhThu"].DefaultCellStyle.Format = "#,##0";
            dgrvSalaries.Columns["LuongThucLanh"].DefaultCellStyle.Format = "#,##0";

            // Khác
            tcAdmin.SelectedTab = tabPageWork;
            tsmiHello.Text = string.Format("Xin chảo, {0}!", Account.NhanVien.HoTen);
            // Hiển thị trạng thái có đăng ký tự khởi động khi mở máy tính trước đó
            tsmiStartup.Checked = ApplicationStartup.IsRegistered();
            // Lấy thông tin kích hoạt đơn giá
            Plan = Controller.DeserializeFromXML() as PlanData;
            if (Plan == null)
            {
                Plan = new PlanData();
                Plan.Prices = new List<PlanItem>();
            }
        }

        private void ShowMessage(Dictionary<Control, bool> flags, List<Button> buttons, Control control, Label lblError, string message = null)
        {
            if (control is MyTextBox)
            {
                MyTextBox txb = control as MyTextBox;
                // Nhập thông tin đúng
                if (message == null)
                {
                    flags[txb] = true;
                    lblError.Text = message;
                    lblError.Visible = false;
                    txb.BorderColor = Color.GreenYellow;

                }
                // Nhập thông tin không hợp lệ
                else
                {
                    flags[txb] = false;
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
                    flags[control] = true;
                    lblError.Text = message;
                    lblError.Visible = false;
                }
                // Nhập thông tin không hợp lệ
                else
                {
                    flags[control] = false;
                    lblError.Text = message;
                    lblError.Visible = true;
                }
            }

            Review(flags, buttons);
        }

        private void Review(Dictionary<Control, bool> flags, List<Button> buttons)
        {
            bool passed = flags.All(f => f.Value == true);
            foreach (Button btn in buttons)
            {
                btn.Enabled = passed;
            }
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

        private void Paging<T>(BindingSource binding, List<T> list, NumericUpDown nmrLineNumber, TextBox txbTotalPages, NumericUpDown nmrPageNumber)
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
                binding.DataSource = list;
            }
            else
            {
                binding.DataSource = list.Skip(lineNumber * (pageNumber - 1)).Take(lineNumber);
            }
        }

        private void tsmiLogOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsmiChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword();
        }

        private void ChangePassword()
        {
            FChangePassword f = new FChangePassword(Account);
            f.ShowDialog();
        }

        private void tsmiStartup_Click(object sender, EventArgs e)
        {
            tsmiStartup.Checked = !tsmiStartup.Checked;

            if (tsmiStartup.Checked)
            {
                ApplicationStartup.AddRegistry();
            }
            else
            {
                ApplicationStartup.RemoveRegistry();
            }
        }

        private void tsmiTutorial_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + @"\..\..\Hướng dẫn sử dụng - Phần mềm quản lý nhân viên cửa hàng bảo hành xe máy.docx");
        }

        private void timerNotify_Tick(object sender, EventArgs e)
        {
            if (Plan == null || Plan.Prices == null)
            {
                return;
            }

            DateTime now = DateTime.Now;
            List<PlanItem> activePrices = Plan.Prices.Where(p => p.ActivateTime <= now).ToList();

            if (activePrices.Count == 0)
            {
                return;
            }

            try
            {
                foreach (PlanItem item in activePrices)
                {
                    BangGia priceList = DataProvider.Instance.DB.BangGias.FirstOrDefault(p => p.MaDG == item.PriceID);
                    if (priceList == null)
                    {
                        continue;
                    }

                    priceList.TrangThai = Constants.DANG_DUNG;
                    DataProvider.Instance.DB.SaveChanges();

                    // Có trigger => Phải load lại
                    RefreshAll();
                    Plan.Prices.Remove(item);

                    LoadPrices();
                    CheckPriceID();
                }

                Controller.SerializeToXML(Plan);
                notifyPrice.ShowBalloonTip(Constants.NOTIFY_TIMEOUT, "Thông báo",
                string.Format("Có {0} đơn giá đã được áp dụng theo thời gian kích hoạt đã đặt!", activePrices.Count), ToolTipIcon.Info);
            }
            catch (Exception)
            {
                // Không làm gì...
            }
        }

        private void btnActivePrice_Click(object sender, EventArgs e)
        {
            //if (dtpActiveTime.Value < DateTime.Now.AddSeconds(Constants.WAITING_TIME))
            //{
            //    MessageBox.Show(string.Format("Thời gian kích hoạt phải sau thời gian hiện tại ít nhất {0} giây!", Constants.WAITING_TIME),
            //            "Lỗi: Hoạt động không hợp lệ!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            if (MessageBox.Show("Bạn có chắc muốn đặt thêm lịch kích hoạt mới cho đơn giá này?",
                        "Xác nhận đặt lịch", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
            {
                return;
            }

            Plan.Prices.Add(new PlanItem() { PriceID = Convert.ToInt32(txbPriceID.Text), ActivateTime = dtpActiveTime.Value });

            if (Controller.SerializeToXML(Plan))
            {
                CheckPriceID();
                MessageBox.Show("Đã đặt lịch kích hoạt cho đơn giá thành công!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelActivePrice_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn hủy lịch kích hoạt này?",
                        "Xác nhận hủy", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
            {
                return;
            }

            Plan.Prices.Remove(Plan.Prices.FirstOrDefault());
            Controller.SerializeToXML(Plan);

            CheckPriceID();
            MessageBox.Show("Đã hủy lịch kích hoạt!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            notifyPrice.Dispose();
        }
    }
}
