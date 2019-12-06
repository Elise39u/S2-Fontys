using KillerAppS2DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace KillerAppS2Interfaces
{
    public interface IUserContainer<T>
    {
        string CreateUser(string username, string email, string firstName, string LastName,
            string password);
        string DeleteUser(int id);
        UserDTO GetUserByID(int id);
        List<UserDTO> GetAllUsers();
    }
}
