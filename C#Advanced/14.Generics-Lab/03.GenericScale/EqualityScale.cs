using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale

{
   public class EqualityScale<T>
        where T  : IComparable<T>
    {
        public EqualityScale(T left, T right)
        {
            this.Left = left;
            this.Right = right;
        }
        public T Left { get; set; }
        public T Right { get; set; }
       

       public bool? AreEqual()
        {
            bool result = this.Left.Equals(this.Right);
            return result;
        }

        public bool IsFirstGreater()
        {
            return this.Left.CompareTo(this.Right)>0;
        }

       
    }
}
