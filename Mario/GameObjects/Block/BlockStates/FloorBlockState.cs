using Game1;
using Mario.BlocksClasses;
using Mario.Classes.BlocksClasses;
using Mario.Enums;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.BlockStates
{
    class FloorBlockState : BlockState
    {
        public FloorBlockState(Block block) : base(block)
        {
            blockSprite = SpriteFactory.Instance.CreateSprite(BlockFactory.Instance.GetSpriteDictionary[BlockType.Floor.ToString()]);
        }
        public override bool IsFloorBlock()
        {
            return true;
        }
    }
}
