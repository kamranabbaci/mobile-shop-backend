using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using TechAPI.Models;

namespace TechAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        [HttpPost]
        public IActionResult SaveInventoryData([FromBody] Inventory inventoryDto)
        {
            string connectionString =
                "Server=DESKTOP-8BL3MIG\\SQLEXPRESS;Database=techDb;Trusted_Connection=True;TrustServerCertificate=True;";

            using SqlConnection connection = new SqlConnection(connectionString);

            using SqlCommand command = new SqlCommand("sp_SaveInventoryData", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ProductID", inventoryDto.ProductID);
            command.Parameters.AddWithValue("@ProductName", inventoryDto.ProductName);
            command.Parameters.AddWithValue("@StockAvailable", inventoryDto.StockAvailable);
            command.Parameters.AddWithValue("@ReorderStock", inventoryDto.ReorderStock);

            connection.Open();
            command.ExecuteNonQuery();

            return Ok(new
            {
                message = "Inventory Data Saved"
            });
        }

        [HttpGet]
        public IActionResult GetInventoryData()
        {
            string connectionString =
                "Server=DESKTOP-8BL3MIG\\SQLEXPRESS;Database=techDb;Trusted_Connection=True;TrustServerCertificate=True;";

            List<Inventory> inventoryList = new List<Inventory>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetInventoryData", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Inventory inventory = new Inventory
                        {
                            ProductID = Convert.ToInt32(reader["ProductID"]),
                            ProductName = reader["ProductName"].ToString(),
                            StockAvailable = Convert.ToInt32(reader["StockAvailable"]),
                            ReorderStock = Convert.ToInt32(reader["ReorderStock"])
                        };
                        inventoryList.Add(inventory);
                    }
                    reader.Close();
                }
            }
            return Ok(inventoryList);
        }

        [HttpPut]
        public IActionResult UpdateInventoryData([FromBody] Inventory inventoryDto)
        {
            string connectionString =
                "Server=DESKTOP-8BL3MIG\\SQLEXPRESS;Database=techDb;Trusted_Connection=True;TrustServerCertificate=True;";

            using SqlConnection connection = new SqlConnection(connectionString);

            using SqlCommand command = new SqlCommand("sp_UpdateInventoryData", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ProductID", inventoryDto.ProductID);
            command.Parameters.AddWithValue("@ProductName", inventoryDto.ProductName);
            command.Parameters.AddWithValue("@StockAvailable", inventoryDto.StockAvailable);
            command.Parameters.AddWithValue("@ReorderStock", inventoryDto.ReorderStock);

            connection.Open();
            command.ExecuteNonQuery();

            return Ok(new
            {
                message = "Inventory Data Updated"
            });
        }

        [HttpDelete("{productID}")]
        public IActionResult DeleteInventoryData(int productID)
        {
            string connectionString =
                "Server=DESKTOP-8BL3MIG\\SQLEXPRESS;Database=techDb;Trusted_Connection=True;TrustServerCertificate=True;";

            using SqlConnection connection = new SqlConnection(connectionString);

            using SqlCommand command = new SqlCommand("sp_DeleteInventoryData", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ProductID", productID);

            connection.Open();
            command.ExecuteNonQuery();

            return Ok(new
            {
                message = "Inventory Data Deleted"
            });
        }
    }
}