﻿using Game1;
using Mario.Classes.BlocksClasses;
using Mario.Enums;
using Mario.ItemClasses;
using Mario.XMLRead;
using Microsoft.Xna.Framework;

namespace Mario.MarioStates.MarioPowerupStates
{
	internal class FireMarioPowerupState : MarioPowerupState
	{
		public FireMarioPowerupState(IMario mario) : base(mario)
		{
		}
		public override MarioPowerupType MarioPowerupType => MarioPowerupType.Fire;

		public override void BeFire()
		{
			//override NO-OP
		}
        public override void ThrowFireball()
        {
            Vector2 launchPosition = Mario.Position;
            ItemManager.Instance.gameObjectListsByType["Projectile"].Add(new Fireball(launchPosition));

            
        }
    }
}