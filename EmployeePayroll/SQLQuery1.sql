create table EmpDetails
(EmpId int primary key identity(1,1),
EmployeeName varchar(32),
StartDate Date)
select *from EmpDetails
insert into EmpDetails Values('Akhila',CAST('1999-10-02' as Date)) 