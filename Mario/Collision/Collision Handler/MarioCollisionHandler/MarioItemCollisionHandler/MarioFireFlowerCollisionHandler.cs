﻿using Game1;
using Mario.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Collision.MarioCollisionHandler.MarioItemCollisionHandler
{
    public class MarioFireFlowerCollisionHandler : IMarioCollisionHandler
    {
        public MarioFireFlowerCollisionHandler()
        {
        }
        public void HandleCollision(IMario mario, Direction result)
        {
            if (mario.IsNormalMario() || mario.IsSuperMario())
            {
                mario.BeFire();
            }
        }
    }
}
