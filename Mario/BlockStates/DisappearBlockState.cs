using Game1;
using Mario.BlocksClasses;
using Mario.Classes.BlocksClasses;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.BlockStates
{
    public class DisappearBlockState : BlockState
    {

        public DisappearBlockState(Block block) : base(block)
        {
            blockSprite = SpriteFactory.Instance.CreateHiddenBlockSprite();
        }
      

    }
}
