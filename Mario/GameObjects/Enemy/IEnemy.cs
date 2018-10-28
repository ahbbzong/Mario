using Mario.BlockStates;
using Mario.Enums;
using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Game1
{
    public interface IEnemy: IGameObject, IPhysicsBody
    {
        void Beflipped();
        void BeStomped();

        void TurnLeft();
        void TurnRight();

        bool IsGoombaStomped();
        bool IsKoopaStomped();
        bool IsFlipped();
        bool IsGoomba();
        bool IsKoopa();
        bool IsLeftStomped();
        bool IsRightStomped();

        Rectangle Box { get; }

        GravityManagement gravityManagement { get; set; }
        
		void IsLandTrue();
        void IsLandFalse();
    }
}
