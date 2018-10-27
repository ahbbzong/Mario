﻿using Game1;
using Mario.AbstractClass;
using Mario.Classes.BlocksClasses;
using Mario.EnemyClasses;
using Mario.Enums;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.EnemyStates.GoombaStates
{
    public class StompedGoombaState : EnemyState
    {
        int count = 0;
        public StompedGoombaState(Enemy enemy) :base(enemy)
        {
            enemy.Velocity = Vector2.Zero;
        }

        public override bool IsStomped()
        {
            return true;

        }
        public override bool IsGoomba()
        {
            return true;
        }
        public override void Update()
        {
            count++;
        }
        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (count < 15)
            {
                EnemySprite.Draw(spriteBatch, location);
            }
        }


    }
}

