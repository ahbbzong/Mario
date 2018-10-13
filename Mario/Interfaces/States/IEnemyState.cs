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
        void Beflipped();
        void BeStomped();
        void TurnLeft();
        void TurnRight();
        void BeKilled();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        bool IsStomped();
    
    }
}
