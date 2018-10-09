using Game1;
using Mario.AbstractClass;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.BlockSprite
{
    public class FloorBlockSprite : StaticSprite
    {

        public FloorBlockSprite(Texture2D floorBlockSheet) : base(floorBlockSheet)
        {
        }
    }

}
