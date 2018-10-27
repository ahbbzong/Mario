using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game1;
using Mario.Factory;
using Mario.Enums;
using Mario.Classes.BlocksClasses;

namespace Mario.ItemClasses
{
    public class Starman : Item
    {
        public Starman(Vector2 location) : base(location)
        {
        }
        public override bool IsStarman()
        {
            return true;
        }
        public override void IsLandTrue()
        {
            IsLand = true;
            gravityManagement.ReverseYVelocity();

        }
    }


}
