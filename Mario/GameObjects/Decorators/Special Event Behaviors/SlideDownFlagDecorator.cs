using Game1;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.GameObjects.Decorators.Special_Event_Behaviors
{
	class SlideDownFlagDecorator :MarioSpecialEventDecorator
	{
		private Vector2 locationOfBase = Vector2.Zero;
		private float timeToFall = 1;


		public SlideDownFlagDecorator(IMario mario, Vector2 locationOfBase, float timeToFall):base(mario)
		{
			this.locationOfBase = locationOfBase;
			this.timeToFall = timeToFall;
		}

		public override void Update()
		{
			if(Math.Abs(DecoratedMario.Position.Y - locationOfBase.Y) > 1)
			{
				DecoratedMario.Position += Vector2.UnitY * 10;
			}
			else
			{
				RemoveSelf();
			}
		}

		public override void RemoveSelf()
		{
			base.RemoveSelf();
		}
	}
}
