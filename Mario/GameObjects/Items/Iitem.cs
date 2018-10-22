using Mario;
using Mario.BlockStates;
using Mario.Enums;
using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1
{
    public interface IItem : IGameObject, IPhysicsBody
    {
        
        Physics Physics { get; set; }
        ItemType Type { get; }
        Rectangle Box { get; }
        bool IsLand { get; set; }
        void IsLandTrue();
        void IsLandFalse();

    }

}
      
