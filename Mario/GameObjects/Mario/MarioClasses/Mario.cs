using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using Game1;
using Mario.MarioStates;
using Mario.Enums;
using Mario.MarioStates.MarioMovementStates;
using Mario.MarioStates.MarioPowerupStates;
using Mario.Factory;
using System.Diagnostics;
using System.Threading;
using Mario.XMLRead;
using Mario.GameObjects.Decorators;

namespace Mario
{
    public class Mario : IMario,ICollidiable
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
					MarioSprite = SpriteFactory.Instance.CreateSprite(MarioFactory.Instance.GetSpriteDictionary[MarioPowerupState.GetType()][MarioMovementState.MarioMovementType.ToString()]);
				}catch(System.Collections.Generic.KeyNotFoundException ex)
				{
					Debug.WriteLine("ERROR: " + MarioPowerupState.MarioPowerupType.ToString() + " , " + MarioMovementState.MarioMovementType.ToString());
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
						ItemManager.Instance.Mario = new TransitionStateMarioDecorator(this, marioPowerupState, newState);
					}
					else
					{
						ItemManager.Instance.Mario = new TransitionStateMarioDecorator(this, newState, newState);
					}
					marioPowerupState = newState;
					
				}
				catch (System.Collections.Generic.KeyNotFoundException ex)
				{
					Debug.WriteLine("ERROR: " + MarioPowerupState.MarioPowerupType.ToString() + " , " + MarioMovementState.MarioMovementType.ToString());
				}
			}
		}
		private ISprite MarioSprite { get; set; }

        private bool fall;
        public bool Island { get; set; }
        public Rectangle Box
        {
            get
            {
				return new Rectangle((int)location.X, (int)location.Y, MarioSprite.Width, MarioSprite.Height);                
            }
            
        }

		public MarioMovementType MarioMovementType => MarioMovementState.MarioMovementType;

		public MarioPowerupType MarioPowerupType => MarioPowerupState.MarioPowerupType;

        public Physics Physics { get; set; }
        public Mario(Vector2 location)
        {
            this.location = location;
			marioPowerupState = new NormalMarioPowerupState(this);
			marioMovementState = new RightIdleMarioMovementState(this);
			MarioSprite = SpriteFactory.Instance.CreateSprite(MarioFactory.Instance.GetSpriteDictionary[MarioPowerupState.GetType()][MarioMovementState.MarioMovementType.ToString()]);
			

			fall = false;
            Island = false;
            Physics = new Physics(this);
        }
		public void Up()
        {
            if(!IsUp())
            MarioMovementState.Up();
        }
        public bool IsUp()
        {
            return MarioMovementState is LeftJumpingMarioMovementState|| MarioMovementState is RightJumpingMarioMovementState;
        }
		public void Down()
		{
			
			if(!(MarioPowerupState is NormalMarioPowerupState && !(MarioMovementState is LeftJumpingMarioMovementState) && !(MarioMovementState is RightJumpingMarioMovementState)))
			{
				MarioMovementState.Down();
			}
        }
        public void Left()
        {
            if (!IsRight())
            {
                MarioMovementState.Left();
            }

        }
        public void Right()
        {
            if (!IsLeft())
            {
                MarioMovementState.Right();
            }
        }
        public void Dead()
        {
            MarioPowerupState.Dead();
            MarioMovementState = new DeadMarioMovementState(this);
        }
        public void BeSuper()
        {
            location.Y -= 5;
            MarioPowerupState.BeSuper();
        }
        public void BeNormal()
        {
            MarioPowerupState.BeNormal();
        }
        public void BeFire()
        {
            location.Y -= 5;
            MarioPowerupState.BeFire();
        }
        public void BeStar()
        {
			ItemManager.Instance.Mario = new StarMarioDecorator(this);
        }
        public bool IsSuperMario()
        {
			return MarioPowerupState is SuperMarioPowerupState;
        }
        public bool IsFireMario()
        {
			return MarioPowerupState is FireMarioPowerupState;
        }

        public bool IsNormalMario()
        {
			return MarioPowerupState is NormalMarioPowerupState;
        }
        public bool IsStarMario()
        {
			return false;
        }

        public void Update()
        {
			MarioSprite.Update();
            if (!Island)
            {
                Physics.Update();
            }
            if(Physics.YVelocity>0)
            {
                fall = true;
            }
            else
            {
                fall = false;
            }
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
            Physics.ResetGravity();
            Island = true;
            MarioMovementState.NoInput();
        }
        public void IsLandFlase()
        {
            Island = false;
        }

        public void NoInput()
        {
            if (!IsUp())
            {
                MarioMovementState.NoInput();
                Physics.ApplyFriction();
            }
        }
            
            
        
        public void ThrowFireball()
        {
            if(MarioPowerupState.MarioPowerupType == MarioPowerupType.Fire)
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

		public void TakeDamage()
		{
			MarioPowerupState.TakeDamage();
		}

		public void Draw(SpriteBatch spriteBatch, Color c)
		{

			MarioSprite.Draw(spriteBatch, location,c);
		}
	}
}
