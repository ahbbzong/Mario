using Mario.BlockStates;
using Mario.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public interface IBlock : IDrawable, IUpdateable
    {

        BlockType Type { get; }
        Rectangle Box { get; }
        bool IsHiddenBlock();
        bool IsBreakableBlock();
        bool IsQuestionBlock();
        void React();
        ref Vector2 Getposition();
    }
}
