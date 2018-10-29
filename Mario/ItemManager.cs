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

namespace Mario.XMLRead
{
	
    public class ItemManager
    {
		private static ItemManager instance = new ItemManager();
		public static ItemManager Instance { get=>instance; set=> instance = value; }
		private static IList<IController> ControllerList { get; set; }
		private Dictionary<Type, IList<IGameObject>> gameObjectListsByType = new Dictionary<Type, IList<IGameObject>>();
		public Dictionary<Type, IList<IGameObject>> GameObjectListsByType { get => gameObjectListsByType; set => gameObjectListsByType = value; }
		public IMario Mario { get { return (IMario)GameObjectListsByType[typeof(IMario)][0]; } set { GameObjectListsByType[typeof(IMario)][0] = value; } }
        public ICamera CameraMario { get; set; }
        public ICameraController CameraController { get; set; }
        //for floor
        public IList<Rectangle> FloorBoxPosition { get; }
        //end of floor box part
		public GameTime CurrentGameTime { get; set; }

		private ItemManager()
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
            //floor box
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
		public void TestingCollision()

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

			//TO DO: make gameobject interface and make lists with objects in the screen

			//CHECK with camera
			collisionFound = collisionDetecter.Collision(mario.Box, CameraMario.InnerBox);
			intersection = collisionDetecter.intersection;
			if (!collisionFound.Equals(Direction.None))
			{
				mario.Position += new Vector2(intersection.Width, 0);
			}

