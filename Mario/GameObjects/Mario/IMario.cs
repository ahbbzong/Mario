using Mario.GameObjects.Mario;
using Mario.Interfaces.GameObjects;
using Mario.MarioStates.MarioMovementStates;
using Mario.MarioStates.MarioPowerupStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
	public interface IMario : IGameObject, IMovementEventBehavior, IPowerupEventBehavior, IPhysicsBody, IPlayerStats
    {
        bool IsStarMario();
        bool IsActive();
        bool IsFalling();
        bool IsRunningLeft();
        bool IsRunningRight();
        bool IsUp();
        bool IsAtEnd();
        bool IsCrouching();
        void ThrowProjectile();
        
        MarioMovementState MarioMovementState { get; set; }
        MarioPowerupState MarioPowerupState { get; set; }
        PhysicsMario Physics { get;set; }
        void SetIsLandTrue();
        bool IsLandResponse();
        void SetFalling(bool fall);
        void Sprint();
		void Draw(SpriteBatch spriteBatch, Color c);
        void SetIsLandFalse();

		ISprite MarioSprite { get; set; }
    }
}
