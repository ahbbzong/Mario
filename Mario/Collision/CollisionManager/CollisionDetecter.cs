using Game1;
using Mario.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Collision
{
    public class CollisionDetecter
    {
        private Direction resultFirst { get; set; }
        public Rectangle intersection { get; set; }
        public CollisionDetecter()
        {//Constructor
        }
        public Direction Collision(Rectangle firstRecDetect, Rectangle secondRecDetect)
        {
            intersection = Rectangle.Intersect(firstRecDetect, secondRecDetect);
                if (!intersection.IsEmpty)
                {
                    if (intersection.Height <= intersection.Width)
                    {
                        resultFirst = DetectTopOrBottomCollision(firstRecDetect, secondRecDetect);
                    }
                    else if (intersection.Height >= intersection.Width)
                    {
                       resultFirst = DetectLeftOrRightCollision(firstRecDetect, secondRecDetect);
                    }
                }
                else { resultFirst = Direction.None; }
            
            return resultFirst;

        }  
        private static Direction DetectTopOrBottomCollision(Rectangle firstRecDetect, Rectangle secondRecDetect)
        {
            if (firstRecDetect.Bottom >= secondRecDetect.Top && firstRecDetect.Bottom <= secondRecDetect.Bottom)
            {
                return Direction.Up;
            }
            else
            {
                return Direction.Down;
            }
           
        }
        private static Direction DetectLeftOrRightCollision(Rectangle firstRecDetect, Rectangle secondRecDetect)
        {
            if (firstRecDetect.Right >= secondRecDetect.Left && firstRecDetect.Right <= secondRecDetect.Right)
            {
                return Direction.Left;
            }
            else 
            {
                return Direction.Right;
            }
          
        }
    }
}
