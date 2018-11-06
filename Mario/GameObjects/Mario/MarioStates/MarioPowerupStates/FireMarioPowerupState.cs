using Game1;
using Mario.Classes.BlocksClasses;
using Mario.Enums;
using Mario.ItemClasses;
using Mario.XMLRead;
using Microsoft.Xna.Framework;
using System;

namespace Mario.MarioStates.MarioPowerupStates
{
	internal class FireMarioPowerupState : MarioPowerupState
	{
		public FireMarioPowerupState(IMario mario) : base(mario)
		{
		}

		public override void BeFire()
		{
			//override NO-OP
		}
        public override void ThrowProjectile()
        {
            Vector2 launchPosition = Mario.Position;
            GameObjectManager.Instance.GameObjectListsByType[typeof(IProjectile)].Add(new Fireball(launchPosition));
        }

		public override bool CanThrowProjectile()
		{
			return true;
		}
		public override void TakeDamage()
		{
			Mario.BeNormal();
		}
    }
}