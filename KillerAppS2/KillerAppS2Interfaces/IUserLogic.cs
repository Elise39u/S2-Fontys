using KillerAppS2DTO;
using System;

namespace KillerAppS2Interfaces
{
    public interface IUserLogic<T>
    {
        string Login(string email, string password);
        string Register(string username, string email, string firstName, string LastName,
            string password);
        UserDTO UpdateUser(UserDTO user);
    }
}
