CREATE DATABASE PBL_VS1
GO
USE PBL_VS1
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
    Ma_Ban INT identity(1,1) PRIMARY KEY  NOT NULL,
	Ten_Ban NVARCHAR(50) NOT NULL,
	Ma_Khu_Vuc INT,
    Tinh_Trang BIT,
	Ma_Ban_Chuyen_Den INT
	CONSTRAINT fk_htk_Ma_Khu_Vuc FOREIGN KEY (Ma_Khu_Vuc) REFERENCES KHU_VUC (Ma_Khu_Vuc)
)
GO
-- THÊM dữ liệu cho data Bàn
INSERT INTO BAN(Ten_Ban, Ma_Khu_Vuc, Tinh_Trang) values  
(N'BAN_01',1, 1),
(N'BAN_02',2, 1),
(N'BAN_03',3, 1),
(N'BAN_04',1, 1),
(N'BAN_05',2, 1),
(N'BAN_06',3, 1),
(N'BAN_07',1, 1),
(N'BAN_08',3, 1),
(N'BAN_09',3, 1),
(N'BAN_10',3, 1),
(N'BAN_11',1, 1),
(N'BAN_12',2, 1),
(N'BAN_13',3, 1),
(N'BAN_14',1, 1),
(N'BAN_15',2, 1),
(N'BAN_16',3, 1),
(N'BAN_17',1, 1),
(N'BAN_18',3, 1),
(N'BAN_19',3, 1),
(N'BAN_20',3, 1);
GO
SELECT *FROM dbo.BAN;
GO

CREATE TABLE NHAN_VIEN
(
    Ma_Nhan_Vien varchar(50) PRIMARY KEY NOT NULL,
	Ten_Nhan_Vien NVARCHAR(100) NOT NULL,
	Gioi_Tinh NVARCHAR(50) ,
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
	Giam_gia decimal(12,2)
)
GO
-- THÊM dữ liệu cho data Loại Khách Hàng
INSERT INTO LOAI_KHACH_HANG(Ma_Loai_Khach_Hang, Ten_Loai_Khach_Hang, Giam_gia) values 
(1,N'Tiềm năng', 0),
(2,N'Bạc', 5),
(3,N'Vàng', 10);
GO

SELECT *FROM dbo.LOAI_KHACH_HANG;
GO

CREATE TABLE KHACH_HANG
(
    Ma_Khach_Hang INT identity(1,1) PRIMARY KEY  NOT NULL,
	Ma_Loai_Khach_Hang INT ,  -- Khóa ngoại
	Ten_Khach_Hang NVARCHAR(100) NOT NULL,
	Dia_Chi NVARCHAR(150) NOT NULL,
	SDT VARCHAR(20) NOT NULL,
	Diem_Tich_Luy decimal(12,3), -- ĐIỂM TÍCH LŨY KHI MUA HÀNG
	CONSTRAINT fk_htk_Ma_Loai_Khach_Hang FOREIGN KEY (Ma_Loai_Khach_Hang) REFERENCES LOAI_KHACH_HANG (Ma_Loai_Khach_Hang)
)
GO

INSERT INTO KHACH_HANG(Ten_Khach_Hang, Ma_Loai_Khach_Hang, Dia_Chi, SDT, Diem_Tich_Luy) values 
( N'Trần Văn Phúc', 1, N'20 - Phan Rang', '0932345644', 0),
(N'Trần Văn Phước',1, N'20 - Điện Biên Phủ', '0936656424', 0),
(N'Lê Tùng Duy',1, N'28 - Điện Biên Phủ', '0932355654', 0),
(N'Hoàng Phước Dung',1, N'20 - Ngô Sĩ Liên', '0932545634', 0),
(N'Trần Bích Phương',1, N'05 - Ngô Sĩ Liên', '0932325461', 0),
(N'Đào Thị Bích Hằng',1, N'192 - Nguyễn Lương Bằng', '0932341248', 0),
(N'Nguyễn Phước Duy',1, N'120 - Điện Biên Phủ', '0932317598', 0),
(N'Phàm Ngọc Bích',1, N'222 - Phan Rang', '0932387692', 0),
(N'Huỳnh Như Sương',1, N'150 - Điện Biên Phủ', '0931578444', 0);

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
    Ma_Hang_Hoa INT identity(1,1) PRIMARY KEY  NOT NULL,
	Ten_Hang_Hoa NVARCHAR(100) NOT NULL,
	Ma_Loai_Hang_Hoa INT ,-- KHÓA NGOẠI
	Hinh_Anh image not null,
	Gia_Hang_Hoa decimal(12,3) ,
	Tinh_Trang INT 
	CONSTRAINT fk_htk_Ma_Loai_Hang_Hoa FOREIGN KEY (Ma_Loai_Hang_Hoa) REFERENCES LOAI_HANG_HOA (Ma_Loai_Hang_Hoa)
)
GO
INSERT INTO HANG_HOA(Ten_Hang_Hoa, Ma_Loai_Hang_Hoa, Gia_Hang_Hoa, Tinh_Trang) values
(N'Cà phê Mocha',1,120000, 1),
(N'Caramel Macchiato',1,100000, 1),
(N'Cà phê sữa lắc',1,15000, 1),
(N'Cà phê tiramisu',1,100000, 1),
(N'Cà phê Ireland',1,50000, 1),
(N'Cà phê sữa chua',1,50000, 1),
(N'Cà phê sữa',1,20000, 1),
(N'Cappuccino',1,89000, 1),
(N'Marocchino',1,89000, 1),
(N'Nước ép dưa hấu',2,15000, 1),
(N'Nước ép táo',2,15000, 1),
(N'Nước ép cam',2,20000, 1),
(N'Nước ép thanh long',2,20000, 1),
(N'Nước ép mít',2,25000, 1),
(N'Sinh tố dâu tây',3,35000, 1),
(N'Sinh tố lê',3,25000, 1),
(N'Sinh tố đào',3,25000, 1),
(N'Sinh tố thơm',3,25000, 1),
(N'Trà lạnh',4,55000, 1),
(N'Trà trái cây',4,55000, 1),
(N'Trà hoa cúc mật ong',4,55000, 1),
(N'Trà quế mật ong',4,45000, 1),
(N'Sữa chua nếp cẩm',5,35000, 1),
(N'Sữa chua thạch trái cây',5,89000, 1),
(N'Sữa chua vị lá dứa',5,28000, 1);
GO
SELECT *FROM dbo.HANG_HOA;
GO

