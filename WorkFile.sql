use [TaskManager]
go

create table [User] (
userId uniqueidentifier default newid() primary key,
loginName nvarchar(50) not null,
passwordHash nvarchar(64) not null,
email nvarchar(50) not null,
firstName nvarchar(50),
lastName nvarchar(50),
dateOfBirth datetime2,
companyName nvarchar(50),
qualification nvarchar(50),
projectId uniqueidentifier,
extraInf  nvarchar(max)
);

alter table [User] add foreign key (doneBy) references [User](userId) on delete no action;

create table [Roles](
roleId uniqueidentifier default newid() primary key,
roleName nvarchar(50) not null,
)

create table [UserRoles](
roleId uniqueidentifier not null,
userId uniqueidentifier not null,
)

alter table [UserRoles]
add foreign key (userId) references [User](userId);

alter table [UserRoles]
add foreign key (roleId) references [Roles](roleId);

create table [Project] (
projectId uniqueidentifier default newid() primary key,
name nvarchar(50) not null,
managerId uniqueidentifier not null,
foreign key (managerId) references [User](userId),
summary nvarchar(max)
);

alter table [User]
add foreign key (projectId) references [Project](projectId);

create table [Task] (
taskId uniqueidentifier default newid() primary key,
name nvarchar(50) not null,
projrctId uniqueidentifier not null,
foreign key (projrctId) references [Project](projectId),
summary nvarchar(max),
creationTime datetime2 default getdate(),
deadline datetime2
);

create table [SubTask] (
sutaskId uniqueidentifier default newid() primary key,
name nvarchar(50) not null,
creationTime datetime2 default getdate(),
taskId uniqueidentifier,
foreign key (taskId) references [Task](taskId),
doneBy uniqueidentifier,
foreign key (doneBy) references [User](userId)
);

delete SubTask;

select [userId], [loginName], [passwordHash], [email], [firstName], [lastName], [dateOfBirth], [companyName], [qualification], [extraInf], [roleId] 
from [User]

select [userId], [loginName], [passwordHash], [email], [firstName], [lastName], [dateOfBirth], [companyName], [qualification], [extraInf], [roleId] 
from [User] where loginName='first'

select HASHBYTES('SHA2_512','12345');

select * from [User];

insert into [User] (loginName,passwordHash,email) values ('third', HASHBYTES('sha2_512', '12345'),'victoriya.kolomiets080395@yandex.ru');

select * from [User] where loginName='second' and passwordHash=HASHBYTES('sha2_512','12345');
 
 create procedure dbo.getAllUsers as
 begin
 select * from [User]
 end

declare @login nvarchar(30) ='second';
declare @password nvarchar(30) ='12345';
select * from [User] where loginName=@login and passwordHash=hashbytes('sha2_512', @password);

declare @login varchar(30) ='second';
declare @password varchar(30) ='12345';
select * from [User] where loginName=@login and passwordHash=hashbytes('sha2_512', @password);

insert into [Roles]
 (name) 
 values 
 ('manager' );

select * from [User];
select * from [Roles];
select * from [UserRoles];

alter table UserRoles add CONSTRAINT pair PRIMARY KEY (userId, roleId);

insert into [UserRoles] (userId,roleId) values ('7471B862-5D30-4D2E-90EC-3F8AC094125E','2B879D00-3181-4BCA-94B3-C0FD5D4CC4CE');
insert into [UserRoles] (userId,roleId) values ('DE95B9E9-DC52-4B14-B95B-567A1FDA906F','2B879D00-3181-4BCA-94B3-C0FD5D4CC4CE');
insert into [UserRoles] (userId,roleId) values ('DE95B9E9-DC52-4B14-B95B-567A1FDA906F','7BC3DF8E-C582-45F3-A377-096D33294689');
insert into [UserRoles] (userId,roleId) values ('DC441CA7-0879-4EB9-859D-C2D0D8AF2C64','2B879D00-3181-4BCA-94B3-C0FD5D4CC4CE');
insert into [UserRoles] (userId,roleId) values ('DC441CA7-0879-4EB9-859D-C2D0D8AF2C64','6216D639-398A-4266-9D8E-C9FDA5E76251');
insert into [UserRoles] (userId,roleId) values ('DC441CA7-0879-4EB9-859D-C2D0D8AF2C64','7BC3DF8E-C582-45F3-A377-096D33294689');


