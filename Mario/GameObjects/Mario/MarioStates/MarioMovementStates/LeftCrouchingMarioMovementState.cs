using Game1;
using Mario.Enums;

namespace Mario.MarioStates.MarioMovementStates
{
	internal class LeftCrouchingMarioMovementState : MarioMovementState
	{
		public LeftCrouchingMarioMovementState(IMario mario) : base(mario)
		{

		}

		public override MarioMovementType MarioMovementType => MarioMovementType.LeftCrouch;

		public override void Up()
		{
			Mario.MarioMovementState = new LeftIdleMarioMovementState(Mario);
		}

		public override void NoInput()
		{
			Mario.MarioMovementState = new LeftIdleMarioMovementState(Mario);
		}
        public override void Left()
        {
        }

        public override void Right()
        {
        }

    }
}