using Mario.Interfaces.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1;
using Mario.Enums;

namespace Mario.MarioStates.MarioMovementStates
{
	public abstract class MarioMovementState : IMovementEventBehavior
	{
		private IMario mario;
		protected IMario Mario { get => mario; set => mario = value; }

		public abstract MarioMovementType MarioMovementType { get; }

		protected MarioMovementState(IMario mario)
		{
			Mario = mario;
		}
		public virtual void Down()
		{
			//NO-OP by default
		}

		public virtual void Left()
		{
            mario.Getposition().X -= 3;
		}

		public virtual void Right()
		{
            mario.Getposition().X += 3;
        }

		public virtual void Up()
		{
            mario.Getposition().Y -= 3;
        }

		public virtual void NoInput()
		{
		}
	}
}
