using Mario;
using Mario.BlockStates;
using Mario.Enums;
using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1
{
    public interface IItem : IGameObject, IPhysicsBody
    {

        GravityManagement gravityManagement { get; set; }
       
        Rectangle Box { get; }
        bool IsLand { get; set; }
        bool IsStarman();
        bool IsCoin();
        void IsLandTrue();
        void IsLandFalse();
        void TurnLeft();
        void TurnRight();
    }

}
      
