using Game1;
using Mario.Enums;

namespace Mario.MarioStates.MarioMovementStates
{
	internal class RightIdleMarioMovementState : MarioMovementState
	{
		public RightIdleMarioMovementState(IMario mario) : base(mario)
		{
		}

		public override MarioMovementType MarioMovementType => MarioMovementType.RightIdle;

		public override void Up()
		{
			Mario.MarioMovementState = new RightJumpingMarioMovementState(Mario);
		}
		public override void Down()
		{
			Mario.MarioMovementState = new RightCrouchingMarioMovementState(Mario);
		}

		public override void Left()
		{
			Mario.MarioMovementState = new LeftIdleMarioMovementState(Mario);
		}

		public override void Right()
		{
			Mario.MarioMovementState = new RightRunningMarioMovementState(Mario);
		}
	}
}