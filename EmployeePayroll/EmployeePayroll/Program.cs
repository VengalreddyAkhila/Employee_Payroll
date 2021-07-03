using System;

namespace EmployeePayroll
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            PayrollService payroll = new PayrollService();
            payroll.GetData();
            EmployeeDetails employeeDetails = new EmployeeDetails();
        }
    }
}
