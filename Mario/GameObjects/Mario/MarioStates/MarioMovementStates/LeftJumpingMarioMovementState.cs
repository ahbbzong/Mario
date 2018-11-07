using Game1;
using Mario.Enums;
using Mario.Sound;

namespace Mario.MarioStates.MarioMovementStates
{
	internal class LeftJumpingMarioMovementState : MarioMovementState
	{
		public LeftJumpingMarioMovementState(IMario mario) : base(mario)
		{

        }

		public override MarioMovementType MarioMovementType => MarioMovementType.LeftJump;

		public override void Down()
		{
			Mario.MarioMovementState = new LeftIdleMarioMovementState(Mario);
		}

		public override void NoInput()
		{
			Mario.MarioMovementState = new LeftIdleMarioMovementState(Mario);
		}
        public override void Right()
        {
            //No need to right
        }

    }
}