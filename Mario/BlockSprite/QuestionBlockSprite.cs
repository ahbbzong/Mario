using Game1;
using Mario.AbstractClass;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.BlockSprite
{
    public class QuestionBlockSprite : AnimatedSprite
    {
     
        public QuestionBlockSprite(Texture2D questionBlockSheet, int rows, int columns) : base(questionBlockSheet,rows,columns)
        {
            
        }
    }
}
