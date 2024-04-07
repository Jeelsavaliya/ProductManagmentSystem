using System.Data.SqlClient;

namespace ProductManagmentSystem.Models.ClsProduct
{
    public class EditProduct
    {
        public bool Edit(ProductModel model)
        {
            string ConnectionString = @"Server=LAPTOP-V175VFGH;Database=Product_Details;User Id=sa;Password=#sa123";
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "UPDATE Product SET ProductImg = '"+model.ProductImg+"', ProductName = '" + model.ProductName + "', ProductNumber ='" + model.ProductNumber + "', Description = '" + model.Description + "', ProductPrice = '" + model.ProductPrice + "' WHERE ProductId = " + model.ProductId;

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
