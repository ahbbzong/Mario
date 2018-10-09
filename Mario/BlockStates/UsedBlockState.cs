using Game1;
using Mario.BlocksClasses;
using Mario.Classes.BlocksClasses;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.BlockStates
{
    public class UsedBlockState : BlockState
    {
        public UsedBlockState(Block block) : base(block)
        {
            this.block = block;
            blockSprite = SpriteFactory.Instance.CreateUsedBlockSprite();
        }

    }
}
