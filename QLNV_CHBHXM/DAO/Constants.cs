using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNV_CHBHXM
{
    static class Constants
    {
        public const decimal SALARY_INCREMENT = 1000000;
        public const string TAT_CA = "Tất cả";

        // Nhân viên
        public static readonly string[] EMPLOYEE_HEADER = { "Mã nhân viên" , "Họ và tên" , "Giới tính", "Ngày sinh", "Địa chỉ",
            "Số điện thoại", "Email", "Lương cơ bản", "Tên đăng nhập", "Loại", "Trạng thái"};
        public static readonly string[] EMPLOYEE_COLUMN = { "MaNV" , "HoTen" , "GioiTinh", "NgaySinh", "DiaChi",
            "SoDT", "Email", "LuongCoBan", "TenDangNhap", "TenLoai", "TrangThai"};

        // Nhân viên thu gọn
        public static readonly string[] EMP_HEADER = { "Mã nhân viên", "Họ và tên" };
        public static readonly string[] EMP_COLUMN = { "MaNV" , "HoTen"};

        public const string NHAN_VIEN = "Nhân viên";
        public const string QUAN_LY = "Quản lý";

        public const string DANG_LAM = "Đang làm";
        public const string NGHI = "Nghỉ";

        // Thêm nhân viên từ file Excel
        public static readonly string[] EXCEL_HEADER = { "Họ và tên" , "Giới tính", "Ngày sinh", "Địa chỉ",
            "Số điện thoại", "Email", "Lương cơ bản", "Loại", "Trạng thái"};

        // Dịch vụ
        public static readonly string[] SERVICE_HEADER = { "Mã dịch vụ", "Tên dịch vụ" };
        public static readonly string[] SERVICE_COLUMN = { "MaDV" , "TenDV"};

        // Loại xe
        public static readonly string[] VEHICLE_HEADER = { "Mã loại xe", "Tên loại xe" };
        public static readonly string[] VEHICLE_COLUMN = { "MaLX", "TenLX" };

        // Năng lực
        public static readonly string[] TALENT_HEADER = { "Mã nhân viên", "Họ và tên", "Mã dịch vụ", "Tên dịch vụ" };
        public static readonly string[] TALENT_COLUMN = { "MaNV", "HoTen", "MaDV", "TenDV" };

        // Bảng giá
        public static readonly string[] PRICE_HEADER = { "Mã đơn giá", "Tên dịch vụ", "Tên loại xe", "Đơn giá", "Trạng thái" };
        public static readonly string[] PRICE_COLUMN = { "MaDG", "TenDV", "TenLX", "DonGia", "TrangThai" };

        public const string DANG_DUNG = "Đang dùng";
        public const string NGUNG = "Ngưng";

        // Công việc
        public static readonly string[] WORK_HEADER = { "Mã công việc", "Mã nhân viên", "Họ và tên", "Tổng tiền" };
        public static readonly string[] WORK_COLUMN = { "MaCV", "MaNV", "HoTen", "TongTien" };

        // Chi tiết công việc
        public static readonly string[] DETAIL_HEADER = { "Mã đơn giá", "Tên dịch vụ", "Tên loại xe", "Đơn giá", "Số lượng", "Tổng" };
        public static readonly string[] DETAIL_COLUMN = { "MaDG", "TenDV", "TenLX", "DonGia", "SoLuong", "Tong" };

        // Lương
        public static readonly string[] SALARY_HEADER = { "Mã nhân viên", "Họ và tên", "Tháng", "Năm", "Số ngày thực làm", "Tổng doanh thu", "Lương thực lãnh"};
        public static readonly string[] SALARY_COLUMN = { "MaNV", "HoTen", "Thang", "Nam", "SoNgayThucLam", "TongDoanhThu", "LuongThucLanh" };

        // Sắp xếp lương
        public static readonly string[] SORT_SALARY_HEADER = { "Mã nhân viên", "Họ và tên", "Thời gian", "Số ngày thực làm", "Tổng doanh thu", "Lương thực lãnh" };
        public static readonly string[] SORT_SALARY_COLUMN = { "MaNV", "HoTen", "Nam, Thang", "SoNgayThucLam", "TongDoanhThu", "LuongThucLanh" };

        // Sắp xếp lương của bạn
        public static readonly string[] SORT_YOUR_SALARY_HEADER = { "Thời gian", "Số ngày thực làm", "Tổng doanh thu", "Lương thực lãnh" };
        public static readonly string[] SORT_YOUR_SALARY_COLUMN = { "Nam, Thang", "SoNgayThucLam", "TongDoanhThu", "LuongThucLanh" };

        // Thời gian hiện thông báo
        public static int NOTIFY_TIMEOUT = 10000;
        // Thời gian trễ (Đơn vị: giây)
        public static int WAITING_TIME = 30;
    }
}
