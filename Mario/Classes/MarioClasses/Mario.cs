using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using Game1;
using Mario.MarioStates;
using Mario.Enums;
using Mario.MarioStates.MarioMovementStates;
using Mario.MarioStates.MarioPowerupStates;
using Mario.Factory;

namespace Mario
{
    public class Mario : IMario,ICollidiable
    {
        private Vector2 location = Vector2.Zero;
		public Vector2 Location { get => location; set => location = value; }
		public MarioMovementState MarioMovementState { get; set; }
		public MarioPowerupState MarioPowerupState { get; set; }

		private ISprite marioSprite { get; set; }

        private bool fall;
        public Rectangle Box
        {
            get
            {
				return new Rectangle((int)location.X, (int)location.Y, marioSprite.Width, marioSprite.Height);                
            }
            
        }

		public MarioMovementType MarioMovementType => MarioMovementState.MarioMovementType;

		public MarioPowerupType MarioPowerupType => MarioPowerupState.MarioPowerupType;
        public float XVelocity { get ; set; }
        public float YVelocity { get ; set; }
        public float XVelocityMax { get ; set; }
        public float YVelocityMax { get ; set; }
        private Physics physics;
        public Mario(Vector2 location)
        {
            this.location = location;
            MarioMovementState = new RightIdleMarioMovementState(this);
			MarioPowerupState = new NormalMarioPowerupState(this);
            
			marioSprite = MarioFactory.Instance.GetSpriteDictionary[MarioPowerupState.MarioPowerupType.ToString()][MarioMovementState.MarioMovementType.ToString()];
			fall = false;
            XVelocity = 0;
            YVelocity = 0;
            XVelocityMax = 3.5f;
            YVelocityMax = 3.5f;
            physics = new Physics(this);

        }
		public void Up()
        {
            MarioMovementState.Up();
            fall = false;
            location.Y -= 3;
        }
		public void Down()
		{
			
			if(!(MarioPowerupState.MarioPowerupType == MarioPowerupType.Normal && MarioMovementState.MarioMovementType != MarioMovementType.LeftJump && MarioMovementState.MarioMovementType != MarioMovementType.RightJump))
			{
				MarioMovementState.Down();
			}
            fall = true;
            location.Y += 3;
        }
        public void Left()
        {
            MarioMovementState.Left();
            location.X -=3;

        }
        public void Right()
        {
            MarioMovementState.Right();
            location.X += 3;
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
			marioSprite = MarioFactory.Instance.GetSpriteDictionary[MarioPowerupState.MarioPowerupType.ToString()][MarioMovementState.MarioMovementType.ToString()];
            marioSprite.Update();
            physics.Update();
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
            return MarioPowerupState.MarioPowerupType == MarioPowerupType.Dead;
        }
        public bool Isfalling()
        {
            return fall;
        }

		public void NoInput()
		{
			MarioMovementState.NoInput();
		}
	}
}
