using QLNV_CHBHXM.DAO;
using QLNV_CHBHXM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNV_CHBHXM.GUI
{
    public partial class FAdmin
    {
        #region Nhân viên
        //===================================================== Nhân viên =====================================================
        private void LoadComboType(ComboBox cb)
        {
            cb.DataSource = DataProvider.Instance.DB.LoaiNVs.ToList();
            cb.DisplayMember = "TenLoai";
        }

        private void AddEmpBinding()
        {
            txbEmpID.DataBindings.Add(new Binding("Text", dgrvEmployees.DataSource, "MaNV", true, DataSourceUpdateMode.Never));
            txbName.DataBindings.Add(new Binding("Text", dgrvEmployees.DataSource, "HoTen", true, DataSourceUpdateMode.Never));
            dtpBirthday.DataBindings.Add(new Binding("Value", dgrvEmployees.DataSource, "NgaySinh", true, DataSourceUpdateMode.Never));
            txbAddress.DataBindings.Add(new Binding("Text", dgrvEmployees.DataSource, "DiaChi", true, DataSourceUpdateMode.Never));
            txbPhone.DataBindings.Add(new Binding("Text", dgrvEmployees.DataSource, "SoDT", true, DataSourceUpdateMode.Never));
            txbEmail.DataBindings.Add(new Binding("Text", dgrvEmployees.DataSource, "Email", true, DataSourceUpdateMode.Never));
            nmrBasicSalary.DataBindings.Add(new Binding("Value", dgrvEmployees.DataSource, "LuongCoBan", true, DataSourceUpdateMode.Never));
        }

        private void InitEmployeeFlags()
        {
            EmployeeFlags = new Dictionary<Control, bool>
            {
                { txbName, false },
                { dtpBirthday, false },
                { txbAddress, false },
                { txbPhone, false },
                { txbEmail, false }
            };
        }

        // Kiểm tra mã nhân viên
        private void CheckEmpID()
        {
            CheckUsername();

            pnlEmpInfo.Visible = pnlAddingEmp.Visible || (dgrvEmployees.RowCount > 0);

            string empID = txbEmpID.Text;
            if (string.IsNullOrEmpty(empID))
            {
                btnEditEmp.Enabled = btnDeleteEmp.Enabled = false;
                return;
            }
            else
            {
                btnEditEmp.Enabled = btnDeleteEmp.Enabled = true;
            }

            NhanVien employee;
            try
            {
                employee = DataProvider.Instance.DB.NhanViens.Find(empID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm theo mã nhân viên!\n\n",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nếu đang thêm mới nhân viên sẽ không tìm thấy => Thoát, không thực hiện các bước dưới
            if (employee == null)
            {
                return;
            }

            switch (employee.GioiTinh)
            {
                case "Nam":
                    rbtnMale.Checked = true;
                    break;
                case "Nữ":
                    rbtnFemale.Checked = true;
                    break;
            }

            cbType.SelectedIndex = cbType.Items.IndexOf(employee.LoaiNV);
            cbEmpStatus.SelectedIndex = cbEmpStatus.Items.IndexOf(employee.TrangThai);
        }

        // Kiểm tra họ tên
        private void CheckName()
        {
            string name = txbName.Text;
            if (string.IsNullOrEmpty(name))
            {
                ShowMessage(EmployeeFlags, new List<Button>() { btnEditEmp, btnAcceptAddEmp }, txbName, lblName, "Họ tên nhân viên không được để trống!");
                return;
            }

            if (!Regex.IsMatch(name, @"^[a-zA-Z\sàáãạảăắằẳẵặâấầẩẫậèéẹẻẽêềếểễệđìíĩỉịòóõọỏôốồổỗộơớờởỡợùúũụủưứừửữựỳỵỷỹý
                                            ÀÁÃẠẢĂẮẰẲẴẶÂẤẦẨẪẬÈÉẸẺẼÊỀẾỂỄỆĐÌÍĨỈỊÒÓÕỌỎÔỐỒỔỖỘƠỚỜỞỠỢÙÚŨỤỦƯỨỪỬỮỰỲỴỶỸÝ]+$"))
            {
                ShowMessage(EmployeeFlags, new List<Button>() { btnEditEmp, btnAcceptAddEmp }, txbName, lblName, "Họ tên nhân viên chỉ được bao gồm các chữ cái a-z, A-Z\n" +
                    "(có hoặc không dấu) và khoảng trắng giữa các từ!");
                return;
            }

            ShowMessage(EmployeeFlags, new List<Button>() { btnEditEmp, btnAcceptAddEmp }, txbName, lblName);
        }

        // Kiểm tra ngày sinh
        private void CheckBirthday()
        {
            if (dtpBirthday.Value > DateTime.Now.AddYears(-18))
            {
                ShowMessage(EmployeeFlags, new List<Button>() { btnEditEmp, btnAcceptAddEmp }, dtpBirthday, lblBirthday, "Nhân viên phải từ đủ 18 tuổi trở lên!");
                ptbBirthday.Image = imlTickCross.Images[1];
            }
            else
            {
                ShowMessage(EmployeeFlags, new List<Button>() { btnEditEmp, btnAcceptAddEmp }, dtpBirthday, lblBirthday);
                ptbBirthday.Image = imlTickCross.Images[0];
            }
        }

        // Kiểm tra địa chỉ
        private void CheckAddress()
        {
            string address = txbAddress.Text;
            if (string.IsNullOrEmpty(address))
            {
                ShowMessage(EmployeeFlags, new List<Button>() { btnEditEmp, btnAcceptAddEmp }, txbAddress, lblAddress, "Địa chỉ không được để trống!");
                return;
            }

            ShowMessage(EmployeeFlags, new List<Button>() { btnEditEmp, btnAcceptAddEmp }, txbAddress, lblAddress);
        }

        // Kiểm tra số điện thoại
        private void CheckPhone()
        {
            string phone = txbPhone.Text;
            if (string.IsNullOrEmpty(phone))
            {
                ShowMessage(EmployeeFlags, new List<Button>() { btnEditEmp, btnAcceptAddEmp }, txbPhone, lblPhone, "Số điện thoại không được để trống!");
                return;
            }

            if (!Regex.IsMatch(phone, @"^0{1}\d{9}$"))
            {
                ShowMessage(EmployeeFlags, new List<Button>() { btnEditEmp, btnAcceptAddEmp }, txbPhone, lblPhone, "Số điện thoại phải là số 10 chữ số và bắt đầu bằng chữ số 0!");
                return;
            }

            ShowMessage(EmployeeFlags, new List<Button>() { btnEditEmp, btnAcceptAddEmp }, txbPhone, lblPhone);
        }

        // Kiểm tra email
        private void CheckEmail()
        {
            string email = txbEmail.Text;
            if (string.IsNullOrEmpty(email))
            {
                ShowMessage(EmployeeFlags, new List<Button>() { btnEditEmp, btnAcceptAddEmp }, txbEmail, lblEmail, "Email không được để trống!");
                return;
            }

            if (!Regex.IsMatch(email, @"^[a-zA-Z]+[a-zA-Z0-9]*@[a-zA-Z]+(\.{1}[a-zA-Z]+)+$"))
            {
                ShowMessage(EmployeeFlags, new List<Button>() { btnEditEmp, btnAcceptAddEmp }, txbEmail, lblEmail, "Định dạng email không hợp lệ!");
                return;
            }

            ShowMessage(EmployeeFlags, new List<Button>() { btnEditEmp, btnAcceptAddEmp }, txbEmail, lblEmail);
        }

        // Chỉnh sửa thông tin nhân viên
        private void EditEmployee()
        {
            if (MessageBox.Show("Bạn có chắc muốn chỉnh sửa thông tin của nhân viên đã chọn?",
                    "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
            {
                return;
            }

            string empID = txbEmpID.Text;
            // Chuẩn hóa họ tên
            string name = Utility.Standardlize(txbName.Text);
            string gender = rbtnMale.Checked ? "Nam" : "Nữ";
            DateTime birthday = dtpBirthday.Value;
            string address = txbAddress.Text;
            string phone = txbPhone.Text;
            string email = txbEmail.Text;
            LoaiNV type = cbType.SelectedItem as LoaiNV;
            string status = cbEmpStatus.SelectedItem.ToString();

            try
            {
                NhanVien employee = DataProvider.Instance.DB.NhanViens.Find(empID);
                employee.HoTen = name;
                employee.GioiTinh = gender;
                employee.NgaySinh = birthday;
                employee.DiaChi = address;
                employee.SoDT = phone;
                employee.Email = email;
                employee.LoaiNV = type;
                employee.TrangThai = status;
                DataProvider.Instance.DB.SaveChanges();

                // Nếu sửa thông tin của chính mình
                if (employee == Account.NhanVien)
                {
                    tsmiHello.Text = string.Format("Xin chảo, {0}!", Account.NhanVien.HoTen);
                }

                LoadEmployees();
                LoadTalents();

                MessageBox.Show("Đã sửa thông tin nhân viên thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi sửa thông tin nhân viên!\n\n",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteEmployee()
        {
            string empID = txbEmpID.Text;
            try
            {
                NhanVien employee = DataProvider.Instance.DB.NhanViens.Find(empID);
                if (employee.CongViecs.Any())
                {
                    int count = employee.CongViecs.Count;
                    MessageBox.Show(string.Format("Không thể xóa nhân viên đã chọn vì đang có {0} thông tin công việc liên quan đến nhân viên này!\n\n" +
                        "Hãy xóa tất cả thông tin công việc có liên quan rồi thử lại!", count),
                    "Lỗi: Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (employee.DichVus.Any())
                {
                    int count = employee.DichVus.Count;
                    MessageBox.Show(string.Format("Không thể xóa nhân viên đã chọn vì đang có {0} phân công năng lực liên quan đến nhân viên này!\n\n" +
                        "Hãy xóa tất cả phân công năng lực có liên quan rồi thử lại!", count),
                    "Lỗi: Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (employee.TaiKhoans.Any())
                {
                    if (MessageBox.Show("Xóa nhân viên đã chọn sẽ xóa tài khoản của nhân viên này!\n\n" +
                        "Bạn vẫn muốn tiếp tục?",
                    "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                    {
                        return;
                    }

                    string username = empID.ToLower();

                    // Kiểm tra trường hợp tự xóa chính mình
                    if (username == Account.TenDangNhap)
                    {
                        MessageBox.Show("Không thể xóa tài khoản đang đăng nhập vào hệ thống!",
                            "Lỗi: Hoạt động không cho phép", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    TaiKhoan account = DataProvider.Instance.DB.TaiKhoans.Find(username);
                    DataProvider.Instance.DB.TaiKhoans.Remove(account);
                    DataProvider.Instance.DB.SaveChanges();
                    LoadEmployees();
                    MessageBox.Show("Đã xóa tài khoản của nhân viên này!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa thông tin của nhân viên đã chọn?",
                "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                {
                    return;
                }

                DataProvider.Instance.DB.NhanViens.Remove(employee);
                DataProvider.Instance.DB.SaveChanges();

                LoadEmployees();
                CheckEmpID();
                LoadTalents();

                MessageBox.Show("Đã xóa thông tin nhân viên thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa thông tin nhân viên!",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEmployees()
        {
            /* 
             * Tìm kiếm nhân viên 
             */
            // Tìm kiếm trong SQL không phân biệt hoa thường
            string empID = txbFindEmpID.Text;
            // Chuẩn hóa họ tên
            string name = Utility.Standardlize(txbFindName.Text);

            string gender = rbtnFindAllGender.Checked ? "" : (rbtnFindMale.Checked ? "Nam" : "Nữ");
            DateTime fromDate = dtpFromDate.Value;
            DateTime toDate = dtpToDate.Value;
            string address = txbFindAddress.Text;
            string phone = txbFindPhone.Text;
            string email = txbFindEmail.Text;
            decimal fromSalary = nmrFromSalary.Value;
            decimal toSalary = nmrToSalary.Value;

            object obj = cbFindType.SelectedItem;
            if (obj == null)
            {
                return;
            }
            string typeName = obj.ToString();
            if (typeName == Constants.TAT_CA)
            {
                typeName = "";
            }

            object obj2 = cbFindEmpStatus.SelectedItem;
            if (obj2 == null)
            {
                return;
            }
            string status = obj2.ToString();
            if (status == Constants.TAT_CA)
            {
                status = "";
            }

            /* 
             * Sắp xếp nhân viên 
             */
            int idx = cbSortEmployees.SelectedIndex;
            if (idx == -1)
            {
                return;
            }
            string columnName = Constants.EMPLOYEE_COLUMN[idx];

            string sortDirection = (rbtnAscEmployee.Checked) ? "ASC" : "DESC";

            try
            {
                var list = DataProvider.Instance.DB.USP_TimKiemVaSapXepNhanVien(empID, name, gender, fromDate, toDate, address,
                phone, email, fromSalary, toSalary, typeName, status, columnName, sortDirection).ToList();

                txbEmpAmount.Text = list.Count.ToString();

                Paging(employees, list, nmrLineNumber, txbTotalPages, nmrPageNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm và sắp xếp thông tin nhân viên!",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowEmployeeByEmpID(string empID)
        {
            txbFindEmpID.Text = empID;
            txbFindName.Clear();
            rbtnFindAllGender.Checked = true;
            dtpFromDate.Value = dtpFromDate.MinDate;
            dtpToDate.Value = dtpToDate.MaxDate;
            txbFindAddress.Clear();
            txbFindPhone.Clear();
            txbFindEmail.Clear();

            nmrFromSalary.Value = nmrFromSalary.Minimum;
            nmrToSalary.Value = nmrToSalary.Maximum;

            cbFindType.SelectedIndex = 0;
            cbFindEmpStatus.SelectedIndex = 0;
            cbSortEmployees.SelectedIndex = 0;
            rbtnAscEmployee.Checked = true;
        }

        private void ChangeModeAddingEmp()
        {
            pnlAddingEmp.Visible = true;
            pnlAddEditDelEmp.Visible = false;

            RemoveEmpBinding();
            ClearEmpInfo();
        }

        private string GetNextEmpID(string typeName)
        {
            List<string> list = (from n in DataProvider.Instance.DB.NhanViens
                                 where n.LoaiNV.TenLoai == typeName
                                 select n.MaNV).ToList();
            List<int> orders = new List<int>();

            string year = DateTime.Now.Year.ToString().Substring(2, 2);
            string type = (typeName == Constants.QUAN_LY) ? "NVQL" : "NVBT";

            foreach (string id in list)
            {
                if (!Regex.IsMatch(id, @"^N" + year + type + @"\d{3}$"))
                {
                    continue;
                }

                orders.Add(Convert.ToInt32(id.Substring(7, 3)));
            }
            orders.Sort();

            int next = 0;
            foreach (int number in orders)
            {
                if (next == number)
                {
                    ++next;
                }
                else
                {
                    break;
                }
            }

            string order;
            if (next < 10)
            {
                order = "00" + next;
            }
            else if (next < 100)
            {
                order = "0" + next;
            }
            else
            {
                order = next.ToString();
            }

            return "N" + year + type + order;
        }

        private void ClearEmpInfo()
        {
            txbEmpID.Text = GetNextEmpID((cbType.SelectedItem as LoaiNV).TenLoai);
            txbName.Clear();
            dtpBirthday.Value = DateTime.Now;
            txbAddress.Clear();
            txbPhone.Clear();
            txbEmail.Clear();

            nmrBasicSalary.ReadOnly = false;
            nmrBasicSalary.Increment = Constants.SALARY_INCREMENT;
            nmrBasicSalary.Value = Constants.SALARY_INCREMENT;

            cbType.Enabled = true;
            ckbCreateAccount.Visible = true;
        }

        private void RemoveEmpBinding()
        {
            List<Control> controls = new List<Control>()
            {
                txbEmpID, txbName, dtpBirthday, txbAddress, txbPhone, txbEmail, nmrBasicSalary
            };

            foreach (Control item in controls)
            {
                item.DataBindings.Clear();
            }
        }

        private void AddEmployee()
        {
            // Mã nhân viên viết hoa
            string empID = txbEmpID.Text.ToUpper();
            // Chuẩn hóa họ tên
            string name = Utility.Standardlize(txbName.Text);

            string gender = rbtnMale.Checked ? "Nam" : "Nữ";
            DateTime birthday = dtpBirthday.Value;
            string address = txbAddress.Text;
            string phone = txbPhone.Text;

            string email = txbEmail.Text;

            decimal basicSalary = nmrBasicSalary.Value;
            int typeID = (cbType.SelectedItem as LoaiNV).MaLoai;
            string status = cbEmpStatus.SelectedItem.ToString();

            NhanVien employee = new NhanVien()
            {
                MaNV = empID,
                HoTen = name,
                GioiTinh = gender,
                NgaySinh = birthday,
                DiaChi = address,
                SoDT = phone,
                Email = email,
                LuongCoBan = basicSalary,
                MaLoai = typeID,
                TrangThai = status
            };

            try
            {
                DataProvider.Instance.DB.NhanViens.Add(employee);
                DataProvider.Instance.DB.SaveChanges();

                LoadEmployees();
                MessageBox.Show("Đã thêm thông tin nhân viên mới thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (ckbCreateAccount.Checked)
                {
                    AddAccount();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi thêm thông tin nhân viên mới!\n\n",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ClearEmpInfo();
        }

        private void ChangeModeEditingEmp()
        {
            pnlAddingEmp.Visible = false;
            pnlAddEditDelEmp.Visible = true;

            AddEmpBinding();
            nmrBasicSalary.ReadOnly = true;
            nmrBasicSalary.Increment = 0;

            cbType.Enabled = false;

            ckbCreateAccount.Visible = false;

            if (dgrvEmployees.Rows.Count == 0)
            {
                txbEmpID.Clear();
                nmrBasicSalary.Value = 0;
            }
        }

        private void ReportEmployees()
        {
            string title = txbTitle_Emp.Text;

            /* 
             * Tìm kiếm nhân viên 
             */
            // Tìm kiếm trong SQL không phân biệt hoa thường
            string empID = txbFindEmpID.Text;
            // Chuẩn hóa họ tên
            string name = Utility.Standardlize(txbFindName.Text);

            string gender = rbtnFindAllGender.Checked ? "" : (rbtnFindMale.Checked ? "Nam" : "Nữ");
            DateTime fromDate = dtpFromDate.Value;
            DateTime toDate = dtpToDate.Value;
            string address = txbFindAddress.Text;
            string phone = txbFindPhone.Text;
            string email = txbFindEmail.Text;
            decimal fromSalary = nmrFromSalary.Value;
            decimal toSalary = nmrToSalary.Value;

            object obj = cbFindType.SelectedItem;
            if (obj == null)
            {
                return;
            }
            string typeName = obj.ToString();
            if (typeName == Constants.TAT_CA)
            {
                typeName = "";
            }

            object obj2 = cbFindEmpStatus.SelectedItem;
            if (obj2 == null)
            {
                return;
            }
            string status = obj2.ToString();
            if (status == Constants.TAT_CA)
            {
                status = "";
            }

            /* 
             * Sắp xếp nhân viên 
             */
            int idx = cbSortEmployees.SelectedIndex;
            if (idx == -1)
            {
                return;
            }
            string columnName = Constants.EMPLOYEE_COLUMN[idx];

            string sortDirection = (rbtnAscEmployee.Checked) ? "ASC" : "DESC";

            // Xuất danh sách nhân viên
            Dictionary<string, object> filters = new Dictionary<string, object>()
            {
                {"Title", title },
                {"MaNV", empID },
                {"HoTen", name },
                {"GioiTinh", gender },
                {"TuNgay", fromDate },
                {"DenNgay", toDate },
                {"DiaChi", address },
                {"SoDT", phone },
                {"Email", email },
                {"TuLuong", fromSalary },
                {"DenLuong", toSalary },
                {"TenLoai", typeName },
                {"TrangThai", status },
                {"TenCot", columnName },
                {"HuongSapXep", sortDirection },
            };

            FReportEmployee f = new FReportEmployee(filters);
            f.ShowDialog();
        }

        //===================================================== Tài khoản =====================================================
        private void CheckUsername()
        {
            string username = txbUsername.Text;

            if (dgrvEmployees.RowCount == 0)
            {
                btnAddAccount.Enabled = lblNoAccount.Visible = btnResetPassword.Enabled = btnDeleteAccount.Enabled = false;
                return;
            }

            btnAddAccount.Enabled = lblNoAccount.Visible = string.IsNullOrEmpty(username);
            btnResetPassword.Enabled = btnDeleteAccount.Enabled = !string.IsNullOrEmpty(username);
        }

        private void AddAccountBinding()
        {
            txbUsername.DataBindings.Add(new Binding("Text", dgrvEmployees.DataSource, "TenDangNhap", true, DataSourceUpdateMode.Never));
        }

        private void AddAccount()
        {
            string empID = txbEmpID.Text;
            string username = empID.ToLower();

            if (MessageBox.Show("Bạn có chắc muốn thêm tài khoản cho nhân viên được chọn không?\n\n" +
                "Tên đăng nhập: " + username + "\n" +
                "Mật khẩu: Theo ngày sinh của nhân viên (ddMMyy)",
                   "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
            {
                return;
            }

            string passEncode = null;
            if (rbtnPassByBirthday.Checked)
            {
                DateTime birthday = dtpBirthday.Value;

                string[] strs = birthday.ToString("dd/MM/yy").Split('/');

                string password = string.Format("{0}{1}{2}", strs[0], strs[1], strs[2]);
                passEncode = Encoder.MD5Hash(Encoder.Base64Encode(password));
            }

            try
            {
                TaiKhoan account = new TaiKhoan() { TenDangNhap = username, MatKhau = passEncode, MaNV = empID };
                DataProvider.Instance.DB.TaiKhoans.Add(account);
                DataProvider.Instance.DB.SaveChanges();

                LoadEmployees();
                MessageBox.Show("Đã thêm tài khoản cho nhân viên!",
                   "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi thêm tài khoản cho nhân viên!",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetPassword()
        {
            if (MessageBox.Show("Bạn có chắc muốn đặt lại mật khẩu cho tài khoản của nhân viên đã chọn?\n\n" +
                "Mật khẩu đặt lại theo ngày sinh của nhân viên (ddMMyy)",
                    "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
            {
                return;
            }

            string username = txbUsername.Text;
            DateTime birthday = dtpBirthday.Value;
            string[] strs = birthday.ToString("dd/MM/yy").Split('/');
            string password = string.Format("{0}{1}{2}", strs[0], strs[1], strs[2]);
            string passEncode = Encoder.MD5Hash(Encoder.Base64Encode(password));

            try
            {
                TaiKhoan account = DataProvider.Instance.DB.TaiKhoans.Find(username);
                account.MatKhau = passEncode;
                DataProvider.Instance.DB.SaveChanges();

                LoadEmployees();
                MessageBox.Show("Đã đặt lại mật khẩu cho tài khoản của nhân viên đã chọn!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khiđặt lại mật khẩu cho tài khoản của nhân viên đã chọn!",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteAccount()
        {
            string username = txbUsername.Text;
            if (username == Account.TenDangNhap)
            {
                MessageBox.Show("Bạn không thể tự xóa tài khoản của mình!",
                    "Lỗi: Hoạt động không cho phép", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa tài khoản của nhân viên đã chọn không?",
                    "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
            {
                return;
            }

            try
            {
                TaiKhoan account = DataProvider.Instance.DB.TaiKhoans.Find(username);
                DataProvider.Instance.DB.TaiKhoans.Remove(account);
                DataProvider.Instance.DB.SaveChanges();

                LoadEmployees();
                MessageBox.Show("Đã xóa tài khoản!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa tài khoản này!",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ConnexionExcel ConxObject;

        private void SetOpenExcelFileDlg()
        {
            openExcelFileDlg.Title = "Chọn file Excel lưu danh sách nhân viên";
            openExcelFileDlg.FileName = "";

            openExcelFileDlg.CheckFileExists = true;
            openExcelFileDlg.CheckPathExists = true;

            openExcelFileDlg.DefaultExt = "xls";
            openExcelFileDlg.Filter = "Excel Files (.xls)|*.xls|Excel Files (.xlsx)|*.xlsx|Excel Files (*.xlsm)|*.xlsm";
            openExcelFileDlg.FilterIndex = 2;
            openExcelFileDlg.RestoreDirectory = true;
        }

        private void BrowseExcelFile()
        {
            if (openExcelFileDlg.ShowDialog() == DialogResult.OK)
            {
                string pathToExcelFile = openExcelFileDlg.FileName;
                txbExcelFileURL.Text = pathToExcelFile;
            }
        }

        private void ImportEmpData()
        {
            try
            {
                ConxObject = new ConnexionExcel(txbExcelFileURL.Text);

                //Query a worksheet with a header row
                var query = from n in ConxObject.UrlConnexion.Worksheet<TTNhanVien>()
                            select n;

                var columnNames = ConxObject.UrlConnexion.GetColumnNames("Sheet1");
                List<string> list = Constants.EXCEL_HEADER.Except(columnNames).ToList();

                if (list.Any())
                {
                    MessageBox.Show("Không thể thêm danh sách nhân viên từ file Excel đã chọn vì thiếu các cột: " + string.Join(" - ", list),
                            "Lỗi: Thiếu dữ liệu đầu vào!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra tính hợp lệ của tất cả thông tin nhân viên trong danh sách trước khi thêm vào CSDL
                try
                {
                    foreach (TTNhanVien tt in query)
                    {
                        string error = CheckEmpInfomation(tt);
                        if (error != null)
                        {
                            MessageBox.Show(string.Format("Thông báo lỗi: {0}\n\n" +
                                "Danh sách nhân viên mới sẽ không được thêm vào!", error),
                            "Lỗi: Thông tin nhân viên không đúng quy định", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ngày sinh hoặc lương cơ bản của nhân viên không đúng định dạng!\n\n" +
                                "Danh sách nhân viên mới sẽ không được thêm vào!",
                            "Lỗi: Dữ liệu đầu vào không đúng định dạng!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Xác nhận thêm
                int count = query.ToList().Count;
                if (MessageBox.Show(string.Format("Bạn sắp sửa thêm {0} nhân viên từ file vào cơ sở dữ liệu, bạn có muốn tiếp tục không?", count),
                        "Xác nhận thêm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                {
                    return;
                }

                bool addEmpSuccess = true;
                // Thêm tất cả
                foreach (TTNhanVien tt in query)
                {
                    // Tìm mã nhân viên phù hợp
                    string empID = GetNextEmpID(tt.Loai);
                    // Chuẩn hóa họ tên
                    string name = Utility.Standardlize(tt.HoTen);

                    string gender = tt.GioiTinh;
                    DateTime birthday = tt.NgaySinh;
                    string address = tt.DiaChi;
                    string phone = tt.SoDT;

                    string email = tt.Email;

                    decimal basicSalary = tt.LuongCoBan;
                    int typeID = DataProvider.Instance.DB.LoaiNVs.FirstOrDefault(l => l.TenLoai == tt.Loai).MaLoai;
                    string status = tt.TrangThai;

                    NhanVien employee = new NhanVien()
                    {
                        MaNV = empID,
                        HoTen = name,
                        GioiTinh = gender,
                        NgaySinh = birthday,
                        DiaChi = address,
                        SoDT = phone,
                        Email = email,
                        LuongCoBan = basicSalary,
                        MaLoai = typeID,
                        TrangThai = status
                    };

                    try
                    {
                        DataProvider.Instance.DB.NhanViens.Add(employee);
                        DataProvider.Instance.DB.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi thêm danh sách nhân viên mới!",
                        "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        addEmpSuccess = false;
                    }
                }

                if (addEmpSuccess)
                {
                    LoadEmployees();
                    MessageBox.Show("Đã thêm thông tin danh sách nhân viên mới thành công!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("File đang được sử dụng hoặc không thể truy cập vào nội dung file!\n\n",
                        "Lỗi: Không thể truy cập file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string CheckEmpInfomation(TTNhanVien tt)
        {
            string nameError = Checker.CheckName(tt.HoTen);
            if (nameError != null)
            {
                return nameError;
            }

            string genderError = Checker.CheckGender(tt.GioiTinh);
            if (genderError != null)
            {
                return genderError;
            }

            string birthdayError = Checker.CheckBirthday(tt.NgaySinh);
            if (birthdayError != null)
            {
                return birthdayError;
            }

            string addressError = Checker.CheckAddress(tt.DiaChi);
            if (addressError != null)
            {
                return addressError;
            }

            string phoneError = Checker.CheckPhone(tt.SoDT);
            if (phoneError != null)
            {
                return phoneError;
            }

            string emailError = Checker.CheckEmail(tt.Email);
            if (emailError != null)
            {
                return emailError;
            }

            string basicSalaryError = Checker.CheckBasicSalary(tt.LuongCoBan);
            if (basicSalaryError != null)
            {
                return basicSalaryError;
            }

            string typeError = Checker.CheckType(tt.Loai);
            if (typeError != null)
            {
                return typeError;
            }

            string statusError = Checker.CheckStatus(tt.TrangThai);
            if (statusError != null)
            {
                return statusError;
            }

            return null;
        }

        // ------------------------------------- Events -------------------------------------
        private void txbEmpID_TextChanged(object sender, EventArgs e)
        {
            CheckEmpID();
        }

        private void txbName_TextChanged(object sender, EventArgs e)
        {
            CheckName();
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

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pnlAddingEmp.Visible)
            {
                txbEmpID.Text = GetNextEmpID((cbType.SelectedItem as LoaiNV).TenLoai);
            }
        }

        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            EditEmployee();
        }

        private void txbSearchEmployees_TextChanged(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void rbtnSearchEmployees_CheckedChanged(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void dtpSearchEmployees_ValueChanged(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void nmrSearchEmployees_ValueChanged(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void cbSearchEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void cbSortEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void rbtnSortEmployee_CheckedChanged(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void btnDeleteEmp_Click(object sender, EventArgs e)
        {
            DeleteEmployee();
        }

        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            ChangeModeAddingEmp();
        }

        private void btnAcceptAddEmp_Click(object sender, EventArgs e)
        {
            AddEmployee();
        }

        private void btnCancelAddEmp_Click(object sender, EventArgs e)
        {
            ChangeModeEditingEmp();
        }

        private void btnShowYourEmpInfo_Click(object sender, EventArgs e)
        {
            ShowEmployeeByEmpID(Account.MaNV);
        }

        private void btnShowAllEmps_Click(object sender, EventArgs e)
        {
            ShowEmployeeByEmpID("");
        }

        private void tcEmployee_Click(object sender, EventArgs e)
        {
            CheckEmpID();
        }

        private void nmrPageNumber_ValueChanged(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void nmrLineNumber_ValueChanged(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            nmrPageNumber.Value = 1;
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            --nmrPageNumber.Value;
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            ++nmrPageNumber.Value;
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            int totalPages = Convert.ToInt32(txbTotalPages.Text);
            nmrPageNumber.Value = (totalPages == 0) ? 1 : totalPages;
        }

        private void cbFindEmpStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void txbUsername_TextChanged(object sender, EventArgs e)
        {
            CheckUsername();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            AddAccount();
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            DeleteAccount();
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            ResetPassword();
        }

        private void btnReport_Emp_Click(object sender, EventArgs e)
        {
            ReportEmployees();
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            BrowseExcelFile();
        }

        private void txbExcelFileURL_TextChanged(object sender, EventArgs e)
        {
            btnImportData.Enabled = !string.IsNullOrEmpty(txbExcelFileURL.Text);
        }

        private void btnImportData_Click(object sender, EventArgs e)
        {
            ImportEmpData();
        }

        #endregion
    }
}
