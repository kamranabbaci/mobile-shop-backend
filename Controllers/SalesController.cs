using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using TechAPI.Models;

namespace TechAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly string connectionString =
            "Server=DESKTOP-8BL3MIG\\SQLEXPRESS;Database=techDb;Trusted_Connection=True;TrustServerCertificate=True;";

        [HttpGet]
        public IActionResult GetSales()
        {
            List<Sale> sales = new List<Sale>();

            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand("sp_GetSales", connection);

            command.CommandType = CommandType.StoredProcedure;

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                sales.Add(new Sale
                {
                    SaleID = Convert.ToInt32(reader["SaleID"]),

                    CustomerID = Convert.ToInt32(reader["CustomerID"]),
                    CustomerName = reader["CustomerName"].ToString() ?? "",

                    ProductID = Convert.ToInt32(reader["ProductID"]),
                    ProductName = reader["ProductName"].ToString() ?? "",

                    Quantity = Convert.ToInt32(reader["Quantity"]),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                    Discount = Convert.ToDecimal(reader["Discount"]),
                    TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                    SaleDate = Convert.ToDateTime(reader["SaleDate"])
                });
            }

            return Ok(sales);
        }

        [HttpPost]
        public IActionResult SaveSale([FromBody] Sale sale)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(connectionString);
                using SqlCommand command = new SqlCommand("sp_SaveSale", connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@CustomerID", sale.CustomerID);
                command.Parameters.AddWithValue("@ProductID", sale.ProductID);
                command.Parameters.AddWithValue("@Quantity", sale.Quantity);
                command.Parameters.AddWithValue("@UnitPrice", sale.UnitPrice);
                command.Parameters.AddWithValue("@Discount", sale.Discount);

                connection.Open();
                command.ExecuteNonQuery();

                return Ok(new
                {
                    message = "Sale saved successfully"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }


        [HttpGet("CustomerHistory/{customerID}")]
        public IActionResult GetCustomerPurchaseHistory(int customerID)
        {
            List<Sale> sales = new List<Sale>();

            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand("sp_GetCustomerPurchaseHistory", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CustomerID", customerID);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                sales.Add(new Sale
                {
                    SaleID = Convert.ToInt32(reader["SaleID"]),
                    CustomerID = Convert.ToInt32(reader["CustomerID"]),
                    CustomerName = reader["CustomerName"].ToString() ?? "",
                    ProductID = Convert.ToInt32(reader["ProductID"]),
                    ProductName = reader["ProductName"].ToString() ?? "",
                    Quantity = Convert.ToInt32(reader["Quantity"]),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                    Discount = Convert.ToDecimal(reader["Discount"]),
                    TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                    SaleDate = Convert.ToDateTime(reader["SaleDate"])
                });
            }

            return Ok(sales);
        }


    }
}