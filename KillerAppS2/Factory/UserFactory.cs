using System;
using KillerAppS2DAL;
using KillerAppS2DTO;
using KillerAppS2Interfaces;

namespace Factory
{
    public class UserFactory
    {
        public static IUserLogic<UserDTO> CreateUserDALLogic()
        {
            return new UserDAL();
        }
    }
}
