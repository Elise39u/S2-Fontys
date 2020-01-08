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
            UserDAL = UserFactory.CreateUserDALLogic();
        }

        public UserDTO Login(string email, string password)
        {
            UserDTO result = UserDAL.Login(email, password);
            return result;
        }

        public string Register(string email, string firstName, string prefix, string lastName, string password)
        {
            if (!email.Contains("@") || email == "") { return "Email doens`t contains @ or is empty"; };
            if (firstName == "") { return "Firstname is empty"; };
            if (lastName == "") { return "Lastname is empty"; };
            if (password == "") { return "Password is empty"; };

            string result = UserDAL.Register(email, firstName, prefix, lastName, password);
            return result;
        }

        public UserDTO UpdateUser(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
