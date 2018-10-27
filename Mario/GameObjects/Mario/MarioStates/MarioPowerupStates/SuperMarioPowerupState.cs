using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1;
using Mario.Enums;

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
		}
	}
}
