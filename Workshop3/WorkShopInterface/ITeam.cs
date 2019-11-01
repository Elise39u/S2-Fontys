using System;
using System.Collections.Generic;
using System.Text;

namespace WorkShopInterface
{
    public interface ITeam<T>
    {
        T UpdateTeam(T t);
    }
}
