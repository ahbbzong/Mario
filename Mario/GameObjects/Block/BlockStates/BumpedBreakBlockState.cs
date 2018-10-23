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
            public BumpedBreakBlockState(Block block) : base(block)
            {
            }
        public override void Update()
        {
            if (movedY != 0)
            {
                block.Position+= Vector2.UnitY;
                movedY--;
            }
            else
            {
                block.BlockState = new BreakableBlockState(block);
            }
            blockSprite.Update();
        }
        public override bool IsBumpedBreakBlock()
        {
            return true;
        }
    }
    }
