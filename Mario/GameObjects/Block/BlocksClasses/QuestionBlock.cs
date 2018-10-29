using Mario.BlockStates;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game1;
using Mario.Classes.BlocksClasses;
using Mario.Enums;
using System;

namespace Mario.BlocksClasses
{
    public class QuestionBlock : Block
    {
        public QuestionBlock(Vector2 location) : base(location)
        {
            BlockState = new QuestionBlockState(this);
        }
        public override void React()
        {
            BlockState.React();
        }
    }
}
