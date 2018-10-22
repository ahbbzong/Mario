using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1
{
    public interface IBlockState : IUpdateable
    {
        void React();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
     
        bool IsHiddenBlock();
        bool IsBreakableBlock();
        bool IsQuestionBlock();
       
    }
}
