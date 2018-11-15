using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public interface IDisplay
    {
       void Draw(SpriteBatch spriteBatch);
       void Update();
        void Draw(object spriteBatch);
    }
}
