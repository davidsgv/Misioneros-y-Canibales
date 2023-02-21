using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBusqueda
{
    public interface ICondition<T>
    {
        public bool IsStateValid(T state);
    }
}
