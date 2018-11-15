using Game1;

namespace Mario.Collision.FireballCollisionHandler
{
	public class FireballEnemyCollisionHandler : IProjectileCollisionHandler
    {
        public FireballEnemyCollisionHandler()
        {
        }
        public void HandleCollision(IProjectile fireball)
        {
            GameObjectManager.Instance.GameObjectListsByType[typeof(IProjectile)].Remove(fireball);
        }
    }
}
