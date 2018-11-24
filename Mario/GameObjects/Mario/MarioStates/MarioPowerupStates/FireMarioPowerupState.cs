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
        int counter;
        bool fire;
        public FireMarioPowerupState(IMario mario) : base(mario)
		{
            counter = 0;
            fire = true;
        }

		public override void BeFire()
		{
		}
        public override void ThrowProjectile()
        {
            counter++;
            if (counter == 20 && !fire)
            {
                fire = true;
            }
            if (fire)
            {
                Vector2 launchPosition = Mario.Position;
                GameObjectManager.Instance.GameObjectListsByType[typeof(IProjectile)].Add(new Fireball(launchPosition));
                counter = 0;
                fire = false;
            }
            
        }

		
		public override void TakeDamage()
		{
			Mario.BeNormal();
		}
    }
}