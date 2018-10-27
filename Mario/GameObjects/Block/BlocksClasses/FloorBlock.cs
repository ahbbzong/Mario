
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
        public override Rectangle Box
        {
            get
            {
                return new Rectangle(0, 0, 0, 0);
            }
        }
        public FloorBlock(Vector2 location) : base(location)
        {
            BlockState = new FloorBlockState(this);
            Type = BlockType.Floor;
        }
}
}
