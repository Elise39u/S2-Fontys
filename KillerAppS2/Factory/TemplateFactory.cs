using KillerAppS2DAL;
using KillerAppS2DTO;
using KillerAppS2Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public class TemplateFactory
    {
        public static ITemplateLogic<TemplateDTO> CreateTemplateDALLogic()
        {
            return new TemplateDAL();
        }

        public static IUserLogic<UserDTO> CreateUserDALLogic()
        {
            return new UserDAL();
        }
    }
}
