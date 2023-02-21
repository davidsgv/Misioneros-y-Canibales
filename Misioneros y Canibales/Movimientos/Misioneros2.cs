﻿using ArbolBusqueda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisionerosCanibales.Movimientos
{
    public class Misioneros2 : IProcess<State>
    {
        public Misioneros2()
        {
            Id = 2;
            Name = "2 Misioneros";
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public State Exec(State state)
        {
            //mover los de la izquierda
            if (state.Boat == 1)
            {
                state.RightSide[1] = state.RightSide[1] - 2;
                state.LeftSide[1] = state.LeftSide[1] + 2;
            }
            else //mover los de la derecha
            {
                state.LeftSide[1] = state.LeftSide[1] - 2;
                state.RightSide[1] = state.RightSide[1] + 2;
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
                if (state.RightSide[1] < 2)
                    return false;

            }
            else //mover los de la derecha
            {
                if (state.LeftSide[1] < 2)
                    return false;
            }

            return true;
        }
    }
}
