-- Những bảng database cần có trong quản lý quán cafe
-- Khu vực(KHU_VUC)
-- Bàn(BAN)
-- Hóa đơn(HOA_DON_BAN_HANG)
-- Chi tiết hóa đơn(CHI_TIET_HD_BAN_HANG)
-- Nhân viên liên quan(quản lý nhân viên)(NHAN_VIEN)
-- Khách hàng của hóa đơn(quản lý khách hàng)(KHACH_HANG)
-- Chi tiết khách hàng(loại khách hàng)(LOAI_KHACH_HANG)
-- Hàng hóa(HANG_HOA)
-- Loại hàng hóa(đồ uống, thức ăn)(LOAI_HANG_HOA)

CREATE DATABASE PBL_SQL_V1
GO
USE PBL_SQL_V1
GO
CREATE TABLE KHU_VUC
(
    Ma_Khu_Vuc INT PRIMARY KEY  NOT NULL,
	Ten_Khu_Vuc NVARCHAR(50) NOT NULL,
	Trang_Thai NVARCHAR(70) 
)
GO
-- Cấp phát dữ liệu cho Khu vực
INSERT INTO KHU_VUC(Ma_Khu_Vuc, Ten_Khu_Vuc, Trang_Thai) values 
(1,N'Tầng 1',''),
(2,N'Tầng 2',''),
(3,N'Tầng 3','');
GO
SELECT *FROM dbo.KHU_VUC;
GO
CREATE TABLE BAN
(
    Ma_Ban INT PRIMARY KEY  NOT NULL,
	Ten_Ban NVARCHAR(50) NOT NULL,
	Ma_Khu_Vuc INT,
    Tinh_Trang BIT,
	Ma_Ban_Chuyen_Den INT
	CONSTRAINT fk_htk_Ma_Khu_Vuc FOREIGN KEY (Ma_Khu_Vuc) REFERENCES KHU_VUC (Ma_Khu_Vuc)
)
GO
-- THÊM dữ liệu cho data Bàn
INSERT INTO BAN(Ma_Ban, Ten_Ban, Ma_Khu_Vuc, Tinh_Trang, Ma_Ban_Chuyen_Den) values  
(1,N'BAN_01',1, 1),
(2,N'BAN_02',2, 1),
(3,N'BAN_03',3, 1),
(4,N'BAN_04',1, 1),
(5,N'BAN_05',2, 1),
(6,N'BAN_06',3, 1),
(7,N'BAN_07',1, 1),
(8,N'BAN_08',3, 1),
(9,N'BAN_09',3, 1),
(10,N'BAN_10',3, 1);
GO
SELECT *FROM dbo.BAN;
GO

CREATE TABLE NHAN_VIEN
(
    Ma_Nhan_Vien VARCHAR(50) PRIMARY KEY NOT NULL,
	Ten_Nhan_Vien NVARCHAR(100) NOT NULL,
	Gioi_Tinh NVARCHAR(50) NOT NULL,
	Chuc_Vu NVARCHAR(100) NOT NULL,
	Phan_Quyen BIT NOT NULL,
	Dia_Chi NVARCHAR(150) NOT NULL,
	SDT VARCHAR(20) NOT NULL,
	Mat_Khau VARCHAR(50) NOT NULL,
	Tinh_Trang INT NOT NULL,
)
GO
-- THÊM dữ liệu cho data Nhân Viên
INSERT INTO NHAN_VIEN(Ma_Nhan_Vien, Ten_Nhan_Vien, Gioi_Tinh, Chuc_Vu, Phan_Quyen, Dia_Chi, SDT, Mat_Khau, Tinh_Trang) values
  ('NV01',N'Trần Văn Phúc',N'Nam',N'Quản lý', 1,N'111 - Nguyễn Lương Bằng', '0311112222','121212', 1),
  ('NV02',N'Trần Hương Giang', N'Nữ',N'Quản lý', 1, N'15 - Nguyễn Lương Bằng', '0987748835','142929', 1),
  ('NV03',N'Trần Thanh Tú', N'Nữ',N'Nhân Viên', 0, N'16 - Nguyễn Lương Bằng', '0987772835','173929', 1),
  ('NV04',N'Nguyễn Bảo Nhi', N'Nữ',N'Nhân Viên', 0, N'113 - Nguyễn Lương Bằng', '0987778836','171929', 1),
  ('NV05',N'Trần Văn Hoàng', N'Nam',N'Nhân Viên', 0, N'1333 - Nguyễn Lương Bằng', '0987578863','174921', 1);
