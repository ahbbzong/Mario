﻿using Game1;
using Mario.Enums;
using Mario.Sound;

namespace Mario.MarioStates.MarioPowerupStates
{
	internal class DeadMarioPowerupState : MarioPowerupState
	{
		public DeadMarioPowerupState(IMario mario) : base(mario)
		{
            MotionSound.MarioDie.Play();

        }

        public override bool IsActive()
		{
			return false;
		}
		public override void BeDead()
		{
			//override with NO -OP, no need to reinstance every frame
		}
	}
}