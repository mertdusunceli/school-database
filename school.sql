USE [master]
GO
/****** Object:  Database [OkulSistem]    Script Date: 8/22/2017 1:46:41 PM ******/
CREATE DATABASE [OkulSistem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OkulSistem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\OkulSistem.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'OkulSistem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\OkulSistem_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [OkulSistem] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OkulSistem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OkulSistem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OkulSistem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OkulSistem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OkulSistem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OkulSistem] SET ARITHABORT OFF 
GO
ALTER DATABASE [OkulSistem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OkulSistem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OkulSistem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OkulSistem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OkulSistem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OkulSistem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OkulSistem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OkulSistem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OkulSistem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OkulSistem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OkulSistem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OkulSistem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OkulSistem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OkulSistem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OkulSistem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OkulSistem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OkulSistem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OkulSistem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OkulSistem] SET  MULTI_USER 
GO
ALTER DATABASE [OkulSistem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OkulSistem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OkulSistem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OkulSistem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [OkulSistem] SET DELAYED_DURABILITY = DISABLED 
GO
USE [OkulSistem]
GO
/****** Object:  Table [dbo].[Bolum]    Script Date: 8/22/2017 1:46:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bolum](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[adi] [varchar](50) NOT NULL,
	[ref_Fakulte] [int] NULL,
	[active] [int] NULL,
 CONSTRAINT [PK_Bolum] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ders]    Script Date: 8/22/2017 1:46:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ders_adi] [varchar](50) NOT NULL,
	[ders_referans] [varchar](50) NOT NULL,
	[kredi] [int] NOT NULL,
	[ref_bolum] [int] NULL,
	[active] [int] NULL,
 CONSTRAINT [PK_Ders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Fakulte]    Script Date: 8/22/2017 1:46:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Fakulte](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fakulteAdi] [varchar](512) NOT NULL,
	[active] [int] NULL,
 CONSTRAINT [PK_Fakulte] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Kullanici]    Script Date: 8/22/2017 1:46:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Kullanici](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[adi] [varchar](50) NOT NULL,
	[sifre] [varchar](50) NULL,
	[email] [text] NOT NULL,
	[telefon] [int] NOT NULL,
	[ref_Personel] [int] NOT NULL,
	[active] [int] NULL,
 CONSTRAINT [PK_Kullanici] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Kullanici_Roller]    Script Date: 8/22/2017 1:46:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanici_Roller](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Kullanici_ref] [int] NOT NULL,
	[Rol_ref] [int] NOT NULL,
	[active] [int] NULL,
 CONSTRAINT [PK_Kullanici_Roller] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Oda]    Script Date: 8/22/2017 1:46:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Oda](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[oda_numara] [varchar](50) NOT NULL,
	[kat] [int] NOT NULL,
	[active] [int] NULL,
 CONSTRAINT [PK_Oda] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Oda_Dersleri]    Script Date: 8/22/2017 1:46:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oda_Dersleri](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ref_DersId] [int] NOT NULL,
	[ref_OdId] [int] NOT NULL,
	[active] [int] NULL,
 CONSTRAINT [PK_Oda_Dersleri] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Oda_Personel]    Script Date: 8/22/2017 1:46:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oda_Personel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ref_OdaId] [int] NOT NULL,
	[ref_PersonelId] [int] NOT NULL,
	[active] [int] NULL,
 CONSTRAINT [PK_Oda_Personel] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Okul]    Script Date: 8/22/2017 1:46:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Okul](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[adi] [varchar](50) NOT NULL,
	[adres] [text] NOT NULL,
	[telefon] [int] NOT NULL,
	[email] [text] NOT NULL,
	[active] [int] NULL CONSTRAINT [DF_Okul_active]  DEFAULT ((1)),
 CONSTRAINT [PK_Okul] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Personel]    Script Date: 8/22/2017 1:46:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Personel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[adi] [varchar](50) NOT NULL,
	[soyad] [varchar](50) NOT NULL,
	[yas] [varchar](50) NOT NULL,
	[mezun_tarih] [date] NULL,
	[sinif] [int] NULL,
	[ref_bolum] [int] NOT NULL,
	[ref_okul] [int] NOT NULL,
	[active] [int] NULL,
 CONSTRAINT [PK_Ogrenci] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 8/22/2017 1:46:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rol](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[adi] [varchar](50) NOT NULL,
	[yetki] [text] NOT NULL,
	[active] [int] NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sinavlar]    Script Date: 8/22/2017 1:46:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sinavlar](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ref_ders] [int] NOT NULL,
	[ref_personel] [int] NOT NULL,
	[durum] [text] NOT NULL,
	[puan] [int] NOT NULL,
	[active] [int] NULL,
 CONSTRAINT [PK_Sinavlar] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Bolum] ON 

INSERT [dbo].[Bolum] ([id], [adi], [ref_Fakulte], [active]) VALUES (1, N'Bilgisayar', 2, 0)
INSERT [dbo].[Bolum] ([id], [adi], [ref_Fakulte], [active]) VALUES (2, N'Kimya', 1, 0)
INSERT [dbo].[Bolum] ([id], [adi], [ref_Fakulte], [active]) VALUES (3, N'Ekonomi', 2, 0)
INSERT [dbo].[Bolum] ([id], [adi], [ref_Fakulte], [active]) VALUES (4, N'Elektrik Elektronik', 1, 1)
INSERT [dbo].[Bolum] ([id], [adi], [ref_Fakulte], [active]) VALUES (5, N'Mimarlik', 3, 1)
INSERT [dbo].[Bolum] ([id], [adi], [ref_Fakulte], [active]) VALUES (6, N'Psikoloji', 2, 0)
INSERT [dbo].[Bolum] ([id], [adi], [ref_Fakulte], [active]) VALUES (7, N'Tiyatro', 3, 1)
INSERT [dbo].[Bolum] ([id], [adi], [ref_Fakulte], [active]) VALUES (8, N'Arkeoloji', 2, 1)
SET IDENTITY_INSERT [dbo].[Bolum] OFF
SET IDENTITY_INSERT [dbo].[Ders] ON 

INSERT [dbo].[Ders] ([id], [ders_adi], [ders_referans], [kredi], [ref_bolum], [active]) VALUES (1, N'Organik Kimya', N'CHEM143', 5, 2, 1)
INSERT [dbo].[Ders] ([id], [ders_adi], [ders_referans], [kredi], [ref_bolum], [active]) VALUES (2, N'Iletkenlik', N'EE108', 5, 4, 1)
SET IDENTITY_INSERT [dbo].[Ders] OFF
SET IDENTITY_INSERT [dbo].[Fakulte] ON 

INSERT [dbo].[Fakulte] ([id], [fakulteAdi], [active]) VALUES (1, N'Fen Bilimleri ', 1)
INSERT [dbo].[Fakulte] ([id], [fakulteAdi], [active]) VALUES (2, N'Sosyal Bilimler', 0)
INSERT [dbo].[Fakulte] ([id], [fakulteAdi], [active]) VALUES (3, N'Guzel Sanatlar', 1)
INSERT [dbo].[Fakulte] ([id], [fakulteAdi], [active]) VALUES (4, N'Iktisadi ve Idari Bilimler', 1)
SET IDENTITY_INSERT [dbo].[Fakulte] OFF
SET IDENTITY_INSERT [dbo].[Kullanici] ON 

INSERT [dbo].[Kullanici] ([id], [adi], [sifre], [email], [telefon], [ref_Personel], [active]) VALUES (1, N'mertd', N'123456A!', N'mertdusunceli@gmail.com', 530415513, 1, 0)
INSERT [dbo].[Kullanici] ([id], [adi], [sifre], [email], [telefon], [ref_Personel], [active]) VALUES (2, N'celal1996', NULL, N'cll@gmail.com', 212, 2, 1)
SET IDENTITY_INSERT [dbo].[Kullanici] OFF
SET IDENTITY_INSERT [dbo].[Kullanici_Roller] ON 

INSERT [dbo].[Kullanici_Roller] ([id], [Kullanici_ref], [Rol_ref], [active]) VALUES (1, 1, 1, 1)
INSERT [dbo].[Kullanici_Roller] ([id], [Kullanici_ref], [Rol_ref], [active]) VALUES (2, 1, 3, 0)
SET IDENTITY_INSERT [dbo].[Kullanici_Roller] OFF
SET IDENTITY_INSERT [dbo].[Oda] ON 

INSERT [dbo].[Oda] ([id], [oda_numara], [kat], [active]) VALUES (1, N'A1-203', 2, 1)
INSERT [dbo].[Oda] ([id], [oda_numara], [kat], [active]) VALUES (3, N'B1-311', 3, 1)
INSERT [dbo].[Oda] ([id], [oda_numara], [kat], [active]) VALUES (4, N'A2-202', 2, 0)
INSERT [dbo].[Oda] ([id], [oda_numara], [kat], [active]) VALUES (5, N'C2-167', 1, 0)
INSERT [dbo].[Oda] ([id], [oda_numara], [kat], [active]) VALUES (6, N'C1-443', 4, 0)
SET IDENTITY_INSERT [dbo].[Oda] OFF
SET IDENTITY_INSERT [dbo].[Oda_Dersleri] ON 

INSERT [dbo].[Oda_Dersleri] ([id], [ref_DersId], [ref_OdId], [active]) VALUES (1, 1, 1, 0)
INSERT [dbo].[Oda_Dersleri] ([id], [ref_DersId], [ref_OdId], [active]) VALUES (2, 1, 5, 1)
INSERT [dbo].[Oda_Dersleri] ([id], [ref_DersId], [ref_OdId], [active]) VALUES (3, 1, 3, 1)
SET IDENTITY_INSERT [dbo].[Oda_Dersleri] OFF
SET IDENTITY_INSERT [dbo].[Oda_Personel] ON 

INSERT [dbo].[Oda_Personel] ([id], [ref_OdaId], [ref_PersonelId], [active]) VALUES (1, 1, 2, 1)
INSERT [dbo].[Oda_Personel] ([id], [ref_OdaId], [ref_PersonelId], [active]) VALUES (2, 4, 1, 1)
SET IDENTITY_INSERT [dbo].[Oda_Personel] OFF
SET IDENTITY_INSERT [dbo].[Okul] ON 

INSERT [dbo].[Okul] ([id], [adi], [adres], [telefon], [email], [active]) VALUES (1, N'YTU', N'Davutpasa', 2123096663, N'info@ytu.edu', 1)
INSERT [dbo].[Okul] ([id], [adi], [adres], [telefon], [email], [active]) VALUES (2, N'Beykent', N'Ayazaga', 2122345434, N'info@beykent.edu', 0)
INSERT [dbo].[Okul] ([id], [adi], [adres], [telefon], [email], [active]) VALUES (3, N'BJHHJGHJGHGH', N'VVCHVVH', 8, N'SADFA', 0)
INSERT [dbo].[Okul] ([id], [adi], [adres], [telefon], [email], [active]) VALUES (6, N'c', N'a', 9, N'ba', 0)
INSERT [dbo].[Okul] ([id], [adi], [adres], [telefon], [email], [active]) VALUES (8, N'Bogazici', N'Bebek', 3, N'a', 1)
INSERT [dbo].[Okul] ([id], [adi], [adres], [telefon], [email], [active]) VALUES (1007, N'asasd', N'asd', 2, N'as', 1)
INSERT [dbo].[Okul] ([id], [adi], [adres], [telefon], [email], [active]) VALUES (1008, N'xcxfxfxfx', N'ghjhh', 6, N'dfgdfgfdfgdfg', 0)
INSERT [dbo].[Okul] ([id], [adi], [adres], [telefon], [email], [active]) VALUES (1009, N's', N'a', 12, N'21', 1)
INSERT [dbo].[Okul] ([id], [adi], [adres], [telefon], [email], [active]) VALUES (1010, N'istek', N'antalya', 242, N'iletisim@istek.edu', 1)
INSERT [dbo].[Okul] ([id], [adi], [adres], [telefon], [email], [active]) VALUES (1011, N'koc', N'sariyer', 212, N'koc@koc.com', 0)
INSERT [dbo].[Okul] ([id], [adi], [adres], [telefon], [email], [active]) VALUES (1012, N'gebze uni', N'gebze', 262, N'info@gebze.edu', 1)
SET IDENTITY_INSERT [dbo].[Okul] OFF
SET IDENTITY_INSERT [dbo].[Personel] ON 

INSERT [dbo].[Personel] ([id], [adi], [soyad], [yas], [mezun_tarih], [sinif], [ref_bolum], [ref_okul], [active]) VALUES (1, N'Mert', N'Dusunceli', N'19', CAST(N'2020-06-30' AS Date), 1, 5, 1, 1)
INSERT [dbo].[Personel] ([id], [adi], [soyad], [yas], [mezun_tarih], [sinif], [ref_bolum], [ref_okul], [active]) VALUES (2, N'Huseyin', N'Djibrine', N'26', CAST(N'2017-06-30' AS Date), 4, 3, 2, 1)
INSERT [dbo].[Personel] ([id], [adi], [soyad], [yas], [mezun_tarih], [sinif], [ref_bolum], [ref_okul], [active]) VALUES (3, N'Ahmet', N'Deniz', N'24', CAST(N'2017-06-30' AS Date), 5, 3, 2, 1)
INSERT [dbo].[Personel] ([id], [adi], [soyad], [yas], [mezun_tarih], [sinif], [ref_bolum], [ref_okul], [active]) VALUES (4, N'Kemal', N'Deniz', N'24', CAST(N'2017-06-30' AS Date), 5, 1, 1, 0)
INSERT [dbo].[Personel] ([id], [adi], [soyad], [yas], [mezun_tarih], [sinif], [ref_bolum], [ref_okul], [active]) VALUES (5, N'Asli', N'Deniz', N'18', CAST(N'2021-06-30' AS Date), 1, 2, 1, 1)
INSERT [dbo].[Personel] ([id], [adi], [soyad], [yas], [mezun_tarih], [sinif], [ref_bolum], [ref_okul], [active]) VALUES (6, N'Mert', N'Dusunceli', N'19', CAST(N'2020-06-30' AS Date), 2, 1, 1010, 1)
SET IDENTITY_INSERT [dbo].[Personel] OFF
SET IDENTITY_INSERT [dbo].[Rol] ON 

INSERT [dbo].[Rol] ([id], [adi], [yetki], [active]) VALUES (1, N'admin', N'all', 1)
INSERT [dbo].[Rol] ([id], [adi], [yetki], [active]) VALUES (2, N'professor', N'exam, personnel, room, lecture', 1)
INSERT [dbo].[Rol] ([id], [adi], [yetki], [active]) VALUES (3, N'student', N'exam, personnel, room, lecture', 1)
SET IDENTITY_INSERT [dbo].[Rol] OFF
SET IDENTITY_INSERT [dbo].[Sinavlar] ON 

INSERT [dbo].[Sinavlar] ([id], [ref_ders], [ref_personel], [durum], [puan], [active]) VALUES (1, 1, 2, N'Pass', 95, 1)
INSERT [dbo].[Sinavlar] ([id], [ref_ders], [ref_personel], [durum], [puan], [active]) VALUES (2, 1, 4, N'Fail', 38, 1)
SET IDENTITY_INSERT [dbo].[Sinavlar] OFF
ALTER TABLE [dbo].[Bolum]  WITH CHECK ADD  CONSTRAINT [FK_Bolum_Fakulte] FOREIGN KEY([ref_Fakulte])
REFERENCES [dbo].[Fakulte] ([id])
GO
ALTER TABLE [dbo].[Bolum] CHECK CONSTRAINT [FK_Bolum_Fakulte]
GO
ALTER TABLE [dbo].[Ders]  WITH CHECK ADD  CONSTRAINT [FK_Ders_Bolum] FOREIGN KEY([ref_bolum])
REFERENCES [dbo].[Bolum] ([id])
GO
ALTER TABLE [dbo].[Ders] CHECK CONSTRAINT [FK_Ders_Bolum]
GO
ALTER TABLE [dbo].[Kullanici]  WITH CHECK ADD  CONSTRAINT [FK_Kullanici_Personel] FOREIGN KEY([ref_Personel])
REFERENCES [dbo].[Personel] ([id])
GO
ALTER TABLE [dbo].[Kullanici] CHECK CONSTRAINT [FK_Kullanici_Personel]
GO
ALTER TABLE [dbo].[Kullanici_Roller]  WITH CHECK ADD  CONSTRAINT [FK_Kullanici_Roller_Kullanici] FOREIGN KEY([Kullanici_ref])
REFERENCES [dbo].[Kullanici] ([id])
GO
ALTER TABLE [dbo].[Kullanici_Roller] CHECK CONSTRAINT [FK_Kullanici_Roller_Kullanici]
GO
ALTER TABLE [dbo].[Kullanici_Roller]  WITH CHECK ADD  CONSTRAINT [FK_Kullanici_Roller_Rol] FOREIGN KEY([Rol_ref])
REFERENCES [dbo].[Rol] ([id])
GO
ALTER TABLE [dbo].[Kullanici_Roller] CHECK CONSTRAINT [FK_Kullanici_Roller_Rol]
GO
ALTER TABLE [dbo].[Oda_Dersleri]  WITH CHECK ADD  CONSTRAINT [FK_Oda_Dersleri_Ders] FOREIGN KEY([ref_DersId])
REFERENCES [dbo].[Ders] ([id])
GO
ALTER TABLE [dbo].[Oda_Dersleri] CHECK CONSTRAINT [FK_Oda_Dersleri_Ders]
GO
ALTER TABLE [dbo].[Oda_Dersleri]  WITH CHECK ADD  CONSTRAINT [FK_Oda_Dersleri_Oda] FOREIGN KEY([ref_OdId])
REFERENCES [dbo].[Oda] ([id])
GO
ALTER TABLE [dbo].[Oda_Dersleri] CHECK CONSTRAINT [FK_Oda_Dersleri_Oda]
GO
ALTER TABLE [dbo].[Oda_Personel]  WITH CHECK ADD  CONSTRAINT [FK_Oda_Personel_Oda] FOREIGN KEY([ref_OdaId])
REFERENCES [dbo].[Oda] ([id])
GO
ALTER TABLE [dbo].[Oda_Personel] CHECK CONSTRAINT [FK_Oda_Personel_Oda]
GO
ALTER TABLE [dbo].[Oda_Personel]  WITH CHECK ADD  CONSTRAINT [FK_Oda_Personel_Personel] FOREIGN KEY([ref_PersonelId])
REFERENCES [dbo].[Personel] ([id])
GO
ALTER TABLE [dbo].[Oda_Personel] CHECK CONSTRAINT [FK_Oda_Personel_Personel]
GO
ALTER TABLE [dbo].[Personel]  WITH CHECK ADD  CONSTRAINT [FK_Ogrenci_Bolum] FOREIGN KEY([ref_bolum])
REFERENCES [dbo].[Bolum] ([id])
GO
ALTER TABLE [dbo].[Personel] CHECK CONSTRAINT [FK_Ogrenci_Bolum]
GO
ALTER TABLE [dbo].[Personel]  WITH CHECK ADD  CONSTRAINT [FK_Ogrenci_Okul] FOREIGN KEY([ref_okul])
REFERENCES [dbo].[Okul] ([id])
GO
ALTER TABLE [dbo].[Personel] CHECK CONSTRAINT [FK_Ogrenci_Okul]
GO
ALTER TABLE [dbo].[Sinavlar]  WITH CHECK ADD  CONSTRAINT [FK_Sinavlar_Ders] FOREIGN KEY([ref_ders])
REFERENCES [dbo].[Ders] ([id])
GO
ALTER TABLE [dbo].[Sinavlar] CHECK CONSTRAINT [FK_Sinavlar_Ders]
GO
ALTER TABLE [dbo].[Sinavlar]  WITH CHECK ADD  CONSTRAINT [FK_Sinavlar_Personel] FOREIGN KEY([ref_personel])
REFERENCES [dbo].[Personel] ([id])
GO
ALTER TABLE [dbo].[Sinavlar] CHECK CONSTRAINT [FK_Sinavlar_Personel]
GO
USE [master]
GO
ALTER DATABASE [OkulSistem] SET  READ_WRITE 
GO
