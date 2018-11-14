using Game1;
using Mario.BlocksClasses;
using Mario.Classes.BlocksClasses;
using Mario.Enums;
using Mario.Factory;
using Mario.Sound;
using Mario.XMLRead;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.BlockStates
{
    class HiddenBlockState : BlockState
    {
        public HiddenBlockState(IBlock block) : base(block)
        {
            BlockSprite = SpriteFactory.Instance.CreateEmptySprite(BlockUtil.HiddenEmptySprite, BlockUtil.HiddenEmptySprite);
        }
        public override void React()
        {
            MotionSound.BreakBlock.Play();
            Block.BlockState = new DisappearBlockState(Block);
            GameObjectManager.Instance.GameObjectListsByType[typeof(IBlock)].Add(BlockFactory.Instance.GetGameObject(typeof(UsedBlockState), new Vector2(Block.Position.X, Block.Position.Y)));
        }
   
    }
}
