using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNV_CHBHXM.DAO
{
    public static class Checker
    {
        // Kiểm tra họ tên
        public static string CheckName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return "Họ tên nhân viên không được để trống!";
            }

            if (!Regex.IsMatch(name, @"^[a-zA-Z\sàáãạảăắằẳẵặâấầẩẫậèéẹẻẽêềếểễệđìíĩỉịòóõọỏôốồổỗộơớờởỡợùúũụủưứừửữựỳỵỷỹý
                                            ÀÁÃẠẢĂẮẰẲẴẶÂẤẦẨẪẬÈÉẸẺẼÊỀẾỂỄỆĐÌÍĨỈỊÒÓÕỌỎÔỐỒỔỖỘƠỚỜỞỠỢÙÚŨỤỦƯỨỪỬỮỰỲỴỶỸÝ]+$"))
            {
                return "Họ tên nhân viên chỉ được bao gồm các chữ cái a-z, A-Z\n" +
                    "(có hoặc không dấu) và khoảng trắng giữa các từ!";
            }

            return null;
        }

        // Kiểm tra giới tính
        public static string CheckGender(string gender)
        {
            if (gender != "Nam" && gender != "Nữ")
            {
                return "Giới tính phải là \"Nam\" hoặc \"Nữ\"!";
            }

            return null;
        }

        // Kiểm tra ngày sinh
        public static string CheckBirthday(DateTime birthday)
        {
            if (birthday > DateTime.Now.AddYears(-18))
            {
                return "Nhân viên phải từ đủ 18 tuổi trở lên!";
            }

            return null;
        }

        // Kiểm tra địa chỉ
        public static string CheckAddress(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                return "Địa chỉ không được để trống!";
            }

            return null;
        }

        // Kiểm tra số điện thoại
        public static string CheckPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
            {
                return "Số điện thoại không được để trống!";
            }

            if (!Regex.IsMatch(phone, @"^0{1}\d{9}$"))
            {
                return "Số điện thoại phải là số 10 chữ số và bắt đầu bằng chữ số 0!";
            }

            return null;
        }

        // Kiểm tra email
        public static string CheckEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return "Email không được để trống!";
            }

            if (!Regex.IsMatch(email, @"^[a-zA-Z]+[a-zA-Z0-9]*@[a-zA-Z]+(\.{1}[a-zA-Z]+)+$"))
            {
                return "Định dạng email không hợp lệ!";
            }

            return null;
        }

        // Kiểm tra lương cơ bản
        public static string CheckBasicSalary(decimal basicSalary)
        {
            if (basicSalary < 0)
            {
                return "Lương cơ bản không thể có giá trị âm!";
            }

            return null;
        }

        // Kiểm tra loại nhân viên
        public static string CheckType(string type)
        {
            if (type != "Quản lý" && type != "Nhân viên")
            {
                return "Loại phải là \"Quản lý\" hoặc \"Nhân viên\"!";
            }

            return null;
        }

        // Kiểm tra trạng thái
        public static string CheckStatus(string status)
        {
            if (status != Constants.DANG_LAM && status != Constants.NGHI)
            {
                return string.Format("Trạng thái phải là {0} hoặc {1}!", Constants.DANG_LAM, Constants.NGHI);
            }

            return null;
        }

    }
}
