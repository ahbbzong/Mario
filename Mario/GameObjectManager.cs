using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Mario.Collision;
using Mario.Collision.ItemCollisionHandler;
using Mario.Collision.MarioCollisionHandler.MarioItemCollisionHandler;
using Mario.Collision.MarioCollisionHandler.MarioBlockCollisionHandler;
using Mario.Collision.EnemyCollisionHandler;
using Mario.Collision.MarioCollisionHandler.MarioEnemyCollisionHandler;
using Mario.Interfaces.GameObjects;
using Mario.Factory;
using Mario.Enums;
using Mario.Interfaces.CollisionHandlers;
using Mario.Collision.FireballCollisionHandler;
using Mario.CameraClasses;
using Mario.BlocksClasses;
using Mario.ItemClasses;
using System.Diagnostics;
using Mario.GameObjects.Block;
using Mario.XMLRead;
using Game1;
using Mario.EnemyClasses;
using Mario.EnemyStates.GoombaStates;

namespace Mario.XMLRead
{
	
    public class GameObjectManager
    {
		private static GameObjectManager instance = new GameObjectManager();
		public static GameObjectManager Instance { get=>instance; set=> instance = value; }
		private static IList<IController> ControllerList { get; set; }
		private Dictionary<Type, IList<IGameObject>> gameObjectListsByType = new Dictionary<Type, IList<IGameObject>>();
		public Dictionary<Type, IList<IGameObject>> GameObjectListsByType { get => gameObjectListsByType; set => gameObjectListsByType = value; }
		public IMario Mario { get { return (IMario)GameObjectListsByType[typeof(IMario)][0]; } set { GameObjectListsByType[typeof(IMario)][0] = value; } }
        public ICamera CameraMario { get; set; }
        public ICameraController CameraController { get; set; }
        
        public IList<Rectangle> FloorBoxPosition { get; }
		public GameTime CurrentGameTime { get; set; }

		private GameObjectManager()
        {
            GameObjectListsByType = new Dictionary<Type, IList<IGameObject>>
            {

                {typeof(IBackground), new List<IGameObject>() },
                {typeof(IItem),new List<IGameObject>() },
                {typeof(IPipe), new List<IGameObject>() },
                {typeof(IBlock), new List<IGameObject>() },
                {typeof(IProjectile), new List<IGameObject>() },
                {typeof(IEnemy), new List<IGameObject>() },
                {typeof(IMario),new List<IGameObject>() }
            };

			ControllerList = new List<IController>
			{
				new Keyboards()
			};
            FloorBoxPosition = new List<Rectangle>();
        }
        public void SetInitialValuesCamera()
        {
            CameraMario = new Camera();
            CameraController = new CameraController(CameraMario);
        }
        public void LoadContent()
        {
            ItemFactory.Instance.LoadContent(Game1.Instance.Content);
            BlockFactory.Instance.LoadContent(Game1.Instance.Content);
            EnemyFactory.Instance.LoadContent(Game1.Instance.Content);
            BackgroundFactory.Instance.LoadContent(Game1.Instance.Content);
            ProjectileFactory.Instance.LoadContent(Game1.Instance.Content);
            MarioFactory.Instance.LoadContent(Game1.Instance.Content);
            LevelLoader.Instance.LoadFile("XMLFile1.xml");
            foreach (IController controller in ControllerList)
            {
                controller.Initialize((IMario)GameObjectListsByType[typeof(IMario)][0]);
            }
		}
		public void UpdateCollision()

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
			CollisionDetecter collisionDetecter = new CollisionDetecter();
			collisionFound = collisionDetecter.Collision(mario.Box, CameraMario.InnerBox);
			intersection = collisionDetecter.Intersection;
			if (!collisionFound.Equals(Direction.None))
			{
				mario.Position += new Vector2(intersection.Width, 0);
			}
			
