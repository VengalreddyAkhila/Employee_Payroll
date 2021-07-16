CREATE PROCEDURE SpAddEmployeeData
	@EmployeeName varchar(255),	
	@Basic_Pay float,
	@Gender varchar(32),
	@Department varchar(255),	
	@StartDate Date,
	@PhoneNumber bigint,
	@Address varchar(255),	
	@Deductions float,
	@Taxable_Pay float,
	@Tax float,
	@Net_Pay float
AS
BEGIN
	INSERT INTO EmployeePayroll(EmployeeName,Basic_Pay ,Gender, StartDate,Department, PhoneNumber, Address, Deductions, Taxable_Pay, Tax, Net_Pay) 
	VALUES(@EmployeeName, @Basic_Pay,  @Gender,CAST(@StartDate as Date), @Department, @PhoneNumber, @Address, @Deductions, @Taxable_Pay, @Tax,@Net_Pay);
END