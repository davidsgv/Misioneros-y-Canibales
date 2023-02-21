using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBusqueda
{
    public class BusquedaProfundidad<T> where T : ICloneable, IComparable
    {
        public BusquedaProfundidad(T initialState, T expectedState, List<IProcess<T>> process,  List<ICondition<T>> conditions, int maxDeep) {
            //Define the initial/head node
            var initialNode = new Node<T>(initialState);
            this.Head = initialNode;

            //save the final result
            this.ExpectedResult = expectedState;

            //save the list of posible process
            this.ProcessList = process;
            this.ConditionList = conditions;
            this.MaxDeep = maxDeep;

            this.PosibleResult = new List<Node<T>>();
        }


        internal Node<T> Head { get; set; }
        internal List<IProcess<T>> ProcessList { get; }
        internal List<ICondition<T>> ConditionList { get; }
        internal T ExpectedResult { get; }
        internal List<Node<T>> PosibleResult { get; set; }
        internal int MaxDeep { get; set; }

        //create the tree and find all posible results
        public List<List<int>>? FindResult()
        {
            BuildTree(Head);

            var results = new List<List<int>>();
            foreach (var node in PosibleResult)
            {
                var result = new List<int>();

                var prevNode = node;
                while(prevNode != null)
                {
                    result.Add(prevNode.Process);
                    prevNode = prevNode.PrevNode;
                }

                results.Add(result);
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

            foreach (var process in ProcessList)
            {
                //if the move is not valid continue
                //var isValid = process.ValidateExec(node.State);

                //execute the procces 
                var newState = process.Exec((T)node.State.Clone());

                //if the state is not valid dont add the node
                var isValid = true;
                foreach (var condition in ConditionList)
                {
                    if(!condition.IsStateValid(newState))
                        isValid = false;
                }
                if (!isValid)
                    continue;

                //create the new node with the new state
                var newNode = new Node<T>(newState, node, process.Id, process.Name);

                //validate if the state if not in the previus steps
                if (!newNode.validatePreviusSteps())
                    continue; //dont add the node

                //if pass the prevs validations add the new node
                nodes.Add(newNode);
            }

            node.NextNodes = nodes;

            return true;
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
