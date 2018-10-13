﻿using Game1;
using Mario.Enums;

namespace Mario.MarioStates.MarioMovementStates
{
	internal class LeftJumpingMarioMovementState : MarioMovementState
	{
		public LeftJumpingMarioMovementState(IMario mario) : base(mario)
		{
		}

		public override MarioMovementType MarioMovementType => MarioMovementType.LeftJump;

		public override void Down()
		{
			Mario.MarioMovementState = new LeftIdleMarioMovementState(Mario);
		}
	}
}