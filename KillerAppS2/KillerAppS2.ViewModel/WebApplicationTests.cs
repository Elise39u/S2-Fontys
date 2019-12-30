using NUnit.Framework;
using KillerAppS2.Models;
using KillerAppS2.Controllers;
using Microsoft.AspNetCore.Mvc;
using KillerAppS2;
using KillerAppS2Interfaces;
using KillerAppS2DTO;
using Factory;

namespace Tests
{
    public class WebApplicationTests
    {
        /*
         * Test crashes due to 2 so far known issues
         
         1. HttpContext is null --> Causing a system Null reference
         This due to a UX choice. Called the Method --> GetUsername in the TemplateController 
         This method present the username on screen for the user but Httpcontext session is not known in the test area
         Due to Httpcontext needs ASP.Net to run its causes the system reference null exception.
         The research suggets that we need to create a mockup van the session classes in order to get this to work. 
         On the other side the research also says it a time consumeing and hard idea 

         2. TempData Is null --> Causes a system Null reference 
         When we comment the line with GetUserName the following error occuer 
         A system null reference error on the line with tempdata. This choice is made so we can pas the templatename from view to view.
         Due to same issue related with Httpcontext we get the same issue
         The research suggets that we need to create a mockup van the session classes in order to get this to work. 
         On the other side the research also says it a time consuming and hard idea 

         Research suggets that the idea is hard to implent en time consuming
         So for now i leave the test broken but make a not of the issues so perhaps i can look for a better soloution in the future
         */
        public IUserLogic<UserDTO> UserDAL;
        public UserDTO user;

        [SetUp]
        public void Setup()
        {
            UserDAL = UserFactory.CreateUserDALLogic();

            user = UserDAL.Login("Justin555@Live.nl", "Dropzone8");
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

        [Test]
        public void Can_TemplateName_Be_Set_To_Location()
        { 
            TemplateController templateController = new TemplateController();
            Assert.AreEqual("", templateController.TemplateName, "Template name not initlized");

            templateController.SetTemplateNameToLocation();
            Assert.AreEqual("Location", templateController.TemplateName, $"Template name is not been updated, value: {templateController.TemplateName}");
        }

        [Test]
        public void Can_TemplateName_Be_Set_To_Npc()
        {
            TemplateController templateController = new TemplateController();
            Assert.AreEqual("", templateController.TemplateName, "Template name not initlized");

            templateController.SetTemplateNameToNpc();
            Assert.AreEqual("NPC", templateController.TemplateName, $"Template name is not been updated, value: {templateController.TemplateName}");
        }

        [Test]
        public void Can_TemplateName_Be_Set_To_Monster()
        {
            TemplateController templateController = new TemplateController();
            Assert.AreEqual("", templateController.TemplateName, "Template name not initlized");

            templateController.SetTemplateNameToMonster();
            Assert.AreEqual("Monster", templateController.TemplateName, $"Template name is not been updated, value: {templateController.TemplateName}");
        }

        [Test]
        public void Can_TemplateName_Be_Set_To_Item()
        {
            TemplateController templateController = new TemplateController();
            Assert.AreEqual("", templateController.TemplateName, "Template name not initlized");

            templateController.SetTemplateNameToItem();
            Assert.AreEqual("Item", templateController.TemplateName, $"Template name is not been updated, value: {templateController.TemplateName}");
        }

        [Test]
        public void Can_TemplateName_Be_Set_To_Shop()
        {
            TemplateController templateController = new TemplateController();
            Assert.AreEqual("", templateController.TemplateName, "Template name not initlized");

            templateController.SetTemplateNameToShop();
            Assert.AreEqual("Shop", templateController.TemplateName, $"Template name is not been updated, value: {templateController.TemplateName}");
        }

        [Test]
        public void Can_TemplateName_Be_Set_To_Area()
        {
            TemplateController templateController = new TemplateController();
            Assert.AreEqual("", templateController.TemplateName, "Template name not initlized");

            templateController.SetTemplateNameToArea();
            Assert.AreEqual("area", templateController.TemplateName, $"Template name is not been updated, value: {templateController.TemplateName}");
        }
    }
}