            //other checking
            //Floor Box
            foreach (Rectangle floorBox in FloorBoxPosition)
            {
                foreach (IProjectile projectile in GameObjectListsByType[typeof(IProjectile)])
                {
                    collisionFound = collisionDetecter.Collision(projectile.Box, floorBox);
                    intersection = collisionDetecter.intersection;
                    projectileCollisionHandler = new FireballBlockCollisionHandler(new BreakableBlock(new Vector2(0, 0)), intersection, collisionFound);
                    projectileCollisionHandler.HandleCollision(projectile);
                }
                foreach (IItem obj in GameObjectListsByType[typeof(IItem)])
                {
                    collisionFound = collisionDetecter.Collision(obj.Box, floorBox);
                    intersection = collisionDetecter.intersection;
                    itemHandler = new ItemBlockCollisionHandler(new BreakableBlock(new Vector2(0, 0)), intersection, collisionFound);
                    itemHandler.HandleCollision(obj);
                }
                foreach (IEnemy enemy in GameObjectListsByType[typeof(IEnemy)])
                {
                    if (!enemy.IsFlipped())
                    {
                        collisionFound = collisionDetecter.Collision(enemy.Box, floorBox);
                        intersection = collisionDetecter.intersection;
                        enemyHandler = new EnemyBlockCollisionHandler(new BreakableBlock(new Vector2(0, 0)), intersection, collisionFound);
                        enemyHandler.HandleCollision(enemy);
                    }
                }
                if (!mario.IsDead())
                {
                    collisionFound = collisionDetecter.Collision(Mario.Box, floorBox);
                    intersection = collisionDetecter.intersection;
                    blockHandler = new BlockHandler(Mario);
                    blockHandler.HandleCollision(new BreakableBlock(new Vector2(0, 0)),Mario, collisionFound);
                    CallMarioBlockHandler(new BreakableBlock(new Vector2(0, 0)), collisionFound, intersection);
                }
            }
            //projectile
            foreach (IProjectile projectile in GameObjectListsByType[typeof(IProjectile)])
            {
                foreach (IBlock block in GameObjectListsByType[typeof(IBlock)])
                {
                    collisionFound = collisionDetecter.Collision(projectile.Box, block.Box);
                    intersection = collisionDetecter.intersection;
                    projectileCollisionHandler = new FireballBlockCollisionHandler(block, intersection, collisionFound);
                    projectileCollisionHandler.HandleCollision(projectile);
                }
                foreach (IBlock pipe in GameObjectListsByType[typeof(IPipe)])
                {
                    collisionFound = collisionDetecter.Collision(projectile.Box, pipe.Box);
                    intersection = collisionDetecter.intersection;

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
            //item
            foreach (IItem obj in GameObjectListsByType[typeof(IItem)])
			{
				collisionFound = collisionDetecter.Collision(Mario.Box, obj.Box);
				if (collisionFound != Direction.None && !Mario.IsDead())
				{
					intersection = collisionDetecter.intersection;
					itemHandler = new ItemMarioCollisionHandler();
					itemHandler.HandleCollision(obj);
					CallMarioItemHandler(obj, collisionFound, intersection);
				}
				for (int i = GameObjectListsByType[typeof(IBlock)].Count - 1; i >= 0; i--)
				{
                    
                    IBlock block = (IBlock)GameObjectListsByType[typeof(IBlock)][i];
                    if (!block.IsHiddenBlock())
                    {
                        collisionFound = collisionDetecter.Collision(obj.Box, block.Box);
                        intersection = collisionDetecter.intersection;
                        itemHandler = new ItemBlockCollisionHandler(block, intersection, collisionFound);
                        itemHandler.HandleCollision(obj);
                    }
				}
				for (int i = GameObjectListsByType[typeof(IPipe)].Count - 1; i >= 0; i--)
				{
					IBlock pipe = (IBlock)GameObjectListsByType[typeof(IPipe)][i];
					collisionFound = collisionDetecter.Collision(obj.Box, pipe.Box);
					intersection = collisionDetecter.intersection;
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
					intersection = collisionDetecter.intersection;
					blockHandler = new BlockHandler(Mario);
                    blockHandler.HandleCollision(block, Mario,collisionFound);
					CallMarioBlockHandler(block, collisionFound, intersection);
				}
			}
            foreach (IEnemy enemy in GameObjectListsByType[typeof(IEnemy)])
            {
                if (!enemy.IsFlipped())
                {
                    collisionFound = collisionDetecter.Collision(Mario.Box, enemy.Box);
                    if (!Mario.IsDead())
                    {
                        enemyHandler = new EnemyMarioCollisionHandler(Mario,collisionFound);
                        intersection = collisionDetecter.intersection;
                        enemyHandler.HandleCollision(enemy);
                        marioHandler = new MarioEnemyCollisionHandler(enemy);
                        marioHandler.HandleCollision(Mario, collisionFound, intersection);
                    }
                    foreach (IBlock block in GameObjectListsByType[typeof(IBlock)])
                    {
                        if (!block.IsHiddenBlock())
                        {
                            collisionFound = collisionDetecter.Collision(enemy.Box, block.Box);
                            intersection = collisionDetecter.intersection;
                            enemyHandler = new EnemyBlockCollisionHandler(block, intersection, collisionFound);
                            enemyHandler.HandleCollision(enemy);
                        }

                    }
                    foreach (IBlock pipe in GameObjectListsByType[typeof(IPipe)])
                    {
                            collisionFound = collisionDetecter.Collision(enemy.Box, pipe.Box);
                            intersection = collisionDetecter.intersection;
                            enemyHandler = new EnemyBlockCollisionHandler(pipe, intersection, collisionFound);
                            enemyHandler.HandleCollision(enemy);

                    }
            
                    foreach (IEnemy goomba in GameObjectListsByType[typeof(IEnemy)])
                    {
                        if (enemy.IsKoopa() && goomba.IsGoomba())
                        {
                            collisionFound = collisionDetecter.Collision(enemy.Box, goomba.Box);
                            intersection = collisionDetecter.intersection;
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
                    pipeHandler = new BlockHandler(Mario);
                    intersection = collisionDetecter.intersection;
                    pipeHandler.HandleCollision(pipe,Mario, collisionFound);
                    CallMarioBlockHandler(pipe, collisionFound, intersection);

                }
            }
            //fix Mario position so that Mario can't go back based on Camera
            //STILL neeed to change
            float difference = (float)(Mario.Position.X - ItemManager.instance.CameraMario.Location.X);
            if ( difference <= 5 && difference>=0)
            {
                mario.Position += new Vector2(difference,0);
            }

        }
        public void CallMarioItemHandler(IItem obj, Direction collisionFound, Rectangle intersection)
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
				marioHandler.HandleCollision(Mario, collisionFound, intersection);
			}
			
        }
        public void CallMarioBlockHandler(IBlock block, Direction collisionFound, Rectangle intersection)
        {
            IMarioCollisionHandler marioHandler;
			if(block is HiddenBlock)
			{
				marioHandler = new MarioHiddenBlockHandler(block);
			}
			else
			{
				marioHandler = new MarioBlockHandler();
			}

			marioHandler.HandleCollision(Mario, collisionFound, intersection);

		}
        //add a big mushroom, star, 1plus mushroom, or a coin behind the block
        public void AddNormalItem(IBlock block)
        {
			Type IItemType = typeof(IItem);
            switch (block.ItemContains)
            {
                case "Coin":
                    GameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(typeof(Coin), new Vector2(block.Position.X, block.Position.Y-30)));
                    break;
                case "Starman":
                    GameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(typeof(Starman), new Vector2(block.Position.X, block.Position.Y - 30)));
                    break;
                case "OneUpMushroom":
                    GameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(typeof(OneUpMushroom), new Vector2(block.Position.X, block.Position.Y - 30)));
                    break;
                case "None":
                    GameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(typeof(MagicMushroom), new Vector2(block.Position.X, block.Position.Y - 30)));
                    break;
            }
        }
        //add a fire flower, 1plus mushroom, or a coin behind the block
        public void AddBigItem(IBlock block)
        {
			Type IItemType = typeof(IItem);
            switch (block.ItemContains)
            {
                case "Coin":
                    GameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(typeof(Coin), new Vector2(block.Position.X, block.Position.Y - 30)));
                    break;
                case "None":
                    GameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(typeof(FireFlower), new Vector2(block.Position.X, block.Position.Y - 30)));
                    break;
                case "Starman":
                    GameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(typeof(Starman), new Vector2(block.Position.X, block.Position.Y - 30)));
                    break;
                case "OneUpMushroom":
                    GameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(typeof(OneUpMushroom), new Vector2(block.Position.X, block.Position.Y - 30)));
                    break;
            }
        }
        public void Update()
        {
			foreach(IController controller in ControllerList)
			{
				controller.Update();
			}
			for(int j =  GameObjectListsByType.Count -1; j>= 0;j--) 
			{
				Type key = GameObjectListsByType.ElementAt(j).Key;
				for(int i = GameObjectListsByType[key].Count - 1; i >= 0 ; i--)
				{
					GameObjectListsByType[key][i].Update();
				}
				
			}
			TestingCollision();
			CameraController.Update();
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
			foreach (Type key in GameObjectListsByType.Keys)
			{
				foreach(IGameObject gameObj in GameObjectListsByType[key])
				{
					gameObj.Draw(spriteBatch);
				}
			}
        }

		
    }
}
