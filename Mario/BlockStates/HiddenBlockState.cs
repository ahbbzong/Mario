using Game1;
using Mario.BlocksClasses;
using Mario.Classes.BlocksClasses;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.BlockStates
{
    class HiddenBlockState : BlockState
    {
        public HiddenBlockState(Block block) : base(block)
        {
            this.block = block;
            blockSprite = SpriteFactory.Instance.CreateHiddenBlockSprite();
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
