using System;
using System.Collections.Generic;
using System.Text;

namespace KillerAppS2Interfaces
{
    public interface ITemplateContainer<T>
    {
        T GetATemplateById();
        T GetALLTemplatesFromDB();
        T DeleteTemplate();
    }
}
