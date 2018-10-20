using Mario;
using Mario.Interfaces.GameObjects;
using Mario.MarioStates;
using Mario.MarioStates.MarioMovementStates;
using Mario.MarioStates.MarioPowerupStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public interface IMario : IGameObject, IMovementEventBehavior, IPowerupEventBehavior, IPhysicsBody
    {
        bool IsSuperMario();
        bool IsNormalMario();
        bool IsFireMario();
        bool IsStarMario();
        bool IsDead();
        bool Isfalling();
      
        void ThrowFireball();
        
        Rectangle Box { get; }
        MarioMovementState MarioMovementState { get; set; }
        MarioPowerupState MarioPowerupState { get; set; }
        Physics physics { get;set; }
        void IsLandTrue();

        void IsLandFlase();
      
    }
}
