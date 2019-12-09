using NUnit.Framework;
using System;
using KillerAppS2Logic;
using System.Collections.Generic;
using System.Text;
using KillerAppS2Interfaces;
using KillerAppS2DTO;
using Factory;

namespace KillerAppS2.ViewModel
{
    public class UserLogicTest
    {
        public IUserLogic<UserDTO> UserDAL;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Can_UserFactory_Be_Constructed()
        {
            UserDAL = UserFactory.CreateUserDAL();

            Assert.IsNotNull(UserDAL, "UserDal Failed to be constructed");
        }

        [Test]
        public void Login_With_Vaild_Information()
        {
            UserDAL = UserFactory.CreateUserDAL();

            UserDTO user = UserDAL.Login("Justin555@live.nl", "Dropzone8");

            Assert.IsNotNull(user, $"No User found with email Justin555@live.nl and  password Dropzone8");
            Assert.AreEqual("Justin555@Live.nl", user.Email);
            Assert.AreEqual(user.Username, "Justin van de Laar");
        }

        [Test]
        public void Login_With_Empty_Information()
        {
            UserDAL = UserFactory.CreateUserDAL();

            UserDTO user = UserDAL.Login(" ", " ");

            Assert.AreEqual(user.Email, null, "An email is found");
            Assert.AreEqual(user.Username, null, "An Name has been found");
        }

        [Test]
        public void Login_With_InVaild_Information()
        {
            UserDAL = UserFactory.CreateUserDAL();

            UserDTO user = UserDAL.Login("Justin555", "Dropzone8");

            Assert.AreEqual(user.Email,  null, "An email is found");
            Assert.AreEqual(user.Username,  null, "An Name has been found");
        }
    }
}
