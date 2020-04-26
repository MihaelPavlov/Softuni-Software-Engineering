using System;

namespace Shapes
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            IDrawable draw = new Rectangle(10,5);
            draw.Draw();

            IDrawable draw2 = new Circle(10);
        }
    }
}
