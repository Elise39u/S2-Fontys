﻿using System;
using System.Collections.Generic;
using System.Text;

namespace KillerAppS2Interfaces
{
    public interface ITemplateContainer<T>
    {
        T GetATemplateById();
        List<T> GetALLTemplatesFromDB(string templateName);
        T DeleteTemplate();
        string CreateTemplate(string templateName, T templateDTO);
    }
}