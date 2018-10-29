using Mario.BlockStates;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game1;
using Mario.Classes.BlocksClasses;
using Mario.Enums;
using System;

namespace Mario.BlocksClasses
{
    public class HiddenBlock : Block
    {
        public HiddenBlock(Vector2 location) : base(location)
        {
            BlockState = new HiddenBlockState(this);
        }
        public override void React()
        {
            BlockState.React();
            
        }


    }
}
