using System;

namespace EmployeePayroll
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            PayrollService payroll = new PayrollService();
            EmployeeDetails empDetails = new EmployeeDetails();
            empDetails.EmployeeName = "akhila";
            empDetails.Basic_Pay = 20000;
            empDetails.Gender = "female";
            empDetails.Department = "salesmarketing";
            empDetails.StartDate = DateTime.ParseExact("1996-10-10", "MM-dd-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            empDetails.PhoneNumber = 8976543210;
            empDetails.Address = "x-nagar";
            empDetails.Deductions = 3000;
            empDetails.Taxable_Pay = 200;
            empDetails.Tax = 1000;
            empDetails.PhoneNumber = 8247236911;
            payroll.GetData();
            //payroll.AddRecord(empDetails);
            //payroll.AddNewRecord(empDetails);
            payroll.RetriewSalary("Terissa");
            //payroll.UpdateSalary("Terissa", 20000);

        }
       
    }
}
