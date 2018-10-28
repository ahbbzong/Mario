﻿using Game1;
using Mario.BlockStates;
using Mario.Factory;
using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.AbstractClass
{
    public abstract class Enemy : IEnemy,ICollidiable, IMoveable
    {
        private Vector2 EnemyLocation;
        public IEnemyState EnemyState { get; set; }
        public Rectangle Box
        {
            get
            {
                return new Rectangle((int)EnemyLocation.X, (int)EnemyLocation.Y, EnemyState.GetWidth, EnemyState.GetHeight);
            }
        }
		
		private Vector2 maxVelocity = new Vector2(8.0f,8.0f);
		public Vector2 MaxVelocity { get => maxVelocity; }

		private Vector2 velocity = Vector2.Zero;
		public Vector2 Velocity { get => velocity; set => velocity = value; }
		public bool Island { get; set; }
        public GravityManagement gravityManagement { get; set; }


        protected Enemy(Vector2 location)
        {
            EnemyLocation = location;
			Island = false;
            gravityManagement = new GravityManagement(this);
        }


        public virtual void Update()
        {
            EnemyState.Update();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            EnemyState.Draw(spriteBatch, EnemyLocation);
        }

        public virtual void Beflipped()
        {
            EnemyState.Beflipped();
        }

        public virtual void BeStomped()
        {
            EnemyState.BeStomped();
        }

        public virtual void TurnLeft()
        {
            EnemyState.TurnLeft();
        }
       

        public virtual void TurnRight()
        {
            EnemyState.TurnRight();
        }
       

        public virtual bool IsGoombaStomped()
        {
            return EnemyState.IsGoombaStomped();
        }
		
		public Vector2 Position { get => EnemyLocation; set => EnemyLocation = value; }
        public virtual bool IsFlipped()
        {
            return EnemyState.IsFlipped();
        }

        public virtual bool IsGoomba()
        {
            return EnemyState.IsGoomba();
        }

        public virtual bool IsKoopa()
        {
            return EnemyState.IsKoopa();
        }
		public virtual void IsLandTrue()
		{
            gravityManagement.ResetGravity();
			Island = true;
		}
        public virtual void IsLandFalse()
		{
			Island = false;
		}

		public virtual void Move()
		{
			EnemyLocation += velocity;
		}

        public virtual bool IsLeftStomped()
        {
            return EnemyState.IsLeftStomped();
        }

        public virtual bool IsRightStomped()
        {
            return EnemyState.IsRightStomped();
        }
        public virtual bool IsKoopaStomped()
        {
            return EnemyState.IsKoopaStomped();
        }
    }
}
