using KillerAppS2DTO;
using KillerAppS2Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace KillerAppS2DAL
{
    public class UserDAL : IUserLogic<UserDTO>, IUserContainer<UserDTO>
    {
        static string connectionString = "Data Source=mssql.fhict.local;Initial Catalog=dbi403879;Persist Security Info=True;User ID=dbi403879;Password=BigFish";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd;

        public string CreateUser(string username, string email, string firstName, string LastName, string password)
        {
            throw new NotImplementedException();
        }

        public string DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserByID(int id)
        {
            throw new NotImplementedException();
        }

        public UserDTO Login(string email, string password)
        {
            UserDTO user = new UserDTO();
            string Query = $"SELECT * FROM IVPJustin_User WHERE Email='{email}' AND Password='{password}'";

            conn.Open();
            cmd = new SqlCommand(Query, conn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    user = new UserDTO
                    {
                        UserID = Convert.ToInt32(0),
                        Username = reader.GetString(1) + " " + reader.GetString(2) +  
                                        reader.GetString(3),
                        Email = reader.GetString(4),
                        Attack = reader.GetInt32(6),
                        Defence = reader.GetInt32(7),
                        CurHP = reader.GetInt32(8),
                        MaxHP = reader.GetInt32(9)
                    };
                }
            }
            conn.Close();
            return user;
        }

        public string Register(string username, string email, string firstName, string LastName, string password)
        {
            throw new NotImplementedException();
        }

        public UserDTO UpdateUser(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
