﻿using Game1;

namespace Mario.MarioStates.MarioPowerupStates
{
	internal class NormalMarioPowerupState : MarioPowerupState
	{
		public NormalMarioPowerupState(IMario mario) : base(mario)
		{
            //Motion.MarioOneUp.Play();
        }


        public override void BeNormal()
		{
			//override NO-OP
		}

		public override void TakeDamage()
		{
			//base.TakeDamage();
			Mario.BeDead();
		}
     
    }
}