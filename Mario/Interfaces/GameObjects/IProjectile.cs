﻿using Mario;
using Mario.BlockStates;
using Mario.Enums;
using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1
{
    public interface IProjectile : IGameObject, IPhysicsBody
    {
        
  
        ProjectileType Type { get; }
        Rectangle Box { get; }
        ProjectileState ProjectileState { get; set; }
        bool IsLand { get; set; }
        void IsLandTrue();
        void IsLandFalse();
        void React();
        Physics physics { get; set; }
    }
   
}
      
