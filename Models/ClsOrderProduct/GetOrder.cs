using System.Data;
using System.Data.SqlClient;

namespace ProductManagmentSystem.Models.ClsOrderProduct
{
    public class GetOrder
    {
        public List<OrderProductModel> GetOrderList(int userid)
        {
            string ConnectionString = @"Server=LAPTOP-V175VFGH;Database=Product_Details;User Id=sa;Password=#sa123";
            SqlConnection connection = new SqlConnection(ConnectionString);

            List<OrderProductModel> dataList = new List<OrderProductModel>();

            string query = "SELECT * FROM OrderProduct INNER JOIN Product ON OrderProduct.ProductId = Product.ProductId WHERE OrderProduct.CreatedBy = " + userid;

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            adapter.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                dataList.Add(new OrderProductModel
                {
                    OrderId = Convert.ToInt32(dr["OrderId"]),
                    ProductImg = Convert.ToString(dr["ProductImg"]),
                    ProductName = Convert.ToString(dr["ProductName"]),
                    Description = Convert.ToString(dr["Description"]),
                    ProductPrice = Convert.ToDecimal(dr["ProductPrice"]),
                    Qty = Convert.ToInt32(dr["Qty"]),
                    Amount = Convert.ToDecimal(dr["Amount"])
                });
            }

            return dataList;
        }
    }
}
