﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game1;
using Mario.Factory;
using Mario.Enums;
using Mario.Classes.BlocksClasses;
using Mario.Sound;

namespace Mario.ItemClasses
{
    public class OneUpMushroom : Item
    {
        public OneUpMushroom(Vector2 location) : base(location)
        {
            MotionSound.PowerUpAppears.Play();
        }
    }
}
