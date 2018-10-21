﻿using Mario.BlockStates;
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
        void BeKilled();

        void TurnLeft();
        void TurnRight();

        bool IsStomped();
        bool IsFlipped();
        bool IsGoomba();
        bool IsKoopa();

        Rectangle Box { get; }

        EnemyType Type { get; }
      
    }
}
