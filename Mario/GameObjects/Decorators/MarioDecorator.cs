using Game1;
using Mario.Enums;
using Mario.Interfaces.GameObjects;
using Mario.MarioStates.MarioMovementStates;
using Mario.MarioStates.MarioPowerupStates;
using Microsoft.Xna.Framework;
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

		public Rectangle Box => DecoratedMario.Box;
		
		public MarioMovementState MarioMovementState { get => DecoratedMario.MarioMovementState; set => DecoratedMario.MarioMovementState = value; }
		public MarioPowerupState MarioPowerupState { get => DecoratedMario.MarioPowerupState; set => DecoratedMario.MarioPowerupState = value; }
		public Physics physics { get => DecoratedMario.physics; set => DecoratedMario.physics = value; }

		public MarioMovementType MarioMovementType => DecoratedMario.MarioMovementType;

		public MarioPowerupType MarioPowerupType => DecoratedMario.MarioPowerupType;

		protected IMario DecoratedMario { get => (IMario)DecoratedObject; }
		public Vector2 Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

		public bool IsStarMario()
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
		
	}
}
