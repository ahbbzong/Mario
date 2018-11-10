using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game1;
using Mario.Factory;
using Mario.Enums;
using Mario.Classes.BlocksClasses;
using Mario.Items;
using Mario.XMLRead;
using Mario.MarioStates.MarioMovementStates;
using Mario.GameObjects.Projectile;

namespace Mario.ItemClasses
{
    public class Fireball : Projectile
    {
        
        public Fireball(Vector2 location):base(location)
        {
            ProjectileSprite = SpriteFactory.Instance.CreateSprite(ProjectileFactory.Instance.GetSpriteDictionary[this.GetType()]);
            ProjectileState = new FireballState(this);
            gravityManagement = new GravityManagement(this);
            if (Mario.MarioMovementState.MarioMovementType == MarioMovementType.RightRun||
                Mario.MarioMovementState.MarioMovementType == MarioMovementType.RightIdle||
                Mario.MarioMovementState.MarioMovementType == MarioMovementType.RightJump)
            { XVelocity = ProjectileUtil.projectileSpeed; }
            if (Mario.MarioMovementState is LeftRunningMarioMovementState ||
                Mario.MarioMovementState is LeftIdleMarioMovementState||
                Mario.MarioMovementState is LeftJumpingMarioMovementState)
            { XVelocity = -ProjectileUtil.projectileSpeed; }
        }
        public override void React()
        {
            ProjectileState.React();
        }
    }
}
