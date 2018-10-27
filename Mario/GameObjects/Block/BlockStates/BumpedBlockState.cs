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
        public class BumpedBlockState : BlockState
        {
            private int movedY = 10;
		public BumpedBlockState(IBlock block) : base(block)
		{

		}
		public override void Update()
        {
            if (movedY != 0)
            {
                Block.Position+= Vector2.UnitY;
                movedY--;
            }
            BlockSprite.Update();
        }
        public override bool IsBumpedBlockState()
        {
            return true;
        }
    }
    }
