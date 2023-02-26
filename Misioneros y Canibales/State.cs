using ArbolBusqueda;

namespace MisionerosCanibales
{
    internal class State : IState
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

            // 0 => lado izquierdo
            // 1 => lado derecho
            this.Boat = boat;

            //posible movements
            this.Actions = 5;
        }

        public int CannibalsLeft { get; set; }
        public int MissionariesLeft { get; set; }
        public int CannibalsRight { get; set; }
        public int MissionariesRight { get; set; }
        public BoatStates Boat { get; set; }

        public int Actions { get; }


        public void MoveBoat()
        {
            if(Boat == BoatStates.Left)
                Boat = BoatStates.Right;
            else
                Boat = BoatStates.Left;
        }

        public string GetActionName(int action)
        {
            switch(action)
            {
                case 0:
                    return "Move 1 cannibal";
                case 1:
                    return "Move 2 cannibal";
                case 2:
                    return "Move 1 Missionary";
                case 3:
                    return "Move 2 Missionaries";
                case 4:
                    return "Move 1 Missionary and 1 Cannibal";
            }
            return "action not valid";
        }
        public bool ExecAction(int action)
        {
            switch(action)
            {
                case 0:
                    MoveCannibal();
                    return true;
                case 1:
                    Move2Cannibals();
                    return true;
                case 2:
                    MoveMissionary();
                    return true;
                case 3:
                    Move2Missionaries();
                    return true;
                case 4:
                    MoveMissionaryAndCannibal();
                    return true;
            }
            return false;
        }

        private void MoveCannibal()
        {
            //move right to left
            if (Boat == State.BoatStates.Right)
            {
                CannibalsRight = CannibalsRight - 1;
                CannibalsLeft = CannibalsLeft + 1;
            }
            else //move left to right
            {
                CannibalsLeft = CannibalsLeft - 1;
                CannibalsRight = CannibalsRight + 1;
            }

            MoveBoat();
        }
        private void Move2Cannibals()
        {
            //move right to left
            if (Boat == State.BoatStates.Right)
            {
                CannibalsRight = CannibalsRight - 2;
                CannibalsLeft = CannibalsLeft + 2;
            }
            else //move left to right
            {
                CannibalsLeft = CannibalsLeft - 2;
                CannibalsRight = CannibalsRight + 2;
            }

            MoveBoat();
        }
        private void MoveMissionary()
        {
            //move right to left
            if (Boat == State.BoatStates.Right)
            {
                MissionariesRight = MissionariesRight - 1;
                MissionariesLeft = MissionariesLeft + 1;
            }
            else //mover los de la derecha
            {
                MissionariesLeft = MissionariesLeft - 1;
                MissionariesRight = MissionariesRight + 1;
            }

            MoveBoat();
        }
        private void Move2Missionaries()
        {
            //move right to left
            if (Boat == State.BoatStates.Right)
            {
                MissionariesRight = MissionariesRight - 2;
                MissionariesLeft = MissionariesLeft + 2;
            }
            else //mover los de la derecha
            {
                MissionariesLeft = MissionariesLeft - 2;
                MissionariesRight = MissionariesRight + 2;
            }

            MoveBoat();
        }
        private void MoveMissionaryAndCannibal()
        {
            //mover los de la izquierda
            if (Boat == BoatStates.Right)
            {
                //move missionary
                MissionariesRight = MissionariesRight - 1;
                MissionariesLeft = MissionariesLeft + 1;

                //move cannibal
                CannibalsRight = CannibalsRight - 1;
                CannibalsLeft = CannibalsLeft + 1;
            }
            else //mover los de la derecha
            {
                MissionariesLeft = MissionariesLeft - 1;
                MissionariesRight = MissionariesRight + 1;

                CannibalsLeft = CannibalsLeft - 1;
                CannibalsRight = CannibalsRight + 1;
            }

            MoveBoat();
        }

        public bool IsStateValid()
        {
            //check negative numbers
            if (CannibalsRight < 0 || CannibalsLeft < 0)
                return false;
            if (MissionariesLeft < 0 || MissionariesRight < 0)
                return false;

            //check that is equal or more missinaries than cannibals
            if (CannibalsLeft > MissionariesLeft && MissionariesLeft > 0)
                return false;
            if (CannibalsRight > MissionariesRight && MissionariesRight > 0)
                return false;

            return true;
        }

        public object Clone()
        {
            return new State(this.CannibalsLeft, this.MissionariesLeft,
                this.CannibalsRight, this.MissionariesRight, this.Boat);
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
