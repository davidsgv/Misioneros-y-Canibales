namespace ArbolBusqueda
{
    internal class Node<T> where T : IState
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


        internal List<Node<T>>? NextNodes { get; set; }

    }
}