using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using TechAPI.Models;

namespace TechAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly string connectionString =
            "Server=DESKTOP-8BL3MIG\\SQLEXPRESS;Database=techDb;Trusted_Connection=True;TrustServerCertificate=True;";

        [HttpGet]
        public IActionResult GetProducts()
        {
            List<Product> products = new List<Product>();

            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand("sp_GetProducts", connection);

            command.CommandType = CommandType.StoredProcedure;

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                products.Add(new Product
                {
                    ProductID = Convert.ToInt32(reader["ProductID"]),
                    ProductName = reader["ProductName"].ToString() ?? "",
                    Brand = reader["Brand"].ToString() ?? "",
                    Category = reader["Category"].ToString() ?? "",
                    ModelNumber = reader["ModelNumber"].ToString() ?? "",
                    PurchasePrice = Convert.ToDecimal(reader["PurchasePrice"]),
                    SellingPrice = Convert.ToDecimal(reader["SellingPrice"]),
                    Quantity = Convert.ToInt32(reader["Quantity"]),
                    RAM = reader["RAM"].ToString() ?? "",
                    Storage = reader["Storage"].ToString() ?? "",
                    Color = reader["Color"].ToString() ?? "",
                    Warranty = reader["Warranty"].ToString() ?? "",
                    Description = reader["Description"].ToString() ?? "",
                    Status = reader["Status"].ToString() ?? ""
                });
            }

            return Ok(products);
        }

        [HttpPost]
        public IActionResult SaveProduct([FromBody] Product product)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand("sp_SaveProduct", connection);

            command.CommandType = CommandType.StoredProcedure;

            AddProductParameters(command, product, false);

            connection.Open();
            command.ExecuteNonQuery();

            return Ok(new { message = "Product saved successfully" });
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand("sp_UpdateProduct", connection);

            command.CommandType = CommandType.StoredProcedure;

            AddProductParameters(command, product, true);

            connection.Open();
            command.ExecuteNonQuery();

            return Ok(new { message = "Product updated successfully" });
        }

        [HttpDelete("{productID}")]
        public IActionResult DeleteProduct(int productID)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand("sp_DeleteProduct", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ProductID", productID);

            connection.Open();
            command.ExecuteNonQuery();

            return Ok(new { message = "Product deleted successfully" });
        }

        private void AddProductParameters(SqlCommand command, Product product, bool includeID)
        {
            if (includeID)
            {
                command.Parameters.AddWithValue("@ProductID", product.ProductID);
            }

            command.Parameters.AddWithValue("@ProductName", product.ProductName);
            command.Parameters.AddWithValue("@Brand", product.Brand);
            command.Parameters.AddWithValue("@Category", product.Category);
            command.Parameters.AddWithValue("@ModelNumber", product.ModelNumber);
            command.Parameters.AddWithValue("@PurchasePrice", product.PurchasePrice);
            command.Parameters.AddWithValue("@SellingPrice", product.SellingPrice);
            command.Parameters.AddWithValue("@Quantity", product.Quantity);
            command.Parameters.AddWithValue("@RAM", product.RAM);
            command.Parameters.AddWithValue("@Storage", product.Storage);
            command.Parameters.AddWithValue("@Color", product.Color);
            command.Parameters.AddWithValue("@Warranty", product.Warranty);
            command.Parameters.AddWithValue("@Description", product.Description);
            command.Parameters.AddWithValue("@Status", product.Status);
        }
    }
}