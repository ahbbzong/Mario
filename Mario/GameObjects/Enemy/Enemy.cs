using Game1;
using Mario.BlockStates;
using Mario.Enums;
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
        public EnemyType Type { get; set; }
        public EnemyState EnemyState { get; set; }
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
		private bool Fall { get; set; }
		public bool Island { get; set; }
        public Physics Physics { get; set; }
        public bool IsMoving { get; set; }

        protected Enemy(Vector2 location)
        {
            EnemyLocation = location;
			Island = true;
			Fall = false;
            IsMoving = false;
            Physics = new Physics(this);
        }
		

        public virtual void Update()
        {
            EnemyState.Update();
			Move();
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
            IsMoving = false;
        }

        public virtual void TurnLeft()
        {
			velocity = -Vector2.UnitX;
            EnemyState.TurnLeft();
                IsMoving = true;
               
        }
       

        public virtual void TurnRight()
        {
			velocity = Vector2.UnitX;
            EnemyState.TurnRight();
            
                IsMoving = true;
                
        }
       

        public virtual bool IsStomped()
        {
            return EnemyState.IsStomped();
        }
		
		public Vector2 Position { get => EnemyLocation; set=>EnemyLocation = value; }

		public virtual void BeKilled()
        {
            EnemyState.BeKilled();
        }
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
		public void IsLandTrue()
		{
            Physics.ResetGravity();
			Island = true;
		}
		public void IsLandFalse()
		{
			Island = false;
		}

		public void Move()
		{
			EnemyLocation += velocity;
		}
      
        

    }
}