GO

SELECT *FROM dbo.NHAN_VIEN;
GO

CREATE TABLE LOAI_KHACH_HANG
(
    Ma_Loai_Khach_Hang INT PRIMARY KEY NOT NULL,
	Ten_Loai_Khach_Hang NVARCHAR(100) NOT NULL,
	Giam_gia INT NOT NULL
)
GO
-- THÊM dữ liệu cho data Loại Khách Hàng
INSERT INTO LOAI_KHACH_HANG(Ma_Loai_Khach_Hang, Ten_Loai_Khach_Hang, Giam_gia) values 
(0,N'Tiềm năng', 0),
(1,N'Bạc', 5),
(2,N'Vàng', 10);
GO

SELECT *FROM dbo.LOAI_KHACH_HANG;
GO

CREATE TABLE KHACH_HANG
(
    Ma_Khach_Hang INT PRIMARY KEY  NOT NULL,
	Ma_Loai_Khach_Hang INT NOT NULL,  -- Khóa ngoại
	Ten_Khach_Hang NVARCHAR(100) NOT NULL,
	Dia_Chi NVARCHAR(150) NOT NULL,
	SDT VARCHAR(20) NOT NULL,
	Diem_Tich_Luy INT NOT NULL, -- ĐIỂM TÍCH LŨY KHI MUA HÀNG
	CONSTRAINT fk_htk_Ma_Loai_Khach_Hang FOREIGN KEY (Ma_Loai_Khach_Hang) REFERENCES LOAI_KHACH_HANG (Ma_Loai_Khach_Hang)
)
GO

INSERT INTO KHACH_HANG(Ma_Khach_Hang, Ten_Khach_Hang, Ma_Loai_Khach_Hang, Dia_Chi, SDT, Diem_Tich_Luy) values 
(1, N'Trần Văn Phúc', 0, N'20 - Phan Rang', '0932345644', 0),
(2,N'Trần Văn Phước',0, N'20 - Điện Biên Phủ', '0936656424', 0),
(3,N'Lê Tùng Duy',0, N'28 - Điện Biên Phủ', '0932355654', 0),
(4,N'Hoàng Phước Dung',0, N'20 - Ngô Sĩ Liên', '0932545634', 0),
(5,N'Trần Bích Phương',0, N'05 - Ngô Sĩ Liên', '0932325461', 0),
(6,N'Đào Thị Bích Hằng',0, N'192 - Nguyễn Lương Bằng', '0932341248', 0),
(7,N'Nguyễn Phước Duy',0, N'120 - Điện Biên Phủ', '0932317598', 0),
(8,N'Phàm Ngọc Bích',0, N'222 - Phan Rang', '0932387692', 0),
(9,N'Huỳnh Như Sương',0, N'150 - Điện Biên Phủ', '0931578444', 0);

SELECT *FROM dbo.KHACH_HANG;
GO

CREATE TABLE LOAI_HANG_HOA
(
    Ma_Loai_Hang_Hoa INT PRIMARY KEY NOT NULL,
	Ten_Loai_Hang_Hoa NVARCHAR(100) NOT NULL,
)
GO
INSERT INTO LOAI_HANG_HOA(Ma_Loai_Hang_Hoa, Ten_Loai_Hang_Hoa) values 
(1,N'Cafe'),
(2,N'Nước ép'),
(3,N'Sinh tố hoa quả'),
(4,N'Trà lạnh & trà nóng'),
(5,N'Sữa chua');
GO

SELECT *FROM dbo.LOAI_HANG_HOA;
GO

