using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArbolBusqueda;

namespace MisionerosCanibales.Movimientos
{
    public class Canibales2 : IProcess<State>
    {
        public Canibales2()
        {
            Id = 1;
            Name = "2 Canibales";
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public State Exec(State state)
        {
            //mover los de la izquierda
            if (state.Boat == 1)
            {
                state.RightSide[0] = state.RightSide[0] - 2;
                state.LeftSide[0] = state.LeftSide[0] + 2;
            }
            else //mover los de la derecha
            {
                state.LeftSide[0] = state.LeftSide[0] - 2;
                state.RightSide[0] = state.RightSide[0] + 2;
            }

            if (state.Boat == 1)
                state.Boat = 0;
            else
                state.Boat = 1;

            return state;
        }

        public bool ValidateExec(State state)
        {
            //mover los de la izquierda
            if (state.Boat == 1)
            {
                if (state.RightSide[0] < 2)
                    return false;

            }
            else //mover los de la derecha
            {
                if (state.LeftSide[0] < 2)
                    return false;
            }

            return true;
        }
    }
}
