﻿CREATE DATABASE TT_QLTV
GO

USE TT_QLTV
GO

CREATE TABLE SACH (
     MASACH INT IDENTITY(1,1) NOT NULL,
	TENSACH NVARCHAR(50),
	 GIATRI NVARCHAR(20)
)
CREATE TABLE NHANVIEN (
    MANV INT IDENTITY(1,1) NOT NULL,
	HOTEN NVARCHAR(40),
	NS DATE,
	GT NVARCHAR(4)
)
CREATE TABLE NGUOIMUON(
    MANM INT IDENTITY(1,1) NOT NULL,
	HOTEN NVARCHAR(40),
	NS DATE,
	GT NVARCHAR(4),
	DC NVARCHAR(100),
	SDT NCHAR(15)
	)
GO
CREATE TABLE MUONSACH(
   MAMUON INT IDENTITY(1,1) NOT NULL,
   MANV INT,
   MANM INT,
   MASACH INT,
   THOIGIAN DATE,
   DATRAHAYCHUA NVARCHAR(30)
   )
GO
 
CREATE TABLE THELOAI(
   MATHELOAI INT IDENTITY(1,1) NOT NULL,
   TENTHELOAI NVARCHAR(100)
   )
GO
CREATE TABLE TACGIA(
   MATG INT IDENTITY(1,1) NOT NULL,
   TENTG NVARCHAR(40)
   )
GO
CREATE TABLE PHANLOAI(
   MAPL INT IDENTITY(1,1) NOT NULL,
   KIEUPL NVARCHAR(100),
   MASACH INT,
   MATHELOAI INT
   )
GO
CREATE TABLE SANGTAC(
   MASANGTAC INT IDENTITY(1,1) NOT NULL,
   MATG INT,
   MASACH INT
   )
GO
ALTER TABLE dbo.SACH ADD CONSTRAINT PK_MASACH  PRIMARY KEY(MASACH)
ALTER TABLE dbo.NHANVIEN ADD CONSTRAINT PK_MANV  PRIMARY KEY(MANV)
ALTER TABLE dbo.NGUOIMUON ADD CONSTRAINT PK_MANM  PRIMARY KEY(MANM)
ALTER TABLE dbo.MUONSACH ADD CONSTRAINT PK_MAMUON  PRIMARY KEY(MAMUON)
ALTER TABLE dbo.THELOAI ADD CONSTRAINT PK_MATHELOAI  PRIMARY KEY(MATHELOAI)
ALTER TABLE dbo.TACGIA ADD CONSTRAINT PK_MATG  PRIMARY KEY(MATG)
ALTER TABLE dbo.SANGTAC ADD CONSTRAINT PK_MASANGTAC  PRIMARY KEY(MASANGTAC) 
ALTER TABLE dbo.PHANLOAI ADD CONSTRAINT PK_MAPL  PRIMARY KEY(MAPL)
ALTER TABLE dbo.SANGTAC ADD CONSTRAINT FK_MASACH_ST_SA FOREIGN KEY(MASACH) REFERENCES dbo.SACH(MASACH)
ALTER TABLE dbo.SANGTAC ADD CONSTRAINT FK_MATG_ST_TG FOREIGN KEY(MATG) REFERENCES dbo.TACGIA(MATG)
ALTER TABLE dbo.PHANLOAI ADD CONSTRAINT FK_MASACH_PL_SA FOREIGN KEY(MASACH) REFERENCES dbo.SACH(MASACH)
ALTER TABLE dbo.PHANLOAI ADD CONSTRAINT FK_MATHELOAI_PL_TL FOREIGN KEY(MATHELOAI) REFERENCES dbo.THELOAI(MATHELOAI)
ALTER TABLE dbo.MUONSACH ADD CONSTRAINT FK_MASACH_MS_SA FOREIGN KEY(MASACH) REFERENCES dbo.SACH(MASACH)
ALTER TABLE dbo.MUONSACH ADD CONSTRAINT FK_MANV_MS_NV FOREIGN KEY(MANV) REFERENCES dbo.NHANVIEN(MANV)
ALTER TABLE dbo.MUONSACH ADD CONSTRAINT FK_MANM_MS_NM FOREIGN KEY(MANM) REFERENCES dbo.NGUOIMUON(MANM)

GO
------------SÁCH-----------
INSERT INTO SACH(TENSACH , GIATRI)
VALUES(N'Để trở thành code điên','120000')
GO
INSERT INTO SACH(TENSACH , GIATRI)
VALUES(N'Mười vạn câu hỏi vì sao','300000')
GO

