using Mario;
using Mario.BlockStates;
using Mario.Enums;
using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1
{
    public interface IProjectile : IGameObject, IPhysicsBody
    {
        
  
        ProjectileState ProjectileState { get; set; }
        void IsLandTrue();
        void IsLandFalse();
        void React();
        GravityManagement gravityManagement { get; set; }
    }
   
}
      
