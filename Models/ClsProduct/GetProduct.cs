using System.Data.SqlClient;
using System.Data;

namespace ProductManagmentSystem.Models.ClsProduct
{
    public class GetProduct
    {
        public List<ProductModel> GetProductList()
        {
            string ConnectionString = @"Server=LAPTOP-V175VFGH;Database=Product_Details;User Id=sa;Password=#sa123";
            SqlConnection connection = new SqlConnection(ConnectionString);
           
            List<ProductModel> productList = new List<ProductModel>();
            string query = "SELECT * FROM Product";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            adapter.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                productList.Add(new ProductModel
                {
                    ProductId = Convert.ToInt32(dr["ProductId"]),
                    ProductImg = Convert.ToString(dr["ProductImg"]),
                    ProductName = Convert.ToString(dr["ProductName"]),
                    ProductNumber = Convert.ToString(dr["ProductNumber"]),
                    Description = Convert.ToString(dr["Description"]),
                    ProductPrice = Convert.ToInt32(dr["ProductPrice"]),
                });
            }

            return productList;
        }

        public ProductModel GetProductById(int id)
        {
            string ConnectionString = @"Server=LAPTOP-V175VFGH;Database=Product_Details;User Id=sa;Password=#sa123";
            SqlConnection connection = new SqlConnection(ConnectionString);

            ProductModel productdata = new ProductModel();
            string query = "SELECT * FROM Product WHERE ProductId =" + id;
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            adapter.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                productdata.ProductId = Convert.ToInt32(dr["ProductId"]);
                productdata.ProductImg = Convert.ToString(dr["ProductImg"]);
                productdata.ProductName = Convert.ToString(dr["ProductName"]);
                productdata.ProductNumber = Convert.ToString(dr["ProductNumber"]);
                productdata.Description = Convert.ToString(dr["Description"]);
                productdata.ProductPrice = Convert.ToInt32(dr["ProductPrice"]);
            }
            return productdata;
        }
    }
}
