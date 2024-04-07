using System.Data.SqlClient;

namespace ProductManagmentSystem.Models.ClsProduct
{
    public class DeleteProduct
    {
        public bool Delete(int id, int userid)
        {
            string ConnectionString = @"Server=LAPTOP-V175VFGH;Database=Product_Details;User Id=sa;Password=#sa123";
            SqlConnection connection = new SqlConnection(ConnectionString);
            //First of Product was where ProducId is forign key in ProductQuantity Tabele 
            string query = "DELETE FROM ProductQuantity WHERE ProductId = " + id;
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            var i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i >= 1)
            {
                //And then delete ProductQuantity after that delete Product in Product Table
                //If we not do that and first delete product and then delete quantitty,then error will occure because of forign key in quantity table
                string query2 = "DELETE FROM Product WHERE ProductId = " + id;

                SqlCommand cmd2 = new SqlCommand(query2, connection);
                connection.Open();
                int k = cmd2.ExecuteNonQuery();
                connection.Close();
                if (k >= 1)
                {
                    return true;
                }
                return false;
            }
            else
                return false;
        }
    }
}
