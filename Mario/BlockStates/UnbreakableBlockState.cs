using Game1;
using Mario.BlocksClasses;
using Mario.Classes.BlocksClasses;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.BlockStates
{
    class UnbreakableBlockState : BlockState
    {
        public UnbreakableBlockState(Block block) : base(block)
        {
            this.block = block;
            blockSprite = SpriteFactory.Instance.CreateUnBreakableBlockSprite();
        }
        
    }
}
