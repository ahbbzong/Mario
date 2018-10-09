using Game1;
using Mario.BlocksClasses;
using Mario.Classes.BlocksClasses;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.BlockStates
{
    class QuestionBlockState : BlockState
    {

        public QuestionBlockState(Block block) : base(block)
        {
            this.block = block;
            blockSprite = SpriteFactory.Instance.CreateQuestionBlockSprite();
        }
        public override void React()
        {
            block.BlockState = new UsedBlockState(block);
        }
        public override bool IsQuestionBlock()
        {
            return true;
        }
    }
}
