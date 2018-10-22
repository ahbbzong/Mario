
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game1;
using Mario.Factory;
using Mario.BlockStates;
using Mario.Classes.BlocksClasses;
using Mario.Enums;

namespace Mario.BlocksClasses
{
    public class UnbreakableBlock : Block
    {
        public UnbreakableBlock(Vector2 location) : base(location)
        {
            BlockState = new UnbreakableBlockState(this);
            Type = BlockType.Unbreakable;
        }
      
    }
}