CREATE TABLE HANG_HOA
(
    Ma_Hang_Hoa INT PRIMARY KEY  NOT NULL,
	Ten_Hang_Hoa NVARCHAR(100) NOT NULL,
	Ma_Loai_Hang_Hoa INT NOT NULL,-- KHÓA NGOẠI
	Gia_Hang_Hoa INT NOT NULL,
	Tinh_Trang INT NOT NULL
	CONSTRAINT fk_htk_Ma_Loai_Hang_Hoa FOREIGN KEY (Ma_Loai_Hang_Hoa) REFERENCES LOAI_HANG_HOA (Ma_Loai_Hang_Hoa)
)
GO
INSERT INTO HANG_HOA(Ma_Hang_Hoa, Ten_Hang_Hoa, Ma_Loai_Hang_Hoa, Gia_Hang_Hoa, Tinh_Trang) values
(1,N'Cà phê Mocha',1,120000, 1),
(2,N'Caramel Macchiato',1,100000, 1),
(3,N'Cà phê sữa lắc',1,15000, 1),
(4,N'Cà phê tiramisu',1,100000, 1),
(5,N'Cà phê Ireland',1,50000, 1),
(6,N'Cà phê sữa chua',1,50000, 1),
(7,N'Cà phê sữa',1,20000, 1),
(8,N'Cappuccino',1,89000, 1),
(9,N'Marocchino',1,89000, 1),
(10,N'Nước ép dưa hấu',2,15000, 1),
(11,N'Nước ép táo',2,15000, 1),
(12,N'Nước ép cam',2,20000, 1),
(13,N'Nước ép thanh long',2,20000, 1),
(14,N'Nước ép mít',2,25000, 1),
(15,N'Sinh tố dâu tây',3,35000, 1),
(16,N'Sinh tố lê',3,25000, 1),
(17,N'Sinh tố đào',3,25000, 1),
(18,N'Sinh tố thơm',3,25000, 1),
(19,N'Trà lạnh',4,55000, 1),
(20,N'Trà trái cây',4,55000, 1),
(21,N'Trà hoa cúc mật ong',4,55000, 1),
(22,N'Trà quế mật ong',4,45000, 1),
(23,N'Sữa chua nếp cẩm',5,35000, 1),
(24,N'Sữa chua thạch trái cây',5,89000, 1),
(25,N'Sữa chua vị lá dứa',5,28000, 1);
GO
SELECT *FROM dbo.HANG_HOA;
GO

CREATE TABLE HOA_DON_BAN_HANG
(
    Ma_Hoa_Don INT PRIMARY KEY NOT NULL,
	Ma_Nhan_Vien VARCHAR(50) NOT NULL,-- KHÓA NGOẠI
	Ma_Ban INT NOT NULL,-- KHÓA NGOẠI
	Ma_Khach_Hang INT,-- ALLOW NULL VÀ LÀ KHÓA NGOẠI
	Date_HDBH DATETIME NOT NULL,
	Tong_Tien INT NOT NULL,
	Diem_Tich_Luy INT,-- ALLOW NULL
	Giam_Gia INT,-- ALLOW NULL
	CONSTRAINT fk_hdbh_Ma_Nhan_Vien FOREIGN KEY (Ma_Nhan_Vien) REFERENCES NHAN_VIEN (Ma_Nhan_Vien),
	CONSTRAINT fk_hdbh_Ma_Ban FOREIGN KEY (Ma_Ban) REFERENCES BAN (Ma_Ban),
    CONSTRAINT fk_hdbh_Ma_Khach_Hang FOREIGN KEY (Ma_Khach_Hang) REFERENCES KHACH_HANG (Ma_Khach_Hang)
)
GO
INSERT INTO HOA_DON_BAN_HANG(Ma_Hoa_Don, Ma_Nhan_Vien, Ma_Ban, Ma_Khach_Hang, Date_HDBH, Tong_Tien, Diem_Tich_Luy, Giam_Gia) values 
(1,'NV01',3,1,'2022-04-25 07:35:24',150000, 10, 0),
(2,'NV02',2,2,'2022-04-26 08:30:20',200000, 10, 0),
(3,'NV02',1,3,'2022-04-27 08:35:24',289000, 10, 0),
(4,'NV01',8,4,'2022-04-28 09:30:25',100000, 5, 0),
(5,'NV01',8,5,'2022-04-29 10:35:24',300000, 10, 0),
(6,'NV02',4,6,'2022-04-30 10:45:30',200000, 10, 0),
(7,'NV02',5,7,'2022-04-25 11:00:24',35000, 0, 0),
(8,'NV01',6,8,'2022-04-26 11:35:24',20000, 0, 0),
(9,'NV02',9,9,'2022-04-27 13:32:11',150000, 10, 0);
GO
SELECT *FROM dbo.HOA_DON_BAN_HANG;
GO

