using System.Data.SqlClient;

namespace ProductManagmentSystem.Models.ClsOrderProduct
{
    public class InsertOrder
    {
        public bool Insert(int userid)
        {
            string ConnectionString = @"Server=LAPTOP-V175VFGH;Database=Product_Details;User Id=sa;Password=#sa123";
            SqlConnection connection = new SqlConnection(ConnectionString);

            string query = "SELECT * FROM Cart WHERE CreatedBy = " + userid;

            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            var i = cmd.ExecuteScalar();
            connection.Close();

            if (i == null)
            {
                string query1 = "INSERT INTO Cart (TotalPrice,CreatedBy) " +
                    "VALUES(0 , " + userid + ")";
                SqlCommand cmd1 = new SqlCommand(query1, connection);
                connection.Open();
                int j = cmd1.ExecuteNonQuery();
                connection.Close();

                if (j >= 1)
                    return true;
                else
                    return false;
            }
            else
            {
                string query2 = "SELECT CartItemId FROM CartItem WHERE CreatedBy = " + userid;
                SqlCommand cmd2 = new SqlCommand(query2, connection);
                connection.Open();
                var cid = cmd2.ExecuteScalar();
                connection.Close();

                if (cid != null)
                {
                    string query3 = "UPDATE CartItem SET Amount = UnitPrice * Qty WHERE CreatedBy = " + userid;
                    SqlCommand cmd3 = new SqlCommand(query3, connection);
                    connection.Open();
                    int price = cmd3.ExecuteNonQuery();
                    connection.Close();

                    if (price >= 1)
                    {
                        string query4 = "SELECT SUM(Amount) FROM CartItem WHERE CreatedBy = " + userid;
                        SqlCommand cmd4 = new SqlCommand(query4, connection);
                        connection.Open();
                        var tamount = cmd4.ExecuteScalar();
                        connection.Close();


                        string query5 = "UPDATE Cart SET TotalPrice = " + tamount + " WHERE CreatedBy = " + userid;
                        SqlCommand cmd5 = new SqlCommand(query5, connection);
                        connection.Open();
                        int x = cmd5.ExecuteNonQuery();
                        connection.Close();

                        if (x >= 1)
                        {
                            string query6 = "INSERT INTO OrderProduct (ProductId,Qty,UnitPrice,Amount,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt) " +
                                            "SELECT ProductId, Qty, UnitPrice, Amount, CreatedBy, CreatedAt, UpdatedBy, UpdatedAt FROM CartItem " +
                                            "WHERE CreatedBy = " + userid;
                            SqlCommand cmd6 = new SqlCommand(query6, connection);
                            connection.Open();
                            int y = cmd6.ExecuteNonQuery();
                            connection.Close();

                            if (y >= 1)
                            {

                                string query7 = "DELETE FROM CartItem WHERE CreatedBy = " + userid;
                                SqlCommand cmd7 = new SqlCommand(query7, connection);
                                connection.Open();
                                int j = cmd7.ExecuteNonQuery();
                                connection.Close();
                                if (j >= 1)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                                return false;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
        }
    }
}
          
