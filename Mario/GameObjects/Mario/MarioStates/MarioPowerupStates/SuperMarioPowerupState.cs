using Game1;

namespace Mario.MarioStates.MarioPowerupStates
{
	public class SuperMarioPowerupState : MarioPowerupState
	{
		public SuperMarioPowerupState(IMario mario) : base(mario)
		{

        }

        public override void BeSuper()
		{
			//override NO-OP
		}

		public override void TakeDamage()
		{
			Mario.BeNormal();
            Timer.ExtendTime();
        }
    }
}
