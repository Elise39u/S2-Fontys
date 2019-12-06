using NUnit.Framework;
using KillerAppS2.Models;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Can_UserViewModel_Be_Constructedl()
        {
            UserViewModel userViewModel = new UserViewModel();

            Assert.IsNotNull(userViewModel, "Usermodel failed to be constructed");
        }

        [Test]
        public void Can_UserViewModel_Be_Constructedl_WithAEmail_WithAPassword()
        {
            UserViewModel userViewModel = new UserViewModel("Justin555@live.nl", "Test245");

            Assert.IsNotNull(userViewModel, "Usermodel failed to be constructed with a email and password");
            Assert.AreEqual(userViewModel.Email, "Justin555@live.nl", "Email does not match");
            Assert.AreEqual(userViewModel.Password, "Test245", "Password does not match");
        }
    }
}