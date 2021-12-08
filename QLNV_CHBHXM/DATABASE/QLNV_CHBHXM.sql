CREATE DATABASE QLNV_CHBHXM
GO

USE QLNV_CHBHXM
GO

--DROP DATABASE QLNV_CHBHXM

--=================================================== TABLE ===================================================
CREATE TABLE LoaiNV
(
	MaLoai INT IDENTITY PRIMARY KEY,
	TenLoai NVARCHAR(100) UNIQUE NOT NULL
)
GO

CREATE TABLE NhanVien
(
	MaNV VARCHAR(10) PRIMARY KEY,
	HoTen NVARCHAR(100) NOT NULL,
	GioiTinh NVARCHAR(5) NOT NULL CHECK (GioiTinh IN (N'Nam', N'Nữ')),
	NgaySinh DATE NOT NULL,
	DiaChi NVARCHAR(100) NOT NULL,
	SoDT VARCHAR(10) NOT NULL CHECK (ISNUMERIC(SoDT) = 1), -- Số điện thoại phải là số
	Email VARCHAR(100) NOT NULL, -- Email dùng để gửi tin nhắn khi đặt lại mật khẩu
	LuongCoBan DECIMAL NOT NULL CHECK (LuongCoBan >= 0),
	MaLoai INT NOT NULL FOREIGN KEY REFERENCES LoaiNV(MaLoai),
	TrangThai NVARCHAR(100) NOT NULL DEFAULT N'Đang làm' CHECK (TrangThai IN (N'Đang làm', N'Nghỉ'))
)
GO

CREATE TABLE TaiKhoan
(
	TenDangNhap VARCHAR(100) PRIMARY KEY,
	MatKhau VARCHAR(1000) NOT NULL DEFAULT '741253021220717864511724120418410161155', /*0000*/
	MaNV VARCHAR(10) UNIQUE NOT NULL FOREIGN KEY REFERENCES NhanVien(MaNV)
)
GO

CREATE TABLE DichVu
(
	MaDV INT IDENTITY PRIMARY KEY,
	TenDV NVARCHAR(100) UNIQUE NOT NULL,
)
GO

CREATE TABLE NangLuc
(
	MaNV VARCHAR(10) FOREIGN KEY REFERENCES NhanVien(MaNV),
	MaDV INT FOREIGN KEY REFERENCES DichVu(MaDV)
	
	PRIMARY KEY(MaNV, MaDV)
)
GO

