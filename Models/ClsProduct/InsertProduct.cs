using ProductManagmentSystem.Models.ClsProductQuantity;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace ProductManagmentSystem.Models.ClsProduct
{
    public class InsertProduct
    {
        public bool Insert(ProductModel model,int userid)
        {
            string ConnectionString = @"Server=LAPTOP-V175VFGH;Database=Product_Details;User Id=sa;Password=#sa123";
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "INSERT INTO Product (ProductImg,ProductName,ProductNumber,Description,ProductPrice,CreatedBy) " +
                            "VALUES('" + model.ProductImg + "','" + model.ProductName + "','" + model.ProductNumber + "','" + model.Description + "'," + model.ProductPrice + "," + userid + ") SELECT SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            var i = cmd.ExecuteScalar();
            connection.Close();

            if (i != null)
            {
                string query2 = $"INSERT INTO ProductQuantity (ProductId,Quantity) VALUES({i}, 0 )";

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
