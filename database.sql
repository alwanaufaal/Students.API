USE [SelfLearning]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 28/05/2021 10:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](50) NOT NULL,
	[DateofBirth] [datetime] NOT NULL,
	[Address] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([Id], [FullName], [DateofBirth], [Address]) VALUES (1, N'Alwan', CAST(N'1997-07-13T00:00:00.000' AS DateTime), N'Jl. Pulo Asem')
INSERT [dbo].[Students] ([Id], [FullName], [DateofBirth], [Address]) VALUES (2, N'Ridho', CAST(N'2021-05-28T03:05:21.313' AS DateTime), N'Jl. Tanggerang Selatan')
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
/****** Object:  StoredProcedure [dbo].[SP_CreateUpdateStudent]    Script Date: 28/05/2021 10:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_CreateUpdateStudent]
@Id INT,
@FullName VARCHAR(50),
@DateofBirth DATETIME,
@Address VARCHAR(50)
AS
BEGIN
	IF @Id != 0
	BEGIN
		UPDATE Students SET FullName = @FullName, DateofBirth = @DateofBirth, [Address] = @Address
		WHERE Id = @Id
	END
	ELSE
	BEGIN
		INSERT INTO Students(FullName, DateofBirth, [Address])
		VALUES (@FullName, @DateofBirth, @Address)
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllStudents]    Script Date: 28/05/2021 10:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_GetAllStudents]
AS
BEGIN
	SELECT * FROM dbo.Students
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetStudent]    Script Date: 28/05/2021 10:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_GetStudent]
@Id INT
AS
BEGIN
	SELECT * FROM dbo.Students WHERE Id = @Id
END
GO