CREATE TABLE LoaiXe
(
	MaLX INT IDENTITY PRIMARY KEY,
	TenLX NVARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE BangGia
(
	MaDG INT IDENTITY UNIQUE NOT NULL,
	MaDV INT FOREIGN KEY REFERENCES DichVu(MaDV),
	MaLX INT FOREIGN KEY REFERENCES LoaiXe(MaLX),
	DonGia INT CHECK (DonGia >= 0),
	TrangThai NVARCHAR(100) NOT NULL DEFAULT N'Đang dùng' CHECK (TrangThai IN (N'Đang dùng', N'Ngưng'))

	PRIMARY KEY(MaDV, MaLX, DonGia)
)

CREATE TABLE CongViec
(
	MaCV INT IDENTITY UNIQUE NOT NULL,
	MaNV VARCHAR(10) FOREIGN KEY REFERENCES NhanVien(MaNV),
	NgayLam DATE,
	TongTien DECIMAL CHECK (TongTien >= 0)
	
	PRIMARY KEY(MaNV, NgayLam)
)
GO

CREATE TABLE ChiTietCV
(
	MaCV INT FOREIGN KEY REFERENCES CongViec(MaCV),
	MaDG INT FOREIGN KEY REFERENCES BangGia(MaDG),
	Soluong INT NOT NULL CHECK (SoLuong > 0)
	
	PRIMARY KEY(MaCV, MaDG)
)
GO

CREATE TABLE Luong
(
	MaNV VARCHAR(10) FOREIGN KEY REFERENCES NhanVien(MaNV),
	Thang INT CHECK (Thang >= 1 AND Thang <= 12),
	Nam INT CHECK (Nam >= 2000),
	SoNgayThucLam INT NOT NULL CHECK (SoNgayThucLam >= 0 AND SoNgayThucLam <= 31),
	TongDoanhThu DECIMAL CHECK (TongDoanhThu >= 0),
	
	PRIMARY KEY(MaNV, Thang, Nam)
)
GO

--=================================================== FUNCTION ===================================================
-- Lấy mã loại nhân viên theo tên loại
CREATE FUNCTION UF_LayMaLoaiTheoTenLoai(@tenLoai NVARCHAR(100))
RETURNS INT
AS
BEGIN
	DECLARE @maLoai INT = -1
	SELECT @maLoai = MaLoai
	FROM LoaiNV
	WHERE TenLoai = @tenLoai

	RETURN @maLoai
END
GO

-- Hàm chuyển ký tự có dấu về không dấu
CREATE FUNCTION ConvertToUnsign
( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) 
AS 
BEGIN
	IF @strInput IS NULL 
	RETURN @strInput 
	IF @strInput = '' 
	RETURN @strInput 
	
	DECLARE @RT NVARCHAR(4000) 
	DECLARE @SIGN_CHARS NCHAR(136) 
	DECLARE @UNSIGN_CHARS NCHAR (136) 
	SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) 
	SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' 
	
	DECLARE @COUNTER int 
	DECLARE @COUNTER1 int 
	SET @COUNTER = 1 
	WHILE (@COUNTER <=LEN(@strInput)) 
	BEGIN 
		SET @COUNTER1 = 1 
		WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) 
		BEGIN 
			IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) 
			BEGIN 
				IF @COUNTER=1 
					SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) 
				ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) 
				BREAK 
			END 
			SET @COUNTER1 = @COUNTER1 +1 
		END 
		SET @COUNTER = @COUNTER +1 
	END 
	SET @strInput = replace(@strInput,' ','-') 
	RETURN @strInput 
END
GO

--++++++++++++++++++++++++++++++++++++++++++++++++++++ TRIGGER ++++++++++++++++++++++++++++++++++++++++++++++++++++
-- Khi thêm/sửa(TrangThai) đơn giá, ngưng (tất cả) đơn giá có MaDV và MaLX tương ứng
CREATE TRIGGER UTG_CapNhatTrangThaiKhiThemSuaDonGia
ON BangGia FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @maDG INT = -1
	DECLARE @maDV INT = -1
	DECLARE @maLX INT = -1
	DECLARE @trangThai NVARCHAR(100)

	SELECT @maDG = MaDG, @maDV = MaDV, @maLX = MaLX, @trangThai = TrangThai
	FROM inserted

	IF(@trangThai = N'Đang dùng')
	BEGIN
		UPDATE BangGia
		SET TrangThai = N'Ngưng'
		WHERE MaDV = @maDV AND MaLX = @maLX
		AND MaDG != @maDG
	END
END
GO

--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
-- Khi thêm, xóa, sửa một chi tiết công việc, tự động cập nhật tổng tiền trong công việc
-- Nếu xóa tất cả chi tiết công việc của một công việc thì xóa luôn công việc đó
CREATE TRIGGER UTG_TinhLaiTongTienKhiThayDoiChiTietCV
ON ChiTietCV FOR INSERT, UPDATE, DELETE
AS
BEGIN
	DECLARE @maCV INT = -1

	SELECT @maCV = MaCV
	FROM inserted

	-- Không phải là thêm hoặc sửa
	IF(@maCV = -1)
	BEGIN
		SELECT @maCV = MaCV
		FROM deleted

		-- Kiểm tra đây có phải là chi tiết công việc cuối cùng
		DECLARE @dem INT = 0
		SELECT @dem = COUNT(*)
		FROM ChiTietCV
		WHERE MaCV = @maCV

		-- Nếu không còn chi tiết công việc của công việc này thì xóa luôn công việc đó và thoát
		IF(@dem = 0)
		BEGIN
			DELETE FROM CongViec WHERE MaCV = @maCV
			RETURN
		END
	END

	-- Tính lại tổng tiền
	DECLARE @tongTien INT = 0
	SELECT @tongTien = SUM(DonGia * SoLuong)
	FROM ChiTietCV AS CT
	INNER JOIN CongViec AS CV ON CT.MaCV = CV.MaCV
	INNER JOIN BangGia AS BG ON CT.MaDG = BG.MaDG
	WHERE CT.MaCV = @maCV

	UPDATE CongViec SET TongTien = @tongTien WHERE MaCV = @maCV
