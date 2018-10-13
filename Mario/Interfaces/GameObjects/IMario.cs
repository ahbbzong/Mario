using Mario.Interfaces.GameObjects;
using Mario.MarioStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
         public interface IMario : IGameObject, IMovementEventBehavior, IPowerupEventBehavior
        {
        bool IsSuperMario();
        bool IsNormalMario();
        bool IsFireMario();
        bool IsStarMario();
        bool IsDead();

        bool Isfalling();
        Rectangle Box { get; }
        IMarioState marioState { get; set; }

        ref Vector2 Getposition();

    }
}
