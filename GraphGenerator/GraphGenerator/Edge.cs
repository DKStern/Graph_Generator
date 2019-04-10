using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphGenerator
{
    public class Edge
    {
        public int First { get; set; }
        public int Second { get; set; }

        public Edge(int first, int second)
        {
            First = first;
            Second = second;
        }
    }
}
