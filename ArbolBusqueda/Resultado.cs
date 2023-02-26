using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBusqueda
{
    public class Resultado
    {
        public Resultado(int id, int step, string name)
        { 
            Id = id;
            Step = step;
            ProcessName = name;
        }
        public int Id { get; set; }
        public int Step { get; set; }
        public string ProcessName { get; set;}
    }
}
