using ArbolBusqueda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisionerosCanibales.Movimientos
{
    public class Missionary1 : IProcess<State>
    {
        public Missionary1()
        {
            Id = 4;
            Name = "1 Misionero";
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public State Exec(State state)
        {
            //move right to left
            if (state.Boat == State.BoatStates.Right)
            {
                state.MissionariesRight = state.MissionariesRight - 1;
                state.MissionariesLeft = state.MissionariesLeft + 1;
            }
            else //mover los de la derecha
            {
                state.MissionariesLeft = state.MissionariesLeft - 1;
                state.MissionariesRight = state.MissionariesRight + 1;
            }

            state.MoveBoat();

            return state;
        }
    }
}
