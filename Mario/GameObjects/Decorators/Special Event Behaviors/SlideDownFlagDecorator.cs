using Game1;
using Mario.BlockStates;
using Mario.Display;
using Mario.HeadUpDesign;
using Mario.Sound;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
		private float timeToFall = DecoratorUtil.fallFlag;
		private SlidingStates slidingState = SlidingStates.INITIAL;

        public SlideDownFlagDecorator(IMario mario, Vector2 locationOfBase, float timeToFall):base(mario)
		{

			this.locationOfBase = locationOfBase;
			this.timeToFall = timeToFall;
			slidingState = SlidingStates.SLIDING_DOWN;
            ScoringSystem.Instance.AddPointsForFinalPole(mario.Box);
            SoundManager.StopSong();
            SoundManager.Instance.PlaySoundEffect("clearStage");
        }

		public override void Update()
		{
			switch (slidingState)
			{
				case SlidingStates.SLIDING_DOWN:
					if (Math.Abs(DecoratedMario.Position.Y - locationOfBase.Y) > DecoratorUtil.locationOffset)
					{
						DecoratedMario.Position += Vector2.UnitY * DecoratorUtil.locationOffset;
					}
					else
					{
						slidingState = SlidingStates.WALKING_RIGHT;
					}
					break;
				case SlidingStates.WALKING_RIGHT:
					if (DecoratedMario.Position.X > GameObjectManager.Instance.EndOfLevelXPosition + DecoratorUtil.walkRightOffset) 
					{
						slidingState = SlidingStates.EXIT;
					}
					else
					{
						this.DecoratedMario.GoRight();
						this.DecoratedMario.Position += Vector2.UnitX * DecoratorUtil.Double;
						timeToFall--;

                    }

                    break;
				default:
					RemoveSelf();
					break;
			}
			
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
