using Game1;
using Mario.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Collision.MarioCollisionHandler.MarioPipeCollisionHandler
{
    public class MarioPipeCollisionHandler : IMarioCollisionHandler
    {
        Vector2 marioLocation;
        public MarioPipeCollisionHandler() { //No need to fill
        }

        public void HandleCollision(IMario mario, Direction result, Rectangle intersection)
        {
            switch (result)
            {
                case Direction.Up:
                    marioLocation = mario.Getposition();
                    marioLocation.Y -= intersection.Height;
                    break;
                case Direction.Down:
                    marioLocation = mario.Getposition();
                    marioLocation.Y += intersection.Height;
                    break;
                case Direction.Left:
                    marioLocation = mario.Getposition();
                    marioLocation.X -= intersection.Width;
                    break;
                case Direction.Right:
                    marioLocation = mario.Getposition();
                    marioLocation.X -= intersection.Width;
                    break;
            }
        }
    }
}
