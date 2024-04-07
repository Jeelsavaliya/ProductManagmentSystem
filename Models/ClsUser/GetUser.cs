

using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Reflection;

namespace ProductManagmentSystem.Models.ClsUser
{
    public class GetUser
    {
        public List<UserModel> GetUserList()
        {
            string ConnectionString = @"Server=LAPTOP-V175VFGH;Database=Product_Details;User Id=sa;Password=#sa123";
            SqlConnection connection = new SqlConnection(ConnectionString);
            
            List<UserModel> dataList = new List<UserModel>();
            string query = "SELECT * FROM [User]";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            adapter.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                dataList.Add(new UserModel
                {
                    UserId = Convert.ToInt32(dr["UserId"]),
                    UserPhoto = Convert.ToString(dr["UserPhoto"]),
                    FirstName = Convert.ToString(dr["FirstName"]),
                    LastName = Convert.ToString(dr["LastName"]),
                    UserRole = Convert.ToString(dr["UserRole"]),
                    PhoneNumber = Convert.ToString(dr["PhoneNumber"]),
                    Email = Convert.ToString(dr["Email"]),
                    Password = Convert.ToString(dr["Password"]),
                    DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]),
                    //Gender = Convert.ToString(dr["Gender"]),
                    //Address = Convert.ToString(dr["Address"])

                });
            }

            return dataList;    
        }

        public UserModel GetUserById(int id)
        {
            string ConnectionString = @"Server=LAPTOP-V175VFGH;Database=Product_Details;User Id=sa;Password=#sa123";
            SqlConnection connection = new SqlConnection(ConnectionString);

            UserModel data = new UserModel();
            string query = "SELECT * FROM [User] WHERE UserId =" + id;
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            adapter.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                data.UserId = Convert.ToInt32(dr["UserId"]);
                data.UserPhoto = Convert.ToString(dr["UserPhoto"]);
                data.FirstName = Convert.ToString(dr["FirstName"]);
                data.LastName = Convert.ToString(dr["LastName"]);
                data.UserRole = Convert.ToString(dr["UserRole"]);
                data.Gender = Convert.ToString(dr["Gender"]);
                data.PhoneNumber = Convert.ToString(dr["PhoneNumber"]);
                data.DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]);
                data.Email = Convert.ToString(dr["Email"]);
                data.Password = Convert.ToString(dr["Password"]);
                data.Address = Convert.ToString(dr["Address"]);
            }

            return data;
        }
    }
}
