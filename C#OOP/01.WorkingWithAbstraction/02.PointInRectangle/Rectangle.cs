using System;
using System.Collections.Generic;
using System.Text;

namespace _02.PointInRectangle
{
   public class Rectangle
    {
        public Rectangle(int top , int left, int bottom  , int right)
        {
            this.TopLeft = new Point(top, left);
            this.BottomRight = new Point( bottom, right);
        }
        public Rectangle(Point topLeft , Point bottomRight)
        {
            this.TopLeft = TopLeft;
            this.BottomRight = bottomRight;
        }
        public Point TopLeft { get; set; }
        public Point BottomRight { get; set; }

        public bool Contains(Point point)
        {
            if (point.X>=this.TopLeft.X &&
                point.X<=this.BottomRight.X &&
                point.Y>= this.TopLeft.Y &&
                point.Y<= this.BottomRight.Y)
            {
                return true;
            }

            return false;
        }
    }
}
