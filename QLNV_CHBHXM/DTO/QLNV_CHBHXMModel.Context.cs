﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLNV_CHBHXM.DTO
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class QLNV_CHBHXMEntities : DbContext
    {
        public QLNV_CHBHXMEntities()
            : base("name=QLNV_CHBHXMEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BangGia> BangGias { get; set; }
        public virtual DbSet<ChiTietCV> ChiTietCVs { get; set; }
        public virtual DbSet<CongViec> CongViecs { get; set; }
        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<LoaiNV> LoaiNVs { get; set; }
        public virtual DbSet<LoaiXe> LoaiXes { get; set; }
        public virtual DbSet<Luong> Luongs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
    
        public virtual ObjectResult<Nullable<decimal>> USP_LayMaTiepTheo(string table_name)
        {
            var table_nameParameter = table_name != null ?
                new ObjectParameter("table_name", table_name) :
                new ObjectParameter("table_name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("USP_LayMaTiepTheo", table_nameParameter);
        }
    
        public virtual ObjectResult<USP_TimKiemDichVuChuaPhanCong_Result> USP_TimKiemDichVuChuaPhanCong(string maNV, string tenDV)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("maNV", maNV) :
                new ObjectParameter("maNV", typeof(string));
    
            var tenDVParameter = tenDV != null ?
                new ObjectParameter("tenDV", tenDV) :
                new ObjectParameter("tenDV", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_TimKiemDichVuChuaPhanCong_Result>("USP_TimKiemDichVuChuaPhanCong", maNVParameter, tenDVParameter);
        }
    
        public virtual ObjectResult<USP_TimKiemVaSapXepCongViec_Result> USP_TimKiemVaSapXepCongViec(string maNV, string hoTen, Nullable<System.DateTime> ngayLam, string tenCot, string huongSapXep)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("maNV", maNV) :
                new ObjectParameter("maNV", typeof(string));
    
            var hoTenParameter = hoTen != null ?
                new ObjectParameter("hoTen", hoTen) :
                new ObjectParameter("hoTen", typeof(string));
    
            var ngayLamParameter = ngayLam.HasValue ?
                new ObjectParameter("ngayLam", ngayLam) :
                new ObjectParameter("ngayLam", typeof(System.DateTime));
    
            var tenCotParameter = tenCot != null ?
                new ObjectParameter("tenCot", tenCot) :
                new ObjectParameter("tenCot", typeof(string));
    
            var huongSapXepParameter = huongSapXep != null ?
                new ObjectParameter("huongSapXep", huongSapXep) :
                new ObjectParameter("huongSapXep", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_TimKiemVaSapXepCongViec_Result>("USP_TimKiemVaSapXepCongViec", maNVParameter, hoTenParameter, ngayLamParameter, tenCotParameter, huongSapXepParameter);
        }
    
        public virtual ObjectResult<USP_TimKiemVaSapXepDichVu_Result> USP_TimKiemVaSapXepDichVu(string tenDV, string tenCot, string huongSapXep)
        {
            var tenDVParameter = tenDV != null ?
                new ObjectParameter("tenDV", tenDV) :
                new ObjectParameter("tenDV", typeof(string));
    
            var tenCotParameter = tenCot != null ?
                new ObjectParameter("tenCot", tenCot) :
                new ObjectParameter("tenCot", typeof(string));
    
            var huongSapXepParameter = huongSapXep != null ?
                new ObjectParameter("huongSapXep", huongSapXep) :
                new ObjectParameter("huongSapXep", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_TimKiemVaSapXepDichVu_Result>("USP_TimKiemVaSapXepDichVu", tenDVParameter, tenCotParameter, huongSapXepParameter);
        }
    
        public virtual ObjectResult<USP_TimKiemVaSapXepDonGia_Result> USP_TimKiemVaSapXepDonGia(string tenDV, string tenLX, string trangThai, string tenCot, string huongSapXep)
        {
            var tenDVParameter = tenDV != null ?
                new ObjectParameter("tenDV", tenDV) :
                new ObjectParameter("tenDV", typeof(string));
    
            var tenLXParameter = tenLX != null ?
                new ObjectParameter("tenLX", tenLX) :
                new ObjectParameter("tenLX", typeof(string));
    
            var trangThaiParameter = trangThai != null ?
                new ObjectParameter("trangThai", trangThai) :
                new ObjectParameter("trangThai", typeof(string));
    
            var tenCotParameter = tenCot != null ?
                new ObjectParameter("tenCot", tenCot) :
                new ObjectParameter("tenCot", typeof(string));
    
            var huongSapXepParameter = huongSapXep != null ?
                new ObjectParameter("huongSapXep", huongSapXep) :
                new ObjectParameter("huongSapXep", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_TimKiemVaSapXepDonGia_Result>("USP_TimKiemVaSapXepDonGia", tenDVParameter, tenLXParameter, trangThaiParameter, tenCotParameter, huongSapXepParameter);
        }
    
        public virtual ObjectResult<USP_TimKiemVaSapXepLoaiXe_Result> USP_TimKiemVaSapXepLoaiXe(string tenLX, string tenCot, string huongSapXep)
        {
            var tenLXParameter = tenLX != null ?
                new ObjectParameter("tenLX", tenLX) :
                new ObjectParameter("tenLX", typeof(string));
    
            var tenCotParameter = tenCot != null ?
                new ObjectParameter("tenCot", tenCot) :
                new ObjectParameter("tenCot", typeof(string));
    
            var huongSapXepParameter = huongSapXep != null ?
                new ObjectParameter("huongSapXep", huongSapXep) :
                new ObjectParameter("huongSapXep", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_TimKiemVaSapXepLoaiXe_Result>("USP_TimKiemVaSapXepLoaiXe", tenLXParameter, tenCotParameter, huongSapXepParameter);
        }
    
        public virtual ObjectResult<USP_TimKiemVaSapXepLuong_Result> USP_TimKiemVaSapXepLuong(string maNV, string hoTen, Nullable<int> tuSoNgayThucLam, Nullable<int> denSoNgayThucLam, Nullable<int> tuThang, Nullable<int> denThang, Nullable<int> tuNam, Nullable<int> denNam, string tenCot, string huongSapXep)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("maNV", maNV) :
                new ObjectParameter("maNV", typeof(string));
    
            var hoTenParameter = hoTen != null ?
                new ObjectParameter("hoTen", hoTen) :
                new ObjectParameter("hoTen", typeof(string));
    
            var tuSoNgayThucLamParameter = tuSoNgayThucLam.HasValue ?
                new ObjectParameter("tuSoNgayThucLam", tuSoNgayThucLam) :
                new ObjectParameter("tuSoNgayThucLam", typeof(int));
    
            var denSoNgayThucLamParameter = denSoNgayThucLam.HasValue ?
                new ObjectParameter("denSoNgayThucLam", denSoNgayThucLam) :
                new ObjectParameter("denSoNgayThucLam", typeof(int));
    
            var tuThangParameter = tuThang.HasValue ?
                new ObjectParameter("tuThang", tuThang) :
                new ObjectParameter("tuThang", typeof(int));
    
            var denThangParameter = denThang.HasValue ?
                new ObjectParameter("denThang", denThang) :
                new ObjectParameter("denThang", typeof(int));
    
            var tuNamParameter = tuNam.HasValue ?
                new ObjectParameter("tuNam", tuNam) :
                new ObjectParameter("tuNam", typeof(int));
    
            var denNamParameter = denNam.HasValue ?
                new ObjectParameter("denNam", denNam) :
                new ObjectParameter("denNam", typeof(int));
    
            var tenCotParameter = tenCot != null ?
                new ObjectParameter("tenCot", tenCot) :
                new ObjectParameter("tenCot", typeof(string));
    
            var huongSapXepParameter = huongSapXep != null ?
                new ObjectParameter("huongSapXep", huongSapXep) :
                new ObjectParameter("huongSapXep", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_TimKiemVaSapXepLuong_Result>("USP_TimKiemVaSapXepLuong", maNVParameter, hoTenParameter, tuSoNgayThucLamParameter, denSoNgayThucLamParameter, tuThangParameter, denThangParameter, tuNamParameter, denNamParameter, tenCotParameter, huongSapXepParameter);
        }
    
        public virtual ObjectResult<USP_TimKiemVaSapXepNangLuc_Result> USP_TimKiemVaSapXepNangLuc(string maNV, string hoTen, string tenDV, string tenCot, string huongSapXep)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("maNV", maNV) :
                new ObjectParameter("maNV", typeof(string));
    
            var hoTenParameter = hoTen != null ?
                new ObjectParameter("hoTen", hoTen) :
                new ObjectParameter("hoTen", typeof(string));
    
            var tenDVParameter = tenDV != null ?
                new ObjectParameter("tenDV", tenDV) :
                new ObjectParameter("tenDV", typeof(string));
    
            var tenCotParameter = tenCot != null ?
                new ObjectParameter("tenCot", tenCot) :
                new ObjectParameter("tenCot", typeof(string));
    
            var huongSapXepParameter = huongSapXep != null ?
                new ObjectParameter("huongSapXep", huongSapXep) :
                new ObjectParameter("huongSapXep", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_TimKiemVaSapXepNangLuc_Result>("USP_TimKiemVaSapXepNangLuc", maNVParameter, hoTenParameter, tenDVParameter, tenCotParameter, huongSapXepParameter);
        }
    
        public virtual ObjectResult<USP_TimKiemVaSapXepNhanVien_Result> USP_TimKiemVaSapXepNhanVien(string maNV, string hoTen, string gioiTinh, Nullable<System.DateTime> tuNgay, Nullable<System.DateTime> denNgay, string diaChi, string soDT, string email, Nullable<decimal> tuLuong, Nullable<decimal> denLuong, string tenLoai, string trangThai, string tenCot, string huongSapXep)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("maNV", maNV) :
                new ObjectParameter("maNV", typeof(string));
    
            var hoTenParameter = hoTen != null ?
                new ObjectParameter("hoTen", hoTen) :
                new ObjectParameter("hoTen", typeof(string));
    
            var gioiTinhParameter = gioiTinh != null ?
                new ObjectParameter("gioiTinh", gioiTinh) :
                new ObjectParameter("gioiTinh", typeof(string));
    
            var tuNgayParameter = tuNgay.HasValue ?
                new ObjectParameter("tuNgay", tuNgay) :
                new ObjectParameter("tuNgay", typeof(System.DateTime));
    
            var denNgayParameter = denNgay.HasValue ?
                new ObjectParameter("denNgay", denNgay) :
                new ObjectParameter("denNgay", typeof(System.DateTime));
    
            var diaChiParameter = diaChi != null ?
                new ObjectParameter("diaChi", diaChi) :
                new ObjectParameter("diaChi", typeof(string));
    
            var soDTParameter = soDT != null ?
                new ObjectParameter("soDT", soDT) :
                new ObjectParameter("soDT", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var tuLuongParameter = tuLuong.HasValue ?
                new ObjectParameter("tuLuong", tuLuong) :
                new ObjectParameter("tuLuong", typeof(decimal));
    
            var denLuongParameter = denLuong.HasValue ?
                new ObjectParameter("denLuong", denLuong) :
                new ObjectParameter("denLuong", typeof(decimal));
    
            var tenLoaiParameter = tenLoai != null ?
                new ObjectParameter("tenLoai", tenLoai) :
                new ObjectParameter("tenLoai", typeof(string));
    
            var trangThaiParameter = trangThai != null ?
                new ObjectParameter("trangThai", trangThai) :
                new ObjectParameter("trangThai", typeof(string));
    
            var tenCotParameter = tenCot != null ?
                new ObjectParameter("tenCot", tenCot) :
                new ObjectParameter("tenCot", typeof(string));
    
            var huongSapXepParameter = huongSapXep != null ?
                new ObjectParameter("huongSapXep", huongSapXep) :
                new ObjectParameter("huongSapXep", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_TimKiemVaSapXepNhanVien_Result>("USP_TimKiemVaSapXepNhanVien", maNVParameter, hoTenParameter, gioiTinhParameter, tuNgayParameter, denNgayParameter, diaChiParameter, soDTParameter, emailParameter, tuLuongParameter, denLuongParameter, tenLoaiParameter, trangThaiParameter, tenCotParameter, huongSapXepParameter);
        }
    
        public virtual ObjectResult<USP_TimKiemVaSapXepChiTietCV_Result1> USP_TimKiemVaSapXepChiTietCV(Nullable<int> maCV, string tenDV, string tenLX, string tenCot, string huongSapXep)
        {
            var maCVParameter = maCV.HasValue ?
                new ObjectParameter("maCV", maCV) :
                new ObjectParameter("maCV", typeof(int));
    
            var tenDVParameter = tenDV != null ?
                new ObjectParameter("tenDV", tenDV) :
                new ObjectParameter("tenDV", typeof(string));
    
            var tenLXParameter = tenLX != null ?
                new ObjectParameter("tenLX", tenLX) :
                new ObjectParameter("tenLX", typeof(string));
    
            var tenCotParameter = tenCot != null ?
                new ObjectParameter("tenCot", tenCot) :
                new ObjectParameter("tenCot", typeof(string));
    
            var huongSapXepParameter = huongSapXep != null ?
                new ObjectParameter("huongSapXep", huongSapXep) :
                new ObjectParameter("huongSapXep", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_TimKiemVaSapXepChiTietCV_Result1>("USP_TimKiemVaSapXepChiTietCV", maCVParameter, tenDVParameter, tenLXParameter, tenCotParameter, huongSapXepParameter);
        }
    
        public virtual ObjectResult<USP_TimKiemVaSapXepDonGiaTheoNhanVien_Result> USP_TimKiemVaSapXepDonGiaTheoNhanVien(string maNV, string tenDV, string tenLX, string tenCot, string huongSapXep)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("maNV", maNV) :
                new ObjectParameter("maNV", typeof(string));
    
            var tenDVParameter = tenDV != null ?
                new ObjectParameter("tenDV", tenDV) :
                new ObjectParameter("tenDV", typeof(string));
    
            var tenLXParameter = tenLX != null ?
                new ObjectParameter("tenLX", tenLX) :
                new ObjectParameter("tenLX", typeof(string));
    
            var tenCotParameter = tenCot != null ?
                new ObjectParameter("tenCot", tenCot) :
                new ObjectParameter("tenCot", typeof(string));
    
            var huongSapXepParameter = huongSapXep != null ?
                new ObjectParameter("huongSapXep", huongSapXep) :
                new ObjectParameter("huongSapXep", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_TimKiemVaSapXepDonGiaTheoNhanVien_Result>("USP_TimKiemVaSapXepDonGiaTheoNhanVien", maNVParameter, tenDVParameter, tenLXParameter, tenCotParameter, huongSapXepParameter);
        }
    
        public virtual ObjectResult<USP_TimKiemNhanVienRutGon_Result> USP_TimKiemNhanVienRutGon(string maNV, string hoTen)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("maNV", maNV) :
                new ObjectParameter("maNV", typeof(string));
    
            var hoTenParameter = hoTen != null ?
                new ObjectParameter("hoTen", hoTen) :
                new ObjectParameter("hoTen", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_TimKiemNhanVienRutGon_Result>("USP_TimKiemNhanVienRutGon", maNVParameter, hoTenParameter);
        }
    }
}
