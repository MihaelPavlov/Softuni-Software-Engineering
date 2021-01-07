using System;
using System.Collections.Generic;
using System.Text;

namespace GenericArrayCreator
{
    public class ArrayCreator
    {
         public static T[] Create<T>(int lenght , T value)
        {
            var array = new T[lenght];

            for (int i = 0; i < lenght; i++)
            {
                array[i] = value;
            }
            return array;  
        }
    }
}
