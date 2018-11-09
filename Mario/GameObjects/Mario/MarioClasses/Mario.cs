using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using Game1;
using Mario.MarioStates.MarioMovementStates;
using Mario.MarioStates.MarioPowerupStates;
using Mario.Factory;
using System.Diagnostics;
using Mario.GameObjects.Decorators;

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
					if (newState.IsActive())
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
        private bool isCrouch;
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
		private int lives = 0;
		public int Lives { get =>lives; set => lives = value; }
		private int score = 0;
		public int Score { get => score; set => score= value; }
		private float scoreMultiplier = 1;
		public float ScoreMultiplier { set => scoreMultiplier = value; }

		public Mario(Vector2 location)
        {
            this.location = location;
			marioPowerupState = new NormalMarioPowerupState(this);
			marioMovementState = new RightIdleMarioMovementState(this);
			MarioSprite = SpriteFactory.Instance.CreateSprite(MarioFactory.Instance.GetSpriteDictionary[MarioPowerupState.GetType()][MarioMovementState.GetType()]);
            fall = false;
            Island = true;
            isCrouch = false;
            Physics = new PhysicsMario(this);
            
        }
		public void GoUp()
        {
            if (Island)
            {
                Island = false;
                MarioMovementState.GoUp();
                Physics.Jump();

            }
        }
        public bool IsUp()
        {
			return MarioMovementState.IsJumping();
        }
		public void GoDown()
		{
            MarioMovementState.GoDown();
            isCrouch = true;
        }
        public void GoLeft()
        {
           
            if (Island)
            {
                 MarioMovementState.GoLeft();
            }
            else
            {
                Physics.JumpLeft();
            }
        }
        public void GoRight()
        {
            
            if (Island)
            {
                MarioMovementState.GoRight();
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
        public void BeDead()
        {
            MarioPowerupState.BeDead();
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
		
		public bool IsActive()
        {
			return MarioPowerupState.IsActive();
        }
        public bool IsFalling()
        {
            return fall;
        }
        public void SetIsLandTrue()
        {
            Island = true;
        }
        public void SetIsLandFalse()
        {
            Island = false;
        }

        public void NoInput()
        {
            MarioMovementState.NoInput();
            Physics.NotJump();
            isCrouch = false;
        }
            
        public void ThrowProjectile()
        {
            if(MarioPowerupState.CanThrowProjectile())
            {
                MarioPowerupState.ThrowProjectile();
            }
        }

        public bool IsRunningLeft()
        {
            return MarioMovementState is LeftRunningMarioMovementState;
        }

        public bool IsRunningRight()
        {
            return MarioMovementState is RightRunningMarioMovementState;
        }
        public bool IsCrouching()
        {
            return isCrouch;
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
      
    }
}
