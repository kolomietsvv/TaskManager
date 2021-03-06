USE [master]
GO
/****** Object:  Database [TaskManager]    Script Date: 26.09.2016 7:48:57 ******/
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
/****** Object:  Table [dbo].[Contributor]    Script Date: 26.09.2016 7:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contributor](
	[userId] [uniqueidentifier] NOT NULL,
	[projectId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [userIdProjectId] PRIMARY KEY CLUSTERED 
(
	[userId] ASC,
	[projectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Project]    Script Date: 26.09.2016 7:48:57 ******/
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
/****** Object:  Table [dbo].[Roles]    Script Date: 26.09.2016 7:48:57 ******/
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
/****** Object:  Table [dbo].[SubTask]    Script Date: 26.09.2016 7:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubTask](
	[subtaskId] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[name] [nvarchar](50) NOT NULL,
	[creationTime] [datetime2](7) NULL DEFAULT (getdate()),
	[taskId] [uniqueidentifier] NULL,
	[doneBy] [uniqueidentifier] NULL,
	[completionTime] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[subtaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Task]    Script Date: 26.09.2016 7:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[taskId] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[name] [nvarchar](50) NOT NULL,
	[projectId] [uniqueidentifier] NOT NULL,
	[summary] [nvarchar](max) NULL,
	[creationTime] [datetime2](7) NULL DEFAULT (getdate()),
	[deadline] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[taskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 26.09.2016 7:48:57 ******/
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
/****** Object:  Table [dbo].[UserRoles]    Script Date: 26.09.2016 7:48:57 ******/
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
INSERT [dbo].[Contributor] ([userId], [projectId]) VALUES (N'7471b862-5d30-4d2e-90ec-3f8ac094125e', N'26a90688-e1ae-432e-a56f-5644a4d626b4')
INSERT [dbo].[Contributor] ([userId], [projectId]) VALUES (N'de95b9e9-dc52-4b14-b95b-567a1fda906f', N'26a90688-e1ae-432e-a56f-5644a4d626b4')
INSERT [dbo].[Contributor] ([userId], [projectId]) VALUES (N'dc441ca7-0879-4eb9-859d-c2d0d8af2c64', N'26a90688-e1ae-432e-a56f-5644a4d626b4')
INSERT [dbo].[Project] ([projectId], [name], [managerId], [summary]) VALUES (N'26a90688-e1ae-432e-a56f-5644a4d626b4', N'ProjectOfFirst', N'dc441ca7-0879-4eb9-859d-c2d0d8af2c64', N'Some summary for this project')
INSERT [dbo].[Roles] ([roleId], [roleName]) VALUES (N'7bc3df8e-c582-45f3-a377-096d33294689', N'Manager')
INSERT [dbo].[Roles] ([roleId], [roleName]) VALUES (N'2b879d00-3181-4bca-94b3-c0fd5d4cc4ce', N'User')
INSERT [dbo].[Roles] ([roleId], [roleName]) VALUES (N'6216d639-398a-4266-9d8e-c9fda5e76251', N'Admin')
INSERT [dbo].[SubTask] ([subtaskId], [name], [creationTime], [taskId], [doneBy], [completionTime]) VALUES (N'dbd3cab6-b403-4969-991f-03f3c79697ab', N'Добавить анимацию на закрытие окна', CAST(N'2016-09-14 14:12:25.5660000' AS DateTime2), N'622a1f4d-de3e-4c9a-85ce-9aaf17239652', NULL, NULL)
INSERT [dbo].[SubTask] ([subtaskId], [name], [creationTime], [taskId], [doneBy], [completionTime]) VALUES (N'226c3246-58a5-4f60-9cdf-ad9057be8c10', N'Заварить чай', CAST(N'2016-09-14 14:13:29.8100000' AS DateTime2), N'622a1f4d-de3e-4c9a-85ce-9aaf17239652', N'de95b9e9-dc52-4b14-b95b-567a1fda906f', CAST(N'2016-09-23 16:12:51.9630000' AS DateTime2))
INSERT [dbo].[SubTask] ([subtaskId], [name], [creationTime], [taskId], [doneBy], [completionTime]) VALUES (N'826568d3-0887-43ec-8449-f1b8c9533c20', N'добавить кнопку <<Настройки>>', CAST(N'2016-03-03 00:00:00.0000000' AS DateTime2), N'622a1f4d-de3e-4c9a-85ce-9aaf17239652', N'dc441ca7-0879-4eb9-859d-c2d0d8af2c64', NULL)
INSERT [dbo].[Task] ([taskId], [name], [projectId], [summary], [creationTime], [deadline]) VALUES (N'88545cdc-d27e-483d-a961-9153e085d478', N'Новая задача', N'26a90688-e1ae-432e-a56f-5644a4d626b4', N'Это описание новой задачи', CAST(N'2016-09-07 16:42:13.0730000' AS DateTime2), CAST(N'2016-09-13 00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Task] ([taskId], [name], [projectId], [summary], [creationTime], [deadline]) VALUES (N'622a1f4d-de3e-4c9a-85ce-9aaf17239652', N'Через API', N'26a90688-e1ae-432e-a56f-5644a4d626b4', N'LOL работает', CAST(N'2016-09-06 13:03:56.2330000' AS DateTime2), CAST(N'2016-09-07 00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Task] ([taskId], [name], [projectId], [summary], [creationTime], [deadline]) VALUES (N'1e82f417-a6a5-4ed3-b4b4-beee60364683', N'Create Interface', N'26a90688-e1ae-432e-a56f-5644a4d626b4', N'Create animated interface with new technologies', CAST(N'2016-08-09 12:19:04.6700000' AS DateTime2), CAST(N'2016-08-30 00:00:00.0000000' AS DateTime2))
INSERT [dbo].[User] ([userId], [loginName], [email], [firstName], [lastName], [dateOfBirth], [companyName], [qualification], [extraInf], [passwordHash]) VALUES (N'7471b862-5d30-4d2e-90ec-3f8ac094125e', N'third', N'victoriya.kolomiets080395@yandex.ru', NULL, NULL, NULL, NULL, NULL, NULL, N'827ccb0eea8a706c4c34a16891f84e7b')
INSERT [dbo].[User] ([userId], [loginName], [email], [firstName], [lastName], [dateOfBirth], [companyName], [qualification], [extraInf], [passwordHash]) VALUES (N'de95b9e9-dc52-4b14-b95b-567a1fda906f', N'second', N'victoriya.kolomiets080395@yandex.ru', NULL, NULL, NULL, NULL, NULL, NULL, N'827ccb0eea8a706c4c34a16891f84e7b')
INSERT [dbo].[User] ([userId], [loginName], [email], [firstName], [lastName], [dateOfBirth], [companyName], [qualification], [extraInf], [passwordHash]) VALUES (N'ac1b88b4-6c53-4393-8fab-67ddddc96e0f', N'4th', N'victoriya.kolomiets080395@yandex.ru', NULL, NULL, NULL, NULL, NULL, NULL, N'827CCB0EEA8A706C4C34A16891F84E7B')
INSERT [dbo].[User] ([userId], [loginName], [email], [firstName], [lastName], [dateOfBirth], [companyName], [qualification], [extraInf], [passwordHash]) VALUES (N'dc441ca7-0879-4eb9-859d-c2d0d8af2c64', N'first', N'victoriya.kolomiets080395@yandex.ru', N'Иван', N'Иванов', CAST(N'1990-08-03 00:00:00.0000000' AS DateTime2), N'ООО "Рога и копыта"', N'd3', N'Люблю кошек', N'827ccb0eea8a706c4c34a16891f84e7b')
INSERT [dbo].[User] ([userId], [loginName], [email], [firstName], [lastName], [dateOfBirth], [companyName], [qualification], [extraInf], [passwordHash]) VALUES (N'093fa816-aa0e-40ca-aa73-d2331d1a4f5a', N'12345', N'victoriya.kolomiets080395@yandex.ru', NULL, NULL, NULL, NULL, NULL, NULL, N'827CCB0EEA8A706C4C34A16891F84E7B')
INSERT [dbo].[UserRoles] ([roleId], [userId]) VALUES (N'2b879d00-3181-4bca-94b3-c0fd5d4cc4ce', N'7471b862-5d30-4d2e-90ec-3f8ac094125e')
INSERT [dbo].[UserRoles] ([roleId], [userId]) VALUES (N'7bc3df8e-c582-45f3-a377-096d33294689', N'de95b9e9-dc52-4b14-b95b-567a1fda906f')
INSERT [dbo].[UserRoles] ([roleId], [userId]) VALUES (N'2b879d00-3181-4bca-94b3-c0fd5d4cc4ce', N'de95b9e9-dc52-4b14-b95b-567a1fda906f')
INSERT [dbo].[UserRoles] ([roleId], [userId]) VALUES (N'2b879d00-3181-4bca-94b3-c0fd5d4cc4ce', N'ac1b88b4-6c53-4393-8fab-67ddddc96e0f')
INSERT [dbo].[UserRoles] ([roleId], [userId]) VALUES (N'7bc3df8e-c582-45f3-a377-096d33294689', N'dc441ca7-0879-4eb9-859d-c2d0d8af2c64')
INSERT [dbo].[UserRoles] ([roleId], [userId]) VALUES (N'2b879d00-3181-4bca-94b3-c0fd5d4cc4ce', N'dc441ca7-0879-4eb9-859d-c2d0d8af2c64')
INSERT [dbo].[UserRoles] ([roleId], [userId]) VALUES (N'6216d639-398a-4266-9d8e-c9fda5e76251', N'dc441ca7-0879-4eb9-859d-c2d0d8af2c64')
INSERT [dbo].[UserRoles] ([roleId], [userId]) VALUES (N'2b879d00-3181-4bca-94b3-c0fd5d4cc4ce', N'093fa816-aa0e-40ca-aa73-d2331d1a4f5a')
ALTER TABLE [dbo].[Contributor]  WITH CHECK ADD FOREIGN KEY([projectId])
REFERENCES [dbo].[Project] ([projectId])
GO
ALTER TABLE [dbo].[Contributor]  WITH CHECK ADD FOREIGN KEY([projectId])
REFERENCES [dbo].[Project] ([projectId])
GO
ALTER TABLE [dbo].[Contributor]  WITH CHECK ADD FOREIGN KEY([userId])
REFERENCES [dbo].[User] ([userId])
GO
ALTER TABLE [dbo].[Contributor]  WITH CHECK ADD FOREIGN KEY([userId])
REFERENCES [dbo].[User] ([userId])
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
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK__Task__projrctId__06CD04F7] FOREIGN KEY([projectId])
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
/****** Object:  StoredProcedure [dbo].[addCompletionTime]    Script Date: 26.09.2016 7:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[addCompletionTime] @subtaskId nvarchar(50) as 
begin
update [Subtask] set completionTime = getdate()
where subtaskId=@subtaskId
end

GO
/****** Object:  StoredProcedure [dbo].[addContributor]    Script Date: 26.09.2016 7:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[addContributor] @projectId nvarchar(50), @loginName nvarchar(50) as 
begin
declare @userId uniqueidentifier;
select @userId=userId from [User] where loginName=@loginName;
insert into [Contributor] (projectId, userId) values (@projectId,@userId);
end
GO
/****** Object:  StoredProcedure [dbo].[addDoneBy]    Script Date: 26.09.2016 7:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[addDoneBy] @subtaskId nvarchar(50), @userLogin nvarchar(50) as 
begin
declare @userId uniqueidentifier;
select @userId=userId from [User] where loginName=@userLogin
if(select doneBy from [Subtask] where subtaskId=@subtaskId)is null
update [Subtask] set doneBy = @userId
where  subtaskId=@subtaskId
end
GO
/****** Object:  StoredProcedure [dbo].[addProject]    Script Date: 26.09.2016 7:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[addProject] @loginName nvarchar(50), @projectName nvarchar(50), @summary nvarchar(50)=null as
begin
declare @userId uniqueidentifier;
select @userId=userId from [User] where loginName=@loginName;
insert into [Project] (name,managerId, summary) values (@projectName,@userId, @summary);
end
GO
/****** Object:  StoredProcedure [dbo].[addRole]    Script Date: 26.09.2016 7:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[addRole] @token nvarchar(50), @roleName nvarchar(50) as
begin 
declare @roleId uniqueidentifier;
select @roleId=roleId from [Roles] where roleName=@roleName;
insert into [UserRoles] (userId,roleId) values (@token,@roleId);
end
GO
/****** Object:  StoredProcedure [dbo].[addSubTask]    Script Date: 26.09.2016 7:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[addSubTask] @taskId nvarchar(50), @subTaskName nvarchar(50)=null,  @creationTime datetime2 as
begin
insert into [SubTask] (name,taskId,creationTime) values (@subTaskName,@taskId,@creationTime);
end
GO
/****** Object:  StoredProcedure [dbo].[addTask]    Script Date: 26.09.2016 7:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[addTask] @projectId nvarchar(50), @taskName nvarchar(50),  @taskSummary nvarchar(50)=null,
@deadline datetime2 as
begin
insert into [Task] (projectId, name, summary, deadline) values (@projectId, @taskName, @taskSummary, @deadline);
end
GO
/****** Object:  StoredProcedure [dbo].[addUser]    Script Date: 26.09.2016 7:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[addUser] @loginName nvarchar(50), @email nvarchar(50), @passwordHash varchar(50) as
begin
insert into [User] (loginName, email, passwordHash) values (@loginName, @email, @passwordHash);
end
GO
/****** Object:  StoredProcedure [dbo].[canLogin]    Script Date: 26.09.2016 7:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[canLogin] @loginName nvarchar(50), @passwordHash nvarchar(50) as
begin
declare @isPasswordCorrect bit;
select @isPasswordCorrect=COUNT(*) FROM [User] WHERE (loginName = @loginName and passwordHash=@passwordHash);
declare @isHaveRoles bit;
select @isHaveRoles=COUNT(roleName)
from [User] join [UserRoles] on [User].userId=[UserRoles].userId 
	 join [Roles] on [Roles].roleId=[UserRoles].roleId
	 where [User].loginName=@loginName;
select cast ((@isPasswordCorrect & @isHaveRoles) as bit);
end
GO
/****** Object:  StoredProcedure [dbo].[deleteRole]    Script Date: 26.09.2016 7:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[deleteRole] @userLogin nvarchar(50), @roleName nvarchar(50) as
begin
declare @roleId uniqueidentifier;
select @roleId=roleId from [Roles] where roleName=@roleName;
declare @userId uniqueidentifier;
select @userId=userId from [User] where loginName=@userLogin;
delete from [UserRoles] where userId=@userId and roleId=@roleId;
end
GO
/****** Object:  StoredProcedure [dbo].[getAllProjectContributors]    Script Date: 26.09.2016 7:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getAllProjectContributors] @projectId nvarchar(50) as
begin
	select loginName, email,
	firstName, lastName,
	companyName, qualification,
	extraInf, DATEDIFF(year, dateOfBirth, getDate()) as age
	from [Contributor] join [User] on [User].userId=[Contributor].userId
	where [Contributor].projectId=@projectId  
end
GO
/****** Object:  StoredProcedure [dbo].[getAllProjectsLike]    Script Date: 26.09.2016 7:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getAllProjectsLike] @projectName nvarchar(50), @summary nvarchar(50) as
begin
select * from [Project] where 
	name like @projectName and summary like @summary
end
GO
/****** Object:  StoredProcedure [dbo].[getAllSubTasks]    Script Date: 26.09.2016 7:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getAllSubTasks] @taskId nvarchar(50) as
begin
select subtaskId, [SubTask].name, [SubTask].creationTime, 
[SubTask].taskId, loginName as doneBy, completionTime, [Task].projectId
from [SubTask] join [Task]  on [Task].taskId=[Subtask].taskId
	join [Project] on Task.projectId=Project.projectId
	join [User] on [User].userId=doneBy
	where [SubTask].taskId=@taskId
	union
	select subtaskId, [SubTask].name, [SubTask].creationTime, 
	[SubTask].taskId, null as doneBy, completionTime, [Task].projectId
	from [SubTask] join [Task]  on [Task].taskId=[Subtask].taskId
	join [Project] on Task.projectId=Project.projectId
	where [SubTask].taskId=@taskId and doneBy is null
end
GO
/****** Object:  StoredProcedure [dbo].[getAllTasks]    Script Date: 26.09.2016 7:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getAllTasks] @projectId nvarchar(50) as
begin
select * from [Task] where projectId=@projectId;
end
GO
/****** Object:  StoredProcedure [dbo].[getAllUserProjects]    Script Date: 26.09.2016 7:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getAllUserProjects] @loginName nvarchar(50) as
begin
declare @userId uniqueidentifier;
select @userId=userId from [User] where loginName=@loginName;
select [Contributor].projectId, name, summary, loginName as managerLogin
	from [Project] 
	join [Contributor] on [Contributor].projectId=[Project].projectId
	join [User] on [User].userId=[Project].managerId
	where [Contributor].userId=@userId
	UNION
	select projectId, name, summary, loginName as managerLogin
	from [Project] join [User] on [User].userId=[Project].managerId
	where [User].loginName=@loginName  
end
GO
/****** Object:  StoredProcedure [dbo].[getAllUserRoles]    Script Date: 26.09.2016 7:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getAllUserRoles] @loginName nvarchar(50) as
begin
select roleName
from [User] join [UserRoles] on [User].userId=[UserRoles].userId 
	 join [Roles] on [Roles].roleId=[UserRoles].roleId
	 where [User].loginName=@loginName;
end
GO
/****** Object:  StoredProcedure [dbo].[getAllUsers]    Script Date: 26.09.2016 7:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[getAllUsersLike]    Script Date: 26.09.2016 7:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getAllUsersLike] @loginName nvarchar(50)='', @email nvarchar(50)='',
	@firstName nvarchar(50)='', @lastName nvarchar(50)='', @age int=0, @isYounger bit='false',
	@companyName nvarchar(50)='', @qualification nvarchar(50)='', @extraInf nvarchar(50)='' as
begin
if(@isYounger='true')
	begin
	select 
	loginName, email,
	firstName, lastName,
	companyName, qualification,
	extraInf, DATEDIFF(year, dateOfBirth, getDate()) as age
	from [User] where
	loginName like '%'+@loginName+'%' and
	email like '%'+@email+'%' and
	isnull(firstName, '') like '%'+@firstName+'%' and
	isnull(lastName, '') like '%'+@lastName+'%' and
	isnull(companyName,'') like '%'+@companyName+'%' and
	isnull(qualification, '') like '%'+@qualification+'%' and
	isnull(extraInf, '') like '%'+@extrainf+'%' and
	isnull(DATEDIFF( year, dateOfBirth, getDate() ), 0) < @age
	end
else
	begin
	select loginName, email,
	firstName, lastName,
	companyName, qualification,
	extraInf, DATEDIFF(year, dateOfBirth, getDate()) as age
	from [User] where loginName like '%'+@loginName+'%' and
	email like '%'+@email+'%' and
	isnull(firstName, '') like '%'+@firstName+'%' and
	isnull(lastName, '') like '%'+@lastName+'%' and
	isnull(companyName,'') like '%'+@companyName+'%' and
	isnull(qualification, '') like '%'+@qualification+'%' and
	isnull(extraInf, '') like '%'+@extrainf+'%' and
	isnull(DATEDIFF( year, dateOfBirth, getDate() ), 0) >= @age
	end
end
GO
/****** Object:  StoredProcedure [dbo].[getProject]    Script Date: 26.09.2016 7:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getProject] @projectId nvarchar(50) as 
begin
select name, summary, loginName from [User] 
join [Project] on [User].userId=[Project].managerId
where projectId=@projectId
end
GO
/****** Object:  StoredProcedure [dbo].[getUser]    Script Date: 26.09.2016 7:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[removeDoneBy]    Script Date: 26.09.2016 7:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[removeDoneBy] @subtaskId nvarchar(50) as 
begin
update [Subtask] set doneBy = null
where subtaskId=@subtaskId
end

GO
USE [master]
GO
ALTER DATABASE [TaskManager] SET  READ_WRITE 
GO
