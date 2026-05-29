using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using TechAPI.Models;

namespace TechAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly string connectionString =
            "Server=DESKTOP-8BL3MIG\\SQLEXPRESS;Database=techDb;Trusted_Connection=True;TrustServerCertificate=True;";

        [HttpGet]
        public IActionResult GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand("sp_GetCustomers", connection);

            command.CommandType = CommandType.StoredProcedure;

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                customers.Add(new Customer
                {
                    CustomerID = Convert.ToInt32(reader["CustomerID"]),
                    CustomerName = reader["CustomerName"].ToString() ?? "",
                    PhoneNumber = reader["PhoneNumber"].ToString() ?? "",
                    Email = reader["Email"].ToString() ?? "",
                    Address = reader["Address"].ToString() ?? "",
                    City = reader["City"].ToString() ?? "",
                    Status = reader["Status"].ToString() ?? "",
                    CreatedDate = Convert.ToDateTime(reader["CreatedDate"])
                });
            }

            return Ok(customers);
        }

        [HttpPost]
        public IActionResult SaveCustomer([FromBody] Customer customer)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand("sp_SaveCustomer", connection);

            command.CommandType = CommandType.StoredProcedure;

            AddCustomerParameters(command, customer, false);

            connection.Open();
            command.ExecuteNonQuery();

            return Ok(new
            {
                message = "Customer saved successfully"
            });
        }

        [HttpPut]
        public IActionResult UpdateCustomer([FromBody] Customer customer)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand("sp_UpdateCustomer", connection);

            command.CommandType = CommandType.StoredProcedure;

            AddCustomerParameters(command, customer, true);

            connection.Open();
            command.ExecuteNonQuery();

            return Ok(new
            {
                message = "Customer updated successfully"
            });
        }

        [HttpDelete("{customerID}")]
        public IActionResult DeleteCustomer(int customerID)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand("sp_DeleteCustomer", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CustomerID", customerID);

            connection.Open();
            command.ExecuteNonQuery();

            return Ok(new
            {
                message = "Customer deleted successfully"
            });
        }

        private void AddCustomerParameters(SqlCommand command, Customer customer, bool includeID)
        {
            if (includeID)
            {
                command.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
            }

            command.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
            command.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
            command.Parameters.AddWithValue("@Email", customer.Email);
            command.Parameters.AddWithValue("@Address", customer.Address);
            command.Parameters.AddWithValue("@City", customer.City);
            command.Parameters.AddWithValue("@Status", customer.Status);
        }
    }
}