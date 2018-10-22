using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario
{
    abstract class GameObjectDecorator : IGameObject
    {

        protected IGameObject decoratedObj;

        public virtual void Draw(SpriteBatch spriteBatch)
        { 

        }
        public virtual void Update()
        {

        }
    }
}
