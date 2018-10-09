using Game1;
using Mario.AbstractClass;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.GoombaSprite
{
    public class MovingGoombaSprite : AnimatedSprite
    {
        
      

        public MovingGoombaSprite(Texture2D MovingSheet, int rows, int columns) : base(MovingSheet,rows,columns)
        {
           
        }
      
    }
}
