using Mario.BlockStates;
using Mario.Enums;
using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public interface IBlock : IGameObject, IPhysicsBody
    {

        BlockType Type { get; }
        Rectangle Box { get; }
        bool IsHiddenBlock();
        bool IsBreakableBlock();
        bool IsQuestionBlock();
        void React();
    }
}
