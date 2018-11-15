using Game1;
using Mario.HeadUpDesign;

namespace Mario.Collision.EnemyCollisionHandler
{
	public class EnemyProjectileCollisionHandler : IEnemyCollisionHandler
    {
        public EnemyProjectileCollisionHandler()
		{
        }
        public void HandleCollision(IEnemy enemy)
        {
            enemy.Beflipped();
            if (enemy.IsGoomba())//need to change later
            {
                ScoringSystem.Instance.AddPointsForFireballGoombaHit(enemy);
            }
            else
            {
                ScoringSystem.Instance.AddPointsForFireballKoopaHit(enemy);
            }
        }
    }
}
