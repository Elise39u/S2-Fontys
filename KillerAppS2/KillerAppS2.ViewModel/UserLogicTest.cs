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
            UserDAL = UserFactory.CreateUserDAL();
        }

        [Test]
        public void Can_UserFactory_Be_Constructed()
        {
            Assert.IsNotNull(UserDAL, "UserDal Failed to be constructed");
        }

        [Test]
        public void Login_With_Vaild_Information()
        {
            UserDTO user = UserDAL.Login("justin555@live.nl", "Dropzone8");

            Assert.IsNotNull(user, $"No User found with email Justin555@live.nl and  password Dropzone8");
            Assert.AreEqual("justin555@live.nl", user.Email);
            Assert.AreEqual(user.Username, "Justin Van de Laar");
        }

        [Test]
        public void Login_With_Empty_Information()
        {
            UserDTO user = UserDAL.Login(" ", " ");

            Assert.AreEqual(user.Email, null, "An email is found");
            Assert.AreEqual(user.Username, null, "An Name has been found");
        }

        [Test]
        public void Login_With_InVaild_Information()
        {
            UserDTO user = UserDAL.Login("Justin555", "Dropzone8");

            Assert.AreEqual(user.Email,  null, "An email is found");
            Assert.AreEqual(user.Username,  null, "An Name has been found");
        }

        [Test]
        public void Register_With_Vaild_Information()
        {
            string result = UserDAL.Register("justin555@live.nl", "Justin", "Van de ", "Laar", "Dropzone8");
            
            Assert.AreEqual("Insert Succesfull", result, "User not created");
        }

        [Test]
        public void Register_With_Empty_Information()
        {
            string result = UserDAL.Register("", "", "", "", "Dropzone8");
            
            Assert.AreEqual("An error occurerd", result, "User Created");
        }

        [Test]
        public void Register_With_InVaild_Information()
        {
            string result = UserDAL.Register(2.ToString(), "", "", "", "Dropzone8" + 5);

            Assert.AreEqual("An error occurerd", result, "User Created");
        }

        [Test]
        public void Register_User_And_Login_With_The_New_User()
        {
            string result = UserDAL.Register("test@test.nl", "Justin", "Van de ", "Laar", "BigFish33");

            UserDTO user = UserDAL.Login("test@test.nl", "BigFish33");

            Assert.AreEqual("Insert Succesfull", result, "User not created");
            Assert.IsNotNull(user, $"No User found with email test@test.nl and  password BigFish33");
            Assert.AreEqual(user.Email, "test@test.nl", "test@test.nl not found in database");
            Assert.AreEqual(user.Username, "Justin Van de Laar", $"Username Justin van de Laar is not the same as {user.Username}");
        }
    }
}
