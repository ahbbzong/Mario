using Mario.BlockStates;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game1;
using Mario.Classes.BlocksClasses;
using Mario.Enums;
using System;

namespace Mario.BlocksClasses
{
    public class BreakableBlock : Block
    {
        public BreakableBlock(Vector2 location):base(location)
        {
            BlockState = new BreakableBlockState(this);
            Type = BlockType.Breakable;
        }

        public override void React()
        {
            BlockState.React();
        }


    }
}
