using Game1;
using Mario.BlocksClasses;
using Mario.Classes.BlocksClasses;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.BlockStates
{
    class PipeState : BlockState
    {
        public PipeState(Block pipe) : base(pipe)
        {
            block = pipe;
            blockSprite = SpriteFactory.Instance.CreatePipeSprite();
        }
       

    }
}
