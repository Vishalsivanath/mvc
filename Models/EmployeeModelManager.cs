using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace Employe.Models
{
    public class EmployeeModelManager
    {
        string conn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        public List<Employee> GetEmployees()
        {
            SqlConnection connection = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("All_employes", connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while(reader.Read())
            {
                Employee employee = new Employee();
                employee.empid = Convert.ToInt32(reader["empid"]);
                employee.Name = reader["empname"].ToString();
                employee.Gender = reader["gender"].ToString();
                employee.Role = reader["emprole"].ToString();
                employee.Country = reader["country"].ToString();
                employee.State = reader["state"].ToString();
                employee.City = reader["city"].ToString();
                employee.Username = reader["Username"].ToString();
                employee.Password = reader["Password"].ToString();
                employee.Status = reader["status"].ToString();
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
            if(reader.Read())
            {
                employee.empid = Convert.ToInt32(reader["empid"]);
                employee.Name = reader["empname"].ToString();
                employee.Gender = reader["gender"].ToString();
                employee.Role = reader["emprole"].ToString();
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
            SqlConnection connection = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("UpdateEmploye", connection);
            connection.Open();
            int Updatedrows = cmd.ExecuteNonQuery();
            return Updatedrows;
        }
        public int Delete(int id)
        {
            SqlConnection connection = new SqlConnection(conn);
            string query = string.Format("UpdateEmploye", id);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            int deletedrows = cmd.ExecuteNonQuery();
            return deletedrows;
        }
        

    }
}