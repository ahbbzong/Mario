
using Mario.Collision.FireballCollisionHandler;
using Mario.Collision.ItemCollisionHandler;
using Mario.Collision;
using Mario.Enums;
using Mario.Interfaces.GameObjects;
using Mario.XMLRead;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1;
using Mario.Collision.EnemyCollisionHandler;
using Mario.Factory;
using Mario.BlockStates;
using Mario.GameObjects.Block;
using Mario.Collision.MarioCollisionHandler.MarioEnemyCollisionHandler;
using Mario.EnemyStates.GoombaStates;
using Mario.Collision.MarioCollisionHandler.MarioBlockCollisionHandler;
using Mario.Collision.MarioCollisionHandler.MarioItemCollisionHandler;
using Mario.ItemClasses;
using Mario.HeadUpDesign;

namespace Mario.Collision.CollisionManager
{
	class CollisionDetector
	{

		private static readonly CollisionDetector instance = new CollisionDetector();
		public static CollisionDetector Instance { get => instance; }
		private IDictionary<Type, IList<IGameObject>> GameObjectListsByType { get => GameObjectManager.Instance.GameObjectListsByType;}
		private IList<Rectangle> FloorBoxPosition { get => GameObjectManager.Instance.FloorBoxPosition; }

		private ICamera CameraMario { get => GameObjectManager.Instance.CameraMario; }
		private IMario Mario { get => GameObjectManager.Instance.Mario; }
       
