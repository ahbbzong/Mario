using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using Game1;
using Mario.MarioStates;

namespace Mario
{
    public class Mario : IMario,ICollidiable
    {
        private Vector2 location = Vector2.Zero;
		public Vector2 Location { get => location; set => location = value; }
        public IMarioState marioState { get; set; }
		private ISprite marioSprite { get; set; }

        private bool fall;
        public Rectangle Box
        {
            get
            {
                return new Rectangle((int)location.X, (int)location.Y, marioSprite.Width, marioSprite.Height);
                
            }
            
        }
        public Mario(Vector2 location)
        {
            this.location = location;
            marioState = new NormalMarioLeftIdleState(this);
            fall = false;
           
        }
		public void Up()
        {
            marioState.Up();
            fall = false;
        }
        public void Down()
        {
            marioState.Down();
            fall = true;
        }
        public void Left()
        {
            marioState.Left();
        }
        public void Right()
        {
            marioState.Right();
        }
        public void Dead()
        {
            marioState.Dead();
        }
        public void BeSuper()
        {
            marioState.BeSuperMario();
        }
        public void BeNormal()
        {
            marioState.BeNormalMario();
        }
        public void BeFire()
        {
            marioState.BeFireMario();
        }
        public void BeStar()
        {
            marioState.BeStarMario();
        }
        public bool IsSuperMario()
        {
            return marioState.IsSuperMario();
        }
        public bool IsFireMario()
        {
            return marioState.IsFireMario();
        }

        public bool IsNormalMario()
        {
            return marioState.IsNormalMario();
        }
        public bool IsStarMario()
        {
            return marioState.IsStarMario();
        }

        public void Update()
        {
            marioSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
			marioSprite.Draw(spriteBatch,location);
        }

        public ref Vector2 Getposition()
        {
            return ref location;
        }

        public bool IsDead()
        {
            return marioState.IsDead();
        }
        public bool Isfalling()
        {
            return fall;
        }

     
    }
}
