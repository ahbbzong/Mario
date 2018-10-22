using Mario.BlockStates;
using Mario.Classes.BlocksClasses;
using Mario.Enums;
using Mario.Factory;
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
                blockSprite = SpriteFactory.Instance.CreateSprite(BlockFactory.Instance.GetSpriteDictionary[BlockType.Breakable.ToString()]);
            }
        public override void Update()
        {
            if (movedY != 0)
            {
                block.Getposition().Y++;
                movedY--;
            }
            else
            {
                block.BlockState = new BreakableBlockState(block);
            }
            blockSprite.Update();
        }
    }
    }
