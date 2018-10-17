using Game1;
using Mario.Enums;

namespace Mario.MarioStates.MarioMovementStates
{
	internal class DeadMarioMovementState : MarioMovementState
	{
		public DeadMarioMovementState(IMario mario) : base(mario)
		{
		}

        public override MarioMovementType MarioMovementType => MarioMovementType.Dead;

        public override void Left()
        {
        }

        public override void Right()
        {
        }

        public override void Up()
        {
        }
    }
}