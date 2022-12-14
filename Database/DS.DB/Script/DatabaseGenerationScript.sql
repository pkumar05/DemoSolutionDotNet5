USE [EmployeeInformation]
GO
/****** Object:  Schema [DS]    Script Date: 18/08/2022 10:58:18 AM ******/
CREATE SCHEMA [DS]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 18/08/2022 10:58:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[MessageTemplate] [nvarchar](max) NULL,
	[Level] [nvarchar](128) NULL,
	[TimeStamp] [datetimeoffset](7) NOT NULL,
	[Exception] [nvarchar](max) NULL,
	[Properties] [xml] NULL,
	[LogEvent] [nvarchar](max) NULL,
	[UserName] [nvarchar](200) NULL,
	[IP] [varchar](200) NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [DS].[Departments]    Script Date: 18/08/2022 10:58:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [DS].[Departments](
	[Id] [varchar](36) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Code] [varchar](100) NULL,
	[Descriptions] [nvarchar](100) NULL,
	[Active] [bit] NOT NULL,
	[CreatedBy] [nvarchar](256) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Updatedby] [nvarchar](256) NULL,
	[UpdatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [DS].[EmployeeProfile]    Script Date: 18/08/2022 10:58:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [DS].[EmployeeProfile](
	[Id] [varchar](36) NOT NULL,
	[EmployeeDepartmentId] [varchar](36) NOT NULL,
	[EmployeeProfileId] [varchar](36) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Code] [varchar](100) NULL,
	[Descriptions] [nvarchar](100) NULL,
	[Active] [bit] NOT NULL,
	[CreatedBy] [nvarchar](256) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Updatedby] [nvarchar](256) NULL,
	[UpdatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [DS].[Employees]    Script Date: 18/08/2022 10:58:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [DS].[Employees](
	[Id] [varchar](36) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[MiddleName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](320) NOT NULL,
	[Phone] [nvarchar](20) NULL,
	[HomeAddress] [nvarchar](100) NULL,
	[CurrentTitle] [nvarchar](50) NULL,
	[Data] [nvarchar](max) NULL,
	[Active] [bit] NOT NULL,
	[CreatedBy] [nvarchar](256) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Updatedby] [nvarchar](256) NULL,
	[UpdatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [DS].[Profile]    Script Date: 18/08/2022 10:58:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [DS].[Profile](
	[Id] [varchar](36) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Code] [varchar](100) NULL,
	[Descriptions] [nvarchar](100) NULL,
	[Active] [bit] NOT NULL,
	[CreatedBy] [nvarchar](256) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Updatedby] [nvarchar](256) NULL,
	[UpdatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [DS].[EmployeeProfile]  WITH CHECK ADD FOREIGN KEY([EmployeeDepartmentId])
REFERENCES [DS].[Departments] ([Id])
GO
ALTER TABLE [DS].[EmployeeProfile]  WITH CHECK ADD FOREIGN KEY([EmployeeProfileId])
REFERENCES [DS].[Profile] ([Id])
GO
