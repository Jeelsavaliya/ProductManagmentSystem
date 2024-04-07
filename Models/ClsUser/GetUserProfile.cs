using System.Data;
using System.Data.SqlClient;

namespace ProductManagmentSystem.Models.ClsUser
{
    public class GetUserProfile
    {
        public List<UserModel> UserProfile(int userid)
        {
            string ConnectionString = @"Server=LAPTOP-V175VFGH;Database=Product_Details;User Id=sa;Password=#sa123";
            SqlConnection connection = new SqlConnection(ConnectionString);

            List<UserModel> dataList = new List<UserModel>();
            string query = "SELECT * FROM [User] WHERE UserId = " + userid;
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
    }
}
