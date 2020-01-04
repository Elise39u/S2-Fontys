using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using KillerAppS2DTO;
using KillerAppS2DAL;
using KillerAppS2Logic;
using KillerAppS2Tests;
using KillerAppS2;
using Factory;
using KillerAppS2Interfaces;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using KillerAppS2.Models;
using Microsoft.AspNetCore.Http;

namespace KillerAppS2Tests
{
    public class TemplateLogicTest
    {
        public ITemplateContainer<TemplateDTO> TemplateDalContainer;
        public ITemplateLogic<TemplateDTO> TemplateDalLogic;
        public TemplateLogic TemplateLogic;
        
        [SetUp]
        public void Setup()
        {
            TemplateDalContainer = TemplateFactory.CreateTemplateDalContainer();
            TemplateDalLogic = TemplateFactory.CreateTemplateDALLogic();
            TemplateLogic = new TemplateLogic();
        }

        [Test]
        public void Can_TemplateFactory_Be_Created_With_ITemplateContainer()
        {
            Assert.IsNotNull(TemplateDalContainer, "TemplateDAL failed to be constructed");
        }

        [Test]
        public void Can_TemplateFactory_Be_Created_With_ITemplateLogic()
        {
            Assert.IsNotNull(TemplateDalLogic, "TemplateDAL failed to be constructed");
        }

        [Test]
        public void Get_Locations_From_DataBase()
        {
            List<TemplateDTO> templateDTOs = TemplateDalContainer.GetALLTemplatesFromDB("Location");
            Assert.AreEqual(0, templateDTOs.Count(), "There are records found");
        }

        [Test]
        public void Create_Location_Test()
        {
            TemplateDTO Locaiton = new TemplateDTO
            {
                Name = "A new Beginning?",
                Title = "A doom start",
                Story = "You wake up from a nasty new years eve",
                AreaId = 1,
                FotoUrl = "~/Image/Background"
            };

            string result = TemplateLogic.CreateTemplate("Location", Locaiton);
            Assert.AreEqual("Insert succesfull", result);
        }
    }
}
