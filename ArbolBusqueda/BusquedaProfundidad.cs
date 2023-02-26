using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBusqueda
{
    public class BusquedaProfundidad<T> where T : IState
    {
        public BusquedaProfundidad(T initialState, T expectedState, int maxDeep) {
            //Define the initial/head node
            var initialNode = new Node<T>(initialState);
            this.Head = initialNode;

            //save the final result
            this.ExpectedResult = expectedState;

            //save the list of posible process
            this.MaxDeep = maxDeep;

            this.PosibleResult = new List<Node<T>>();
        }


        internal Node<T> Head { get; set; }
        internal T ExpectedResult { get; }
        internal List<Node<T>> PosibleResult { get; set; }
        internal int MaxDeep { get; set; }

        //create the tree and find all posible results
        public List<List<Resultado>>? FindResult()
        {
            BuildTree(Head);

            var results = new List<List<Resultado>>();
            foreach (var node in PosibleResult)
            {
                var resultList = new List<Resultado>();

                var prevNode = node;
                var iterator = 0;
                while(prevNode.PrevNode != null)
                {
                    iterator++;
                    var result = new Resultado(prevNode.Process, iterator, prevNode.ProcessName);
                    resultList.Add(result);
                    prevNode = prevNode.PrevNode;
                }

                results.Add(resultList);
            }

            return results;
        }

        private void BuildTree(Node<T> node)
        {
            InsertProcess(node);

            if (node.NextNodes == null)
                return;

            foreach(var item in node.NextNodes)
            {
                BuildTree(item);
            }
        }

        private bool InsertProcess(Node<T> node)
        {
            //validate deep (no more than 100)
            if (this.CheckDeep(node))
                return false;

            //validate if the state is the expected state
            if (node.State.CompareTo(ExpectedResult) == 1)
            {
                PosibleResult.Add(node);
                return false;
            }

            var nodes = new List<Node<T>>();

            for(int i = 0; i < node.State.Actions; i++)
            {
                T newState = (T)node.State.Clone();

                //si no se puede aplicar la accion continua la siguiente
                if (!newState.ExecAction(i))
                    continue;

                var processName = node.State.GetActionName(i);
                var newNode = new Node<T>(newState, node, i, processName);

                //validate if the state if not in the previus steps
                if (StateIsInPreviousSteps(newNode))
                    continue; //dont add the node

                //validate is state is valid
                if (!newNode.State.IsStateValid())
                    continue; //dont add the node

                nodes.Add(newNode);
            }

            node.NextNodes = nodes;

            return true;
        }

        private bool StateIsInPreviousSteps(Node<T> node)
        {
            if (node == null)
                return false;

            var prevNode = node.PrevNode;
            while(prevNode != null)
            {
                if (node.State.CompareTo(prevNode.State) == 1)
                {
                    return true;
                }
                prevNode = prevNode.PrevNode;
            }
            return false;
        }

        private bool CheckDeep(Node<T> node)
        {
            int count = 0;

            while(node != null)
            {
                count ++;
                node = node.PrevNode;
            }

            return count > MaxDeep;
        }
    }
}
