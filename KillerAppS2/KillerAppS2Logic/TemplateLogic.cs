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
        private ITemplateContainer<TemplateDTO> TemplateDal { get; }
        public List<TemplateDTO> TemplateDTOs { get; private set; } = new List<TemplateDTO>();

        public TemplateLogic()
        {
            TemplateDal = TemplateFactory.CreateTemplateDalContainer();
        }

        public List<TemplateDTO> GetAllTemplates(string templateName)
        {
            TemplateDTOs = TemplateDal.GetALLTemplatesFromDB(templateName);
            return TemplateDTOs;
        }
    }
}
