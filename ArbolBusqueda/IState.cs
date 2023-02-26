using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBusqueda
{
    public interface IState : ICloneable, IComparable
    {
        //cantidad de acciones
        public int Actions { get;}

        //valida si el estado generado es valido
        public bool IsStateValid();
        //ejecuta la accion para cambiar un estado
        public bool ExecAction(int action);
        public string GetActionName(int action);

    }
}
