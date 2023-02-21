using ArbolBusqueda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisionerosCanibales.Movimientos
{
    public class MisioneroCanibal : IProcess<State>
    {
        public MisioneroCanibal()
        {
            Id = 5;
            Name = "1 Misionero 1 canibal";
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public State Exec(State state)
        {
            //mover los de la izquierda
            if (state.Boat == 1)
            {
                //move misionero
                state.RightSide[1] = state.RightSide[1] - 1;
                state.LeftSide[1] = state.LeftSide[1] + 1;

                //move canibal
                state.RightSide[0] = state.RightSide[0] - 1;
                state.LeftSide[0] = state.LeftSide[0] + 1;
            }
            else //mover los de la derecha
            {
                state.LeftSide[1] = state.LeftSide[1] - 1;
                state.RightSide[1] = state.RightSide[1] + 1;

                state.LeftSide[0] = state.LeftSide[0] - 1;
                state.RightSide[0] = state.RightSide[0] + 1;
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
                if (state.RightSide[0] < 1)
                    return false;

                if (state.RightSide[1] < 1)
                    return false;

            }
            else //mover los de la derecha
            {
                if (state.LeftSide[0] < 1)
                    return false;

                if (state.LeftSide[1] < 1)
                    return false;
            }

            return true;
        }
    }
}
