USE [master]
GO
/****** Object:  Database [TaskManager]    Script Date: 17.07.2016 22:53:40 ******/
CREATE DATABASE [TaskManager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TaskManager', FILENAME = N'C:\Users\Вика\TaskManager.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TaskManager_log', FILENAME = N'C:\Users\Вика\TaskManager_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TaskManager] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TaskManager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TaskManager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TaskManager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TaskManager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TaskManager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TaskManager] SET ARITHABORT OFF 
GO
ALTER DATABASE [TaskManager] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TaskManager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TaskManager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TaskManager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TaskManager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TaskManager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TaskManager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TaskManager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TaskManager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TaskManager] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TaskManager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TaskManager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TaskManager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TaskManager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TaskManager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TaskManager] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TaskManager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TaskManager] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TaskManager] SET  MULTI_USER 
GO
ALTER DATABASE [TaskManager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TaskManager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TaskManager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TaskManager] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [TaskManager]
GO
/****** Object:  Table [dbo].[Engagement]    Script Date: 17.07.2016 22:53:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Engagement](
	[engagementId] [uniqueidentifier] NOT NULL,
	[projectId] [uniqueidentifier] NOT NULL,
	[userId] [uniqueidentifier] NOT NULL,
	[engagementTime] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[engagementId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Project]    Script Date: 17.07.2016 22:53:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[projectId] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[name] [nvarchar](50) NOT NULL,
	[managerId] [uniqueidentifier] NOT NULL,
	[summary] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[projectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 17.07.2016 22:53:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[roleId] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[roleName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[roleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubTask]    Script Date: 17.07.2016 22:53:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubTask](
	[subtaskId] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[creationTime] [datetime2](7) NULL,
	[taskId] [uniqueidentifier] NULL,
	[doneBy] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[subtaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Task]    Script Date: 17.07.2016 22:53:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[taskId] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[projrctId] [uniqueidentifier] NOT NULL,
	[summary] [nvarchar](max) NULL,
	[creationTime] [datetime2](7) NULL,
	[deadline] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[taskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 17.07.2016 22:53:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[userId] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[loginName] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[firstName] [nvarchar](50) NULL,
	[lastName] [nvarchar](50) NULL,
	[dateOfBirth] [datetime2](7) NULL,
	[companyName] [nvarchar](50) NULL,
	[qualification] [nvarchar](50) NULL,
	[extraInf] [nvarchar](max) NULL,
	[passwordHash] [varchar](64) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 17.07.2016 22:53:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[roleId] [uniqueidentifier] NOT NULL,
	[userId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pair] PRIMARY KEY CLUSTERED 
(
	[userId] ASC,
	[roleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Project] ([projectId], [name], [managerId], [summary]) VALUES (N'26a90688-e1ae-432e-a56f-5644a4d626b4', N'ProjectOfFirst', N'dc441ca7-0879-4eb9-859d-c2d0d8af2c64', N'Some summary for this project')
INSERT [dbo].[Roles] ([roleId], [roleName]) VALUES (N'7bc3df8e-c582-45f3-a377-096d33294689', N'Manager')
INSERT [dbo].[Roles] ([roleId], [roleName]) VALUES (N'2b879d00-3181-4bca-94b3-c0fd5d4cc4ce', N'User')
INSERT [dbo].[Roles] ([roleId], [roleName]) VALUES (N'6216d639-398a-4266-9d8e-c9fda5e76251', N'Admin')
INSERT [dbo].[User] ([userId], [loginName], [email], [firstName], [lastName], [dateOfBirth], [companyName], [qualification], [extraInf], [passwordHash]) VALUES (N'7471b862-5d30-4d2e-90ec-3f8ac094125e', N'third', N'victoriya.kolomiets080395@yandex.ru', NULL, NULL, NULL, NULL, NULL, NULL, N'827ccb0eea8a706c4c34a16891f84e7b')
INSERT [dbo].[User] ([userId], [loginName], [email], [firstName], [lastName], [dateOfBirth], [companyName], [qualification], [extraInf], [passwordHash]) VALUES (N'84bc94ec-525b-49b2-a4dd-45906b9107d3', N'5th', N'victoriya.kolomiets080395@yandex.ru', NULL, NULL, NULL, NULL, NULL, NULL, N'827CCB0EEA8A706C4C34A16891F84E7B')
INSERT [dbo].[User] ([userId], [loginName], [email], [firstName], [lastName], [dateOfBirth], [companyName], [qualification], [extraInf], [passwordHash]) VALUES (N'eafbca30-10bf-4abd-8dbe-4b12fdeda1af', N'4th', N'victoriya.kolomiets080395@yandex.ru', NULL, NULL, NULL, NULL, NULL, NULL, N'827CCB0EEA8A706C4C34A16891F84E7B')
INSERT [dbo].[User] ([userId], [loginName], [email], [firstName], [lastName], [dateOfBirth], [companyName], [qualification], [extraInf], [passwordHash]) VALUES (N'e9b1ae55-86d0-40fe-b7e3-4ce1b1ae9efc', N'9th', N'victoriya.kolomiets080395@yandex.ru', NULL, NULL, NULL, NULL, NULL, NULL, N'827CCB0EEA8A706C4C34A16891F84E7B')
INSERT [dbo].[User] ([userId], [loginName], [email], [firstName], [lastName], [dateOfBirth], [companyName], [qualification], [extraInf], [passwordHash]) VALUES (N'de95b9e9-dc52-4b14-b95b-567a1fda906f', N'second', N'victoriya.kolomiets080395@yandex.ru', NULL, NULL, NULL, NULL, NULL, NULL, N'827ccb0eea8a706c4c34a16891f84e7b')
INSERT [dbo].[User] ([userId], [loginName], [email], [firstName], [lastName], [dateOfBirth], [companyName], [qualification], [extraInf], [passwordHash]) VALUES (N'dc441ca7-0879-4eb9-859d-c2d0d8af2c64', N'first', N'victoriya.kolomiets080395@yandex.ru', NULL, NULL, NULL, NULL, NULL, NULL, N'827ccb0eea8a706c4c34a16891f84e7b')
INSERT [dbo].[User] ([userId], [loginName], [email], [firstName], [lastName], [dateOfBirth], [companyName], [qualification], [extraInf], [passwordHash]) VALUES (N'b2a4f3c0-92aa-4466-a6d5-f3e36ac71242', N'8th', N'victoriya.kolomiets080395@yandex.ru', NULL, NULL, NULL, NULL, NULL, NULL, N'827CCB0EEA8A706C4C34A16891F84E7B')
INSERT [dbo].[UserRoles] ([roleId], [userId]) VALUES (N'2b879d00-3181-4bca-94b3-c0fd5d4cc4ce', N'7471b862-5d30-4d2e-90ec-3f8ac094125e')
INSERT [dbo].[UserRoles] ([roleId], [userId]) VALUES (N'2b879d00-3181-4bca-94b3-c0fd5d4cc4ce', N'84bc94ec-525b-49b2-a4dd-45906b9107d3')
INSERT [dbo].[UserRoles] ([roleId], [userId]) VALUES (N'2b879d00-3181-4bca-94b3-c0fd5d4cc4ce', N'eafbca30-10bf-4abd-8dbe-4b12fdeda1af')
INSERT [dbo].[UserRoles] ([roleId], [userId]) VALUES (N'2b879d00-3181-4bca-94b3-c0fd5d4cc4ce', N'e9b1ae55-86d0-40fe-b7e3-4ce1b1ae9efc')
INSERT [dbo].[UserRoles] ([roleId], [userId]) VALUES (N'7bc3df8e-c582-45f3-a377-096d33294689', N'de95b9e9-dc52-4b14-b95b-567a1fda906f')
INSERT [dbo].[UserRoles] ([roleId], [userId]) VALUES (N'2b879d00-3181-4bca-94b3-c0fd5d4cc4ce', N'de95b9e9-dc52-4b14-b95b-567a1fda906f')
INSERT [dbo].[UserRoles] ([roleId], [userId]) VALUES (N'7bc3df8e-c582-45f3-a377-096d33294689', N'dc441ca7-0879-4eb9-859d-c2d0d8af2c64')
INSERT [dbo].[UserRoles] ([roleId], [userId]) VALUES (N'2b879d00-3181-4bca-94b3-c0fd5d4cc4ce', N'dc441ca7-0879-4eb9-859d-c2d0d8af2c64')
INSERT [dbo].[UserRoles] ([roleId], [userId]) VALUES (N'6216d639-398a-4266-9d8e-c9fda5e76251', N'dc441ca7-0879-4eb9-859d-c2d0d8af2c64')
INSERT [dbo].[UserRoles] ([roleId], [userId]) VALUES (N'2b879d00-3181-4bca-94b3-c0fd5d4cc4ce', N'b2a4f3c0-92aa-4466-a6d5-f3e36ac71242')
ALTER TABLE [dbo].[Engagement] ADD  DEFAULT (newid()) FOR [engagementId]
GO
ALTER TABLE [dbo].[Engagement] ADD  DEFAULT (getdate()) FOR [engagementTime]
GO
ALTER TABLE [dbo].[SubTask] ADD  DEFAULT (newid()) FOR [subtaskId]
GO
ALTER TABLE [dbo].[SubTask] ADD  DEFAULT (getdate()) FOR [creationTime]
GO
ALTER TABLE [dbo].[Task] ADD  DEFAULT (newid()) FOR [taskId]
GO
ALTER TABLE [dbo].[Task] ADD  DEFAULT (getdate()) FOR [creationTime]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK__Project__manager__3C69FB99] FOREIGN KEY([managerId])
REFERENCES [dbo].[User] ([userId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK__Project__manager__3C69FB99]
GO
ALTER TABLE [dbo].[SubTask]  WITH CHECK ADD FOREIGN KEY([doneBy])
REFERENCES [dbo].[User] ([userId])
GO
ALTER TABLE [dbo].[SubTask]  WITH CHECK ADD FOREIGN KEY([taskId])
REFERENCES [dbo].[Task] ([taskId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK__Task__projrctId__06CD04F7] FOREIGN KEY([projrctId])
REFERENCES [dbo].[Project] ([projectId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK__Task__projrctId__06CD04F7]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK__UserRoles__roleI__2BFE89A6] FOREIGN KEY([roleId])
REFERENCES [dbo].[Roles] ([roleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK__UserRoles__roleI__2BFE89A6]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK__UserRoles__userI__2CF2ADDF] FOREIGN KEY([userId])
REFERENCES [dbo].[User] ([userId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK__UserRoles__userI__2CF2ADDF]
GO
/****** Object:  StoredProcedure [dbo].[addUser]    Script Date: 17.07.2016 22:53:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[addUser] @loginName nvarchar(50), @email nvarchar(50), @passwordHash varchar(50) as
begin
insert into [User] (loginName, email, passwordHash) values (@loginName, @email, @passwordHash);
end
GO
/****** Object:  StoredProcedure [dbo].[canLogin]    Script Date: 17.07.2016 22:53:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[canLogin] @loginName nvarchar(50), @passwordHash nvarchar(50) as
begin
select CAST(COUNT(*) AS BIT) FROM [User] WHERE (loginName = @loginName and passwordHash=@passwordHash)
end
GO
/****** Object:  StoredProcedure [dbo].[createRole]    Script Date: 17.07.2016 22:53:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[createRole] @userId nvarchar(50), @roleName nvarchar(50) as
begin 
declare @roleId uniqueidentifier;
select @roleId=roleId from [Roles] where roleName=@roleName;
insert into [UserRoles] (userId,roleId) values (@userId,@roleId);
end
GO
/****** Object:  StoredProcedure [dbo].[getAllUserProjects]    Script Date: 17.07.2016 22:53:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getAllUserProjects] @userLogin nvarchar(50) as
begin
	select projectId, name, managerId, summary
	from [Project] join [User] on [User].userId=[Project].managerId
	where [User].loginName=@userLogin  
end
GO
/****** Object:  StoredProcedure [dbo].[getAllUserRoles]    Script Date: 17.07.2016 22:53:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getAllUserRoles] @userLogin nvarchar(50) as
begin
select roleName
from [User] join [UserRoles] on [User].userId=[UserRoles].userId 
	 join [Roles] on [Roles].roleId=[UserRoles].roleId
	 where [User].loginName=@userLogin;
end
GO
/****** Object:  StoredProcedure [dbo].[getAllUsers]    Script Date: 17.07.2016 22:53:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getAllUsers] as
begin
	select 
	userId, loginName, email, passwordHash, firstName, 
	lastName, dateOfBirth, companyName, qualification, extraInf
	from [User]
end
GO
/****** Object:  StoredProcedure [dbo].[getUser]    Script Date: 17.07.2016 22:53:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getUser] @loginName nvarchar(50) as
begin
select userId, loginName, email, passwordHash, firstName, 
	lastName, dateOfBirth, companyName, qualification, extraInf from [User] where loginName=@loginName
end
GO
USE [master]
GO
ALTER DATABASE [TaskManager] SET  READ_WRITE 
GO
