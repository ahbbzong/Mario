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
        public int GetWidth
        {
            get
            {
                return EnemySprite.Width();
            }
        }
        public int GetHeight
        {
            get
            {
                return EnemySprite.Height();
            }
        }
        protected EnemyState(Enemy enemy)
        {
            this.enemy = enemy;
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

        public virtual bool IsStomped()
        {
            return false;
        }

        public virtual void TurnLeft()
        {
            //Need to be overriden
        }

        public virtual void TurnRight()
        {
            //Need to be overriden
        }

        public virtual void Update()
        {
            EnemySprite.Update();
        }

      

    }
}
