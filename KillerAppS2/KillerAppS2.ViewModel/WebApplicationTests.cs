using NUnit.Framework;
using KillerAppS2.Models;
using KillerAppS2.Controllers;
using Microsoft.AspNetCore.Mvc;
using KillerAppS2;

namespace Tests
{
    public class WebApplicationTests
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