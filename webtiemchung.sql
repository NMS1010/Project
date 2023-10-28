/*
 Navicat Premium Data Transfer

 Source Server         : SQLServer
 Source Server Type    : SQL Server
 Source Server Version : 15002104
 Source Host           : MINHSON\MINHSON:1433
 Source Catalog        : webtiemchung
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 15002104
 File Encoding         : 65001

 Date: 28/10/2023 12:15:32
*/

CREATE DATABASE webtiemchung
GO

USE webtiemchung
GO
-- ----------------------------
-- Table structure for HoaDon
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[HoaDon]') AND type IN ('U'))
	DROP TABLE [dbo].[HoaDon]
GO

CREATE TABLE [dbo].[HoaDon] (
  [NgayThanhToan] datetime  NULL,
  [IdLichTiem] int  NOT NULL,
  [TongTien] decimal(18)  NULL,
  [NguoiThanhToan] nvarchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [Id] int  IDENTITY(1,1) NOT NULL
)
GO

ALTER TABLE [dbo].[HoaDon] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of HoaDon
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[HoaDon] ON
GO

SET IDENTITY_INSERT [dbo].[HoaDon] OFF
GO

COMMIT
GO


-- ----------------------------
-- Table structure for KhachHang
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[KhachHang]') AND type IN ('U'))
	DROP TABLE [dbo].[KhachHang]
GO

CREATE TABLE [dbo].[KhachHang] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [Ten] nvarchar(50) COLLATE Latin1_General_CI_AS  NULL,
  [DiaChi] nvarchar(50) COLLATE Latin1_General_CI_AS  NULL,
  [SoDT] int  NULL,
  [Email] nvarchar(50) COLLATE Latin1_General_CI_AS  NULL,
  [NgaySinh] datetime  NULL,
  [GioiTinh] nchar(10) COLLATE Latin1_General_CI_AS  NULL,
  [CCCD] nvarchar(50) COLLATE Latin1_General_CI_AS  NULL,
  [MatKhau] nvarchar(1000) COLLATE Latin1_General_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[KhachHang] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of KhachHang
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[KhachHang] ON
GO

SET IDENTITY_INSERT [dbo].[KhachHang] OFF
GO

COMMIT
GO


-- ----------------------------
-- Table structure for LichTiem
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[LichTiem]') AND type IN ('U'))
	DROP TABLE [dbo].[LichTiem]
GO

CREATE TABLE [dbo].[LichTiem] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [IdKh] int  NULL,
  [DiaDiemTiem] nvarchar(50) COLLATE Latin1_General_CI_AS  NULL,
  [NgayTiem] datetime  NULL,
  [TrangThai] int  NULL,
  [IdVacXin] int  NULL,
  [IdBacSi] int  NULL
)
GO

ALTER TABLE [dbo].[LichTiem] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of LichTiem
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[LichTiem] ON
GO

SET IDENTITY_INSERT [dbo].[LichTiem] OFF
GO

COMMIT
GO


-- ----------------------------
-- Table structure for LienHe
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[LienHe]') AND type IN ('U'))
	DROP TABLE [dbo].[LienHe]
GO

CREATE TABLE [dbo].[LienHe] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [TenKH] nvarchar(50) COLLATE Latin1_General_CI_AS  NULL,
  [Email] nvarchar(50) COLLATE Latin1_General_CI_AS  NULL,
  [SoDT] int  NULL,
  [NoiDung] nvarchar(50) COLLATE Latin1_General_CI_AS  NULL,
  [TieuDe] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [NgayGui] datetime  NULL,
  [NhanVienId] int  NULL
)
GO

ALTER TABLE [dbo].[LienHe] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of LienHe
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[LienHe] ON
GO

SET IDENTITY_INSERT [dbo].[LienHe] OFF
GO

COMMIT
GO


-- ----------------------------
-- Table structure for NhaCungCap
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[NhaCungCap]') AND type IN ('U'))
	DROP TABLE [dbo].[NhaCungCap]
GO

CREATE TABLE [dbo].[NhaCungCap] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [Ten] nvarchar(50) COLLATE Latin1_General_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[NhaCungCap] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of NhaCungCap
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[NhaCungCap] ON
GO

SET IDENTITY_INSERT [dbo].[NhaCungCap] OFF
GO

COMMIT
GO


-- ----------------------------
-- Table structure for NhanVien
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[NhanVien]') AND type IN ('U'))
	DROP TABLE [dbo].[NhanVien]
GO

