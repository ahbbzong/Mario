using Game1;

namespace Mario.MarioStates.MarioPowerupStates
{
	internal class NormalMarioPowerupState : MarioPowerupState
	{
		public NormalMarioPowerupState(IMario mario) : base(mario)
		{
        }


        public override void BeNormal()
		{
		}

		public override void TakeDamage()
		{
            
            Mario.BeDead();
            Mario.Physics.YVelocity = PhysicsUtil.upForce;
        }
     
    }
}