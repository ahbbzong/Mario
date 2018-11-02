﻿using Mario;
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
        bool IsStarMario();
        bool IsDead();
        bool Isfalling();
        bool IsLeft();
        bool IsRight();
        bool IsUp();
        bool IsCrouch();
        void ThrowFireball();
        
        MarioMovementState MarioMovementState { get; set; }
        MarioPowerupState MarioPowerupState { get; set; }
        PhysicsMario Physics { get;set; }
        void IsLandTrue();
        bool IsLandResponse();
        void SetFalling(bool fall);
        void Sprint();
		void Draw(SpriteBatch spriteBatch, Color c);
        void IsLandFlase();

		ISprite MarioSprite { get; set; }
    }
}