END
GO
--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
-- Khi thêm, sửa, xóa công việc => Tính lại lương trong bảng lương
CREATE TRIGGER UTG_TinhLaiLuongKhiThayDoiCongViec
ON CongViec FOR INSERT, UPDATE, DELETE
AS
BEGIN
	DECLARE @maNV VARCHAR(10) = ''
	DECLARE @ngayLam DATE = NULL
	-- Thêm hoặc sửa
	SELECT @maNV = MaNV, @ngayLam = NgayLam
	FROM inserted

	-- Xóa
	IF(@maNV = '')
	BEGIN
		SELECT @maNV = MaNV, @ngayLam = NgayLam
		FROM deleted
	END

	-- Nếu ban đầu bảng đã trống => Kết thúc
	IF(@maNV = '')
		RETURN

	DECLARE @thang INT = MONTH(@ngayLam)
	DECLARE @nam INT = YEAR(@ngayLam)

	-- Tính lại số ngày thực làm và tổng doanh thu của nhân viên trong tháng/năm
	DECLARE @soNgayThucLam INT = 0
	DECLARE @tongDoanhThu DECIMAL = 0
	SELECT @soNgayThucLam = COUNT(*), @tongDoanhThu = SUM(TongTien)
	FROM CongViec
	WHERE MaNV = @maNV AND MONTH(NgayLam) = @thang AND YEAR(NgayLam) = @nam

	-- Nếu số ngày thực làm = 0 => Xóa bảng ghi lương, xem như chưa có lương và thoát
	IF(@soNgayThucLam = 0)
	BEGIN
		DELETE FROM Luong WHERE MaNV = @maNV AND Thang = @thang AND Nam = @nam
		RETURN
	END

	-- Kiểm tra đã tồn tại bản ghi lương của người này
	DECLARE @dem INT = -1
	SELECT @dem = COUNT(*)
	FROM Luong
	WHERE MaNV = @maNV AND Thang = @thang AND Nam = @nam

	-- Nếu chưa có thì thêm vào
	IF(@dem = 0)
	BEGIN
		INSERT INTO Luong(MaNV, Thang, Nam, SoNgayThucLam, TongDoanhThu) 
		VALUES(@maNV, @thang, @nam, @soNgayThucLam, @tongDoanhThu)
	END
	-- Nếu đã có thì cập nhật lại số liệu
	ELSE
	BEGIN
		UPDATE Luong SET SoNgayThucLam = @soNgayThucLam, TongDoanhThu = @tongDoanhThu
		WHERE MaNV = @maNV AND Thang = @thang AND Nam = @nam
	END
END
GO
--=================================================== STORED PROCEDURE ===================================================
-- Lấy mã tự tăng tiếp theo
CREATE PROC USP_LayMaTiepTheo
@table_name VARCHAR(100)
AS
BEGIN
	SELECT IDENT_CURRENT(@table_name) + IDENT_INCR(@table_name)
