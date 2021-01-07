using System;
using System.Linq;
using System.Collections.Generic;

namespace Delegate
{
    class Program
    {
        delegate bool IntPredicate(int number);
        static void Main(string[] args)
        {
            IntPredicate intPredicateVariable = x => true;
        }
    }
}
