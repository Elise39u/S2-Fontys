using KillerAppS2DTO;
using KillerAppS2Interfaces;
using System;
using System.Collections.Generic;

namespace KillerAppS2DAL
{
    public class UserDAL : IUserLogic<UserDTO>, IUserContainer<UserDTO>
    {
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

        public string Login(string email, string password)
        {
            throw new NotImplementedException();
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
