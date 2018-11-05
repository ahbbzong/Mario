using Game1;
using Mario.Enums;

namespace Mario.MarioStates.MarioPowerupStates
{
	internal class NormalMarioPowerupState : MarioPowerupState
	{
		public NormalMarioPowerupState(IMario mario) : base(mario)
		{
		}
		

		public override void BeNormal()
		{
			//override NO-OP
		}

		public override void TakeDamage()
		{
			base.TakeDamage();
			Mario.BeDead();
		}
	}
}