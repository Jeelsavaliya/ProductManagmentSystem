using Microsoft.CodeAnalysis;
using ProductManagmentSystem.Authentication;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Web.Helpers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using ProductManagmentSystem.Authentication;

namespace ProductManagmentSystem.Models.ClsCartItem
{
    public class InsertCartItem
    {
        #region Insertr Product Into Cart Item
        public bool Insert(int id, decimal price, int userid)
        {
            string ConnectionString = @"Server=LAPTOP-V175VFGH;Database=Product_Details;User Id=sa;Password=#sa123";
            SqlConnection connection = new SqlConnection(ConnectionString);

            //Check weather Product was already in the cart 
            string query = "SELECT * FROM CartItem WHERE ProductId = " + id;

            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            var i = cmd.ExecuteScalar();
            connection.Close();
            if (i == null)
            {
                string query3 = "SELECT CartId FROM Cart WHERE CreatedBy = " + userid;
                SqlCommand cmd3 = new SqlCommand(query3, connection);
                connection.Open();
                var cid = cmd3.ExecuteScalar();
                connection.Close();

                if (cid != null)
                {

                    //if product has not exesit than insert into the cart
                    string query1 = "INSERT INTO CartItem (CartId,ProductId,Qty,UnitPrice,Amount,CreatedBy) " +
                                "VALUES(" + cid + "," + id + ", 1 ," + price + " , " + price + " , " + userid + " ) ";

                    SqlCommand cmd1 = new SqlCommand(query1, connection);
                    connection.Open();
                    var j = cmd1.ExecuteNonQuery();
                    connection.Close();

                    if (j >= 1)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }

            else
            {
                string query4 = "UPDATE CartItem SET UpdatedBy = " + userid + " WHERE ProductId = " + id;

                SqlCommand cmd4 = new SqlCommand(query4, connection);
                connection.Open();
                int m = cmd4.ExecuteNonQuery();
                connection.Close();

                if (m >= 1)
                {
                    //else, product has already in to the cart than update their Qty
                    string query2 = "UPDATE CartItem SET Qty = Qty + 1  WHERE ProductId = " + id;

                    SqlCommand cmd2 = new SqlCommand(query2, connection);
                    connection.Open();
                    var k = cmd2.ExecuteNonQuery();
                    connection.Close();

                    if (k >= 1)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else 
                    return false;
            }
        }
        #endregion

    }
}
