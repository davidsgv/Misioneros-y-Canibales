using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baldes
{
    internal class Buckect
    { 
        public int Capacity { get; }
        public int Value { get; set; }

        public Buckect(int capacity)
        {
            Capacity = capacity;
            Value = 0;
        }

        public void Fill()
        {
            Value = Capacity;
        }
        public void Fill(int quantity)
        {
            Value += quantity;
            if(Value > Capacity)
                Value = Capacity;
        }
        public void Dump()
        {
            Value = 0;
        }
        public void Dump(int quantity)
        {
            Value-=quantity;
            if(Value< 0) 
                Value = 0;
        }

        public bool IsFill()
        {
            return Value == Capacity;
        }
        public bool IsEmpty()
        {
            return Value == 0;
        }
    }
}
