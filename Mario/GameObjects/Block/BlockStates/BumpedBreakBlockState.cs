using Game1;
using Mario.BlockStates;
using Mario.Classes.BlocksClasses;
using Mario.Enums;
using Mario.Factory;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace Mario.BlockStates
    {
        public class BumpedBreakBlockState : BlockState
        {
            private int movedY = 10;
            public BumpedBreakBlockState(IBlock block) : base(block)
            {
            }
        public override void Update()
        {
            if (movedY != 0)
            {
                Block.Position+= Vector2.UnitY;
                movedY--;
            }
            else
            {
                Block.BlockState = new BreakableBlockState(Block);
            }
            BlockSprite.Update();
        }
        public override bool IsBumpedBreakBlock()
        {
            return true;
        }
    }
    }
