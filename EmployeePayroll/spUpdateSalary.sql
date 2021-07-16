CREATE PROCEDURE SpUpdateSalary
	@EmployeeName varchar(255),
	@Basic_Pay float
AS
BEGIN
	 Update EmployeePayroll set EmployeeName =@EmployeeName, Basic_Pay = @Basic_Pay where EmployeeName = @EmployeeName 
END