﻿using Game1;
using Mario.BlocksClasses;
using Mario.Classes.BlocksClasses;
using Mario.Enums;
using Mario.Factory;
using Mario.XMLRead;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.BlockStates
{
    class BreakableBlockState : BlockState
    {
        public BreakableBlockState(Block block) : base(block)
        {
        }
        public override void React()
        {
            if (ItemManager.Instance.Mario.IsNormalMario())
            {
                float yPosition = block.Position.Y;
                block.Position -= Vector2.UnitY*10.0f;
                block.BlockState = new BumpedBreakBlockState(block);
            }
            else
            {
                block.BlockState = new DisappearBlockState(block);
            }
        }
        public override bool IsBreakableBlock()
        {
            return true;
        }

    }
}
