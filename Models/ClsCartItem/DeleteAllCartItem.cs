using System.Data.SqlClient;

namespace ProductManagmentSystem.Models.ClsCartItem
{
    public class DeleteAllCartItem
    {
        public bool Delete(int userid)
        {
            string ConnectionString = @"Server=LAPTOP-V175VFGH;Database=Product_Details;User Id=sa;Password=#sa123";
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "DELETE FROM CartItem WHERE CreatedBy = " + userid;
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
