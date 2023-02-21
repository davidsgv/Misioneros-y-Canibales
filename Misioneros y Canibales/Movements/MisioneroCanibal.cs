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
            if (state.Boat == State.BoatStates.Right)
            {
                //move missionary
                state.MissionariesRight = state.MissionariesRight - 1;
                state.MissionariesLeft = state.MissionariesLeft + 1;

                //move cannibal
                state.CannibalsRight = state.CannibalsRight - 1;
                state.CannibalsLeft = state.CannibalsLeft + 1;
            }
            else //mover los de la derecha
            {
                state.MissionariesLeft = state.MissionariesLeft - 1;
                state.MissionariesRight = state.MissionariesRight + 1;

                state.CannibalsLeft = state.CannibalsLeft - 1;
                state.CannibalsRight = state.CannibalsRight + 1;
            }

            state.MoveBoat();

            return state;
        }
    }
}
