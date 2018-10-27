using Game1;
using Mario.BlocksClasses;
using Mario.Classes.BlocksClasses;
using Mario.Enums;
using Mario.Factory;
using Mario.XMLRead;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.BlockStates
{
    class BreakableBlockState : BlockState
    {
        public BreakableBlockState(IBlock block) : base(block)
        {

			this.BlockSprite = SpriteFactory.Instance.CreateSprite(BlockFactory.Instance.GetSpriteDictionary[this.GetType()]);
		}
        public override void React()
        {
            if (ItemManager.Instance.Mario.IsNormalMario())
            {
                float yPosition = Block.Position.Y;
                Block.Position -= Vector2.UnitY*10.0f;
                Block.BlockState = new BumpedBreakBlockState(Block);
            }
            else
            {
                Block.BlockState = new DisappearBlockState(Block);
            }
        }
        public override bool IsBreakableBlock()
        {
            return true;
        }

    }
}
