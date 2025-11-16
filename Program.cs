using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Input;

namespace IDT_PARKING
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }

    // CREATE TABLE [dbo].[Active] (
    //     [sttthe] [float] NOT NULL,
    //     [CardID] [varchar](50) NOT NULL,
    //     [trangthai] [int] NULL,
    //     CONSTRAINT [PK_Active] PRIMARY KEY CLUSTERED ([sttthe] ASC, [CardID] ASC)
    //     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    // ) ON [PRIMARY]
    // CREATE TABLE [dbo].[Active1] (
    //     [sttthe] [float] NOT NULL,
    //     [CardID] [varchar](50) NOT NULL,
    //     [trangthai] [int] NULL,
    //     CONSTRAINT [PK_Active1] PRIMARY KEY CLUSTERED ([sttthe] ASC, [CardID] ASC)
    //     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    // ) ON [PRIMARY]
    // CREATE TABLE [dbo].[BangGia] (
    //     [MaLoaiThe] [varchar](10) NOT NULL,
    //     [GiaVe] [numeric](18, 0) NULL,
    //     CONSTRAINT [PK_BangGia] PRIMARY KEY CLUSTERED ([MaLoaiThe] ASC)
    //     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    // ) ON [PRIMARY]
    // CREATE TABLE [dbo].[bcthethang] (
    //     [ID] [varchar](50) NOT NULL,
    //     [CardID] [varchar](20) NOT NULL,
    //     [SoTT] [varchar](50) NOT NULL,
    //     [MaKH] [nvarchar](250) NOT NULL,
    //     [TTrang] [varchar](50) NOT NULL,
    //     [MaLoaiThe] [varchar](20) NOT NULL,
    //     [soxe] [varchar](20) NULL,
    //     [nguoicap] [varchar](100) NULL,
    //     [giatien] [money] NOT NULL,
    //     [datcoc] [money] NOT NULL,
    //     [NgayBD] [datetime] NOT NULL,
    //     [NgayKT] [datetime] NOT NULL,
    //     [Ngaycap] [datetime] NOT NULL,
    //     CONSTRAINT [PK_bcthethang_1] PRIMARY KEY CLUSTERED ([ID] ASC, [CardID] ASC, [MaKH] ASC)
    //     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    // ) ON [PRIMARY]    // CREATE TABLE [dbo].[demxe] (
    //     [ngay] [datetime] NOT NULL,
    //     [soxe] [int] NOT NULL,
    //     CONSTRAINT [PK_demxe] PRIMARY KEY CLUSTERED ([ngay] ASC)
    //     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    // ) ON [PRIMARY]    // CREATE TABLE [dbo].[doanhthu] (
    //     [tungay] [datetime] NOT NULL,
    //     [denngay] [datetime] NOT NULL,
    //     [tugio] [varchar](50) NOT NULL,
    //     [dengio] [varchar](50) NOT NULL,
    //     [tong] [money] NOT NULL,
    //     CONSTRAINT [PK_doanhthu] PRIMARY KEY CLUSTERED ([tungay] ASC, [denngay] ASC, [tugio] ASC, [dengio] ASC)
    //     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    // ) ON [PRIMARY]    // CREATE TABLE [dbo].[history] (
    //     [time] [datetime] NOT NULL,
    //     [cong] [nchar](10) NOT NULL,
    //     [noidung] [nvarchar](500) NOT NULL,
    //     [thuchien] [nchar](10) NOT NULL,
    //     [username] [nvarchar](50) NOT NULL,
    //     CONSTRAINT [PK_history] PRIMARY KEY CLUSTERED ([time] ASC)
    //     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    // ) ON [PRIMARY]    // CREATE TABLE [dbo].[ITKHA] (
    //     [STTThe] [varchar](10) NOT NULL,
    //     [CardID] [varchar](20) NOT NULL,
    //     [NgayRa] [datetime] NOT NULL,
    //     [ThoiGianRa] [nchar](10) NOT NULL,
    //     [MaLoaiThe] [varchar](10) NOT NULL,
    //     [GiaTien] [money] NOT NULL,
    //     [username] [varchar](20) NOT NULL,
    //     [IDXe] [varchar](50) NOT NULL,
    //     [IDMat] [varchar](50) NOT NULL,
    //     [GioRa] [nchar](10) NOT NULL,
    //     [cong] [varchar](50) NULL,
    //     [soxe] [varchar](50) NULL,
    //     [soxera] [varchar](50) NOT NULL,
    //     [Thao_Tac] [nvarchar](20) NOT NULL,
    //     [Ngay_Thuc_Hien] [datetime] NOT NULL
    // ) ON [PRIMARY]    // CREATE TABLE [dbo].[KhachHang] (
    //     [MaKH] [varchar](20) NOT NULL,
    //     [hoten] [nvarchar](50) NOT NULL,
    //     [DonVi] [nvarchar](200) NULL,
    //     [DiaChi] [nvarchar](200) NULL,
    //     [dienthoai] [varchar](50) NULL,
    //     [hopdong] [varchar](50) NULL,
    //     [chungloai] [nvarchar](250) NULL,
    //     [hinhanh] [varchar](200) NULL,
    //     CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED ([MaKH] ASC)
    //     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    // ) ON [PRIMARY]    // CREATE TABLE [dbo].[KiemSoatRa_BK] (
    //     [mksoat] [varchar](50) NOT NULL,
    //     [cong] [nchar](10) NULL,
    //     CONSTRAINT [PK_KiemSoatRa_BK] PRIMARY KEY CLUSTERED ([mksoat] ASC)
    //     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    // ) ON [PRIMARY]    // CREATE TABLE [dbo].[LoaiThe] (
    //     [MaLoaiThe] [varchar](10) NOT NULL,
    //     [LoaiThe] [nvarchar](50) NOT NULL,
    //     [DienGiai] [nvarchar](200) NULL,
    //     [STT] [int] NULL,
    //     [tinhtien] [int] NOT NULL,
    //     CONSTRAINT [PK_LoaiThe_1] PRIMARY KEY CLUSTERED ([MaLoaiThe] ASC)
    //     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    // ) ON [PRIMARY]    // CREATE TABLE [dbo].[login] (
    //     [username] [varchar](50) NOT NULL,
    //     [pass] [varchar](50) NOT NULL,
    //     [MaNV] [varchar](20) NOT NULL,
    //     CONSTRAINT [PK_login_1] PRIMARY KEY CLUSTERED ([MaNV] ASC)
    //     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    // ) ON [PRIMARY]    // CREATE TABLE [dbo].[Logining] (
    //     [username] [varchar](50) NOT NULL,
    //     [TT] [int] NOT NULL,
    //     [IDMain] [varchar](50) NOT NULL,
    //     [cong] [varchar](50) NULL,
    //     CONSTRAINT [PK_Logining] PRIMARY KEY CLUSTERED ([username] ASC, [IDMain] ASC)
    //     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    // ) ON [PRIMARY]    // CREATE TABLE [dbo].[LoginInOut] (
    //     [DauVao] [int] NOT NULL,
    //     [DauRa] [int] NOT NULL,
    //     [Ngay] [datetime] NOT NULL,
    //     [Gio] [float] NOT NULL,
    //     [username] [varchar](20) NOT NULL,
    //     [TrangThai] [int] NULL,
    //     [ThoiGian] [nchar](10) NOT NULL,
    //     [IdMain] [nvarchar](50) NULL,
    //     [OL] [int] NULL,
    //     CONSTRAINT [PK_LoginInOut] PRIMARY KEY CLUSTERED ([Ngay] ASC, [Gio] ASC)
    //     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    // ) ON [PRIMARY]    // CREATE TABLE [dbo].[LoginInOut1] (
    //     [DauVao] [int] NOT NULL,
    //     [DauRa] [int] NOT NULL,
    //     [Ngay] [datetime] NOT NULL,
    //     [Gio] [float] NOT NULL,
    //     [username] [varchar](20) NOT NULL,
    //     [TrangThai] [int] NULL,
    //     [ThoiGian] [nchar](10) NULL,
    //     [IdMain] [nvarchar](50) NULL,
    //     [OL] [int] NULL,
    //     CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED ([Ngay] ASC, [Gio] ASC)
    //     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    // ) ON [PRIMARY]    // CREATE TABLE [dbo].[mobarie] (
    //     [maks] [varchar](50) NOT NULL,
    //     [ngaymo] [date] NOT NULL,
    //     [thoigian] [nchar](10) NOT NULL,
    //     [gio] [float] NOT NULL,
    //     [usename] [nchar](10) NULL,
    //     [cong] [varchar](50) NULL,
    //     [VaoRa] [int] NOT NULL,
    //     [Soxe] [varchar](50) NULL,
    //     CONSTRAINT [PK_mobarie] PRIMARY KEY CLUSTERED ([maks] ASC)
    //     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    // ) ON [PRIMARY]    // CREATE TABLE [dbo].[NhanVien] (
    //     [MaNV] [varchar](10) NOT NULL,
    //     [Hoten] [nvarchar](50) NULL,
    //     [DiaChi] [nvarchar](200) NULL,
    //     [Dt] [varchar](20) NULL,
    //     CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED ([MaNV] ASC)
    //     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    // ) ON [PRIMARY]    // CREATE TABLE [dbo].[PhanQuyen] (
    //     [MSQuyen] [varchar](10) NOT NULL,
    //     [ChucNang] [varchar](200) NOT NULL,
    //     CONSTRAINT [PK_PhanQuyen] PRIMARY KEY CLUSTERED ([MSQuyen] ASC)
    //     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    // ) ON [PRIMARY]    // CREATE TABLE [dbo].[QuyenDung] (
    //     [username] [varchar](20) NOT NULL,
    //     [MSQuyen] [varchar](200) NOT NULL,
    //     CONSTRAINT [PK_QuyenDung] PRIMARY KEY CLUSTERED ([username] ASC)
    //     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    // ) ON [PRIMARY]    // CREATE TABLE [dbo].[Ra] (
    //     [STTThe] [varchar](10) NOT NULL,
    //     [CardID] [varchar](20) NOT NULL,
    //     [NgayRa] [datetime] NOT NULL,
    //     [THoiGianRa] [float] NOT NULL,
    //     [MaLoaiThe] [varchar](10) NOT NULL,
    //     [GiaTien] [money] NOT NULL,
    //     [username] [varchar](20) NOT NULL,
    //     [IDXe] [varchar](50) NOT NULL,
    //     [IDMat] [varchar](50) NOT NULL,
    //     [GioRa] [nchar](10) NOT NULL,
    //     [cong] [varchar](50) NULL,
    //     [soxe] [varchar](50) NULL,
    //     [soxera] [varchar](50) NULL,
    //     CONSTRAINT [PK_Ra] PRIMARY KEY CLUSTERED ([CardID] ASC, [IDXe] ASC, [IDMat] ASC)
    //     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    // ) ON [PRIMARY]    // CREATE TABLE [dbo].[Ra1] (
    //     [STTThe] [varchar](10) NOT NULL,
    //     [CardID] [varchar](20) NOT NULL,
    //     [NgayRa] [datetime] NOT NULL,
    //     [THoiGianRa] [float] NOT NULL,
    //     [MaLoaiThe] [varchar](10) NOT NULL,
    //     [GiaTien] [money] NOT NULL,
    //     [username] [varchar](20) NOT NULL,
    //     [IDXe] [varchar](50) NOT NULL,
    //     [IDMat] [varchar](50) NOT NULL,
    //     [GioRa] [nchar](10) NULL,
    //     CONSTRAINT [PK_Ra2] PRIMARY KEY CLUSTERED ([CardID] ASC, [IDXe] ASC, [IDMat] ASC)
    //     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    // ) ON [PRIMARY]    // CREATE TABLE [dbo].[Sync_Img] (
    //     [FromImg] [varchar](max) NOT NULL,
    //     [ToImg] [varchar](max) NOT NULL,
    //     [ID] [smallint] NOT NULL,
    //     [F0] [varchar](50) NULL,
    //     [F1] [int] NULL,
    //     CONSTRAINT [PK_Sync_Img] PRIMARY KEY CLUSTERED ([ID] ASC)
    //     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    // ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]    // CREATE TABLE [dbo].[Syncdata] (
    //     [command] [varchar](max) NOT NULL,
    //     [ID] [numeric](18, 0) NOT NULL,
    //     [IP] [varchar](50) NOT NULL,
    //     CONSTRAINT [PK_Syncdata] PRIMARY KEY CLUSTERED ([ID] ASC, [IP] ASC)
    //     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    // ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]    // CREATE TABLE [dbo].[TheMat] (
    //     [STTThe] [float] NOT NULL,
    //     [CardID] [varchar](20) NOT NULL,
    //     [NgayMat] [datetime] NOT NULL,
    //     [Thoigian] [float] NOT NULL,
    //     [MaLoaiThe] [varchar](20) NOT NULL,
    //     [IDxe] [varchar](50) NOT NULL,
    //     [IDmat] [varchar](50) NOT NULL,
    //     [TT] [int] NULL,
    //     [diengiai] [varchar](50) NULL,
    //     [username] [varchar](20) NOT NULL,
    //     [Ngaytimduoc] [datetime] NULL,
    //     [thoigiantimduoc] [float] NULL,
    //     [usernametimduoc] [nchar](10) NULL,
    //     [GioMat_Str] [nchar](10) NULL,
    //     [GioThay_Str] [nchar](10) NULL,
    //     [congmat] [varchar](50) NULL,
    //     [congthay] [varchar](50) NULL,
    //     [soxe] [varchar](50) NULL,
    //     CONSTRAINT [PK_TheMat_1] PRIMARY KEY CLUSTERED ([STTThe] ASC, [CardID] ASC, [IDxe] ASC)
    //     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    // ) ON [PRIMARY]    // CREATE TABLE [dbo].[TheThang] (
    //     [CardID] [varchar](20) NOT NULL,
    //     [SoTT] [float] NOT NULL,
    //     [MaKH] [varchar](20) NOT NULL,
    //     [TTrang] [int] NOT NULL,
    //     [MaLoaiThe] [varchar](20) NOT NULL,
    //     [NgayBD] [datetime] NOT NULL,
    //     [NgayKT] [datetime] NOT NULL,
    //     [soxe] [nvarchar](100) NULL,
    //     [nguoicap] [varchar](50) NULL,
    //     [giatien] [varchar](50) NULL,
    //     [datcoc] [varchar](50) NULL
    // ) ON [PRIMARY]    // CREATE TABLE [dbo].[Vao] (
    //     [STTThe] [float] NOT NULL,
    //     [CardID] [varchar](20) NOT NULL,
    //     [NgayVao] [datetime] NOT NULL,
    //     [ThoiGian] [float] NOT NULL,
    //     [MaLoaiThe] [varchar](20) NULL,
    //     [username] [varchar](20) NOT NULL,
    //     [IDXe] [varchar](50) NOT NULL,
    //     [IDMat] [varchar](50) NOT NULL,
    //     [TT] [int] NOT NULL,
    //     [UsernameXoa] [varchar](20) NULL,
    //     [NgayXoa] [datetime] NULL,
    //     [ThoiGianXoa] [nchar](10) NULL,
    //     [cong] [varchar](50) NULL,
    //     [congxoa] [varchar](50) NULL,
    //     [loaithe] [int] NULL,
    //     [soxe] [varchar](50) NULL,
    //     [ghichu] [varchar](50) NULL,
    //     CONSTRAINT [PK_Vao] PRIMARY KEY CLUSTERED ([CardID] ASC, [IDXe] ASC, [IDMat] ASC)
    //     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    // ) ON [PRIMARY]    }
}
