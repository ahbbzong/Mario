using Game1;
using Mario.AbstractClass;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Items
{
   public class CoinSprite : AnimatedSprite
    {
        
      
        public CoinSprite(Texture2D coinSheet, int rows, int columns) : base(coinSheet,rows,columns)
        {
          

        }
       
    }
}
