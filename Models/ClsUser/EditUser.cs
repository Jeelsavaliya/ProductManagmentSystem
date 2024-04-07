using System.Data.SqlClient;

namespace ProductManagmentSystem.Models.ClsUser
{
    public class EditUser
    {
        public bool Edit(UserModel model)
        {
            string ConnectionString = @"Server=LAPTOP-V175VFGH;Database=Product_Details;User Id=sa;Password=#sa123";
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "UPDATE [User] SET UserPhoto = '"+model.UserPhoto+"', FirstName = '" + model.FirstName + "', LastName ='" + model.LastName + "', UserRole = '" + model.UserRole + "', PhoneNumber = '" + model.PhoneNumber + "', Email = '" + model.Email + "', Password = '" + model.Password + "', DateOfBirth = '" + model.DateOfBirth.ToString("yyyy-MM-dd") + "', Gender = '" + model.Gender + "', Address = '" + model.Address + "' WHERE UserId = "+ model.UserId;
               
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