CREATE TABLE [dbo].[NhanVien] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [Ten] nvarchar(50) COLLATE Latin1_General_CI_AS  NULL,
  [DiaChi] nvarchar(50) COLLATE Latin1_General_CI_AS  NULL,
  [GioiTinh] nvarchar(10) COLLATE Latin1_General_CI_AS  NULL,
  [SoDT] int  NULL,
  [TaiKhoan] nvarchar(50) COLLATE Latin1_General_CI_AS  NULL,
  [MatKhau] nvarchar(50) COLLATE Latin1_General_CI_AS  NULL,
  [Quyen] nvarchar(10) COLLATE Latin1_General_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[NhanVien] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of NhanVien
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[NhanVien] ON
GO

INSERT INTO [dbo].[NhanVien] ([Id], [Ten], [DiaChi], [GioiTinh], [SoDT], [TaiKhoan], [MatKhau], [Quyen]) VALUES (N'4', N'Admin', N'TPHCM', N'Nam', N'123456789', N'admin', N'USCUABwZ/GM=', N'Admin')
GO

SET IDENTITY_INSERT [dbo].[NhanVien] OFF
GO

COMMIT
GO


-- ----------------------------
-- Table structure for PhieuSucKhoe
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[PhieuSucKhoe]') AND type IN ('U'))
	DROP TABLE [dbo].[PhieuSucKhoe]
GO

CREATE TABLE [dbo].[PhieuSucKhoe] (
  [IdLichTiem] int  NOT NULL,
  [NgayTao] datetime  NULL,
  [TrangThai] bit  NOT NULL,
  [ChieuCao] float(53)  NULL,
  [CanNang] float(53)  NULL,
  [DiUng] nvarchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [BenhHienTai] nvarchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [DangMangThai] bit  NULL,
  [DangDieuTriBenh] bit  NULL,
  [TenBenhNhan] nvarchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [NgaySinh] datetime  NULL,
  [GioiTinh] nvarchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [SoDienThoai] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [DiaChi] nvarchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [Id] int  IDENTITY(1,1) NOT NULL
)
GO

ALTER TABLE [dbo].[PhieuSucKhoe] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of PhieuSucKhoe
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[PhieuSucKhoe] ON
GO

SET IDENTITY_INSERT [dbo].[PhieuSucKhoe] OFF
GO

COMMIT
GO


-- ----------------------------
-- Table structure for VacXin
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[VacXin]') AND type IN ('U'))
	DROP TABLE [dbo].[VacXin]
GO

CREATE TABLE [dbo].[VacXin] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [Ten] nvarchar(50) COLLATE Latin1_General_CI_AS  NULL,
  [NCCId] nvarchar(50) COLLATE Latin1_General_CI_AS  NULL,
  [TieuChuan] nvarchar(50) COLLATE Latin1_General_CI_AS  NULL,
  [SoLo] nvarchar(50) COLLATE Latin1_General_CI_AS  NULL,
  [GiaTien] int  NULL,
  [PhongBenh] nvarchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [SoLuong] int  NULL
)
GO

ALTER TABLE [dbo].[VacXin] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of VacXin
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[VacXin] ON
GO

SET IDENTITY_INSERT [dbo].[VacXin] OFF
GO

COMMIT
GO


-- ----------------------------
-- Auto increment value for HoaDon
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[HoaDon]', RESEED, 5)
GO


-- ----------------------------
-- Auto increment value for KhachHang
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[KhachHang]', RESEED, 5)
GO


-- ----------------------------
-- Primary Key structure for table KhachHang
-- ----------------------------
ALTER TABLE [dbo].[KhachHang] ADD CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for LichTiem
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[LichTiem]', RESEED, 8)
GO


-- ----------------------------
-- Primary Key structure for table LichTiem
-- ----------------------------
ALTER TABLE [dbo].[LichTiem] ADD CONSTRAINT [PK_LichTiem] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for LienHe
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[LienHe]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table LienHe
-- ----------------------------
ALTER TABLE [dbo].[LienHe] ADD CONSTRAINT [PK_LienHe] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for NhaCungCap
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[NhaCungCap]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table NhaCungCap
-- ----------------------------
ALTER TABLE [dbo].[NhaCungCap] ADD CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for NhanVien
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[NhanVien]', RESEED, 4)
GO


-- ----------------------------
-- Primary Key structure for table NhanVien
-- ----------------------------
ALTER TABLE [dbo].[NhanVien] ADD CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for PhieuSucKhoe
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[PhieuSucKhoe]', RESEED, 5)
GO


-- ----------------------------
-- Primary Key structure for table PhieuSucKhoe
-- ----------------------------
ALTER TABLE [dbo].[PhieuSucKhoe] ADD CONSTRAINT [PK__PhieuSuc__3214EC0718A1AFE7] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for VacXin
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[VacXin]', RESEED, 2)
GO


-- ----------------------------
-- Primary Key structure for table VacXin
-- ----------------------------
ALTER TABLE [dbo].[VacXin] ADD CONSTRAINT [PK_VacXin] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

