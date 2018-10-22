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
        public bool Island { get; set; }
        public Rectangle Box
        {
            get
            {
				return new Rectangle((int)location.X, (int)location.Y, marioSprite.Width, marioSprite.Height);                
            }
            
        }

		public MarioMovementType MarioMovementType => MarioMovementState.MarioMovementType;

		public MarioPowerupType MarioPowerupType => MarioPowerupState.MarioPowerupType;

        public Physics physics { get; set; }
        public Mario(Vector2 location)
        {
            this.location = location;
            MarioMovementState = new RightIdleMarioMovementState(this);
			MarioPowerupState = new NormalMarioPowerupState(this);
            
			marioSprite = SpriteFactory.Instance.CreateSprite(MarioFactory.Instance.GetSpriteDictionary[MarioPowerupState.MarioPowerupType.ToString()][MarioMovementState.MarioMovementType.ToString()]);
			fall = false;
            Island = false;
            physics = new Physics(this);
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
			marioSprite = SpriteFactory.Instance.CreateSprite(MarioFactory.Instance.GetSpriteDictionary[MarioPowerupState.MarioPowerupType.ToString()][MarioMovementState.MarioMovementType.ToString()]);
            marioSprite.Update();
            if (!Island)
            {
                physics.Update();
            }
            if(physics.YVelocity>0)
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
        public void IsLandTrue()
        {
            physics.ResetGravity();
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
            physics.ApplyFriction();
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
    }
}
