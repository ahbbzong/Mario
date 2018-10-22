using Game1;
using Mario.BlocksClasses;
using Mario.Classes.BlocksClasses;
using Mario.Enums;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.BlockStates
{
    class PipeState : BlockState
    {
        public PipeState(Block pipe) : base(pipe)
        {
            blockSprite = BlockFactory.Instance.GetSpriteDictionary[BlockType.Pipe.ToString()];
        }


    }
}
