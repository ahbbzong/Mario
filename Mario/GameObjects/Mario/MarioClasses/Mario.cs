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
					MarioSprite = SpriteFactory.Instance.CreateSprite(MarioFactory.Instance.GetSpriteDictionary[MarioPowerupState.MarioPowerupType.ToString()][MarioMovementState.MarioMovementType.ToString()]);
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
					ItemManager.Instance.Mario = new TransitionStateMarioDecorator(this, marioPowerupState, newState);
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
			MarioSprite = SpriteFactory.Instance.CreateSprite(MarioFactory.Instance.GetSpriteDictionary[MarioPowerupState.MarioPowerupType.ToString()][MarioMovementState.MarioMovementType.ToString()]);


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
            return MarioMovementState.MarioMovementType == MarioMovementType.LeftJump|| MarioMovementState.MarioMovementType == MarioMovementType.RightJump;
        }
		public void Down()
		{
			
			if(!(MarioPowerupState.MarioPowerupType == MarioPowerupType.Normal && MarioMovementState.MarioMovementType != MarioMovementType.LeftJump && MarioMovementState.MarioMovementType != MarioMovementType.RightJump))
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
            MarioPowerupState.BeStar();
        }
        public bool IsSuperMario()
        {
            return MarioPowerupState.MarioPowerupType == MarioPowerupType.Big;
        }
        public bool IsFireMario()
        {
			return MarioPowerupState.MarioPowerupType == MarioPowerupType.Fire;
        }

        public bool IsNormalMario()
        {
			return MarioPowerupState.MarioPowerupType == MarioPowerupType.Normal;
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
            return MarioPowerupState.MarioPowerupType == MarioPowerupType.Dead;
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
            if(!IsUp())
			MarioMovementState.NoInput();
            Physics.ApplyFriction();
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
            return MarioMovementState.MarioMovementType == MarioMovementType.LeftRun;
        }

        public bool IsRight()
        {
            return MarioMovementState.MarioMovementType == MarioMovementType.RightRun;
        }

		public void TakeDamage()
		{
			MarioPowerupState.TakeDamage();
		}
	}
}
