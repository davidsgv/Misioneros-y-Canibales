using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBusqueda
{
    public interface IProcess<T>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public T Exec(T state);
        //public bool ValidateExec(T state);
    }
}
