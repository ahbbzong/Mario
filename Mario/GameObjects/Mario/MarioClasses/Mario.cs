using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using Game1;
using Mario.MarioStates;
using Mario.MarioStates.MarioMovementStates;
using Mario.MarioStates.MarioPowerupStates;
using Mario.Factory;
using System.Diagnostics;
using System.Threading;
using Mario.XMLRead;
using Mario.GameObjects.Decorators;
using Mario.Enums;

namespace Mario
{
    public class Mario : IMario,ICollidable
    {
        private Vector2 location = Vector2.Zero;
		public Vector2 Position { get => location; set => location = value; }
		private MarioMovementState marioMovementState;
		public MarioMovementState MarioMovementState
		{
			get
			{
				return marioMovementState;
			}
			set
			{
				try
				{
					marioMovementState = value;
					MarioSprite = SpriteFactory.Instance.CreateSprite(MarioFactory.Instance.GetSpriteDictionary[MarioPowerupState.GetType()][MarioMovementState.GetType()]);
				}catch(System.Collections.Generic.KeyNotFoundException )
				{
					Debug.WriteLine("ERROR: " + MarioPowerupState.GetType().ToString() + " , " + MarioMovementState.MarioMovementType.ToString());
				}
			}
		}
		private MarioPowerupState marioPowerupState;
		public MarioPowerupState MarioPowerupState {
			get {
				return marioPowerupState;
			}
			set
			{
				try
				{
					MarioPowerupState newState = value;
					if (!(newState is DeadMarioPowerupState))
					{
						GameObjectManager.Instance.Mario = new TransitionStateMarioDecorator(this, marioPowerupState, newState);
					}
					else
					{
						GameObjectManager.Instance.Mario = new TransitionStateMarioDecorator(this, newState, newState);
					}
					marioPowerupState = newState;
					
				}
				catch (System.Collections.Generic.KeyNotFoundException )
				{
					Debug.WriteLine("ERROR: " + MarioPowerupState.GetType().ToString() + " , " + MarioMovementState.MarioMovementType.ToString() + " is not found in the dictionary");
				}
			}
		}
		public ISprite MarioSprite { get; set; }

        private bool fall;
        public bool Island { get; set; }
        public Rectangle Box
        {
            get
            {
				return new Rectangle((int)location.X, (int)location.Y, MarioSprite.Width, MarioSprite.Height);                
            }
            
        }
		

        public PhysicsMario Physics { get; set; }
        public Vector2 Velocity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Vector2 Force { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Mario(Vector2 location)
        {
            this.location = location;
			marioPowerupState = new NormalMarioPowerupState(this);
			marioMovementState = new RightIdleMarioMovementState(this);
			MarioSprite = SpriteFactory.Instance.CreateSprite(MarioFactory.Instance.GetSpriteDictionary[MarioPowerupState.GetType()][MarioMovementState.GetType()]);
            fall = false;
            Island = true;
            Physics = new PhysicsMario(this);
            
        }
		public void Up()
        {
            if (Island)
            {
                Island = false;
                MarioMovementState.Up();
                Physics.Jump();
            }
        }
        public bool IsUp()
        {
            return MarioMovementState is LeftJumpingMarioMovementState|| MarioMovementState is RightJumpingMarioMovementState;
        }
		public void Down()
		{
            MarioMovementState.Down();
        }
        public void Left()
        {
           
            if (Island)
            {
                 MarioMovementState.Left();
            }
            else
            {
                Physics.JumpLeft();
            }
        }
        public void Right()
        {
            
            if (Island)
            {
                MarioMovementState.Right();
            }
            else
            {
                Physics.JumpRight();
            }
        }
        public void Sprint()
        {
            if (Island)
            {
                Physics.Sprint();
            }
        }
        public void Dead()
        {
			MarioPowerupState = new DeadMarioPowerupState(this);
           MarioMovementState = new DeadMarioMovementState(this);
        }
        public void BeSuper()
        {
            MarioPowerupState.BeSuper();
        }
        public void BeNormal()
        {
            MarioPowerupState.BeNormal();
        }
        public void BeFire()
        {
            MarioPowerupState.BeFire();
        }
        public void BeStar()
        {
			GameObjectManager.Instance.Mario = new StarMarioDecorator(this);
        }
        public bool IsStarMario()
        {
			return false;
        }

        public void Update()
        {
			MarioSprite.Update();
            Physics.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
			MarioSprite.Draw(spriteBatch,location);
        }
		
		public bool IsDead()
        {
            return MarioPowerupState is DeadMarioPowerupState;
        }
        public bool Isfalling()
        {
            return fall;
        }
        public void IsLandTrue()
        {
            Island = true;
        }
        public void IsLandFlase()
        {
            Island = false;
        }

        public void NoInput()
        {
            MarioMovementState.NoInput();
            Physics.NotJump();
        }
            
        public void ThrowFireball()
        {
            if(MarioPowerupState is FireMarioPowerupState)
            {
                MarioPowerupState.ThrowFireball();
            }
        }

        public bool IsLeft()
        {
            return MarioMovementState is LeftRunningMarioMovementState;
        }

        public bool IsRight()
        {
            return MarioMovementState is RightRunningMarioMovementState;
        }
        public bool IsCrouch()
        {
            return (MarioMovementState is LeftCrouchingMarioMovementState
                  || MarioMovementState is RightCrouchingMarioMovementState)
                  &&(!(MarioPowerupState is NormalMarioPowerupState));
        }
		public void TakeDamage()
		{
			MarioPowerupState.TakeDamage();
		}

		public void Draw(SpriteBatch spriteBatch, Color c)
		{

			MarioSprite.Draw(spriteBatch, location,c);
		}

        public void SetFalling(bool fallState)
        {
            fall = fallState;
        }
        public bool IsLandResponse()
        {
            return Island;
        }
        public void SetContainsItem(String item)
        {
        }
    }
}