CREATE TABLE CHI_TIET_HD_BAN_HANG
(
    Ma_CTHD INT PRIMARY KEY NOT NULL,-- MÃ CHI TIẾT HÓA ĐƠN BÁN HÀNG 
    Ma_Hoa_Don INT NOT NULL,-- KHÓA NGOẠI
	Ma_Hang_Hoa INT NOT NULL,-- KHÓA NGOẠI
	So_Luong INT NOT NULL,
	CONSTRAINT fk_hdbh_Ma_Ma_Hoa_Don FOREIGN KEY (Ma_Hoa_Don) REFERENCES HOA_DON_BAN_HANG (Ma_Hoa_Don),
	CONSTRAINT fk_hdbh_Ma_Hang_Hoa FOREIGN KEY (Ma_Hang_Hoa) REFERENCES HANG_HOA (Ma_Hang_Hoa)
)
GO
--INSERT INTO CT_HDBH_TAI_CHO(Ma_CTHD, Ma_Hoa_Don, Ma_Hang_Hoa, So_Luong) values 
INSERT INTO CHI_TIET_HD_BAN_HANG(Ma_CTHD, Ma_Hoa_Don, Ma_Hang_Hoa, So_Luong) values 
(1, 1,2, 1),
(2, 1,5, 1),
(3, 2,2, 1),
(4, 2,4, 1),
(5, 3,2, 1),
(6, 3,4, 1),
(7, 3,8, 1),
(8, 4,2, 1),
(9, 5,4, 3),
(10, 6,18, 4),
(11, 7,15, 1),
(12, 8,13, 1),
(13, 9,5, 1),
(14, 9,6, 1),
(15, 9,16, 1),
(16, 9,17, 1);
SELECT *FROM dbo.CHI_TIET_HD_BAN_HANG;
GO

-- TRUY VẤN SQL hiển thị loại đồ uống theo danh mục
-- Muốn hiển thị loại đồ uống, đồ uống và giá tiền:
SELECT LOAI_HANG_HOA.Ten_Loai_Hang_Hoa, HANG_HOA.Ten_Hang_Hoa, HANG_HOA.Gia_Hang_Hoa
FROM LOAI_HANG_HOA, HANG_HOA
WHERE LOAI_HANG_HOA.Ma_Loai_Hang_Hoa = HANG_HOA.Ma_Loai_Hang_Hoa
AND LOAI_HANG_HOA.Ma_Loai_Hang_Hoa = 'LHH02'

---------------------------------------------------
CREATE PROC PROC_XEM_MENU_THEO_Hang_Hoa
    @Ma_Loai_Hang_Hoa VARCHAR(50)
AS
BEGIN
      SELECT LOAI_HANG_HOA.Ten_Loai_Hang_Hoa, HANG_HOA.Ten_Hang_Hoa, HANG_HOA.Gia_Hang_Hoa
      FROM LOAI_HANG_HOA, HANG_HOA
      WHERE LOAI_HANG_HOA.Ma_Loai_Hang_Hoa = HANG_HOA.Ma_Loai_Hang_Hoa
          AND LOAI_HANG_HOA.Ma_Loai_Hang_Hoa = @Ma_Loai_Hang_Hoa
END

EXEC PROC_XEM_MENU_THEO_Hang_Hoa 'LHH01'

--- HIỂN THỊ danh mục đồ uống trong 1 đơn hàng
-- Ma_Hoa_Don,Ten_Nhan_Vien,Ten_Khach_Hang, Ten_hang_hoa,giá, số lượng, tổng tiền, ngày mua
--- dữ liệu từ Bảng Hóa đơn, Nhân viên, khách hàng, hàng hóa,chi tiết hóa đơn
SELECT HOA_DON_BAN_HANG.Ma_Hoa_Don, NHAN_VIEN.Ten_Nhan_Vien, KHACH_HANG.Ten_Khach_Hang, HANG_HOA.Ten_Hang_Hoa,HANG_HOA.Gia_Hang_Hoa,CHI_TIET_HD_BAN_HANG.So_Luong,HOA_DON_BAN_HANG.Tong_Tien,HOA_DON_BAN_HANG.Date_HDBH
FROM HOA_DON_BAN_HANG,NHAN_VIEN,KHACH_HANG,HANG_HOA,CHI_TIET_HD_BAN_HANG
WHERE HOA_DON_BAN_HANG.Ma_Hoa_Don = CHI_TIET_HD_BAN_HANG.Ma_Hoa_Don
   AND HOA_DON_BAN_HANG.Ma_Khach_Hang = KHACH_HANG.Ma_Khach_Hang
   AND HOA_DON_BAN_HANG.Ma_Nhan_Vien = NHAN_VIEN.Ma_Nhan_Vien
   AND CHI_TIET_HD_BAN_HANG.Ma_Hang_Hoa = HANG_HOA.Ma_Hang_Hoa

