using Game1;
using Mario.Enums;

namespace Mario.MarioStates.MarioPowerupStates
{
	internal class FireMarioPowerupState : MarioPowerupState
	{
		public FireMarioPowerupState(IMario mario) : base(mario)
		{
		}

		public override MarioPowerupType MarioPowerupType => MarioPowerupType.Fire;

		public override void BeFire()
		{
			//override NO-OP
		}
	}
}