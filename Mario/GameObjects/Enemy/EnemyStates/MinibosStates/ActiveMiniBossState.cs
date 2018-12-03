using Game1;
using Mario.AbstractClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.GameObjects
{
	class ActiveMiniBossState : EnemyState
	{
		public ActiveMiniBossState(IEnemy enemy) : base(enemy)
		{
		}

		public override void Beflipped()
		{
			base.Beflipped();
		}

		public override void BeStomped()
		{
			base.BeStomped();
		}

		public override bool IsFlipped()
		{
			return base.IsFlipped();
		}

		public override bool IsGoomba()
		{
			return base.IsGoomba();
		}

		public override bool IsKoopa()
		{
			return base.IsKoopa();
		}

		public override void MiniBossStompReact()
		{
			base.MiniBossStompReact();
		}

		public override void TurnLeft()
		{
			base.TurnLeft();
		}

		public override void TurnRight()
		{
			base.TurnRight();
		}

		public override void Update()
		{
			base.Update();
		}
	}
}