            foreach (Rectangle floorBox in FloorBoxPosition)
            {
                foreach (IProjectile projectile in GameObjectListsByType[typeof(IProjectile)])
                {
                    collisionFound = collisionDetecter.Collision(projectile.Box, floorBox);
                    intersection = collisionDetecter.Intersection;
                    projectileCollisionHandler = new FireballBlockCollisionHandler(new BreakableBlock(new Vector2(0, 0)), intersection, collisionFound);
                    projectileCollisionHandler.HandleCollision(projectile);
                }
                foreach (IItem obj in GameObjectListsByType[typeof(IItem)])
                {
                    collisionFound = collisionDetecter.Collision(obj.Box, floorBox);
                    intersection = collisionDetecter.Intersection;
                    itemHandler = new ItemBlockCollisionHandler(new BreakableBlock(new Vector2(0, 0)), intersection, collisionFound);
                    itemHandler.HandleCollision(obj);
                }
                foreach (IEnemy enemy in GameObjectListsByType[typeof(IEnemy)])
                {
                    if (!enemy.IsFlipped())
                    {
                        collisionFound = collisionDetecter.Collision(enemy.Box, floorBox);
                        intersection = collisionDetecter.Intersection;
                        enemyHandler = new EnemyBlockCollisionHandler(new BreakableBlock(new Vector2(0, 0)), intersection, collisionFound);
                        enemyHandler.HandleCollision(enemy);
                    }
                }
                if (!mario.IsDead())
                {
                    collisionFound = collisionDetecter.Collision(Mario.Box, floorBox);
                    intersection = collisionDetecter.Intersection;
                    blockHandler = new BlockHandler();
                    blockHandler.HandleCollision(new BreakableBlock(new Vector2(0, 0)),Mario, collisionFound);
                    CallMarioBlockHandler(new BreakableBlock(new Vector2(0, 0)), collisionFound, intersection);
                }
            }
            foreach (IProjectile projectile in GameObjectListsByType[typeof(IProjectile)])
            {
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

                    projectileCollisionHandler = new FireballBlockCollisionHandler(pipe, intersection,collisionFound);
                    projectileCollisionHandler.HandleCollision(projectile);

                }
                foreach (IEnemy enemy in GameObjectListsByType[typeof(IEnemy)])
                {

                    projectileCollisionHandler = new FireballEnemyCollisionHandler(enemy);
                    collisionFound = collisionDetecter.Collision(enemy.Box, projectile.Box);
                    enemyHandler = new EnemyProjectileCollisionHandler();
                    if (collisionFound != Direction.None)
                    {
                        enemyHandler.HandleCollision(enemy);
                        projectileCollisionHandler.HandleCollision(projectile);
                    }
                }
            }
            foreach (IItem obj in GameObjectListsByType[typeof(IItem)])
			{
				collisionFound = collisionDetecter.Collision(Mario.Box, obj.Box);
				if (collisionFound != Direction.None && !Mario.IsDead())
				{
					intersection = collisionDetecter.Intersection;
					itemHandler = new ItemMarioCollisionHandler();
					itemHandler.HandleCollision(obj);
					CallMarioItemHandler(obj, collisionFound);
				}
				for (int i = GameObjectListsByType[typeof(IBlock)].Count - 1; i >= 0; i--)
				{
                    
                    IBlock block = (IBlock)GameObjectListsByType[typeof(IBlock)][i];
                    if (!(block is HiddenBlock))
                    {
                        collisionFound = collisionDetecter.Collision(obj.Box, block.Box);
                        intersection = collisionDetecter.Intersection;
                        itemHandler = new ItemBlockCollisionHandler(block, intersection, collisionFound);
                        itemHandler.HandleCollision(obj);
                    }
				}
				for (int i = GameObjectListsByType[typeof(IPipe)].Count - 1; i >= 0; i--)
				{
					IBlock pipe = (IBlock)GameObjectListsByType[typeof(IPipe)][i];
					collisionFound = collisionDetecter.Collision(obj.Box, pipe.Box);
					intersection = collisionDetecter.Intersection;
					itemHandler = new ItemBlockCollisionHandler(pipe, intersection, collisionFound);
					itemHandler.HandleCollision(obj);
				}
			}
			for (int j = GameObjectListsByType[typeof(IBlock)].Count - 1; j >= 0; j--)
			{
				IBlock block = (IBlock)GameObjectListsByType[typeof(IBlock)][j];
				collisionFound = collisionDetecter.Collision(Mario.Box, block.Box);
				if (!Mario.IsDead())
				{
					intersection = collisionDetecter.Intersection;
					blockHandler = new BlockHandler();
                    blockHandler.HandleCollision(block, Mario,collisionFound);
					CallMarioBlockHandler(block, collisionFound, intersection);
				}
			}
            foreach (IEnemy enemy in GameObjectListsByType[typeof(IEnemy)])
            {
                if (!enemy.IsFlipped())
                {
                    collisionFound = collisionDetecter.Collision(Mario.Box, enemy.Box);
                    if (!Mario.IsDead()&&!(enemy.EnemyState is StompedGoombaState))
                    {
                        enemyHandler = new EnemyMarioCollisionHandler(Mario,collisionFound);
                        intersection = collisionDetecter.Intersection;
                        enemyHandler.HandleCollision(enemy);
                        marioHandler = new MarioEnemyCollisionHandler(enemy, intersection);
                        marioHandler.HandleCollision(Mario,collisionFound);
                    }
                    foreach (IBlock block in GameObjectListsByType[typeof(IBlock)])
                    {
                        if (!(block is HiddenBlock))
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
                            enemyHandler = new EnemyEnemyCollisionHandler(goomba, intersection,collisionFound);
                            enemyHandler.HandleCollision(enemy);
                        }
                    }
                }
            }
                
            
            foreach (IBlock pipe in GameObjectListsByType[typeof(IPipe)])
            {
                collisionFound = collisionDetecter.Collision(Mario.Box, pipe.Box);
                if (collisionFound != Direction.None && !Mario.IsDead())
                {
                    pipeHandler = new BlockHandler();
                    intersection = collisionDetecter.Intersection;
                    pipeHandler.HandleCollision(pipe,Mario, collisionFound);
                    CallMarioBlockHandler(pipe, collisionFound, intersection);

                }
            }
            float difference = (float)(Mario.Position.X - GameObjectManager.instance.CameraMario.Location.X);
            if ( difference <= 5 && difference>=0)
            {
                mario.Position += new Vector2(difference,0);
            }

        }
        public void CallMarioItemHandler(IItem obj, Direction collisionFound)
        {
            IMarioCollisionHandler marioHandler;
			if (obj is FireFlower)
			{

				marioHandler = new MarioFireFlowerCollisionHandler();
			}
			else if (obj is Starman)
			{

				marioHandler = new MarioStarmanCollisionHandler();

			}
			else if(obj is MagicMushroom)
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
			
        }
        public void CallMarioBlockHandler(IBlock block, Direction collisionFound, Rectangle intersection)
        {
            IMarioCollisionHandler marioHandler;
			if(block is HiddenBlock)
			{
				marioHandler = new MarioHiddenBlockHandler(intersection);
			}
			else
			{
				marioHandler = new MarioBlockHandler(intersection);
			}

			marioHandler.HandleCollision(Mario, collisionFound);

		}
      
        public void Update()
        {
			foreach(IController controller in ControllerList)
			{
				controller.Update();
			}
			for(int j =  GameObjectListsByType.Count -1; j>= 0;j--) 
			{
				Type gameObjectType = GameObjectListsByType.ElementAt(j).Key;
				for(int i = GameObjectListsByType[gameObjectType].Count - 1; i >= 0 ; i--)
				{
                    if (!CameraMario.offLeftRightScreen(gameObjectListsByType[gameObjectType][i].Box))
                    {
                        gameObjectListsByType[gameObjectType][i].Update();
                    }
				}
                if (CameraMario.offUpDownScreen(Mario.Box))
                {
                    Mario.Dead();
                }
			}
			UpdateCollision();
			CameraController.Update();
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
			foreach (Type gameObjectType in GameObjectListsByType.Keys)
			{
				foreach(IGameObject gameObj in GameObjectListsByType[gameObjectType])
				{
					gameObj.Draw(spriteBatch);
				}
			}
        }

		
    }
}
