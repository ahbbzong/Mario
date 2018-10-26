using Game1;
using Mario.EnemyStates.GoombaStates;
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
    public abstract class EnemyState : IEnemyState
    {
        protected ISprite EnemySprite { get; set; }
        public Enemy enemy { get; set; }
        protected Vector2 XVelocity { get; set; }
        public int GetWidth
        {
            get
            {
                return EnemySprite.Width;
            }
        }
        public int GetHeight
        {
            get
            {
                return EnemySprite.Height;
            }
        }
        protected EnemyState(Enemy enemy)
        {
            this.enemy = enemy;
            XVelocity = new Vector2(1, 0);
        }
        public virtual void Beflipped()
        {
            //Need to be overriden
        }

        public virtual void BeStomped()
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            EnemySprite.Draw(spriteBatch, location);
        }

        public virtual bool IsGoombaStomped()
        {
            return false;
        }
      

        public virtual void TurnLeft()
        {

        }

        public virtual void TurnRight()
        {

        }

        public virtual void Update()
        {
            EnemySprite.Update();
            if (!enemy.Island)
            {
                enemy.Physics.Update();
            }
        }

        public virtual bool IsFlipped()
        {
            return false;
        }

        public virtual bool IsGoomba()
        {
            return false;
        }

        public virtual bool IsKoopa()
        {
            return false;
        }

        public virtual bool IsLeftStomped()
        {
            return false;
        }

        public virtual bool IsRightStomped()
        {
            return false;
        }
        public virtual bool IsKoopaStomped()
        {
            return false;
        }
    }
}