		public void Update()
		{
            IMario mario = (IMario)GameObjectListsByType[typeof(IMario)][0];
            Direction collisionFound;
            Rectangle intersection;
            IBlockCollisionHandler blockHandler;
            IBlockCollisionHandler pipeHandler;
            IItemCollisionHandler itemHandler;
            IEnemyCollisionHandler enemyHandler;
            IMarioCollisionHandler marioHandler;
            IProjectileCollisionHandler projectileCollisionHandler;
            CollisionUtility collisionDetecter = new CollisionUtility();
            collisionFound = collisionDetecter.Collision(mario.Box, CameraMario.InnerBox);
            intersection = collisionDetecter.Intersection;

            if (!collisionFound.Equals(Direction.None))
			{
				mario.Position += Vector2.UnitY * intersection.Width;
            }

			foreach (Rectangle floorBox in FloorBoxPosition)
			{
				for (int j = GameObjectListsByType[typeof(IProjectile)].Count - 1; j >= 0; j--)
				{
					IProjectile projectile = (IProjectile)GameObjectListsByType[typeof(IProjectile)][j];
					collisionFound = collisionDetecter.Collision(projectile.Box, floorBox);
					intersection = collisionDetecter.Intersection;
					projectileCollisionHandler = new FireballBlockCollisionHandler((IBlock)BlockFactory.Instance.GetGameObject(typeof(BrickBlockState), new Vector2(0, 0)), intersection, collisionFound);
					projectileCollisionHandler.HandleCollision(projectile);
				}
				for (int j = GameObjectListsByType[typeof(IItem)].Count - 1; j >= 0; j--)
				{
					IItem item = (IItem)GameObjectListsByType[typeof(IItem)][j];
					collisionFound = collisionDetecter.Collision(item.Box, floorBox);
					intersection = collisionDetecter.Intersection;
					itemHandler = new ItemBlockCollisionHandler((IBlock)BlockFactory.Instance.GetGameObject(typeof(BrickBlockState), new Vector2(0, 0)), intersection, collisionFound);
					itemHandler.HandleCollision(item);
				}
				foreach (IEnemy enemy in GameObjectListsByType[typeof(IEnemy)])
				{
					if (!enemy.IsFlipped())
					{
						collisionFound = collisionDetecter.Collision(enemy.Box, floorBox);
						intersection = collisionDetecter.Intersection;
						enemyHandler = new EnemyBlockCollisionHandler((IBlock)BlockFactory.Instance.GetGameObject(typeof(BrickBlockState), new Vector2(0, 0)), intersection, collisionFound);
						enemyHandler.HandleCollision(enemy);
					}
				}
				if (mario.IsActive())
				{
					collisionFound = collisionDetecter.Collision(Mario.Box, floorBox);
					intersection = collisionDetecter.Intersection;
					blockHandler = new BlockHandler();
					blockHandler.HandleCollision((IBlock)BlockFactory.Instance.GetGameObject(typeof(BrickBlockState), new Vector2(0, 0)), Mario, collisionFound);
					CallMarioBlockHandler((IBlock)BlockFactory.Instance.GetGameObject(typeof(BrickBlockState), new Vector2(0, 0)), collisionFound, intersection);
				}
			}
			for (int j = GameObjectListsByType[typeof(IProjectile)].Count - 1; j >= 0; j--)
			{
				IProjectile projectile = (IProjectile)GameObjectListsByType[typeof(IProjectile)][j];
				foreach (IBlock block in GameObjectListsByType[typeof(IBlock)])
				{
					collisionFound = collisionDetecter.Collision(projectile.Box, block.Box);
					intersection = collisionDetecter.Intersection;
					projectileCollisionHandler = new FireballBlockCollisionHandler(block, intersection, collisionFound);
					projectileCollisionHandler.HandleCollision(projectile);
				}
				foreach (IBlock pipe in GameObjectListsByType[typeof(IPipe)])
				{
					collisionFound = collisionDetecter.Collision(projectile.Box, pipe.Box);
					intersection = collisionDetecter.Intersection;

					projectileCollisionHandler = new FireballBlockCollisionHandler(pipe, intersection, collisionFound);
					projectileCollisionHandler.HandleCollision(projectile);

				}
				foreach (IEnemy enemy in GameObjectListsByType[typeof(IEnemy)])
				{

					projectileCollisionHandler = new FireballEnemyCollisionHandler();
					collisionFound = collisionDetecter.Collision(enemy.Box, projectile.Box);
					enemyHandler = new EnemyProjectileCollisionHandler();
					if (collisionFound != Direction.None)
					{
						enemyHandler.HandleCollision(enemy);
						projectileCollisionHandler.HandleCollision(projectile);

					}
				}
			}
			for (int j = GameObjectListsByType[typeof(IItem)].Count - 1; j >= 0; j--)
			{
				IItem item = (IItem)GameObjectListsByType[typeof(IItem)][j];
				collisionFound = collisionDetecter.Collision(Mario.Box, item.Box);
				if (collisionFound != Direction.None && Mario.IsActive())
				{
					intersection = collisionDetecter.Intersection;
					itemHandler = new ItemMarioCollisionHandler();
					itemHandler.HandleCollision(item);
					CallMarioItemHandler(item, collisionFound);
				}
				for (int i = GameObjectListsByType[typeof(IBlock)].Count - 1; i >= 0; i--)
				{

					IBlock block = (IBlock)GameObjectListsByType[typeof(IBlock)][i];
					if (!(block.BlockState is HiddenBlockState))
					{
						collisionFound = collisionDetecter.Collision(item.Box, block.Box);
						intersection = collisionDetecter.Intersection;
						itemHandler = new ItemBlockCollisionHandler(block, intersection, collisionFound);
						itemHandler.HandleCollision(item);
					}
				}
				for (int i = GameObjectListsByType[typeof(IPipe)].Count - 1; i >= 0; i--)
				{
					IBlock pipe = (IBlock)GameObjectListsByType[typeof(IPipe)][i];
					collisionFound = collisionDetecter.Collision(item.Box, pipe.Box);
					intersection = collisionDetecter.Intersection;
					itemHandler = new ItemBlockCollisionHandler(pipe, intersection, collisionFound);
					itemHandler.HandleCollision(item);
				}
			}
			for (int j = GameObjectListsByType[typeof(IBlock)].Count - 1; j >= 0; j--)
			{
				IBlock block = (IBlock)GameObjectListsByType[typeof(IBlock)][j];
				collisionFound = collisionDetecter.Collision(Mario.Box, block.Box);
				if (Mario.IsActive())
				{
					intersection = collisionDetecter.Intersection;
					blockHandler = new BlockHandler();
					blockHandler.HandleCollision(block, Mario, collisionFound);
					CallMarioBlockHandler(block, collisionFound, intersection);
				}
			}
			foreach (IEnemy enemy in GameObjectListsByType[typeof(IEnemy)])
			{
				if (!enemy.IsFlipped())
				{
					collisionFound = collisionDetecter.Collision(Mario.Box, enemy.Box);
					if (Mario.IsActive() && !(enemy.EnemyState is StompedGoombaState))
					{
						enemyHandler = new EnemyMarioCollisionHandler(Mario, collisionFound);
						intersection = collisionDetecter.Intersection;
						enemyHandler.HandleCollision(enemy);
						marioHandler = new MarioEnemyCollisionHandler(enemy, intersection);
						marioHandler.HandleCollision(Mario, collisionFound);
                        
					}
					foreach (IBlock block in GameObjectListsByType[typeof(IBlock)])
					{
						if (!(block.BlockState is HiddenBlockState))
						{
							collisionFound = collisionDetecter.Collision(enemy.Box, block.Box);
							intersection = collisionDetecter.Intersection;
							enemyHandler = new EnemyBlockCollisionHandler(block, intersection, collisionFound);
							enemyHandler.HandleCollision(enemy);
						}

					}
					foreach (IBlock pipe in GameObjectListsByType[typeof(IPipe)])
					{
						collisionFound = collisionDetecter.Collision(enemy.Box, pipe.Box);
						intersection = collisionDetecter.Intersection;
						enemyHandler = new EnemyBlockCollisionHandler(pipe, intersection, collisionFound);
						enemyHandler.HandleCollision(enemy);

					}

					foreach (IEnemy goomba in GameObjectListsByType[typeof(IEnemy)])
					{
						if (enemy.IsKoopa() && goomba.IsGoomba())
						{
							collisionFound = collisionDetecter.Collision(enemy.Box, goomba.Box);
							intersection = collisionDetecter.Intersection;
							enemyHandler = new EnemyEnemyCollisionHandler(goomba, intersection, collisionFound);
							enemyHandler.HandleCollision(enemy);
						}
					}
				}
			}


			foreach (IBlock pipe in GameObjectListsByType[typeof(IPipe)])
			{
				collisionFound = collisionDetecter.Collision(Mario.Box, pipe.Box);
				if (collisionFound != Direction.None && Mario.IsActive())
				{

                    intersection = collisionDetecter.Intersection;
					CallMarioBlockHandler(pipe, collisionFound, intersection);

				}
                if (GameObjectListsByType[typeof(IPipe)].IndexOf(pipe)==CollisionUtil.groundPipeIndex)
                {
                    pipeHandler = new PipeHandler(CollisionUtil.groundPipeIndex);
                    pipeHandler.HandleCollision(pipe, Mario, collisionFound);
                }
                if (GameObjectListsByType[typeof(IPipe)].IndexOf(pipe) == CollisionUtil.undergroundPipeIndex)
                {
                    pipeHandler = new PipeHandler(CollisionUtil.undergroundPipeIndex);
                    pipeHandler.HandleCollision(pipe, Mario, collisionFound);
                }
            }
			float difference = (float)(Mario.Position.X - GameObjectManager.Instance.CameraMario.Location.X);
			if (difference <= CollisionUtil.differenceFive && difference >= CollisionUtil.differenceZero)
			{
				mario.Position += Vector2.UnitY * difference;
            }
		}

		public void CallMarioItemHandler(IItem item, Direction collisionFound)
		{
			IMarioCollisionHandler marioHandler;
			if (item is FireFlower)
			{

				marioHandler = new MarioFireFlowerCollisionHandler();
			}
			else if (item is Starman)
			{

				marioHandler = new MarioStarmanCollisionHandler();

			}
			else if (item is MagicMushroom)
			{

				marioHandler = new MarioMagicMushroomCollisionHandler();
			}
			else
			{
				marioHandler = null;
			}

			if (marioHandler != null)
			{
				marioHandler.HandleCollision(Mario, collisionFound);
			}
            if (item is Coin)
            {
                CoinSystem.Instance.AddCoin();
            }
            else
            {
                ScoringSystem.Instance.AddPointsForCollectingItem(item);
            }
     
		}
		public void CallMarioBlockHandler(IBlock block, Direction collisionFound, Rectangle intersection)
		{
			IMarioCollisionHandler marioHandler;
			if (block.BlockState is HiddenBlockState)
			{
				marioHandler = new MarioHiddenBlockHandler(intersection);
			}
			else
			{
				marioHandler = new MarioBlockHandler(intersection);
			}

			marioHandler.HandleCollision(Mario, collisionFound);

		}
       
	}
}
