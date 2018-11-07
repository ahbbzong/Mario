using Game1;
using Mario.Enums;
using Mario.Sound;

namespace Mario.MarioStates.MarioMovementStates
{
	internal class RightJumpingMarioMovementState : MarioMovementState
	{
		public RightJumpingMarioMovementState(IMario mario):base(mario)
		{
		}

		public override MarioMovementType MarioMovementType => MarioMovementType.RightJump;

		public override void Down()
		{
			Mario.MarioMovementState = new RightIdleMarioMovementState(Mario);
		}

		public override void NoInput()
		{
			Mario.MarioMovementState = new RightIdleMarioMovementState(Mario);
		}
        public override void Left()
        {
            //No need to left
        }
    }
}