using Game1;
using Mario.Enums;
using Mario.Sound;

namespace Mario.MarioStates.MarioPowerupStates
{
	internal class DeadMarioPowerupState : MarioPowerupState
	{
		public DeadMarioPowerupState(IMario mario) : base(mario)
		{
            Motion.MarioPowerUp.Play();
        }

        public override void Dead()
		{
			//override with NO -OP, no need to reinstance every frame
		}
	}
}