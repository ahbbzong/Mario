using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using Game1;
using Mario.MarioStates;

namespace Mario
{
    public class Mario : IMario,ICollidiable
    {
        private Vector2 marioLocation;
        public MarioState marioState { get; set; }
        private bool fall;
        public Rectangle Box
        {
            get
            {
                return new Rectangle((int)marioLocation.X, (int)marioLocation.Y, marioState.getWidth, marioState.getHeight);
                
            }
            
        }
        public Mario(Vector2 location)
        {
            marioLocation = location;
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
        public void BeSuperMario()
        {
            marioState.BeSuperMario();
        }
        public void BeNormalMario()
        {
            marioState.BeNormalMario();
        }
        public void BeFireMario()
        {
            marioState.BeFireMario();
        }
        public void BeStarMario()
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
            marioState.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            marioState.Draw(spriteBatch, marioLocation);
        }

        public ref Vector2 Getposition()
        {
            return ref marioLocation;
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
