using Game1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public interface IEnemyState :  IUpdateable
    {
        int GetWidth { get; }
        int GetHeight { get; }
        void Beflipped();
        void BeStomped();
        void TurnLeft();
        void TurnRight();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        bool IsGoombaStomped();
        bool IsKoopaStomped();
        bool IsFlipped();
        bool IsLeftStomped();
        bool IsRightStomped();
        bool IsGoomba();
        bool IsKoopa();
    
    }
}
