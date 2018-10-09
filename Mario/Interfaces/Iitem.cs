using Mario.BlockStates;
using Mario.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1
{
    public interface IItem : IDrawable, IUpdateable
    {
        
  
        GameObjectType Type { get; }
        Rectangle Box { get; }
        ref Vector2 Getposition();
    }
   
}
      