-- XEM ĐƠN HÀNG THEO MÃ HÓA ĐƠN
CREATE PROC PROC_XEM_HOA_DON
    @Ma_Hoa_Don INT
AS
BEGIN
      SELECT HOA_DON_BAN_HANG.Ma_Hoa_Don, NHAN_VIEN.Ten_Nhan_Vien, KHACH_HANG.Ten_Khach_Hang, HANG_HOA.Ten_Hang_Hoa,HANG_HOA.Gia_Hang_Hoa,CHI_TIET_HD_BAN_HANG.So_Luong,HOA_DON_BAN_HANG.Tong_Tien,HOA_DON_BAN_HANG.Date_HDBH
FROM HOA_DON_BAN_HANG,NHAN_VIEN,KHACH_HANG,HANG_HOA,CHI_TIET_HD_BAN_HANG
WHERE HOA_DON_BAN_HANG.Ma_Hoa_Don = CHI_TIET_HD_BAN_HANG.Ma_Hoa_Don
   AND HOA_DON_BAN_HANG.Ma_Khach_Hang = KHACH_HANG.Ma_Khach_Hang
   AND HOA_DON_BAN_HANG.Ma_Nhan_Vien = NHAN_VIEN.Ma_Nhan_Vien
   AND CHI_TIET_HD_BAN_HANG.Ma_Hang_Hoa = HANG_HOA.Ma_Hang_Hoa
   AND HOA_DON_BAN_HANG.Ma_Hoa_Don = @Ma_Hoa_Don
END

EXEC PROC_XEM_HOA_DON 2

-- XEM ĐƠN HÀNG THEO MÃ KHÁCH HÀNG
CREATE PROC PROC_XEM_HOA_DON_THEO_MA_KH_
    @Ma_Khach_Hang INT
AS
BEGIN
      SELECT HOA_DON_BAN_HANG.Ma_Hoa_Don, NHAN_VIEN.Ten_Nhan_Vien, KHACH_HANG.Ten_Khach_Hang, HANG_HOA.Ten_Hang_Hoa,HANG_HOA.Gia_Hang_Hoa,CHI_TIET_HD_BAN_HANG.So_Luong,HOA_DON_BAN_HANG.Tong_Tien,HOA_DON_BAN_HANG.Date_HDBH
FROM HOA_DON_BAN_HANG,NHAN_VIEN,KHACH_HANG,HANG_HOA,CHI_TIET_HD_BAN_HANG
WHERE HOA_DON_BAN_HANG.Ma_Hoa_Don = CHI_TIET_HD_BAN_HANG.Ma_Hoa_Don
   AND HOA_DON_BAN_HANG.Ma_Khach_Hang = KHACH_HANG.Ma_Khach_Hang
   AND HOA_DON_BAN_HANG.Ma_Nhan_Vien = NHAN_VIEN.Ma_Nhan_Vien
   AND CHI_TIET_HD_BAN_HANG.Ma_Hang_Hoa = HANG_HOA.Ma_Hang_Hoa
   AND KHACH_HANG.Ma_Khach_Hang = @Ma_Khach_Hang
END

EXEC PROC_XEM_HOA_DON_THEO_MA_KH_ 1

-- TRUY VẤN HIỂN THỊ DOANH THU TỪ NGÀY - ĐẾN NGÀY
-- thống kê doanh thu
SELECT HOA_DON_BAN_HANG.Ma_Hoa_Don, NHAN_VIEN.Ten_Nhan_Vien, KHACH_HANG.Ten_Khach_Hang, HANG_HOA.Ten_Hang_Hoa,HANG_HOA.Gia_Hang_Hoa,CHI_TIET_HD_BAN_HANG.So_Luong,HOA_DON_BAN_HANG.Tong_Tien,HOA_DON_BAN_HANG.Date_HDBH
FROM HOA_DON_BAN_HANG,NHAN_VIEN,KHACH_HANG,HANG_HOA,CHI_TIET_HD_BAN_HANG
WHERE HOA_DON_BAN_HANG.Ma_Hoa_Don = CHI_TIET_HD_BAN_HANG.Ma_Hoa_Don
   AND HOA_DON_BAN_HANG.Ma_Khach_Hang = KHACH_HANG.Ma_Khach_Hang
   AND HOA_DON_BAN_HANG.Ma_Nhan_Vien = NHAN_VIEN.Ma_Nhan_Vien
   AND CHI_TIET_HD_BAN_HANG.Ma_Hang_Hoa = HANG_HOA.Ma_Hang_Hoa
   AND HOA_DON_BAN_HANG.Date_HDBH >= '2022-04-25'
   AND HOA_DON_BAN_HANG.Date_HDBH <= '2022-04-30'

