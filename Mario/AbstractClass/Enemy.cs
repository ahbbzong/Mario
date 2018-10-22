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
        public EnemyState enemyState { get; set; }
        public Rectangle Box
        {
            get
            {
                return new Rectangle((int)EnemyLocation.X, (int)EnemyLocation.Y, enemyState.GetWidth, enemyState.GetHeight);
            }
        }
		
		private Vector2 maxVelocity = new Vector2(8.0f,8.0f);
		public Vector2 MaxVelocity { get => maxVelocity; }

		private Vector2 velocity = Vector2.Zero;
		public Vector2 Velocity { get => velocity; set => velocity = value; }
		private bool fall { get; set; }
		public bool Island { get; set; }
        public Physics Physics { get; set; }

        protected Enemy(Vector2 location)
        {
            EnemyLocation = location;
			Island = true;
			fall = false;
            Physics = new Physics(this);
        }
		

        public virtual void Update()
        {
            enemyState.Update();
			Move();
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
			velocity = -Vector2.UnitX;
            enemyState.TurnLeft();
        }

        public virtual void TurnRight()
        {
			velocity = Vector2.UnitX;
            enemyState.TurnRight();
        }

        public virtual bool IsStomped()
        {
            return enemyState.IsStomped();
        }

        public virtual ref Vector2 Getposition()
        {
            return ref EnemyLocation;
        }

        public virtual void BeKilled()
        {
            enemyState.BeKilled();
        }
        public virtual bool IsFlipped()
        {
            return enemyState.IsFlipped();
        }

        public virtual bool IsGoomba()
        {
            return enemyState.IsGoomba();
        }

        public virtual bool IsKoopa()
        {
            return enemyState.IsKoopa();
        }
		public void IsLandTrue()
		{
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
