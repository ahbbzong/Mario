using Mario.BlockStates;
using Mario.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public interface IEnemy: IDrawable, IUpdateable
    {
        void Beflipped();
        void BeStomped();
        void TurnLeft();
        void TurnRight();

        bool IsStomped();

        Rectangle Box { get; }

        EnemyType Type { get; }
    }
}
