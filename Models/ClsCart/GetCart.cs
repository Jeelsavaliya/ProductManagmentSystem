using System.Data;
using System.Data.SqlClient;

namespace ProductManagmentSystem.Models.ClsCart
{
    public class GetCart
    {
        public List<CartModel> GetCartist(int userid)
        {
            string ConnectionString = @"Server=LAPTOP-V175VFGH;Database=Product_Details;User Id=sa;Password=#sa123";
            SqlConnection connection = new SqlConnection(ConnectionString);

            List<CartModel> dataList = new List<CartModel>();


            string query = "SELECT * FROM CartItem " +
            "INNER JOIN Cart ON Cart.CreatedBy = CartItem.CreatedBy " +
            "INNER JOIN Product ON CartItem.ProductId = Product.ProductId " +
            "WHERE Cart.CreatedBy = " + userid;
            /*"INNER JOIN Product ON CartItem.ProductId = Product.ProductId";*/
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            adapter.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                dataList.Add(new CartModel
                {
                    CartId = Convert.ToInt32(dr["CartId"]),
                    ProductImg = Convert.ToString(dr["ProductImg"]),
                    ProductName = Convert.ToString(dr["ProductName"]),
                    Description = Convert.ToString(dr["Description"]),
                    ProductPrice = Convert.ToDecimal(dr["ProductPrice"]),
                    Qty = Convert.ToInt32(dr["Qty"]),
                    Amount = Convert.ToDecimal(dr["Amount"]),
                });
            }

            return dataList;

        }
    }
}
