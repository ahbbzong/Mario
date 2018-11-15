using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game1;
using Mario.Factory;
using Mario.Enums;
using Mario.Classes.BlocksClasses;
using System;
using Mario.Sound;

namespace Mario.ItemClasses
{
    public class FireFlower :Item 
    {
        public FireFlower(Vector2 location) : base(location)
        {
            MotionSound.PowerUpAppears.Play();
        }
        public override void Update()
        {
            ItemSprite.Update();
            gravityManagement.Update();

        }
    }
}
