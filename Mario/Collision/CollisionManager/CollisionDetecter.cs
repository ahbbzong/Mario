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
        private Direction DirectionOfCollision { get; set; }
        public Rectangle Intersection { get; set; }
        public CollisionDetecter()
        {
        }
        public Direction Collision(Rectangle firstRecDetect, Rectangle secondRecDetect)
        {
            Intersection = Rectangle.Intersect(firstRecDetect, secondRecDetect);
                if (!Intersection.IsEmpty)
                {
                    if (Intersection.Height <= Intersection.Width)
                    {
                        DirectionOfCollision = DetectTopOrBottomCollision(firstRecDetect, secondRecDetect);
                    }
                    else if (Intersection.Height > Intersection.Width)
                    {
                       DirectionOfCollision = DetectLeftOrRightCollision(firstRecDetect, secondRecDetect);
                    }
                }
                else { DirectionOfCollision = Direction.None; }
            
            return DirectionOfCollision;

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
            if (firstRecDetect.Right > secondRecDetect.Left && firstRecDetect.Right < secondRecDetect.Right)
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
