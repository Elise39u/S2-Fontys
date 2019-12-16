using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using KillerAppS2DTO;
using KillerAppS2DAL;
using KillerAppS2Logic;
using KillerAppS2Tests;
using Factory;
using KillerAppS2Interfaces;
using System.Linq;

namespace KillerAppS2Tests
{
    public class TemplateLogicTest
    {
        public ITemplateContainer<TemplateDTO> TemplateDalContainer;
        public ITemplateLogic<TemplateDTO> TemplateDalLogic;

        [SetUp]
        public void Setup()
        {
            TemplateDalContainer = TemplateFactory.CreateTemplateDalContainer();
            TemplateDalLogic = TemplateFactory.CreateTemplateDALLogic();
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
    }
}
