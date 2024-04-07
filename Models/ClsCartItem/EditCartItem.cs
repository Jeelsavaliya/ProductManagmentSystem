using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ProductManagmentSystem.Models.ClsCartItem
{
    public class EditCartItem
    {
        public bool Edit(int id, int qty, int userid)
        {
            string ConnectionString = @"Server=LAPTOP-V175VFGH;Database=Product_Details;User Id=sa;Password=#sa123";
            SqlConnection connection = new SqlConnection(ConnectionString);
            //string query = "UPDATE CartItem SET Qty = " + qty + " WHERE ProductId = " + id;
            string query = "UPDATE CartItem SET UpdatedBy = " + userid + " WHERE ProductId = " + id;

            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i >= 1)
            {
                string query1 = "UPDATE CartItem SET Qty = " + qty + " WHERE ProductId = " + id;
                SqlCommand cmd1 = new SqlCommand(query1, connection);
                connection.Open();
                int j = cmd.ExecuteNonQuery();
                connection.Close();
                if (j >= 1)
                    return true;
                else
                    return false; 

                /*string query1 = "UPDATE Cart SET UpdatedBy = " + userid + " WHERE ProductId = " + id;
                SqlCommand cmd1 = new SqlCommand(query1, connection);
                connection.Open();
                int j = cmd.ExecuteNonQuery();
                connection.Close();
                if (j >= 1)
                    return true;
                else
                    return false;*/
                return true;
            }
            else
                return false;
        }

    }
}
