﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _02.GenericBoxOfInteger
{
    public class Box<T>
    {
        public T Value { get; set; }
        public Box(T value)
        {
            this.Value = value;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb
                .AppendLine($"{this.Value.GetType()}: {this.Value}");

            return sb.ToString().TrimEnd() ;
        }
    }
}
