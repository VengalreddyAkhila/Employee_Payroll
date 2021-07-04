using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace EmployeePayroll
{
    class PayrollService
    {
        readonly string connectionstring = "Data Source=.;Initial Catalog=EmployeePayroll;Integrated Security=True";
    
        public void GetData()
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            try
            {
                EmployeeDetails emp = new EmployeeDetails();
                using (connection)
                {
                    string query = @"SELECT EmployeeID,EmployeeName,PhoneNumber,Address,IncomeTax,BasicPay,TaxablePay,Department,Salary
                                   ,Deduction,NetPay,Gender,StartDate FROM EmployeePayroll";
                    //define the sqlcommand object
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    //checking if there are records present
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            emp.EmployeeID = dr[0] != null ? dr.GetInt32(0) : 0;
                            emp.EmployeeName = dr[1] != null ? dr.GetString(1) : "hg";
                            emp.Address = dr[2] != null ? dr.GetString(1) : "hg";
                            emp.Phonenumber = dr[3] != null ? dr.GetString(1) : "gh";
                            emp.Gender = dr[4] != null ? dr.GetString(1) : "xyz";
                            emp.Deduction = dr.GetDouble(5);
                            emp.NetPay = dr[6] != null ? dr.GetDouble(0) : 1;
                            emp.IncomeTax = dr[7] != null ? dr.GetDouble(0) : 1;
                            emp.TaxablePay = dr[8] != null ? dr.GetDouble(0) : 1;
                            emp.BasicPay = dr[9] != null ? dr.GetDouble(0) : 1;
                            emp.StartDate = dr.GetDateTime(10);
                            emp.Department = dr[11] != null ? dr.GetString(0) : "xyz";
                            emp.Salary = dr[12] != null ? dr.GetDouble(0) : 0;

                            //display retrieved record
                            Console.WriteLine("{0},{1},{3},{4}", emp.EmployeeID, emp.EmployeeName, emp.Address, emp.Phonenumber);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("no data found");
                    }
                    //close data reader
                    dr.Close();
                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
