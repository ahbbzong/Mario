using Game1;
using Mario.XMLRead;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.GameObjects.Decorators
{
	class TransitionStateMarioDecorator:MarioDecorator
	{
		private double timer = 1.5f;
		public TransitionStateMarioDecorator(IMario mario) : base(mario)
		{

		}

		public override void Update()
		{
			timer -= ItemManager.Instance.CurrentGameTime.ElapsedGameTime.TotalSeconds;
			if(timer <= 0.0)
			{
				RemoveTransitionState();
			}
			base.Update();
		}

		private void RemoveTransitionState()
		{
			ItemManager.Instance.Mario = DecoratedMario;
		}

		public override void TakeDamage()
		{

		}
	}
}
