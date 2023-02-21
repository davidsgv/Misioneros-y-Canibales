using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArbolBusqueda;

namespace MisionerosCanibales.Movimientos
{
    public class Cannibals2 : IProcess<State>
    {
        public Cannibals2()
        {
            Id = 1;
            Name = "2 Canibales";
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public State Exec(State state)
        {
            //move right to left
            if (state.Boat == State.BoatStates.Right)
            {
                state.CannibalsRight = state.CannibalsRight - 2;
                state.CannibalsLeft = state.CannibalsLeft + 2;
            }
            else //move left to right
            {
                state.CannibalsLeft = state.CannibalsLeft - 2;
                state.CannibalsRight = state.CannibalsRight + 2;
            }

            state.MoveBoat();

            return state;
        }
    }
}