insert into [Project] (name,managerId,summary)
values ('ProjectOfFirst','DC441CA7-0879-4EB9-859D-C2D0D8AF2C64','Some summary for this project');


create procedure getAllUsers as
begin
	select 
	userId, loginName, email, passwordHash, firstName, 
	lastName, dateOfBirth, companyName, qualification, extraInf
	from [User]
end

create procedure getAllUserRoles @userLogin nvarchar(50) as
begin
select roleName
from [User] join [UserRoles] on [User].userId=[UserRoles].userId 
	 join [Roles] on [Roles].roleId=[UserRoles].roleId
	 where [User].loginName=@userLogin;
end

create procedure getAllUserProjects @userLogin nvarchar(50) as
begin
	select projectId, name, managerId, summary
	from [Project] join [User] on [User].userId=[Project].managerId
	where [User].loginName=@userLogin  
end

create procedure addUser @loginName nvarchar(50), @email nvarchar(50), @passwordHash varchar(50) as
begin
insert into [User] (loginName, email, passwordHash) values (@loginName, @email, @passwordHash);
end

create procedure getUser @loginName nvarchar(50) as
begin
select userId, loginName, email, passwordHash, firstName, 
	lastName, dateOfBirth, companyName, qualification, extraInf from [User] where loginName=@loginName
end

create procedure canLogin @loginName nvarchar(50), @passwordHash nvarchar(50) as
begin
select CAST(COUNT(*) AS BIT) FROM [User] WHERE (loginName = @loginName and passwordHash=@passwordHash)
end

create procedure createRole @userId nvarchar(50), @roleName nvarchar(50) as
begin
declare @roleId uniqueidentifier;
select @roleId=roleId from [Roles] where roleName=@roleName;
insert into [UserRoles] (userId,roleId) values (@userId,@roleId);
end

exec getUser 'first';
exec createRole '7471B862-5D30-4D2E-90EC-3F8AC094125E', 'User';
exec addUser '4th', 'victoriya.kolomiets080395@yandex.ru', '827ccb0eea8a706c4c34hhhha16891f84e7b'
exec canLogin 'first', '827ccb0eea8a706c4c34hhhha16891f84e7b';
exec getAllUsers;
exec getAllUserRoles 'second';
exec getAllUserProjects 'first';

create procedure getAllTasks @projectId nvarchar(50) as
begin
select * from [Task] where projectId=@projectId;
end

exec getAllTasks '26A90688-E1AE-432E-A56F-5644A4D626B4';

drop procedure getAllTasks

create procedure addTask @projectId nvarchar(50), @taskName nvarchar(50),  @taskSummary nvarchar(50),
@deadline datetime2 as
begin
insert into [Task] (projrctId, name, summary, deadline) values (@projectId, @taskName, @taskSummary, @deadline);
end

exec addTask '26A90688-E1AE-432E-A56F-5644A4D626B4', 'Новое', 'Сделать чё-нить', '2016-09-12';

'disable to add similar projrcts';

create procedure getAllSubTasks @taskId nvarchar(50) as
begin
select * from [SubTask] where taskId=@taskId;
end

exec getAllSubTasks '622a1f4d-de3e-4c9a-85ce-9aaf17239652'
exec addSubTask '622a1f4d-de3e-4c9a-85ce-9aaf17239652', 'Добавить кнопку <<Зарегистрироваться>>', '2016-03-03'; 

create procedure getAllUsersLike @loginName nvarchar(50)='', @email nvarchar(50)='',
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

drop procedure getAllUsersLike

create procedure getAllProjectsLike @projectName nvarchar(50), @summary nvarchar(50) as
begin
select * from [Project] where 
	name like @projectName and summary like @summary
