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
            mario.Physics.MoveLeft();
        }

		public virtual void Right()
		{
            mario.Physics.MoveRight();
        }
		public virtual void Up()
		{

        }
		public virtual void NoInput()
		{

		}
	}
}
