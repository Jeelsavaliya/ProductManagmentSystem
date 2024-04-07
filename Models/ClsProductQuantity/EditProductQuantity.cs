using System.Data.SqlClient;

namespace ProductManagmentSystem.Models.ClsProductQuantity
{
    public class EditProductQuantity
    {
        public bool Edit(int id, int qty)
        {
            string ConnectionString = @"Server=LAPTOP-V175VFGH;Database=Product_Details;User Id=sa;Password=#sa123";
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "UPDATE ProductQuantity SET Quantity = " + qty + " WHERE ProductId = " + id;

            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}