end

exec getAllUsersLike;

create table [Contributor] (
userId uniqueidentifier not null,
projectId uniqueidentifier not null
);

alter table [Contributor] add foreign key (userId) references [User](userId) on delete no action;
alter table [Contributor] add foreign key (projectId) references [Project](projectId) on delete no action;
alter table [Contributor] add CONSTRAINT userIdProjectId PRIMARY KEY (userId, projectId);

create procedure getAllProjectContributors @projectId nvarchar(50) as
begin
	select loginName, email,
	firstName, lastName,
	companyName, qualification,
	extraInf, DATEDIFF(year, dateOfBirth, getDate()) as age
	from [Contributor] join [User] on [User].userId=[Contributor].userId
	where [Contributor].projectId=@projectId  
end


create procedure addContributor @projectId nvarchar(50), @loginName nvarchar(50) as 
begin
declare @userId uniqueidentifier;
select @userId=userId from [User] where loginName=@loginName;
insert into [Contributor] (projectId, userId) values (@projectId,@userId);
end

exec addContributor '26A90688-E1AE-432E-A56F-5644A4D626B4', 'first';
exec addContributor '26A90688-E1AE-432E-A56F-5644A4D626B4', 'second';
exec addContributor '26A90688-E1AE-432E-A56F-5644A4D626B4', 'third';

exec getAllProjectContributors '26A90688-E1AE-432E-A56F-5644A4D626B4'

'автодобавлять себя как контрибьутора своего проекта'

create procedure getProject @projectId nvarchar(50) as 
begin
select name, summary, loginName from [User] 
join [Project] on [User].userId=[Project].managerId
where projectId=@projectId
end

exec getProject '26A90688-E1AE-432E-A56F-5644A4D626B4'
exec getAllUserProjects 'first'

create procedure addDoneBy @subtaskId nvarchar(50), @userLogin nvarchar(50) as 
begin
declare @userId nvarchar(50);
select @userId=userId from [User] where loginName=@userLogin
update [Subtask] set doneBy = @userId
where subtaskId=@subtaskId
end

create procedure addCompletionTime @subtaskId nvarchar(50) as 
begin
update [Subtask] set completionTime = getdate()
where subtaskId=@subtaskId
end

drop procedure addCompletionTime

create procedure removeDoneBy @subtaskId nvarchar(50) as 
begin
update [Subtask] set doneBy = null
where subtaskId=@subtaskId
end

update [Subtask] set completionTime = null
 

exec removeDoneBy 'dbd3cab6-b403-4969-991f-03f3c79697ab';
exec removeDoneBy '3710cf2c-b473-4e2c-912a-1c91bce03a54';
exec removeDoneBy '97ec976c-d7f5-4b9c-9a53-3dcea1c3bc04';
exec removeDoneBy '754cd679-da40-4faa-aaa8-57103bca4ed8';
exec removeDoneBy '02b9bae2-6e4d-4b23-8171-6c70e801e292';
exec removeDoneBy 'bad34072-f18a-4b6a-b160-7a19975acbad';
exec removeDoneBy '226c3246-58a5-4f60-9cdf-ad9057be8c10';
exec removeDoneBy '7c70c7f5-c533-4ad7-acd5-ee14ae896708';
exec removeDoneBy '826568d3-0887-43ec-8449-f1b8c9533c20';
exec removeDoneBy '27ad30e8-f5a2-4804-a974-fb5ca41ea252';

create procedure deleteRole @userLogin nvarchar(50), @roleName nvarchar(50) as
begin
declare @roleId uniqueidentifier;
select @roleId=roleId from [Roles] where roleName=@roleName;
declare @userId uniqueidentifier;
select @userId=userId from [User] where userLogin=@userLogin;
delete from [UserRoles] where userId=@userId and roleId=@roleId;
end

drop procedure deleteRole
select userId from [User] where userId=@userId;
exec getAllUserRoles '12345';

exec deleteRole '12345', 'Admin'