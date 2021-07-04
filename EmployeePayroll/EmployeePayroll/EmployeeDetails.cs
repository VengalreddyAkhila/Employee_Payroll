using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayroll
{
    public class EmployeeDetails
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Address { get; set; }
        public string  Phonenumber { get; set; }       
        public string  Gender { get; set; }
        public double Deduction { get; set; }
        public double NetPay { get; set; }
        public double IncomeTax { get; set; }
        public double TaxablePay { get; set; }
        public double BasicPay { get; set; }
        public DateTime StartDate { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
    }
}
