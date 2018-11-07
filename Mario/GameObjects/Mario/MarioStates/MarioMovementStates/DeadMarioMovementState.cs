using Game1;
using Mario.Enums;
using Mario.Sound;

namespace Mario.MarioStates.MarioMovementStates
{
	internal class DeadMarioMovementState : MarioMovementState
	{
		public DeadMarioMovementState(IMario mario) : base(mario)
		{

            Motion.MarioDie.Play();
        }

        public override MarioMovementType MarioMovementType => MarioMovementType.Dead;

		public override bool IsActive()
		{
			return false;
		}
	}
}