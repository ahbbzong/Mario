using Mario.BlockStates;
using Mario.Enums;
using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public interface IEnemy: IGameObject
    {
        void Beflipped();
        void BeStomped();
        void TurnLeft();
        void TurnRight();

        bool IsStomped();

        Rectangle Box { get; }

        EnemyType Type { get; }
      
        ref Vector2 Getposition();
    }
}
