USE [master]
GO
/****** Object:  Database [S_C]    Script Date: 2019/6/19 2:14:22 ******/
CREATE DATABASE [S_C]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'S_C', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\S_C.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'S_C_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\S_C_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [S_C] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [S_C].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [S_C] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [S_C] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [S_C] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [S_C] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [S_C] SET ARITHABORT OFF 
GO
ALTER DATABASE [S_C] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [S_C] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [S_C] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [S_C] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [S_C] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [S_C] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [S_C] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [S_C] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [S_C] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [S_C] SET  DISABLE_BROKER 
GO
ALTER DATABASE [S_C] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [S_C] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [S_C] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [S_C] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [S_C] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [S_C] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [S_C] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [S_C] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [S_C] SET  MULTI_USER 
GO
ALTER DATABASE [S_C] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [S_C] SET DB_CHAINING OFF 
GO
ALTER DATABASE [S_C] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [S_C] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [S_C] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [S_C] SET QUERY_STORE = OFF
GO
USE [S_C]
GO
/****** Object:  Table [dbo].[category_course]    Script Date: 2019/6/19 2:14:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category_course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[class]    Script Date: 2019/6/19 2:14:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[class](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Enroll_year] [smallint] NULL,
	[Major_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[class_student]    Script Date: 2019/6/19 2:14:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[class_student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[course_class_id] [int] NULL,
	[Student_id] [int] NULL,
	[Gpa_score] [tinyint] NULL,
	[Paper_score] [tinyint] NULL,
	[Practice_score] [tinyint] NULL,
	[Score] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[course]    Script Date: 2019/6/19 2:14:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [char](6) NULL,
	[Cname] [varchar](50) NULL,
	[Ename] [varchar](100) NULL,
	[Score] [tinyint] NULL,
	[Chour] [tinyint] NULL,
	[Lhour] [tinyint] NULL,
	[Tchour] [tinyint] NULL,
	[Tlhour] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Cname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Ename] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[course_class]    Script Date: 2019/6/19 2:14:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[course_class](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Semester_id] [int] NULL,
	[course_id] [int] NULL,
	[Max_class_size] [tinyint] NULL,
	[Teacher_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[curriculum]    Script Date: 2019/6/19 2:14:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[curriculum](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Program_id] [int] NULL,
	[course_id] [int] NULL,
	[Category_id] [int] NULL,
	[Semester] [tinyint] NULL,
	[Isdegree] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[education_program]    Script Date: 2019/6/19 2:14:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[education_program](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Objective] [varchar](2000) NULL,
	[Specification] [varchar](5000) NULL,
	[Duration] [tinyint] NULL,
	[Degree] [varchar](20) NULL,
	[Min_credit] [tinyint] NULL,
	[Publish_year] [smallint] NULL,
	[Major_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[major]    Script Date: 2019/6/19 2:14:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[major](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[plan_study_course]    Script Date: 2019/6/19 2:14:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[plan_study_course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[course_id] [int] NULL,
	[Semester_id] [int] NULL,
	[Student_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[resource]    Script Date: 2019/6/19 2:14:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[resource](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[course_id] [int] NULL,
	[Name] [varchar](50) NULL,
	[Resource_url] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[semester]    Script Date: 2019/6/19 2:14:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[semester](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[student]    Script Date: 2019/6/19 2:14:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[scode] [char](12) NULL,
	[Name] [varchar](50) NULL,
	[Gender] [char](2) NULL,
	[Photo] [char](1) NULL,
	[Class_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[scode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[teacher]    Script Date: 2019/6/19 2:14:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[teacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[tcode] [char](6) NULL,
	[Name] [varchar](50) NULL,
	[Gender] [char](2) NULL,
	[Degree] [varchar](10) NULL,
	[Title] [varchar](10) NULL,
	[Introduction] [varchar](2000) NULL,
	[Photo] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[class]  WITH CHECK ADD FOREIGN KEY([Major_id])
REFERENCES [dbo].[major] ([Id])
GO
ALTER TABLE [dbo].[class_student]  WITH CHECK ADD FOREIGN KEY([course_class_id])
REFERENCES [dbo].[course_class] ([Id])
GO
ALTER TABLE [dbo].[class_student]  WITH CHECK ADD FOREIGN KEY([Student_id])
REFERENCES [dbo].[student] ([Id])
GO
ALTER TABLE [dbo].[course_class]  WITH CHECK ADD FOREIGN KEY([course_id])
REFERENCES [dbo].[course] ([Id])
GO
ALTER TABLE [dbo].[course_class]  WITH CHECK ADD FOREIGN KEY([Semester_id])
REFERENCES [dbo].[course] ([Id])
GO
ALTER TABLE [dbo].[course_class]  WITH CHECK ADD FOREIGN KEY([Teacher_id])
REFERENCES [dbo].[course] ([Id])
GO
ALTER TABLE [dbo].[curriculum]  WITH CHECK ADD FOREIGN KEY([Category_id])
REFERENCES [dbo].[category_course] ([Id])
GO
ALTER TABLE [dbo].[curriculum]  WITH CHECK ADD FOREIGN KEY([course_id])
REFERENCES [dbo].[course] ([Id])
GO
ALTER TABLE [dbo].[curriculum]  WITH CHECK ADD FOREIGN KEY([Program_id])
REFERENCES [dbo].[education_program] ([Id])
GO
ALTER TABLE [dbo].[education_program]  WITH CHECK ADD FOREIGN KEY([Major_id])
REFERENCES [dbo].[major] ([Id])
GO
ALTER TABLE [dbo].[plan_study_course]  WITH CHECK ADD FOREIGN KEY([course_id])
REFERENCES [dbo].[course] ([Id])
GO
ALTER TABLE [dbo].[plan_study_course]  WITH CHECK ADD FOREIGN KEY([Semester_id])
REFERENCES [dbo].[semester] ([Id])
GO
ALTER TABLE [dbo].[plan_study_course]  WITH CHECK ADD FOREIGN KEY([Student_id])
REFERENCES [dbo].[student] ([Id])
GO
ALTER TABLE [dbo].[resource]  WITH CHECK ADD FOREIGN KEY([course_id])
REFERENCES [dbo].[course] ([Id])
GO
ALTER TABLE [dbo].[student]  WITH CHECK ADD FOREIGN KEY([Class_id])
REFERENCES [dbo].[class] ([Id])
GO
ALTER TABLE [dbo].[curriculum]  WITH CHECK ADD  CONSTRAINT [CK__curriculu__Isdeg__6477ECF3] CHECK  (([Isdegree]>=(0) AND [Isdegree]<=(1)))
GO
ALTER TABLE [dbo].[curriculum] CHECK CONSTRAINT [CK__curriculu__Isdeg__6477ECF3]
GO
ALTER TABLE [dbo].[curriculum]  WITH CHECK ADD  CONSTRAINT [CK__curriculu__Semes__656C112C] CHECK  (([Semester]>=(1) AND [semester]<=(8)))
GO
ALTER TABLE [dbo].[curriculum] CHECK CONSTRAINT [CK__curriculu__Semes__656C112C]
GO
ALTER TABLE [dbo].[student]  WITH CHECK ADD CHECK  (([Gender]='男' OR [Gender]='女'))
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'流水号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'category_course', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'课程类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'category_course', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'课程类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'category_course'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'流水号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'class', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'班级名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'class', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入学年份' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'class', @level2type=N'COLUMN',@level2name=N'Enroll_year'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'class', @level2type=N'COLUMN',@level2name=N'Major_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'班级信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'class'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'流水号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'class_student', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'class_student', @level2type=N'COLUMN',@level2name=N'course_class_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'class_student', @level2type=N'COLUMN',@level2name=N'Student_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'平时表现成绩' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'class_student', @level2type=N'COLUMN',@level2name=N'Gpa_score'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'理论考试成绩' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'class_student', @level2type=N'COLUMN',@level2name=N'Paper_score'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实践考核成绩' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'class_student', @level2type=N'COLUMN',@level2name=N'Practice_score'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总评成绩' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'class_student', @level2type=N'COLUMN',@level2name=N'Score'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'班级学生信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'class_student'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'流水号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'course', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'课程号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'course', @level2type=N'COLUMN',@level2name=N'Number'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'课程中文名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'course', @level2type=N'COLUMN',@level2name=N'Cname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'课程英文名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'course', @level2type=N'COLUMN',@level2name=N'Ename'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'course', @level2type=N'COLUMN',@level2name=N'Score'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'周理论学时' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'course', @level2type=N'COLUMN',@level2name=N'Chour'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'周实验学时' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'course', @level2type=N'COLUMN',@level2name=N'Lhour'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'理论总学时' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'course', @level2type=N'COLUMN',@level2name=N'Tchour'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实验总学时' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'course', @level2type=N'COLUMN',@level2name=N'Tlhour'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'课程信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'course'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'流水号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'course_class', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'course_class', @level2type=N'COLUMN',@level2name=N'Semester_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'course_class', @level2type=N'COLUMN',@level2name=N'course_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'班级最大容量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'course_class', @level2type=N'COLUMN',@level2name=N'Max_class_size'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'course_class', @level2type=N'COLUMN',@level2name=N'Teacher_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'课程开班' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'course_class'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'流水号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'curriculum', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'curriculum', @level2type=N'COLUMN',@level2name=N'Program_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'curriculum', @level2type=N'COLUMN',@level2name=N'course_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'curriculum', @level2type=N'COLUMN',@level2name=N'Category_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开课学期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'curriculum', @level2type=N'COLUMN',@level2name=N'Semester'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否学位课程' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'curriculum', @level2type=N'COLUMN',@level2name=N'Isdegree'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'课程体系' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'curriculum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'流水号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'education_program', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'education_program', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'培养目标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'education_program', @level2type=N'COLUMN',@level2name=N'Objective'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'规格要求' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'education_program', @level2type=N'COLUMN',@level2name=N'Specification'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标准学制' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'education_program', @level2type=N'COLUMN',@level2name=N'Duration'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'授予学位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'education_program', @level2type=N'COLUMN',@level2name=N'Degree'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'毕业学分要求' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'education_program', @level2type=N'COLUMN',@level2name=N'Min_credit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'制定年份' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'education_program', @level2type=N'COLUMN',@level2name=N'Publish_year'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'education_program', @level2type=N'COLUMN',@level2name=N'Major_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'培养方案' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'education_program'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'流水号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'major', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'专业名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'major', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'专业方向信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'major'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'流水号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'plan_study_course', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'plan_study_course', @level2type=N'COLUMN',@level2name=N'course_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'plan_study_course', @level2type=N'COLUMN',@level2name=N'Semester_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'plan_study_course', @level2type=N'COLUMN',@level2name=N'Student_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学期信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'plan_study_course'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'流水号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'resource', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'resource', @level2type=N'COLUMN',@level2name=N'course_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'资源名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'resource', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'资源链接' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'resource', @level2type=N'COLUMN',@level2name=N'Resource_url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'课程资源表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'resource'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'流水号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'semester', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学期名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'semester', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学期信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'semester'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'流水号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'student', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'student', @level2type=N'COLUMN',@level2name=N'scode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'student', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'student', @level2type=N'COLUMN',@level2name=N'Gender'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'照片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'student', @level2type=N'COLUMN',@level2name=N'Photo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'student', @level2type=N'COLUMN',@level2name=N'Class_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学生信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'student'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'流水号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'teacher', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'teacher', @level2type=N'COLUMN',@level2name=N'tcode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'teacher', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'teacher', @level2type=N'COLUMN',@level2name=N'Gender'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'teacher', @level2type=N'COLUMN',@level2name=N'Degree'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'职称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'teacher', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'个人简介' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'teacher', @level2type=N'COLUMN',@level2name=N'Introduction'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'个人照片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'teacher', @level2type=N'COLUMN',@level2name=N'Photo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'教师信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'teacher'
GO
USE [master]
GO
ALTER DATABASE [S_C] SET  READ_WRITE 
GO