END
GO
-- USP_LayMaDVTiepTheo 'DichVu'
--===========================================================================================================================
-- Tìm kiếm và sắp xếp nhân viên - tài khoản
CREATE PROC USP_TimKiemVaSapXepNhanVien
@maNV VARCHAR(10),
@hoTen NVARCHAR(100),
@gioiTinh NVARCHAR(5),
@tuNgay DATE,
@denNgay DATE,
@diaChi NVARCHAR(100),
@soDT VARCHAR(10),
@email VARCHAR(100),
@tuLuong DECIMAL,
@denLuong DECIMAL,
@tenLoai NVARCHAR(100),
@trangThai NVARCHAR(100),
@tenCot VARCHAR(100),
@huongSapXep VARCHAR(5)
AS
BEGIN
	DECLARE @table TABLE
	(MaNV VARCHAR(10), HoTen NVARCHAR(100), GioiTinh NVARCHAR(5), NgaySinh DATE, DiaChi NVARCHAR(100),
	SoDT VARCHAR(10), Email VARCHAR(100), LuongCoBan DECIMAL, TenDangNhap VARCHAR(100), TenLoai NVARCHAR(100), TrangThai NVARCHAR(100))

	DECLARE @query NVARCHAR(MAX)

	SELECT @query = 
	N'SELECT N.MaNV, HoTen, GioiTinh, NgaySinh, DiaChi, SoDT, Email, LuongCoBan, TenDangNhap, TenLoai, TrangThai
	FROM NhanVien AS N
	INNER JOIN LoaiNV AS L ON N.MaLoai = L.MaLoai
	LEFT JOIN TaiKhoan AS T ON T.MaNV = N.MaNV
	WHERE N.MaNV LIKE ''%'' + @maNV + ''%'' 
	AND dbo.ConvertToUnsign(HoTen) LIKE ''%'' + dbo.ConvertToUnsign(@hoTen) + ''%''
	AND GioiTinh LIKE ''%'' + @gioiTinh + ''%''
	AND (NgaySinh >= @tuNgay AND NgaySinh <= @denNgay)
	AND dbo.ConvertToUnsign(DiaChi) LIKE ''%'' + dbo.ConvertToUnsign(@diaChi) + ''%''
	AND SoDT LIKE ''%'' + @soDT + ''%''
	AND Email LIKE ''%'' + @email + ''%''
	AND (LuongCoBan >= @tuLuong AND LuongCoBan <= @denLuong)
	AND TenLoai LIKE ''%'' + @tenLoai + ''%''
	AND TrangThai LIKE ''%'' + @trangThai + ''%''
	AND N.MaNV <> ''ADMIN''
	ORDER BY ' + @tenCot + ' ' + @huongSapXep
    
	INSERT INTO @table (MaNV, HoTen, GioiTinh, NgaySinh, DiaChi, SoDT, Email, LuongCoBan, TenDangNhap, TenLoai, TrangThai)
	EXEC sp_executesql @query,
	N'@maNV VARCHAR(10),
	@hoTen NVARCHAR(100),
	@gioiTinh NVARCHAR(5),
	@tuNgay DATE,
	@denNgay DATE,
	@diaChi NVARCHAR(100),
	@soDT VARCHAR(10),
	@email VARCHAR(100),
	@tuLuong DECIMAL,
	@denLuong DECIMAL,
	@tenLoai NVARCHAR(100),
	@trangThai NVARCHAR(100),
	@tenCot VARCHAR(100),
	@huongSapXep VARCHAR(5)',
	@maNV,
	@hoTen,
	@gioiTinh,
	@tuNgay,
	@denNgay,
	@diaChi,
	@soDT,
	@email,
	@tuLuong,
	@denLuong,
	@tenLoai,
	@trangThai,
	@tenCot,
	@huongSapXep

	SELECT * FROM @table
END
GO
-- USP_TimKiemVaSapXepNhanVien '', '', '', '1753-1-1', '9998-12-31', '', '', '', 0, 1000000000, '', N'', 'LuongCoBan', 'ASC'
--===========================================================================================================================
-- Tìm kiếm và sắp xếp dịch vụ
CREATE PROC USP_TimKiemVaSapXepDichVu
@tenDV NVARCHAR(100),
@tenCot VARCHAR(100),
@huongSapXep VARCHAR(5)
AS
BEGIN
	DECLARE @table TABLE
	(MaDV INT, TenDV NVARCHAR(100))

	DECLARE @query NVARCHAR(MAX)

	SELECT @query = 
	N'SELECT MaDV, TenDV
	FROM DichVu
	WHERE dbo.ConvertToUnsign(TenDV) LIKE ''%'' + dbo.ConvertToUnsign(@tenDV) + ''%''
	ORDER BY ' + @tenCot + ' ' + @huongSapXep
    
	INSERT INTO @table (MaDV, TenDV)
	EXEC sp_executesql @query,
	N'@tenDV NVARCHAR(100),
	@tenCot VARCHAR(100),
	@huongSapXep VARCHAR(5)',
	@tenDV,
	@tenCot,
	@huongSapXep

	SELECT * FROM @table
