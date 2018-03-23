create database project2
go
use project2
create table Department
(
deptid int not null identity(1,1) primary key,
deptname varchar(50)
)

go
create table Employee
(
employeeid int identity(1,1) not null primary key ,
deptid int not null ,
empname varchar(50),
empjoiningdate date,
bossname varchar(50),
perdayrate real
)
go

ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT 
[FK__Employee__employ] FOREIGN KEY(deptid)
REFERENCES [dbo].[Department] ([deptid])
ON UPDATE CASCADE
ON DELETE CASCADE
go

create Proc Sp_InsertData
@deptname varchar(50),@empname varchar(50),
@empjoiningdate date,@bossname varchar(50),
@perdayrate real
As
Begin
declare @id int
insert into [dbo].[Department](deptname)
values (@deptname);
select @id= @@IDENTITY
if(@id>0)
	Begin
		insert into [dbo].[Employee](deptid,empname, empjoiningdate,bossname,perdayrate)
		VALUES(@id,@empname, @empjoiningdate,@bossname,@perdayrate)
	End
End

go

create proc Sp_DisplayData
As
Begin
Select Department.deptid as"Serial No" ,Department.deptname as"Dept.Name",Employee.empname as"Emp.Name",Employee.empjoiningdate as"Emp.Joindate",
Employee.bossname as"Boss Name",
Employee.perdayrate as"Per Day Rate" ,Employee.perdayrate*30 as "Monthly Salary"
from [dbo].[Department]
inner join [dbo].[Employee]
on Department.deptid =Employee.employeeid
order by Department.deptid desc
End
GO
create proc Sp_RptData
As
Begin
Select Department.deptid as Serial_No ,Department.deptname as DeptName,Employee.empname as EmpName,
Employee.empjoiningdate as Joindate,
Employee.bossname as BossName,
Employee.perdayrate as Rate ,Employee.perdayrate*30 as MonthlySalary

from [dbo].[Department]
inner join [dbo].[Employee]
on Department.deptid =Employee.employeeid
order by Department.deptid desc
End
go
create Proc Sp_UpdateData
@id int,
@deptname varchar(50),@empname varchar(50),
@empjoiningdate date,@bossname varchar(50) ,
@perdayrate real
As
Begin

Update [dbo].[Department] set deptname=@deptname
where deptid =@id

Update  [dbo].[Employee] set empname=@empname
,empjoiningdate=@empjoiningdate,bossname=@bossname,perdayrate=@perdayrate
		where deptid = @id

End