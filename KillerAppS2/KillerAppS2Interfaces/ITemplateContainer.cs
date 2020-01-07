using System;
using System.Collections.Generic;
using System.Text;

namespace KillerAppS2Interfaces
{
    public interface ITemplateContainer<T>
    {
        T GetATemplateById(int templateId, string templateName);
        List<T> GetALLTemplatesFromDB(string templateName);
        string DeleteTemplate(string templateName, int templateID);
        string CreateTemplate(string templateName, T templateDTO);
    }
}
