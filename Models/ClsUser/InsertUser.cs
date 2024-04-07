using System.Data.SqlClient;

namespace ProductManagmentSystem.Models.ClsUser
{
    public class InsertUser
    {
        public bool Insert(UserModel model)
        {
            string ConnectionString = @"Server=LAPTOP-V175VFGH;Database=Product_Details;User Id=sa;Password=#sa123";
            SqlConnection connection = new SqlConnection(ConnectionString);

            string query = "INSERT INTO [User] (UserPhoto,FirstName,LastName,UserRole,PhoneNumber,Email,Password,DateOfBirth,Gender,Address) " +
                "VALUES('" + model.UserPhoto + "','" + model.FirstName + "','" + model.LastName + "','" + 
                model.UserRole + "','" + model.PhoneNumber + "','" + model.Email + "','" + model.Password + "','" + 
                model.DateOfBirth.ToString("yyyy-MM-dd") + "','" + model.Gender + "','" + model.Address + "')";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

    }
}
