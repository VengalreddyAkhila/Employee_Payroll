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
            empDetails.EmployeeName = "Akhila";
            empDetails.Address = "X-nagar";
            empDetails.Gender = "Female";
            empDetails.Department = "Salesmarketing";
            empDetails.StartDate = DateTime.ParseExact("1999-10-1", "yyyy-mm-dd", System.Globalization.CultureInfo.InvariantCulture);
            empDetails.Basic_Pay = 20000;
            empDetails.Deductions = 3000;
            empDetails.Taxable_Pay = 200;
            empDetails.Tax = 1000;
            empDetails.PhoneNumber = 8247236911;
            payroll.GetData();
            payroll.AddNewRecord(empDetails);
            

        }
       
    }
}
