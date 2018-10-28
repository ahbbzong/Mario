using Game1;
using Mario.Enums;

namespace Mario.MarioStates.MarioMovementStates
{
	internal class LeftIdleMarioMovementState : MarioMovementState
	{
		public LeftIdleMarioMovementState(IMario mario) : base(mario)
		{
		}

		public override MarioMovementType MarioMovementType => MarioMovementType.LeftIdle;

		public override void Down()
		{
			Mario.MarioMovementState = new LeftCrouchingMarioMovementState(Mario);
		}

		public override void Left()
		{
			Mario.MarioMovementState = new LeftRunningMarioMovementState(Mario);
            Mario.Physics.MoveLeft();
        }

        public override void Right()
		{
			Mario.MarioMovementState = new RightIdleMarioMovementState(Mario);
            Mario.Physics.MoveRight();
        }

        public override void Up()
		{
			Mario.MarioMovementState = new LeftJumpingMarioMovementState(Mario);
        }
	}
}