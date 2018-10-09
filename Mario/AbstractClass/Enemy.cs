﻿using Game1;
using Mario.BlockStates;
using Mario.Enums;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.AbstractClass
{
    public abstract class Enemy : IEnemy,ICollidiable
    {
        protected Vector2 EnemyLocation { get; set; }
        public EnemyType Type { get; set; }
        public EnemyState enemyState { get; set; }
        public Rectangle Box
        {
            get
            {
                return new Rectangle((int)EnemyLocation.X, (int)EnemyLocation.Y, enemyState.GetWidth, enemyState.GetHeight);
            }
        }
        protected Enemy(Vector2 location)
        {
            EnemyLocation = location;
        }


        public virtual void Update()
        {
            enemyState.Update();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            enemyState.Draw(spriteBatch, EnemyLocation);
        }

        public virtual void Beflipped()
        {
            enemyState.Beflipped();
        }

        public virtual void BeStomped()
        {
            enemyState.BeStomped();
        }

        public virtual void TurnLeft()
        {
            enemyState.TurnLeft();
        }

        public virtual void TurnRight()
        {
            enemyState.TurnRight();
        }

        public virtual bool IsStomped()
        {
            return enemyState.IsStomped();
        }
    }
}
