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
    class HiddenBlockState : BlockState
    {
        public HiddenBlockState(IBlock block) : base(block)
        {
            BlockSprite = SpriteFactory.Instance.CreateEmptySprite(32,32);
        }
        public override void React()
        {
            Block.BlockState = new DisappearBlockState(Block);
            ItemManager.Instance.GameObjectListsByType[typeof(IBlock)].Add(BlockFactory.Instance.GetGameObject(typeof(UsedBlock), new Vector2(Block.Position.X, Block.Position.Y)));
        }
        public override bool IsHiddenBlock()
        {
            return true;
        }
       
    }
}
