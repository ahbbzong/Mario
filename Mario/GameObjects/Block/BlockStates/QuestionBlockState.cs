using Game1;
using Mario.BlocksClasses;
using Mario.Classes.BlocksClasses;
using Mario.Enums;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.BlockStates
{
    class QuestionBlockState : BlockState
    {

        public QuestionBlockState(Block block) : base(block)
        {
            blockSprite = SpriteFactory.Instance.CreateSprite(BlockFactory.Instance.GetSpriteDictionary[BlockType.Question.ToString()]);
        }
        public override void React()
        {
            float yPosition = block.Getposition().Y;
            block.Getposition().Y -= 10.0f;
            block.BlockState = new BumpedBlockState(block);
        }
        public override bool IsQuestionBlock()
        {
            return true;
        }
    }
}
