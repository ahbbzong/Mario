using Game1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.MarioStates
{
    public abstract class MarioState : IMarioState
    {
        protected ISprite marioSprite { get; set; }
        protected Mario mario { get; set; }
        public int getWidth {
            get  
            {
                return marioSprite.Width();
            }
        }
        public int getHeight
        {
            get
            {
                return marioSprite.Height();
            }
        }

        protected MarioState(Mario mario)
        {
            this.mario = mario;
        }
        public virtual void BeFireMario()
        {
            //May need to override
        }
        public virtual void BeNormalMario()
        {
            //May need to override
        }
        public virtual void BeSuperMario()
        {
            //May need to override
        }
        public virtual void BeStarMario()
        {
            //May need to override
        }
        public virtual void Dead()
        {
            //May need to override
        }
        public virtual void Down()
        {
            //May need to override
        }
        public virtual void Draw(SpriteBatch spriteBatch, Vector2 marioLocation)
        {
            marioSprite.Draw(spriteBatch, marioLocation);
        }

        public virtual bool IsDead()
        {
            return false;
        }

        public virtual bool IsFireMario()
        {
            return false;
        }

        public virtual bool IsNormalMario()
        {
            return false;
        }

        public virtual bool IsSuperMario()
        {
            return false;
        }
        public virtual bool IsStarMario()
        {
            return false;
        }

        public virtual void Left()
        {
            //May need to override
        }
        public virtual void Right()
        {
            //May need to override
        }
        public virtual void Up()
        {
            //May need to override
        }
        public virtual void Update()
        {
            marioSprite.Update();
        }
      
    }
}
