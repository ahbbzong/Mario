using Game1;
using Mario.HeadUpDesign;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.GameObjects.Decorators.Special_Event_Behaviors
{
	internal enum SlidingStates
	{
		SLIDING_DOWN = 0,
		WALKING_RIGHT = 1,
		INITIAL = 2,
		EXIT = 3
	}
	class SlideDownFlagDecorator :MarioSpecialEventDecorator
	{
		private Vector2 locationOfBase = Vector2.Zero;
		private float timeToFall = 1;
		private SlidingStates slidingState = SlidingStates.INITIAL;

		public SlideDownFlagDecorator(IMario mario, Vector2 locationOfBase, float timeToFall):base(mario)
		{

			this.locationOfBase = locationOfBase;
			this.timeToFall = timeToFall;
			slidingState = SlidingStates.SLIDING_DOWN;
            ScoringSystem.Instance.AddPointsForFinalPole(mario.Box);
        }

		public override void Update()
		{
			switch (slidingState)
			{
				case SlidingStates.SLIDING_DOWN:
					if (Math.Abs(DecoratedMario.Position.Y - locationOfBase.Y) > 10)
					{
						DecoratedMario.Position += Vector2.UnitY * 10;
					}
					else
					{
						slidingState = SlidingStates.WALKING_RIGHT;
					}
					break;
				case SlidingStates.WALKING_RIGHT:
					if (DecoratedMario.Position.X > GameObjectManager.Instance.EndOfLevelX + 400) 
					{
						slidingState = SlidingStates.EXIT;
					}
					else
					{
						this.DecoratedMario.GoRight();
						this.DecoratedMario.Position += Vector2.UnitX * 2;
						timeToFall--;
					}

					break;
				default:
					RemoveSelf();
					break;
			}
			Debug.WriteLine(slidingState.ToString() + "," + DecoratedMario.Position.Y + " , " + locationOfBase.Y);
			
		}

		public override bool IsActive()
		{
			return false;
		}
		public override void RemoveSelf()
		{

			base.RemoveSelf();
		}
		
	}
}