END
GO

-- USP_TimKiemVaSapXepDichVu '', 'TenDV', 'ASC'
--===========================================================================================================================
-- Tìm kiếm và sắp xếp loại xe
CREATE PROC USP_TimKiemVaSapXepLoaiXe
@tenLX NVARCHAR(100),
@tenCot VARCHAR(100),
@huongSapXep VARCHAR(5)
AS
BEGIN
	DECLARE @table TABLE
	(MaLX INT, TenLX NVARCHAR(100))

	DECLARE @query NVARCHAR(MAX)

	SELECT @query = 
	N'SELECT MaLX, TenLX
	FROM LoaiXe
	WHERE dbo.ConvertToUnsign(TenLX) LIKE ''%'' + dbo.ConvertToUnsign(@tenLX) + ''%''
	ORDER BY ' + @tenCot + ' ' + @huongSapXep
    
	INSERT INTO @table (MaLX, TenLX)
	EXEC sp_executesql @query,
	N'@tenLX NVARCHAR(100),
	@tenCot VARCHAR(100),
	@huongSapXep VARCHAR(5)',
	@tenLX,
	@tenCot,
	@huongSapXep

	SELECT * FROM @table
END
GO
-- USP_TimKiemVaSapXepLoaiXe '', 'MaLX', 'ASC'
--===========================================================================================================================
-- Tìm kiếm và sắp xếp năng lực
CREATE PROC USP_TimKiemVaSapXepNangLuc
@maNV VARCHAR(10),
@hoTen NVARCHAR(100),
@tenDV NVARCHAR(100),
@tenCot VARCHAR(100),
@huongSapXep VARCHAR(5)
AS
BEGIN
	DECLARE @table TABLE
	(MaNV VARCHAR(10), HoTen NVARCHAR(100), MaDV INT, TenDV NVARCHAR(100))

	DECLARE @query NVARCHAR(MAX)

	SELECT @query = 
	N'SELECT NL.MaNV, HoTen, NL.MaDV, TenDV
	FROM NangLuc AS NL
	INNER JOIN NhanVien AS NV ON NL.MaNV = NV.MaNV
	INNER JOIN DichVu AS DV ON NL.MaDV = DV.MaDV
	WHERE NL.MaNV LIKE ''%'' + @maNV + ''%''
	AND dbo.ConvertToUnsign(HoTen) LIKE ''%'' + dbo.ConvertToUnsign(@hoTen) + ''%''
	AND dbo.ConvertToUnsign(TenDV) LIKE ''%'' + dbo.ConvertToUnsign(@tenDV) + ''%''
	AND TrangThai = N''Đang làm''
	ORDER BY ' + @tenCot + ' ' + @huongSapXep
    
	INSERT INTO @table (MaNV, HoTen, MaDV, TenDV)
	EXEC sp_executesql @query,
	N'@maNV VARCHAR(10),
	@hoTen NVARCHAR(100),
	@tenDV NVARCHAR(100),
	@tenCot VARCHAR(100),
	@huongSapXep VARCHAR(5)',
	@maNV,
	@hoTen,
	@tenDV,
	@tenCot,
	@huongSapXep

	SELECT * FROM @table
END
GO
-- USP_TimKiemVaSapXepNangLuc '', '', '', 'MaNV', 'ASC'
--===========================================================================================================================
-- Tìm kiếm và sắp xếp nhân viên rút gọn
CREATE PROC USP_TimKiemNhanVienRutGon
@maNV VARCHAR(10),
@hoTen NVARCHAR(100)
AS
BEGIN
	SELECT MaNV, HoTen
	FROM NhanVien
	WHERE MaNV LIKE '%' + @maNV + '%'
	AND dbo.ConvertToUnsign(HoTen) LIKE '%' + dbo.ConvertToUnsign(@hoTen) + '%'
	AND TrangThai LIKE N'Đang làm'
