using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Web;

namespace mvc_frame.Models
{
    public class EmployeeModelManger
    {
        string conn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        public List<Employee> GetEmployees()
        {
            SqlConnection connection = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("All_employes", connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while (reader.Read())
            {
                Employee employee = new Employee();
                employee.empid = Convert.ToInt32(reader["empid"]);
                employee.Name = reader["name"].ToString();
                employee.Gender = reader["gender"].ToString();
                employee.Role = reader["role"].ToString();
                employee.Country = reader["country"].ToString();
                employee.State = reader["state"].ToString();
                employee.City = reader["city"].ToString();
                employee.Username = reader["Username"].ToString();
                employee.Password = reader["Password"].ToString();
                employee.Status = reader["status"].ToString();

                employees.Add(employee);

            }
            return employees;
        }

        public Employee GetEmployeebyId(int id)
        {
            SqlConnection connection = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("All_employes", connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Employee employee = new Employee();
            if (reader.Read())
            {
                employee.empid = Convert.ToInt32(reader["empid"]);
                employee.Name = reader["name"].ToString();
                employee.Gender = reader["gender"].ToString();
                employee.Role = reader["role"].ToString();
                employee.Country = reader["country"].ToString();
                employee.State = reader["state"].ToString();
                employee.City = reader["city"].ToString();
                employee.Username = reader["Username"].ToString();
                employee.Password = reader["Password"].ToString();
                employee.Status = reader["status"].ToString();
            }
            return employee;
        }
        public int Create(Employee employee)
        {
            SqlConnection connection = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("AddEmploye", connection);
            connection.Open();
            int insertedrows = cmd.ExecuteNonQuery();
            return insertedrows;

        }
        public int Update(Employee employee)
        {
            int updatedRows = 0;

            using (SqlConnection connection = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateEmploye", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure; // 🔹 Ensure it's a stored procedure

                    // 🔹 Add Parameters
                    cmd.Parameters.AddWithValue("@EmpId", employee.empid);
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@Role", employee.Role);
                    cmd.Parameters.AddWithValue("@Country", employee.Country);
                    cmd.Parameters.AddWithValue("@State", employee.State);
                    cmd.Parameters.AddWithValue("@City", employee.City);
                    cmd.Parameters.AddWithValue("@Username", employee.Username);
                    cmd.Parameters.AddWithValue("@Password", employee.Password);
                    cmd.Parameters.AddWithValue("@Status", employee.Status);

                    connection.Open();
                    updatedRows = cmd.ExecuteNonQuery(); // 🔹 Execute the stored procedure
                }
            }

            return updatedRows; // Return number of rows updated
        }
        public int Delete(int id)
        {
            SqlConnection connection = new SqlConnection(conn);
            string query = string.Format("DeleteEmploye", id);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            int deletedrows = cmd.ExecuteNonQuery();
            return deletedrows;
        }
        public int ValidateUser(string username, string password)
        {
            // Default value (indicates failure)
            int result1 = -1;
            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Login", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password); // Ensure password is hashed

                    SqlParameter returnValue = new SqlParameter();
                    returnValue.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnValue);
                     

                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    result1 = Convert.ToInt32(returnValue.Value);
                    result = Convert.ToInt32(result);
                    using (SqlDataReader reader = cmd.ExecuteReader())  // 🔹 Use ExecuteReader()
                    {
                        if (reader.Read()) // If user exists
                        {
                            result = Convert.ToInt32(reader[0]); // Assuming the stored procedure returns a single value
                        }
                    }
                }
            }

            return result1; // 1 (Success), 0 (Wrong Password), -1 (Username Not Found)
        }


    }
}
