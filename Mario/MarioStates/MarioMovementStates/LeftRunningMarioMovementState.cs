using Game1;
using Mario.Enums;

namespace Mario.MarioStates.MarioMovementStates
{
	internal class LeftRunningMarioMovementState : MarioMovementState
	{
		public LeftRunningMarioMovementState(IMario mario) : base(mario)
		{
		}

		public override MarioMovementType MarioMovementType => MarioMovementType.LeftRun;

		public override void Down()
		{
			Mario.MarioMovementState = new LeftCrouchingMarioMovementState(Mario);
		}

		public override void Right()
		{
			Mario.MarioMovementState = new LeftIdleMarioMovementState(Mario);
		}

		public override void Up()
		{
			Mario.MarioMovementState = new LeftJumpingMarioMovementState(Mario);
		}
	}
}