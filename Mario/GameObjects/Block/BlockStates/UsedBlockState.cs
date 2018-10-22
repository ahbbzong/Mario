﻿using Game1;
using Mario.BlocksClasses;
using Mario.Classes.BlocksClasses;
using Mario.Enums;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.BlockStates
{
    public class UsedBlockState : BlockState
    {
        public UsedBlockState(Block block) : base(block)
        {
            blockSprite = SpriteFactory.Instance.CreateSprite(BlockFactory.Instance.GetSpriteDictionary[BlockType.Used.ToString()]);
        }

    }
}