using System;
using System.Collections.Generic;
using System.Text;
using KillerAppS2Interfaces;
using KillerAppS2DTO;
using Factory;

namespace KillerAppS2Logic
{
    public class TemplateLogic
    {
        private ITemplateContainer<TemplateDTO> TemplateDalContainer { get; }
        public List<TemplateDTO> TemplateDTOs { get; private set; } = new List<TemplateDTO>();

        public TemplateLogic()
        {
            TemplateDalContainer = TemplateFactory.CreateTemplateDalContainer();
        }

        public string CreateTemplate(string templateName, TemplateDTO templateDTO)
        {
            string result = TemplateDalContainer.CreateTemplate(templateName, templateDTO); 
            return result;
        }

        public List<TemplateDTO> GetAllTemplates(string templateName)
        {
            TemplateDTOs = TemplateDalContainer.GetALLTemplatesFromDB(templateName);
            return TemplateDTOs;
        }
    }
}
