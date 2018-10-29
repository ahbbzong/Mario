
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game1;
using Mario.Factory;
using Mario.BlockStates;
using Mario.Classes.BlocksClasses;
using Mario.Enums;
using System;

namespace Mario.BlocksClasses
{
    public class UsedBlock : Block
    {
        public UsedBlock(Vector2 location) : base(location)
        {
            BlockState = new UsedBlockState(this);
        }
      
    }
}
