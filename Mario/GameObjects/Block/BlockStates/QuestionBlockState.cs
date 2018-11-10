using Game1;
using Mario.BlocksClasses;
using Mario.Classes.BlocksClasses;
using Mario.Enums;
using Mario.Factory;
using Mario.GameObjects.Decorators;
using Mario.XMLRead;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.BlockStates
{
    class QuestionBlockState : BlockState
    {

        public QuestionBlockState(IBlock block) : base(block)
        {

			this.BlockSprite = SpriteFactory.Instance.CreateSprite(BlockFactory.Instance.GetSpriteDictionary[this.GetType()]);
		}
        public override void React()
        {
			Block.Position = new Vector2(Block.Position.X, Block.Position.Y - BlockUtil.BlockOffset);

			int index = GameObjectManager.Instance.GameObjectListsByType[typeof(IBlock)].IndexOf(Block);
			if (index >= BlockUtil.Zero)
			{
				GameObjectManager.Instance.GameObjectListsByType[typeof(IBlock)][index] = new BumpedBlockDecorator(Block);
			}
		}
     
    }
}