END
GO
-- USP_TimKiemNhanVienRutGon '', ''
--===========================================================================================================================
-- Tìm kiếm dịch vụ chưa phân công cho nhân viên
CREATE PROC USP_TimKiemDichVuChuaPhanCong
@maNV VARCHAR(10),
@tenDV NVARCHAR(100)
AS
BEGIN
	IF(@maNV = '')
	BEGIN
		SELECT MaDV,TenDV
		FROM DichVu
		WHERE 1 = 2
		RETURN
	END

	SELECT MaDV,TenDV
	FROM DichVu
	WHERE dbo.ConvertToUnsign(TenDV) LIKE '%' + dbo.ConvertToUnsign(@tenDV) + '%'
	AND MaDV NOT IN (SELECT MaDV
				FROM NangLuc
				WHERE MaNV = @maNV)
END
GO
-- USP_TimKiemDichVuChuaPhanCong 'N21NVQL000', ''
--===========================================================================================================================
-- Tìm kiếm và sắp xếp các đơn giá
CREATE PROC USP_TimKiemVaSapXepDonGia
@tenDV NVARCHAR(100),
@tenLX NVARCHAR(100),
@trangThai NVARCHAR(100),
@tenCot VARCHAR(100),
@huongSapXep VARCHAR(5)
AS
BEGIN
	DECLARE @table TABLE
	(MaDG INT, TenDV NVARCHAR(100), TenLX NVARCHAR(100), DonGia INT, TrangThai NVARCHAR(100))

	DECLARE @query NVARCHAR(MAX)

	SELECT @query = 
	N'SELECT MaDG, TenDV, TenLX, DonGia, TrangThai
	FROM BangGia AS BG
	INNER JOIN DichVu AS DV ON BG.MaDV = DV.MaDV
	INNER JOIN LoaiXe AS LX ON BG.MaLX = LX.MaLX
	WHERE dbo.ConvertToUnsign(TenDV) LIKE ''%'' + dbo.ConvertToUnsign(@tenDV) + ''%''
	AND dbo.ConvertToUnsign(TenLX) LIKE ''%'' + dbo.ConvertToUnsign(@tenLX) + ''%''
	AND TrangThai LIKE ''%'' + @trangThai + ''%''
	ORDER BY ' + @tenCot + ' ' + @huongSapXep
    
	INSERT INTO @table (MaDG, TenDV, TenLX, DonGia, TrangThai)
	EXEC sp_executesql @query,
	N'@tenDV NVARCHAR(100),
	@tenLX NVARCHAR(100),
	@trangThai NVARCHAR(100),
	@tenCot VARCHAR(100),
	@huongSapXep VARCHAR(5)',
	@tenDV,
	@tenLX,
	@trangThai,
	@tenCot,
	@huongSapXep

	SELECT * FROM @table
END
GO
-- USP_TimKiemVaSapXepDonGia '', '', N'Đang dùng', 'MaDG', 'ASC'
--===========================================================================================================================
-- Tìm kiếm và sắp xếp các công việc trong ngày
CREATE PROC USP_TimKiemVaSapXepCongViec
@maNV VARCHAR(10),
@hoTen NVARCHAR(100),
@ngayLam DATE,
@tenCot VARCHAR(100),
@huongSapXep VARCHAR(5)
AS
BEGIN
	DECLARE @table TABLE
	(MaCV INT, MaNV VARCHAR(10), HoTen NVARCHAR(100), TongTien DECIMAL)

	DECLARE @query NVARCHAR(MAX)

	SELECT @query = 
	N'SELECT MaCV, CV.MaNV, HoTen, TongTien
	FROM CongViec AS CV
	INNER JOIN NhanVien AS NV ON CV.MaNV = NV.MaNV
	WHERE CV.MaNV LIKE ''%'' + @maNV + ''%''
	AND dbo.ConvertToUnsign(HoTen) LIKE ''%'' + dbo.ConvertToUnsign(@hoTen) + ''%''
	AND NgayLam = @ngayLam
	ORDER BY ' + @tenCot + ' ' + @huongSapXep
    
	INSERT INTO @table (MaCV, MaNV, HoTen, TongTien)
	EXEC sp_executesql @query,
	N'@maNV VARCHAR(10),
	@hoTen NVARCHAR(100),
	@ngayLam DATE,
	@tenCot VARCHAR(100),
	@huongSapXep VARCHAR(5)',
	@maNV,
	@hoTen,
	@ngayLam,
	@tenCot,
	@huongSapXep

	SELECT * FROM @table
