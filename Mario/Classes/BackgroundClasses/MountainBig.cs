using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1;
using Mario.AbstractClass;
using Mario.Classes.BlocksClasses;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Classes.BackgroundClasses
{
    public class MountainBig : Background
    {

        public MountainBig(Vector2 location) : base(location)
        {
            BackgroundSprite = SpriteFactory.Instance.CreatMountainBigSprite();
        }
    }
}
