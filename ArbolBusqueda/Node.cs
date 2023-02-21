namespace ArbolBusqueda
{
    internal class Node<T> where T : ICloneable, IComparable
    {

        internal Node(T Initialstate)
        {
            State = Initialstate;
        }

        internal Node(T state, Node<T>? prevNode, int process, string processName) 
        {
            State= state;
            PrevNode = prevNode;
            Process = process;
            ProcessName = processName;
        }


        //Represents the state of this node
        internal T State { get; set; }

        //Represents the previus node
        internal Node<T>? PrevNode { get; set; }

        //represents the process used to get this state
        public int Process { get; set; }
        public string ProcessName { get; set; }


        //the sons nodes
        internal List<Node<T>>? NextNodes { get; set; }

        //returns true if there is not similar nodes on father leafs
        internal bool validatePreviusSteps()
        {
            var prevNode = PrevNode;

            while (prevNode != null)
            {
                if (State.CompareTo(prevNode.State) == 1)
                {
                    return false;
                }
                prevNode = prevNode.PrevNode;
            }

            return true;
        }
    }
}