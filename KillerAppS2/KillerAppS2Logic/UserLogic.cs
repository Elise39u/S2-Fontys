using KillerAppS2DTO;
using KillerAppS2Interfaces;
using Factory;
using System;

namespace KillerAppS2Logic
{
    public class UserLogic
    {
        private IUserLogic<UserDTO> UserDAL { get; }

        public UserLogic()
        {
            UserDAL = UserFactory.CreateUserDAL();
        }

        public UserDTO Login(string email, string password)
        {
            UserDTO result = UserDAL.Login(email, password);
            return result;
        }

        public string Register(UserDTO user)
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
