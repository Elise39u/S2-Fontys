using KillerAppS2DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace KillerAppS2Interfaces
{
    public interface ITemplateLogic<T>
    {
        string UpdateTemplate(TemplateDTO templateDTO, string templateName);
    }
}
