using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game1;
using Mario.Factory;
using Mario.Enums;
using Mario.Classes.BlocksClasses;
using System;

namespace Mario.ItemClasses
{
    public class FireFlower :Item 
    {
        public FireFlower(Vector2 location) : base(location)
        {
            Console.WriteLine(ItemType.FireFlower.ToString());
            
            ItemSprite = SpriteFactory.Instance.CreateSprite(ItemFactory.Instance.GetSpriteDictionary[ItemType.FireFlower.ToString()]);
            Type = ItemType.FireFlower;

        }
    }
}
