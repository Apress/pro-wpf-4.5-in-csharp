using System;
using System.Collections.Generic;
using System.Text;

namespace Multithreading
{
    public class FindPrimesInput
    {        
        public int To
        { get; set; }

        public int From
        { get; set; }

        public FindPrimesInput(int from, int to)
        {
            To = to;
            From = from;
        }

    }
}