END
GO
-- USP_TimKiemVaSapXepCongViec '', '', '2021-04-27', 'MaCV', 'ASC'
--===========================================================================================================================
-- Tìm kiếm và sắp xếp chi tiết công việc
CREATE PROC USP_TimKiemVaSapXepChiTietCV
@maCV INT,
@tenDV NVARCHAR(100),
@tenLX NVARCHAR(100),
@tenCot VARCHAR(100),
@huongSapXep VARCHAR(5)
AS
BEGIN
	DECLARE @table TABLE
	(MaDG INT, TenDV NVARCHAR(100), TenLX NVARCHAR(100), DonGia INT, SoLuong INT, Tong INT)

	DECLARE @query NVARCHAR(MAX)

	SELECT @query = 
	N'SELECT CV.MaDG, TenDV, TenLX, DonGia, SoLuong, (DonGia * SoLuong) AS [Tong]
	FROM ChiTietCV AS CV
	INNER JOIN BangGia AS BG ON CV.MaDG = BG.MaDG
	INNER JOIN DichVu AS DV ON BG.MaDV = DV.MaDV
	INNER JOIN LoaiXe AS LX ON BG.MaLX = LX.MaLX
	WHERE MaCV = @maCV
	AND dbo.ConvertToUnsign(TenDV) LIKE ''%'' + dbo.ConvertToUnsign(@tenDV) + ''%''
	AND dbo.ConvertToUnsign(TenLX) LIKE ''%'' + dbo.ConvertToUnsign(@tenLX) + ''%''
	ORDER BY ' + @tenCot + ' ' + @huongSapXep
    
	INSERT INTO @table (MaDG, TenDV, TenLX, DonGia, SoLuong, Tong)
	EXEC sp_executesql @query,
	N'@maCV INT,
	@tenDV NVARCHAR(100),
	@tenLX NVARCHAR(100),
	@tenCot VARCHAR(100),
	@huongSapXep VARCHAR(5)',
	@maCV,
	@tenDV,
	@tenLX,
	@tenCot,
	@huongSapXep

	SELECT * FROM @table
END
GO
-- USP_TimKiemVaSapXepChiTietCV -1, '', '', 'TenDV', 'ASC'
--===========================================================================================================================
-- Tìm kiếm và sắp xếp các đơn giá phù hợp với nhân viên (theo bảng năng lực) và đang được dùng
CREATE PROC USP_TimKiemVaSapXepDonGiaTheoNhanVien
@maNV VARCHAR(10),
@tenDV NVARCHAR(100),
@tenLX NVARCHAR(100),
@tenCot VARCHAR(100),
@huongSapXep VARCHAR(5)
AS
BEGIN
	DECLARE @table TABLE
	(MaDG INT, TenDV NVARCHAR(100), TenLX NVARCHAR(100), DonGia INT, TrangThai NVARCHAR(100))

	DECLARE @query NVARCHAR(MAX)

	SELECT @query = 
	N'SELECT MaDG, TenDV, TenLX, DonGia, TrangThai
	FROM BangGia AS BG
	INNER JOIN DichVu AS DV ON BG.MaDV = DV.MaDV
	INNER JOIN LoaiXe AS LX ON BG.MaLX = LX.MaLX
	WHERE dbo.ConvertToUnsign(TenDV) LIKE ''%'' + dbo.ConvertToUnsign(@tenDV) + ''%''
	AND dbo.ConvertToUnsign(TenLX) LIKE ''%'' + dbo.ConvertToUnsign(@tenLX) + ''%''
	AND TrangThai = N''Đang dùng''
	AND DV.MaDV IN (SELECT MaDV
				FROM NangLuc
				WHERE MaNV = @maNV)
	ORDER BY ' + @tenCot + ' ' + @huongSapXep
    
	INSERT INTO @table (MaDG, TenDV, TenLX, DonGia, TrangThai)
	EXEC sp_executesql @query,
	N'@maNV VARCHAR(10),
	@tenDV NVARCHAR(100),
	@tenLX NVARCHAR(100),
	@tenCot VARCHAR(100),
	@huongSapXep VARCHAR(5)',
	@maNV,
	@tenDV,
	@tenLX,
	@tenCot,
	@huongSapXep

	SELECT * FROM @table
