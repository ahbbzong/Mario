using Game1;
using Mario.Enums;
using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;

namespace Mario.Collision
{
	public class PipeHandler : IBlockCollisionHandler
    {
        int index;
        public PipeHandler(int index)
        {
            this.index = index;
        }
        public void HandleCollision(IBlock block, IMario mario,Direction result)
        {
            if (result == Direction.Up&&mario.IsCrouching()&&index==0)
            {
                mario.Position += Vector2.UnitX * 17000;
                
            }
            if(result == Direction.Up && mario.IsCrouching() && index == 8)
            {
                mario.Position -= Vector2.UnitX * 15895;
                mario.Position -= Vector2.UnitY * 80;
            }

        }

        public void HandleCollision(IGameObject source, IGameObject target, Direction direction)
        {
            HandleCollision((IBlock)source, (IMario)target, direction);
        }
        
    }
}
