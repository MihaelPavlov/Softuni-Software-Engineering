using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : IDrawable
    {
        public Circle(int radius)
        {
            this.Radius = radius;
        }
        public int Radius { get; set; }

        public void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
