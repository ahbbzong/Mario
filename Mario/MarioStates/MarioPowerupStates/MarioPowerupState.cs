using Mario.Enums;
using Mario.Interfaces.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1;
using Mario.XMLRead;

namespace Mario.MarioStates.MarioPowerupStates
{
	public abstract class MarioPowerupState : IPowerupEventBehavior
	{
		private IMario mario;
		protected IMario Mario { get => mario; set => mario = value; }
		public MarioPowerupState(IMario mario)
		{
			this.Mario = mario;
		}
		public abstract MarioPowerupType MarioPowerupType { get; }

		public virtual void BeFire()
		{
			Mario.MarioPowerupState = new FireMarioPowerupState(Mario);
		}
		public virtual void BeNormal()
		{
			Mario.MarioPowerupState = new NormalMarioPowerupState(Mario);
		}
		public virtual void BeStar()
		{
			//TO -DO abstract starman to decorator
		}
		public virtual void BeSuper()
		{
			Mario.MarioPowerupState = new SuperMarioPowerupState(Mario);
		}
		public virtual void Dead()
		{
			Mario.MarioPowerupState = new DeadMarioPowerupState(Mario);
		}
        public virtual void ThrowFireball()
        {
            //May need to override
        }
    }
}
