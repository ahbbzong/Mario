
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game1;
using Mario.Factory;
using Mario.BlockStates;
using Mario.Classes.BlocksClasses;
using Mario.Enums;

namespace Mario.BlocksClasses
{
    public class FloorBlock : Block
    {
        public FloorBlock(Vector2 location) : base(location)
        {
            BlockState = new FloorBlockState(this);
        }
    }
}
