using Game1;
using Mario.BlocksClasses;
using Mario.Classes.BlocksClasses;
using Mario.Enums;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.BlockStates
{
    class HiddenBlockState : BlockState
    {
        public HiddenBlockState(Block block) : base(block)
        {
            blockSprite = BlockFactory.Instance.GetSpriteDictionary[BlockType.Hidden.ToString()];
        }
        public override void React()
        {
            block.BlockState = new UsedBlockState(block);
        }
        public override bool IsHiddenBlock()
        {
            return true;
        }
    }
}