-- hiển thị hoanh thu
SELECT Tong_Tien
FROM HOA_DON_BAN_HANG
WHERE HOA_DON_BAN_HANG.Date_HDBH >= '2022-04-25'
   AND HOA_DON_BAN_HANG.Date_HDBH <= '2022-04-30'

-- HIỂN THỊ TỔNG DOANH THU
SELECT SUM(Tong_Tien) 'Tong_Doanh_Thu'
FROM HOA_DON_BAN_HANG
WHERE HOA_DON_BAN_HANG.Date_HDBH >= '2022-04-25'
   AND HOA_DON_BAN_HANG.Date_HDBH <= '2022-04-30'

CREATE PROC PROC_XEM_TONG_DOANH_THU
    @StartDate DATE,
	@EndDate DATE
AS
BEGIN
    SELECT SUM(Tong_Tien) 'Tong_Doanh_Thu'
    FROM HOA_DON_BAN_HANG
    WHERE HOA_DON_BAN_HANG.Date_HDBH >= @StartDate
      AND HOA_DON_BAN_HANG.Date_HDBH <= @EndDate
END

EXEC PROC_XEM_TONG_DOANH_THU '2022-04-25','2022-04-30'


-- Tính tổng tiền của từng đơn hàng.
-- Bao gồm: Mã đơn hàng, Tên nhân viên, Tên Khách hàng, Ngày mua, Tổng tiền
SELECT HOA_DON_BAN_HANG.Ma_Hoa_Don, NHAN_VIEN.Ten_Nhan_Vien, KHACH_HANG.Ten_Khach_Hang, HOA_DON_BAN_HANG.Date_HDBH 'Ngay mua',SUM(CHI_TIET_HD_BAN_HANG.So_Luong * HANG_HOA.Gia_Hang_Hoa) 'Tong Tien'
FROM HOA_DON_BAN_HANG, NHAN_VIEN, KHACH_HANG, CHI_TIET_HD_BAN_HANG, HANG_HOA
WHERE HOA_DON_BAN_HANG.Ma_Khach_Hang = KHACH_HANG.Ma_Khach_Hang
  AND NHAN_VIEN.Ma_Nhan_Vien = HOA_DON_BAN_HANG.Ma_Nhan_Vien
  AND HOA_DON_BAN_HANG.Ma_Hoa_Don = CHI_TIET_HD_BAN_HANG.Ma_Hoa_Don
  AND CHI_TIET_HD_BAN_HANG.Ma_Hang_Hoa = HANG_HOA.Ma_Hang_Hoa
GROUP BY HOA_DON_BAN_HANG.Ma_Hoa_Don, NHAN_VIEN.Ten_Nhan_Vien, KHACH_HANG.Ten_Khach_Hang, HOA_DON_BAN_HANG.Date_HDBH
GO
CREATE PROC UP_GetListTable
AS SELECT * FROM DBO.BAN
GO
EXEC UP_GetListTable
GO 

CREATE PROC UP_AddTable
@name NVARCHAR(100)
AS INSERT DBO.BAN(Ten_Ban) VALUES(@name)
GO

CREATE PROC UP_ModifyTable
@ID INT, @name NVARCHAR(100)
AS UPDATE DBO.BAN SET Ten_Ban = @name WHERE Ma_Ban = @ID
GO

CREATE PROC UP_DeleteTable
@ID INT
AS BEGIN
	DELETE DBO.HANG_HOA WHERE Ma_Hang_Hoa = @ID
	IF(@@ROWCOUNT <= 0)
	UPDATE DBO.BAN SET Tinh_Trang = N'Không khả dụng' WHERE Ma_Ban = @ID
	END
GO