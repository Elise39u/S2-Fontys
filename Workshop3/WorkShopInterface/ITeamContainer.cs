using System;
using System.Collections.Generic;
using System.Text;

namespace WorkShopInterface
{
    public interface ITeamContainerDAL<T>
    {
        List<T> GetAllTs();
        T GetTByID(int id); 
    }
}
