using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace EmployeePayroll
{
    class PayrollService
    {
        readonly string connectionstring = "Data Source=.;Initial Catalog=EmpPayrollService;Integrated Security=True";
        /// <summary>
        ///  get data from database using SqlConnection and SqlCommand passing sql query.
        /// </summary>
        public void GetData()
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            try
            {
                EmployeeDetails emp = new EmployeeDetails();
                using (connection)
                {
                    string query = @"SELECT EmployeeName, Gender, Department, PhoneNumber, Address, Basic_Pay, StartDate FROM EmployeePayroll;";
                    //define the sqlcommand object
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    //checking if there are records present
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            emp.EmployeeName = dr.GetString(0);
                            emp.Gender = dr.GetString(1);
                            emp.Department = dr.GetString(2);
                            emp.PhoneNumber = dr.GetInt64(3);
                            emp.Address = dr.GetString(4);
                            emp.BasicPay = dr.GetDouble(5);
                            emp.StartDate = dr.GetDateTime(6);
                            Console.WriteLine("{0},{1},{2}",emp.EmployeeName,emp.Gender,emp.Department );
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
