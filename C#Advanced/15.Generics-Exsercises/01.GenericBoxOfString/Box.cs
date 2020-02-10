﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _01.GenericBoxOfString
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
                .AppendLine($"System.String: {this.Value}");

            return sb.ToString().TrimEnd() ;
        }
    }
}
