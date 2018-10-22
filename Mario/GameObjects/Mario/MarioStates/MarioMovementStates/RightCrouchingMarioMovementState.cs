﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mario.Enums;
using Game1;
namespace Mario.MarioStates.MarioMovementStates
{
	public class RightCrouchingMarioMovementState : MarioMovementState
	{
		public RightCrouchingMarioMovementState(IMario mario) : base(mario)
		{

		}
		public override MarioMovementType MarioMovementType => MarioMovementType.RightCrouch;


		public override void Up()
		{
			Mario.MarioMovementState = new RightIdleMarioMovementState(Mario);
		}

		public override void NoInput()
		{
			Mario.MarioMovementState = new RightIdleMarioMovementState(Mario);
		}
        public override void Left()
        {
        }

        public override void Right()
        {
        }
    }
}