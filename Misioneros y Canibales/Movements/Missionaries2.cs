using ArbolBusqueda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisionerosCanibales.Movimientos
{
    public class Missionaries2 : IProcess<State>
    {
        public Missionaries2()
        {
            Id = 2;
            Name = "2 Misioneros";
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public State Exec(State state)
        {
            //move right to left
            if (state.Boat == State.BoatStates.Right)
            {
                state.MissionariesRight = state.MissionariesRight - 2;
                state.MissionariesLeft = state.MissionariesLeft + 2;
            }
            else //mover los de la derecha
            {
                state.MissionariesLeft = state.MissionariesLeft - 2;
                state.MissionariesRight = state.MissionariesRight + 2;
            }

            state.MoveBoat();

            return state;
        }
    }
}
