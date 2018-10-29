using Mario.BlockStates;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game1;
using Mario.Factory;
using Mario.Classes.BlocksClasses;
using Mario.Enums;
using Mario.GameObjects.Block;
using System;

namespace Mario.BlocksClasses
{
    public class Pipe : Block, IPipe
    {
        
        public Pipe(Vector2 location) : base(location)
        {

            BlockState = new PipeState(this);

        }
    }
}
