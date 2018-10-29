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
        Rectangle intersection;
        public MarioBlockHandler(Rectangle intersection)
        {
            this.intersection = intersection;
        }
        public void HandleCollision(IMario mario,Direction result)
        {
            switch (result)
            {
                case Direction.Up:
                    mario.SetFalling(false);
                    mario.IsLandTrue();
                    mario.Physics.ResetGravity();
                    mario.Position -= Vector2.UnitY*intersection.Height;
                    if (mario.IsUp())
                    {
                        if (mario.Physics.XVelocityResponse() >= 0.1)
                        {
                            mario.Right();
                        }
                        else if (mario.Physics.XVelocityResponse() <= -0.1)
                        {
                            mario.Left();
                        }
                        else
                        {
                            mario.NoInput();
                        }
                    }
                    break;
                case Direction.Down:
					mario.Position += Vector2.UnitY* intersection.Height;
                    mario.Physics.ResetGravity();
                    mario.SetFalling(true);
                    break;
                case Direction.Left:
                   
                        mario.Physics.ResetHorizontal();
                        mario.Position -= Vector2.UnitX * intersection.Width;
                    
                    break;
                case Direction.Right:
                   
                        mario.Physics.ResetHorizontal();
                        mario.Position += Vector2.UnitX * intersection.Width;
                    
                    break;
               
            }
        }

    }
}
