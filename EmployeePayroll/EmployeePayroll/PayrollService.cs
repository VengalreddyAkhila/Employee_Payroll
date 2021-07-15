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
                            emp.Basic_Pay = dr.GetDouble(5);
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
        public bool AddNewRecord(EmployeeDetails address)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            try
            {
                EmployeeDetails empDetails = new EmployeeDetails();
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("spAddContacts", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeName", empDetails.EmployeeName);
                    cmd.Parameters.AddWithValue("@Basic_Pay", empDetails.Basic_Pay);
                    cmd.Parameters.AddWithValue("@Gender", empDetails.Gender);
                    cmd.Parameters.AddWithValue("@StartDate", empDetails.StartDate);
                    cmd.Parameters.AddWithValue("@Department", empDetails.Department);
                    cmd.Parameters.AddWithValue("@PhoneNumber", empDetails.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Address", empDetails.Address);
                    cmd.Parameters.AddWithValue("@Deductions", empDetails.Deductions);
                    cmd.Parameters.AddWithValue("@Taxable_Pay", empDetails.Taxable_Pay);
                    cmd.Parameters.AddWithValue("@Tax", empDetails.Tax);
                    cmd.Parameters.AddWithValue("@Net_Pay", empDetails.Net_Pay);
                    connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
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