END
GO
-- USP_TimKiemVaSapXepDonGiaTheoNhanVien 'N21NVQL000', '', '', 'MaDG', 'ASC'
--===========================================================================================================================
-- Tìm kiếm và sắp xếp lương nhân viên
CREATE PROC USP_TimKiemVaSapXepLuong
@maNV VARCHAR(10),
@hoTen NVARCHAR(100),
@tuSoNgayThucLam INT,
@denSoNgayThucLam INT,
@tuThang INT,
@denThang INT,
@tuNam INT,
@denNam INT,
@tenCot VARCHAR(100),
@huongSapXep VARCHAR(5)
AS
BEGIN
	DECLARE @table TABLE
	(MaNV VARCHAR(10), HoTen NVARCHAR(100), Thang INT, Nam INT, SoNgayThucLam INT, TongDoanhThu DECIMAL, LuongThucLanh DECIMAL)

	DECLARE @query NVARCHAR(MAX)

	SELECT @query = 
	N'SELECT L.MaNV, HoTen, Thang, Nam, SoNgayThucLam, TongDoanhThu, (LuongCoBan * SoNgayThucLam / 26 + TongDoanhThu * 0.05) AS LuongThucLanh
	FROM Luong AS L
	INNER JOIN NhanVien AS NV ON L.MaNV = NV.MaNV
	WHERE L.MaNV LIKE ''%'' + @maNV + ''%''
	AND dbo.ConvertToUnsign(HoTen) LIKE ''%'' + dbo.ConvertToUnsign(@hoTen) + ''%''
	AND (SoNgayThucLam >= @tuSoNgayThucLam AND SoNgayThucLam <= @denSoNgayThucLam)
	AND (Thang >= @tuThang AND Thang <= @denThang)
	AND (Nam >= @tuNam AND Nam <= @denNam)
	ORDER BY ' + @tenCot + ' ' + @huongSapXep
    
	INSERT INTO @table (MaNV, HoTen, Thang, Nam, SoNgayThucLam, TongDoanhThu, LuongThucLanh)
	EXEC sp_executesql @query,
	N'@maNV VARCHAR(10),
	@hoTen NVARCHAR(100),
	@tuSoNgayThucLam INT,
	@denSoNgayThucLam INT,
	@tuThang INT,
	@denThang INT,
	@tuNam INT,
	@denNam INT,
	@tenCot VARCHAR(100),
	@huongSapXep VARCHAR(5)',
	@maNV,
	@hoTen,
	@tuSoNgayThucLam,
	@denSoNgayThucLam,
	@tuThang,
	@denThang,
	@tuNam,
	@denNam,
	@tenCot,
	@huongSapXep

	SELECT * FROM @table
END
GO
--=================================================== VALUE ===================================================
INSERT INTO LoaiNV(TenLoai)
VALUES (N'Nhân viên')
INSERT INTO LoaiNV(TenLoai)
VALUES (N'Quản lý')
GO

INSERT INTO NhanVien(MaNV, HoTen, GioiTinh, NgaySinh, DiaChi, SoDT, Email, LuongCoBan, MaLoai, TrangThai)
VALUES ('ADMIN', 'Administrator', N'Nam', '2000-1-1', N'...', '0912012314', 'admin12345@gmail.com', 0, dbo.UF_LayMaLoaiTheoTenLoai(N'Quản lý'), N'Nghỉ')
GO

INSERT INTO TaiKhoan(TenDangNhap, MatKhau, MaNV)
VALUES (N'admin', '6fd742a61bd034804c00c49b18045020' /*123*/, 'ADMIN')
GO