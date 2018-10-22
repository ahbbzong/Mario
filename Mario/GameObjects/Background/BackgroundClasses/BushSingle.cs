using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1;
using Mario.AbstractClass;
using Mario.Classes.BlocksClasses;
using Mario.Enums;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Classes.BackgroundClasses
{
    public class BushSingle: Background
    {
       
        public BushSingle(Vector2 location):base(location)
        {
            BackgroundSprite = SpriteFactory.Instance.CreateSprite(BackgroundFactory.Instance.GetSpriteDictionary[BackgroundType.BushSingle.ToString()]);
        }


    }
}
