using KillerAppS2DTO;
using System;

namespace KillerAppS2Interfaces
{
    public interface IUserLogic<T>
    {
        UserDTO Login(string email, string password);
        string Register(string email, string firstName, string prefix, string lastName, string password);
        UserDTO UpdateUser(UserDTO user);
    }
}
