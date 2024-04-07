using System.Data;
using System.Data.SqlClient;

namespace ProductManagmentSystem.Models.ClsCartItem
{
    public class GetCartItem
    {
        public List<CartItemModel> GetCartItemList(int userid)
        {
            string ConnectionString = @"Server=LAPTOP-V175VFGH;Database=Product_Details;User Id=sa;Password=#sa123";
            SqlConnection connection = new SqlConnection(ConnectionString);

            List<CartItemModel> dataList = new List<CartItemModel>();
            string query = "SELECT * FROM CartItem INNER JOIN Product ON CartItem.ProductId=Product.ProductId WHERE CartItem.CreatedBy = " + userid ;
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            adapter.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                dataList.Add(new CartItemModel
                {
                    CartItemId = Convert.ToInt32(dr["CartItemId"]),
                    ProductId = Convert.ToInt32(dr["ProductId"]),
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