create PROC USP_GETSACH 
AS 
begin
SELECT MASACH,TENSACH,GIATRI
FROM SACH
end
exec USP_GETSACH
GO
--TẠO PROC THÊM
CREATE PROC USP_INSERTSACH
	@TENSACH NVARCHAR(50),
	@GIATRI NVARCHAR(20)
AS
BEGIN
	INSERT INTO SACH(TENSACH, GIATRI)
	VALUES(@TENSACH, @GIATRI)
END
GO

--TẠO PROC SỬA:
CREATE PROC USP_UPDATESACH
	@MASACH INT,
	@TENSACH NVARCHAR(50),
	@GIATRI NVARCHAR(20)
AS
BEGIN 
	UPDATE SACH
	SET TENSACH = @TENSACH, GIATRI = @GIATRI
	WHERE MASACH = @MASACH
END
GO

--TẠO PROC XOÁ
CREATE PROC USP_DELETESACH
	@MASACH INT
AS
BEGIN
	DELETE SACH 
	WHERE MASACH = @MASACH
END
GO

--TẠO PROC TÌM KIẾM
CREATE PROCEDURE USP_SEARCHSACH
	@SEARCHVALUE NVARCHAR(50)
AS
BEGIN
	SELECT MASACH,TENSACH,GIATRI
	FROM SACH 
	WHERE (MASACH LIKE N'%' + @SEARCHVALUE + '%') 
		OR (TENSACH LIKE N'%' + @SEARCHVALUE + '%') 
		OR (GIATRI LIKE N'%' + @SEARCHVALUE + '%') 	
END
GO

------------------------------------------------------- Phân Loại-------------------------------------------------------
CREATE PROC PHANLOAI_GETALL
AS
	SELECT MAPL, KIEUPL, dbo.SACH.MASACH, TENSACH, dbo.THELOAI.MATHELOAI, TENTHELOAI
	FROM dbo.PHANLOAI, dbo.SACH, dbo.THELOAI
	WHERE dbo.PHANLOAI.MASACH = dbo.SACH.MASACH AND dbo.THELOAI.MATHELOAI = dbo.PHANLOAI.MATHELOAI
GO

--tạo proc thêm
CREATE PROC SP_PHANLOAI_INSERT
	@KIEUPL NVARCHAR(100),
	@MASACH INT,
	@MATHELOAI INT
AS
BEGIN
	INSERT INTO PHANLOAI(KIEUPL, MASACH, MATHELOAI)
	VALUES(@KIEUPL, @MASACH, @MATHELOAI)
END
GO

--TẠO PROC XOÁ
CREATE PROC SP_PHANLOAI_DELETE
	@MAPL INT
AS
BEGIN
	DELETE dbo.PHANLOAI 
	WHERE MAPL = @MAPL
END
GO

--TẠO PROC SỬA
CREATE PROC SP_PHANLOAI_UPDATE
	@MAPL INT,
	@KIEUPL NVARCHAR(100),
	@MASACH INT,
	@MATHELOAI INT
AS
BEGIN 
	UPDATE dbo.PHANLOAI
	SET KIEUPL = @KIEUPL, MASACH = @MASACH, MATHELOAI = @MATHELOAI
	WHERE MAPL = @MAPL
END
GO

--TẠO PROC TÌM KIẾM
CREATE PROCEDURE SP_PHANLOAI_SEARCH
	@SEARCHVALUE NVARCHAR(100)
AS
BEGIN
	SELECT MAPL, KIEUPL, dbo.SACH.MASACH, TENSACH, dbo.THELOAI.MATHELOAI, TENTHELOAI
	FROM dbo.PHANLOAI, dbo.SACH, dbo.THELOAI
	WHERE (dbo.PHANLOAI.MASACH = dbo.SACH.MASACH AND dbo.PHANLOAI.MATHELOAI = dbo.THELOAI.MATHELOAI) AND 
	((dbo.PHANLOAI.MAPL LIKE N'%' + @SEARCHVALUE + '%') 
		OR (dbo.PHANLOAI.KIEUPL LIKE N'%' + @SEARCHVALUE + '%') 
		OR (dbo.PHANLOAI.MASACH LIKE N'%' + @SEARCHVALUE + '%') 
		OR (dbo.SACH.TENSACH LIKE N'%' + @SEARCHVALUE + '%')
		OR (dbo.PHANLOAI.MATHELOAI Like N'%' + @SEARCHVALUE + '%')
		OR (dbo.THELOAI.TENTHELOAI Like N'%' + @SEARCHVALUE + '%'))
END
GO


    