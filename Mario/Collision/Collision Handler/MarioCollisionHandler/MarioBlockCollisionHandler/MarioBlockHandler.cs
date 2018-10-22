﻿using Game1;
using Mario.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Collision.MarioCollisionHandler.MarioBlockCollisionHandler
{
    public class MarioBlockHandler : IMarioCollisionHandler
    {
        public MarioBlockHandler()
        {
            //No need to fill.
        }
        public void HandleCollision(IMario mario,Direction result, Rectangle intersection)
        {
            switch (result)
            {
                case Direction.Up:
                    mario.Position -= Vector2.UnitY*intersection.Height;
                    mario.IsLandTrue();
                    break;
                case Direction.Down:
					mario.Position += Vector2.UnitY* intersection.Height;
                    mario.physics.ResetGravity();
                    break;
                case Direction.Left:
                    mario.Position -= Vector2.UnitX*intersection.Width;
                    break;
                case Direction.Right:
                    mario.Position += Vector2.UnitX*intersection.Width;
                    break;
                case Direction.None:
                    mario.IsLandFlase();
                    break;

            }
        }

    }
}
