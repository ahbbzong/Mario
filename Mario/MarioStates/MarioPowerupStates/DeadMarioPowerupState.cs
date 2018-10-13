using Game1;
using Mario.Enums;

namespace Mario.MarioStates.MarioPowerupStates
{
	internal class DeadMarioPowerupState : MarioPowerupState
	{
		public DeadMarioPowerupState(IMario mario) : base(mario)
		{
		}

		public override MarioPowerupType MarioPowerupType => MarioPowerupType.Dead;

		public override void Dead()
		{
			//override with NO -OP, no need to reinstance every frame
		}
	}
}