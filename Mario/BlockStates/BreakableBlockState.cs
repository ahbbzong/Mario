﻿using Game1;
using Mario.BlocksClasses;
using Mario.Classes.BlocksClasses;
using Mario.Enums;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.BlockStates
{
    class BreakableBlockState : BlockState
    {
        public BreakableBlockState(Block block) : base(block)
        {
            blockSprite = BlockFactory.Instance.GetSpriteDictionary[BlockType.Breakable.ToString()];
        }
        public override void React()
        {
            block.BlockState = new DisappearBlockState(block);
        }
        public override bool IsBreakableBlock()
        {
            return true;
        }

    }
}
