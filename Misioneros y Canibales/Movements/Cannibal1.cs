using ArbolBusqueda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisionerosCanibales.Movimientos
{
    public class Cannibal1 : IProcess<State>
    {
        public Cannibal1()
        {
            Id = 3;
            Name = "1 Canibal";
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public State Exec(State state)
        {
            //move right to left
            if (state.Boat == State.BoatStates.Right)
            {
                state.CannibalsRight = state.CannibalsRight - 1;
                state.CannibalsLeft = state.CannibalsLeft + 1;
            }
            else //move left to right
            {
                state.CannibalsLeft = state.CannibalsLeft - 1;
                state.CannibalsRight = state.CannibalsRight + 1;
            }

            state.MoveBoat();

            return state;
        }
    }
}
