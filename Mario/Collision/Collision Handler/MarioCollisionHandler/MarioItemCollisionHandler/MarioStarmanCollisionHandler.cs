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
    public class MarioStarmanCollisionHandler : IMarioCollisionHandler
    {
        public MarioStarmanCollisionHandler()
        {
        }
        public void HandleCollision(IMario mario, Direction result, Rectangle intersection)
        {
            if (mario.IsNormalMario() || mario.IsFireMario()||mario.IsSuperMario())
            {
                mario.BeStar();
            }
        }
    }
}