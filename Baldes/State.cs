using ArbolBusqueda;

namespace Baldes
{
    internal class State: IState
    {
        public State(Buckect bucket6, Buckect bucket8) { 
            Buckect6 = bucket6;
            Buckect8 = bucket8;
        }

        public Buckect Buckect6 { get; set; }
        public Buckect Buckect8 { get; set; }

        public int Actions { get; } = 8;

        //always true becouse the state if getting check before aply an action
        public bool IsStateValid()
        {
            return true;
        }

        public bool ExecAction(int action)
        {
            var diference = 0;
            switch (action)
            {
                case 0:
                    //if buckect is fill
                    if (!Buckect8.IsEmpty())
                        return false;

                    Buckect8.Fill();
                    break;
                case 1:
                    if (!Buckect6.IsEmpty())
                        return false;
                    Buckect6.Fill();
                    break;
                case 2:
                    if(!Buckect8.IsEmpty())
                        return false;
                    Buckect8.Dump();
                    break;
                case 3:
                    if (!Buckect6.IsEmpty())
                        return false;
                    Buckect6.Dump();
                    break;
                case 4:
                    if(Buckect6.IsFill() && Buckect8.IsEmpty() && Buckect6.Value + Buckect8.Value > 6)
                        return false;
                    Buckect6.Fill(Buckect8.Value);
                    Buckect8.Dump();
                    break;
                case 5:
                    if(Buckect8.IsFill() && Buckect6.IsEmpty() && Buckect6.Value + Buckect8.Value > 8)
                        return false;
                    Buckect8.Fill(Buckect6.Value);
                    Buckect6.Dump();
                    break;
                case 6:
                    if(Buckect8.IsFill() && Buckect6.IsEmpty() && Buckect6.Value + Buckect8.Value < 7)
                        return false;
                    diference = Buckect8.Value - 8;
                    Buckect8.Fill(Buckect6.Value);
                    Buckect6.Dump(diference);
                    break;
                case 7:
                    if(Buckect6.IsFill() && Buckect8.IsEmpty() && Buckect6.Value + Buckect8.Value < 5)
                        return false;
                    diference = Buckect6.Value - 6;
                    Buckect6.Fill(Buckect8.Value);
                    Buckect8.Dump(diference);
                    break;
            }
            return true;
        }

        public string GetActionName(int action)
        {
            switch (action)
            {
                case 0:
                    return "Llenar el balde 8 galones";
                case 1:
                    return "Llenar el balde de 6 galones";
                case 2:
                    return "Descargue el balde de 8 galones";
                case 3:
                    return "Descargue el balde de 6 galones";
                case 4:
                    return "Vacie el balde de 8 galones en el de 6 galones";
                case 5:
                    return "Vacie el balde de 6 galones en el de 8 galones";
                case 6:
                    return "Llene el balde de 8 galones con el de 6 galones";
                case 7:
                    return "Llene el balde de 6 galones con el de 8 galones";
            }
            return "accion no valida";
        }
        
        public Object Clone()
        {
            var buckect6 = new Buckect(6);
            var buckect8 = new Buckect(8);
            buckect6.Value = Buckect6.Value;
            buckect8.Value = Buckect8.Value;

            return new State(buckect6, buckect8);
        }
        public int CompareTo(Object? obj)
        {
            if (obj == null)
                return 0;

            if (!(obj is State))
                return 0;

            var state = (State)obj;
            if (state.Buckect6.Value != Buckect6.Value)
                return 0;
            if (state.Buckect8.Value != Buckect8.Value)
                return 0;

            return 1;
        }
    }
}
