using ArbolBusqueda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisionerosCanibales.Conditions
{
    internal class Condition: ICondition<State>
    {
        public bool IsStateValid(State state)
        {
            //check negative numbers
            if(state.CannibalsRight < 0 || state.CannibalsLeft < 0)
                return false;
            if(state.MissionariesLeft < 0 || state.MissionariesRight < 0)
                return false;

            //check that is equal or more missinaries than cannibals
            if(state.CannibalsLeft > state.MissionariesLeft && state.MissionariesLeft > 0)
                return false;
            if (state.CannibalsRight > state.MissionariesRight && state.MissionariesRight > 0)
                return false;

            return true;
        }
    }
}
