using Game1;
using Mario.Factory;
using Mario.MarioStates.MarioPowerupStates;
using Mario.XMLRead;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.GameObjects.Decorators
{
	class TransitionStateMarioDecorator:MarioDecorator
	{
		private double timer = 1.5f;
		private ISprite newSprite;
		private ISprite oldSprite;
		private ISprite currentSprite = null;

		public override Rectangle Box
		{
			get
			{
				return new Rectangle((int)Position.X, (int) Position.Y, oldSprite.Width, oldSprite.Height);
			}
		}
		public TransitionStateMarioDecorator(IMario mario) : base(mario)
		{

		}

		public TransitionStateMarioDecorator(IMario mario, MarioPowerupState marioPowerupState, MarioPowerupState newState) : base(mario)
		{
			Debug.WriteLine("Transition State Happend");
			newSprite = SpriteFactory.Instance.CreateSprite(MarioFactory.Instance.GetSpriteDictionary[marioPowerupState.MarioPowerupType.ToString()][MarioMovementState.MarioMovementType.ToString()]);
			oldSprite = SpriteFactory.Instance.CreateSprite(MarioFactory.Instance.GetSpriteDictionary[newState.MarioPowerupType.ToString()][MarioMovementState.MarioMovementType.ToString()]);
			currentSprite = oldSprite;
		}

		public override void Update()
		{
			timer -= ItemManager.Instance.CurrentGameTime.ElapsedGameTime.TotalSeconds;
			if(timer >= 0.0)
			{
				if (currentSprite.Equals(oldSprite))
				{
					currentSprite = newSprite;
				}
				else
				{
					currentSprite = oldSprite;
				}
			}
			else
			{
				RemoveTransitionState();
			}
			base.Update();
		}

		private void RemoveTransitionState()
		{
			
			ItemManager.Instance.Mario = DecoratedMario;
			if(DecoratedMario.MarioPowerupState.MarioPowerupType == Enums.MarioPowerupType.Dead)
			{
				Game1.Instance.Reset();
			}
		}

		public override void TakeDamage()
		{
			//NO-OP, invincible while transitioning between powerupstates
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			currentSprite.Draw(spriteBatch, DecoratedMario.Position);
		}
	}
}
