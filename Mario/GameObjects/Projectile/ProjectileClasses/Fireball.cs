using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game1;
using Mario.Factory;
using Mario.Enums;
using Mario.Classes.BlocksClasses;
using Mario.Items;
using Mario.XMLRead;
using Mario.MarioStates.MarioMovementStates;

namespace Mario.ItemClasses
{
    public class Fireball : Projectile
    {
        
        public Fireball(Vector2 location):base(location)
        {
            ProjectileSprite = SpriteFactory.Instance.CreateSprite(ProjectileFactory.Instance.GetSpriteDictionary[this.GetType()]);
            ProjectileState = new FireballState(this);
            Type = ProjectileType.Fireball;
            physics = new Physics(this);
            if (Mario.MarioMovementState is RightRunningMarioMovementState||
                Mario.MarioMovementState is RightIdleMarioMovementState||
                Mario.MarioMovementState is RightJumpingMarioMovementState)
            { XVelocity = 6; }
            if (Mario.MarioMovementState is LeftRunningMarioMovementState ||
                Mario.MarioMovementState is LeftIdleMarioMovementState||
                Mario.MarioMovementState is LeftJumpingMarioMovementState)
            { XVelocity = -6; }
        }
        public override void React()
        {
            ProjectileState.React();
        }
    }
}
