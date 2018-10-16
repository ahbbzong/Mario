using Mario.BlockStates;
using Mario.Enums;
using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1
{
    public interface IItem : IGameObject, IPhysicsBody
    {
        
  
        ItemType Type { get; }
        Rectangle Box { get; }
        ref Vector2 Getposition();
    }
   
}
      
