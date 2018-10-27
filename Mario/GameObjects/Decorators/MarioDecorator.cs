using Game1;
using Mario.Enums;
using Mario.Interfaces.GameObjects;
using Mario.MarioStates.MarioMovementStates;
using Mario.MarioStates.MarioPowerupStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.GameObjects.Decorators
{
	abstract class MarioDecorator: GameObjectDecorator, IMario
	{
		protected MarioDecorator(IMario mario):base(mario)
		{

		}

		public virtual Rectangle Box => DecoratedMario.Box;
		
		public MarioMovementState MarioMovementState { get => DecoratedMario.MarioMovementState; set => DecoratedMario.MarioMovementState = value; }
		public MarioPowerupState MarioPowerupState { get => DecoratedMario.MarioPowerupState; set => DecoratedMario.MarioPowerupState = value; }
		public Physics Physics { get => DecoratedMario.Physics; set => DecoratedMario.Physics = value; }
		
		protected IMario DecoratedMario { get => (IMario)DecoratedObject; }
		public Vector2 Position { get => DecoratedMario.Position; set => DecoratedMario.Position = value; }

		public void BeFire()
		{
			DecoratedMario.BeFire();
		}

		public void BeNormal()
		{
			DecoratedMario.BeNormal();
		}

		public void BeStar()
		{
			DecoratedMario.BeStar();
		}

		public void BeSuper()
		{
			DecoratedMario.BeSuper();
		}

		public void Dead()
		{
			DecoratedMario.Dead();
		}

		public void Down()
		{
			DecoratedMario.Down();
		}

		public bool IsDead()
		{
			return DecoratedMario.IsDead();
		}

		public bool Isfalling()
		{
			return DecoratedMario.Isfalling();
		}

		public bool IsFireMario()
		{
			return DecoratedMario.IsFireMario();
		}

		public void IsLandFlase()
		{
			DecoratedMario.IsLandFlase();
		}

		public void IsLandTrue()
		{
			DecoratedMario.IsLandTrue();
		}

		public bool IsLeft()
		{
			return DecoratedMario.IsLeft();
		}

		public bool IsNormalMario()
		{
			return DecoratedMario.IsNormalMario();
		}

		public bool IsRight()
		{
			return DecoratedMario.IsRight();
		}

		public virtual bool IsStarMario()
		{
			return DecoratedMario.IsStarMario();
		}

		public bool IsSuperMario()
		{
			return DecoratedMario.IsSuperMario();
		}

		public void Left()
		{
			DecoratedMario.Left();
		}

		public void NoInput()
		{
			DecoratedMario.NoInput();
		}

		public void Right()
		{
			DecoratedMario.Right();
		}

		public void ThrowFireball()
		{
			DecoratedMario.ThrowFireball();
		}

		public void Up()
		{
			DecoratedMario.Up();
		}

		public virtual void TakeDamage()
		{
			DecoratedMario.TakeDamage();
		}

		public void Draw(SpriteBatch spriteBatch, Color c)
		{
			DecoratedMario.Draw(spriteBatch, c);
		}
	}
}
