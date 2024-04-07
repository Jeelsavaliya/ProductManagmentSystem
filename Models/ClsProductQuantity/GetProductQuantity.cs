using System.Data.SqlClient;
using System.Data;

namespace ProductManagmentSystem.Models.ClsProductQuantity
{
    public class GetProductQuantity
    {
        

        public List<ProductQuantityModel> GetProductQuantityList()
        {
            string ConnectionString = @"Server=LAPTOP-V175VFGH;Database=Product_Details;User Id=sa;Password=#sa123";
            SqlConnection connection = new SqlConnection(ConnectionString);

            List<ProductQuantityModel> dataList = new List<ProductQuantityModel>();
            string query = "SELECT * FROM Product INNER JOIN ProductQuantity ON ProductQuantity.ProductID=Product.ProductID";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            adapter.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                dataList.Add(new ProductQuantityModel
                {
                    ProductQuantityId = Convert.ToInt32(dr["ProductQuantityId"]),
                    ProductId = Convert.ToInt32(dr["ProductId"]),
                    ProductName = Convert.ToString(dr["ProductName"]),
                    Quantity = Convert.ToInt32(dr["Quantity"])
                });
            }

            return dataList;
        }

       /* public ProductQuantityModel GetProductQtyById(int id)
        {
            string ConnectionString = @"Server=LAPTOP-V175VFGH;Database=Product_Details;User Id=sa;Password=#sa123";
            SqlConnection connection = new SqlConnection(ConnectionString);

            ProductQuantityModel data = new ProductQuantityModel();
            string query = "SELECT * FROM Product WHERE UserId =" + id;
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            adapter.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                data.ProductQuantityId = Convert.ToInt32(dr["ProductQuantityId"]);
                data.ProductId = Convert.ToInt32(dr["ProductId"]);
                data.Quantity = Convert.ToInt32(dr["Quantity"]);
            }

            return data;
        }*/


    }
}
