using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisionerosCanibales
{
    public class State : ICloneable, IComparable
    {
        public enum BoatStates 
        { 
            Left, 
            Right
        }

        public State(int cannibalsLeft, int missioneriesLeft, int cannibalsRight, int missioneriesRight, BoatStates boat)
        {
            CannibalsLeft = cannibalsLeft;
            MissionariesLeft = missioneriesLeft;

            CannibalsRight = cannibalsRight;
            MissionariesRight = missioneriesRight;
            ////[0] => represents canibales
            ////[1] => represents misioneros 
            //this.LeftSide = new int[2]; 
            //this.RightSide = new int[2];

            //this.LeftSide[0] = canibalesLeft;
            //this.LeftSide[1] = misionerosLeft;
            //this.RightSide[0] = canibalesRight;
            //this.RightSide[1] = misionerosRight;

            // 0 => lado izquierdo
            // 1 => lado derecho
            this.Boat = boat;
        }

        public int CannibalsLeft { get; set; }
        public int MissionariesLeft { get; set; }
        public int CannibalsRight { get; set; }
        public int MissionariesRight { get; set; }
        //public int[] LeftSide { get; set; }
        //public int[] RightSide { get; set; }
        public BoatStates Boat { get; set; }


        public object Clone()
        {
            return new State(this.CannibalsLeft, this.MissionariesLeft, 
                this.CannibalsRight, this.MissionariesRight, this.Boat);
        }

        public void MoveBoat()
        {
            if(Boat == BoatStates.Left)
                Boat = BoatStates.Right;
            else
                Boat = BoatStates.Left;
        }

        public int CompareTo(object? other)
        {
            // 0 => no es igual
            // 1 => es igual
            if (other == null)
                return 0;

            if (!(other is State))
                return 0;
            
            var state = (State)other;
            if (Boat != state.Boat)
                return 0;
            if (CannibalsLeft != state.CannibalsLeft)
                return 0;
            if (MissionariesLeft != state.MissionariesLeft)
                return 0;
            if (CannibalsRight != state.CannibalsRight)
                return 0;
            if (MissionariesRight != state.MissionariesRight)
                return 0;

            return 1;
        }
    }
}
