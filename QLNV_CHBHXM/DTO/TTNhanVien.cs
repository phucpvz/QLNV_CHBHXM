using LinqToExcel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNV_CHBHXM.DTO
{
    public class TTNhanVien
    {
        [ExcelColumn("Họ và tên")]
        public string HoTen { get; set; }

        [ExcelColumn("Giới tính")]
        public string GioiTinh { get; set; }

        [ExcelColumn("Ngày sinh")]
        public DateTime NgaySinh { get; set; }

        [ExcelColumn("Địa chỉ")]
        public string DiaChi { get; set; }

        [ExcelColumn("Số điện thoại")]
        public string SoDT { get; set; }

        [ExcelColumn("Email")]
        public string Email { get; set; }

        [ExcelColumn("Lương cơ bản")]
        public decimal LuongCoBan { get; set; }

        [ExcelColumn("Loại")]
        public string Loai { get; set; }

        [ExcelColumn("Trạng thái")]
        public string TrangThai { get; set; }
    }
}
