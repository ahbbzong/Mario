﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game1;
using Mario.Factory;
using Mario.Enums;
using Mario.Classes.BlocksClasses;

namespace Mario.ItemClasses
{
    public class MagicMushroom : Item
    {
        public MagicMushroom(Vector2 location) : base(location)
        {
            ItemSprite = ItemFactory.Instance.GetSpriteDictionary[ItemType.MagicMushroom.ToString()];
            Type = ItemType.MagicMushroom;
        }
    }
}