CREATE TABLE HOA_DON_BAN_HANG
(
    Ma_Hoa_Don INT identity(1,1) PRIMARY KEY NOT NULL,
	Ma_Nhan_Vien varchar(50),-- KHÓA NGOẠI
	Ma_Ban INT,-- KHÓA NGOẠI
	Ma_Khach_Hang INT,-- ALLOW NULL VÀ LÀ KHÓA NGOẠI
	Gio_den DATETIME,
	Gio_di DATETIME,
	Tong_Tien decimal(12,3),
	Diem_Tich_Luy decimal(12,3),-- ALLOW NULL
	Giam_Gia decimal(12,3),-- ALLOW NULL
	CONSTRAINT fk_hdbh_Ma_Nhan_Vien FOREIGN KEY (Ma_Nhan_Vien) REFERENCES NHAN_VIEN (Ma_Nhan_Vien),
	CONSTRAINT fk_hdbh_Ma_Ban FOREIGN KEY (Ma_Ban) REFERENCES BAN (Ma_Ban),
    CONSTRAINT fk_hdbh_Ma_Khach_Hang FOREIGN KEY (Ma_Khach_Hang) REFERENCES KHACH_HANG (Ma_Khach_Hang)
)
GO
INSERT INTO HOA_DON_BAN_HANG(Ma_Nhan_Vien, Ma_Ban, Ma_Khach_Hang, Gio_den, Gio_di, Tong_Tien, Diem_Tich_Luy, Giam_Gia) values 
('NV01',3,1,'2022-04-25 07:35:24','2022-04-25 08:35:24',150000, 10, 0),
('NV02',2,2,'2022-04-26 08:30:20','2022-04-26 09:30:20',200000, 10, 0),
('NV02',1,3,'2022-04-27 08:35:24','2022-04-27 09:35:24',300000, 10, 0),
('NV01',8,4,'2022-04-28 09:30:25','2022-04-28 10:30:25',100000, 5, 0),
('NV01',8,5,'2022-04-29 10:35:24','2022-04-29 11:00:24',300000, 10, 0),
('NV02',4,6,'2022-04-30 10:45:30','2022-04-30 11:45:30',200000, 10, 0),
('NV02',5,7,'2022-04-25 11:00:24','2022-04-25 12:00:24',35000, 0, 0),
('NV01',6,8,'2022-04-26 11:35:24','2022-04-26 12:35:24',20000, 0, 0),
('NV02',9,9,'2022-04-27 13:32:11','2022-04-27 14:32:11',150000, 10, 0);
GO
SELECT *FROM dbo.HOA_DON_BAN_HANG;
GO

CREATE TABLE CHI_TIET_HD_BAN_HANG
(
    Ma_CTHD INT identity(1,1) PRIMARY KEY NOT NULL,-- MÃ CHI TIẾT HÓA ĐƠN BÁN HÀNG 
    Ma_Hoa_Don INT ,-- KHÓA NGOẠI
	Ma_Hang_Hoa INT ,-- KHÓA NGOẠI
	So_Luong INT ,
	CONSTRAINT fk_hdbh_Ma_Ma_Hoa_Don FOREIGN KEY (Ma_Hoa_Don) REFERENCES HOA_DON_BAN_HANG (Ma_Hoa_Don),
	CONSTRAINT fk_hdbh_Ma_Hang_Hoa FOREIGN KEY (Ma_Hang_Hoa) REFERENCES HANG_HOA (Ma_Hang_Hoa)
)
GO
--INSERT INTO CT_HDBH_TAI_CHO(Ma_CTHD, Ma_Hoa_Don, Ma_Hang_Hoa, So_Luong) values 
INSERT INTO CHI_TIET_HD_BAN_HANG(Ma_Hoa_Don, Ma_Hang_Hoa, So_Luong) values 
( 1,2, 1),
( 1,5, 1),
(2,2, 1),
(2,4, 1),
(3,2, 1),
(3,4, 1),
(3,8, 1),
(4,2, 1),
(5,4, 3),
(6,18, 4),
(7,15, 1),
(8,13, 1),
(9,5, 1),
(9,6, 1),
(9,16, 1),
(9,17, 1);
SELECT *FROM dbo.CHI_TIET_HD_BAN_HANG;
GO