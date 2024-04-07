using System.Data.SqlClient;

namespace ProductManagmentSystem.Models.ClsCartItem
{
    public class DeleteCartItem
    {

        public bool Delete(int id,int userid)
        {
            string ConnectionString = @"Server=LAPTOP-V175VFGH;Database=Product_Details;User Id=sa;Password=#sa123";
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "DELETE FROM CartItem WHERE CartItemId = " + id;
            
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            var i = cmd.ExecuteNonQuery();
            connection.Close();

            if(i>=1)
                return true;
            else
                return false;
        }
    }
}
