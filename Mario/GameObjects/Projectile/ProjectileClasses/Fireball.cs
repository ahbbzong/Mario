using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game1;
using Mario.Factory;
using Mario.Enums;
using Mario.Classes.BlocksClasses;
using Mario.Items;
using Mario.XMLRead;

namespace Mario.ItemClasses
{
    public class Fireball : Projectile
    {
        
        public Fireball(Vector2 location):base(location)
        {
            ProjectileSprite = SpriteFactory.Instance.CreateSprite(ProjectileFactory.Instance.GetSpriteDictionary[ProjectileType.Fireball.ToString()]);
            ProjectileState = new FireballState(this);
            Type = ProjectileType.Fireball;
            physics = new Physics(this);
            gameObjectListsByType = ItemManager.Instance.gameObjectListsByType;
            if (Mario.MarioMovementState.MarioMovementType == MarioMovementType.RightRun||
                Mario.MarioMovementState.MarioMovementType == MarioMovementType.RightIdle||
                Mario.MarioMovementState.MarioMovementType == MarioMovementType.RightJump)
            { XVelocity = 6; }
            if (Mario.MarioMovementState.MarioMovementType == MarioMovementType.LeftRun ||
                Mario.MarioMovementState.MarioMovementType == MarioMovementType.LeftIdle||
                Mario.MarioMovementState.MarioMovementType == MarioMovementType.LeftJump)
            { XVelocity = -6; }
        }
        public override void React()
        {
            ProjectileState.React();
        }
    }
}
