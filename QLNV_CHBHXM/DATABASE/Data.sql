USE QLNV_CHBHXM
GO

--========================================= Nhân viên ==================================================
INSERT INTO NhanVien(MaNV, HoTen, GioiTinh, NgaySinh, DiaChi, SoDT, Email, LuongCoBan, MaLoai, TrangThai)
VALUES ('N21NVQL000', N'Phạm Đức Phú Phúc', N'Nam', '2000-5-7', N'Thôn Cam Bình, xã Tân Phước, thị xã LaGi, tỉnh Bình Thuận',
'0923311124', 'phuphuc0705@gmail.com', 10000000, dbo.UF_LayMaLoaiTheoTenLoai(N'Quản lý'), N'Đang làm')

INSERT INTO NhanVien(MaNV, HoTen, GioiTinh, NgaySinh, DiaChi, SoDT, Email, LuongCoBan, MaLoai, TrangThai)
VALUES ('N21NVQL001', N'Lê Thị Huyền Trân', N'Nữ', '1999-10-2', N'Làng Vạn Hạnh, TT. Phú Mỹ, Tân Thành, Bà Rịa - Vũng Tàu',
'0902011999', 'huyentran99@gmail.com', 11000000, dbo.UF_LayMaLoaiTheoTenLoai(N'Quản lý'), N'Đang làm')

INSERT INTO NhanVien(MaNV, HoTen, GioiTinh, NgaySinh, DiaChi, SoDT, Email, LuongCoBan, MaLoai, TrangThai)
VALUES ('N21NVBT000', N'Nguyễn Thị Trà My', N'Nữ', '2001-1-10', N'22 Trịnh Phong, Phước Tiến, Thành phố Nha Trang, Khánh Hòa',
'0905023321', 'tramy2001@gmail.com', 8000000, dbo.UF_LayMaLoaiTheoTenLoai(N'Nhân viên'), N'Đang làm')

INSERT INTO NhanVien(MaNV, HoTen, GioiTinh, NgaySinh, DiaChi, SoDT, Email, LuongCoBan, MaLoai, TrangThai)
VALUES ('N21NVBT001', N'Trần Phi Hùng', N'Nam', '2001-12-31', N'2506 Hùng Vương, Ba Ngòi, Cam Ranh, Khánh Hòa',
'0902351379', 'hungdeptrai777@gmail.com', 8000000, dbo.UF_LayMaLoaiTheoTenLoai(N'Nhân viên'), N'Đang làm')
GO
--========================================= Dịch vụ ==================================================
INSERT INTO DichVu(TenDV)
VALUES (N'Giảm xóc trước')

INSERT INTO DichVu(TenDV)
VALUES (N'Giảm xóc sau')

INSERT INTO DichVu(TenDV)
VALUES (N'Chế hòa khí, lọc gió')

INSERT INTO DichVu(TenDV)
VALUES (N'Bugi')

INSERT INTO DichVu(TenDV)
VALUES (N'Motor đề')
GO

INSERT INTO DichVu(TenDV)
VALUES (N'Dây ga')
GO

INSERT INTO DichVu(TenDV)
VALUES (N'Dây công tơ mét')
GO

INSERT INTO DichVu(TenDV)
VALUES (N'Dây phanh')
GO

INSERT INTO DichVu(TenDV)
VALUES (N'Bát phanh trước')
GO

INSERT INTO DichVu(TenDV)
VALUES (N'Bát phanh sau')
GO

INSERT INTO DichVu(TenDV)
VALUES (N'Công tắc đèn')
GO

INSERT INTO DichVu(TenDV)
VALUES (N'Súc nạp ắc quy')
GO

--========================================= Loại xe ==================================================
INSERT INTO LoaiXe(TenLX)
VALUES (N'Honda Winner X')

INSERT INTO LoaiXe(TenLX)
VALUES (N'Honda Vision')
GO

INSERT INTO LoaiXe(TenLX)
VALUES (N'Honda SH Mode 125')
GO

INSERT INTO LoaiXe(TenLX)
VALUES (N'Honda Lead 125 Fi')
GO

INSERT INTO LoaiXe(TenLX)
VALUES (N'Honda Future 125 Fi')
GO

INSERT INTO LoaiXe(TenLX)
VALUES (N'Honda Air Blade 125')
GO

INSERT INTO LoaiXe(TenLX)
VALUES (N'SYM Attila 50')
GO

INSERT INTO LoaiXe(TenLX)
VALUES (N'SYM Passing 50')
GO

INSERT INTO LoaiXe(TenLX)
VALUES (N'SYM Elite 50')
GO

INSERT INTO LoaiXe(TenLX)
VALUES (N'SYM Elegant 110')
GO

INSERT INTO LoaiXe(TenLX)
VALUES (N'SYM Star SR 170')
GO
--========================================= Năng lực ==================================================
--========================================= BangGia ==================================================
--========================================= CongViec ==================================================
--========================================= ChiTietCV ==================================================
--========================================= Luong ==================================================
--========================================= TaiKhoan ==================================================

SELECT * FROM NhanVien
SELECT * FROM DichVu
SELECT * FROM LoaiXe
SELECT * FROM NangLuc
SELECT * FROM BangGia
SELECT * FROM CongViec
SELECT * FROM ChiTietCV
SELECT * FROM Luong
SELECT * FROM TaiKhoan

 --DELETE FROM Luong
 --DELETE FROM ChiTietCV
 --DELETE FROM CongViec
 --DELETE FROM BangGia
 --DELETE FROM NangLuc
 --DELETE FROM LoaiXe
 --DELETE FROM DichVu
 --DELETE FROM TaiKhoan WHERE TenDangNhap <> 'admin'
 --DELETE FROM NhanVien WHERE MaNV <> 'ADMIN'