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
        public HiddenBlockState(IBlock block) : base(block)
        {
            BlockSprite = SpriteFactory.Instance.CreateEmptySprite(32,32);
        }
        public override void React()
        {
            Block.BlockState = new UsedBlockState(Block);
        }
        public override bool IsHiddenBlock()
        {
            return true;
        }
        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
           //
        }
    }
}
