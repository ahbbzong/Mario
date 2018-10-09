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
    public class BreakableBlockSprite : StaticSprite
    {
        public BreakableBlockSprite(Texture2D breakableSheet):base(breakableSheet)
        {
        }
    }

}
