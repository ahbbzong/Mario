using Game1;
using Mario.AbstractClass;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.KoopaSprite
{
    public class LeftMovingKoopaSprite : AnimatedSprite
    {
       
      

        public LeftMovingKoopaSprite(Texture2D leftMovingSheet, int rows, int columns) : base(leftMovingSheet,rows,columns)
        {
           
        }
     
    }
}
