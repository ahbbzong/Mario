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
            public BumpedBlockState(Block block) : base(block)
            {
                blockSprite = SpriteFactory.Instance.CreateSprite(BlockFactory.Instance.GetSpriteDictionary[BlockType.Used.ToString()]);
            }
        public override void Update()
        {
            if (movedY != 0)
            {
                block.Position+= Vector2.UnitY;
                movedY--;
            }
            blockSprite.Update();
        }
        public override bool IsBumpedBlockState()
        {
            return true;
        }
    }
    }
