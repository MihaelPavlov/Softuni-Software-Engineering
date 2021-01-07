using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;

namespace BoxOfT
{
   public class Box<T>
    {
        private List<T> list;
        public T Value { get; set; }
      
        public Box()
        {
            this.list = new List<T>();
        }

        public int Count
        {
            get
            {
              return  this.list.Count;
            }
        }
        public void Add(T value)
        {
            this.list.Add(value);
        }
        public T Remove()
        {
            if (this.list.Count==0)
            {
                throw new InvalidOperationException("Cannot remove from empty box");
            }
            var element = this.list[this.list.Count - 1];
            this.list.RemoveAt(this.list.Count - 1);

            return element;

        }

    }
}
