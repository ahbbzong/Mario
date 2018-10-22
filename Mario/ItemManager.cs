using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Game1;
using Mario.Enums;
using Mario.Collision;
using Mario.Collision.ItemCollisionHandler;
using Mario.Collision.MarioCollisionHandler.MarioItemCollisionHandler;
using Mario.Collision.MarioCollisionHandler.MarioBlockCollisionHandler;
using Mario.Collision.EnemyCollisionHandler;
using Mario.Collision.MarioCollisionHandler.MarioEnemyCollisionHandler;
using Mario.Interfaces.GameObjects;
using Mario.Factory;
using Mario.Interfaces.CollisionHandlers;
using Mario.Collision.FireballCollisionHandler;
using Mario.CameraClasses;

namespace Mario.XMLRead
{
    public class ItemManager
    {
		private static ItemManager instance = new ItemManager();
		public static ItemManager Instance { get=>instance; set=> instance = value; }
		private static IList<IController> ControllerList { get => Game1.Instance.controllerList; }
		public Dictionary<string, IList<IGameObject>> gameObjectListsByType;
        public IMario Mario { get { return (IMario)gameObjectListsByType["Mario"][0]; } }
        public ICamera CameraMario { get; set; }
        public ICameraController CameraController { get; set; }
        private ItemManager()
        {
			gameObjectListsByType = new Dictionary<string, IList<IGameObject>>
			{
				
				{"Background", new List<IGameObject>() },
				{"Item",new List<IGameObject>() },
				{"Enemy", new List<IGameObject>() },
				{"Block", new List<IGameObject>() },
				{"Pipe", new List<IGameObject>() },
                {"Projectile", new List<IGameObject>() },
                {"Mario",new List<IGameObject>() }

            };
        }
        public void SetInitialValuesCamera()
        {
            CameraMario = new Camera();
            CameraController = new CameraController(CameraMario);
        }
        public void LoadContent(SpriteBatch spriteBatch)
		{
			SpriteFactory.Instance.LoadAllTextures(Game1.Instance.Content);
			
			ItemFactory.Instance.LoadContent(Game1.Instance.Content);
			BlockFactory.Instance.LoadContent(Game1.Instance.Content);
			EnemyFactory.Instance.LoadContent(Game1.Instance.Content);
			BackgroundFactory.Instance.LoadContent(Game1.Instance.Content);
            ProjectileFactory.Instance.LoadContent(Game1.Instance.Content);
            MarioFactory.Instance.LoadContent(Game1.Instance.Content);

			LevelLoader.Instance.LoadFile("XMLFile1.xml");

            foreach (IController controller in ControllerList)
            {
                controller.Initialize((IMario)gameObjectListsByType["Mario"][0]);
            }
		}
		public void TestingCollision()

		{
			IMario mario = (IMario)gameObjectListsByType["Mario"][0];
            Direction collisionFound;
			Rectangle intersection;
			IBlockCollisionHandler blockHandler;
			IItemCollisionHandler itemHandler;
			IEnemyCollisionHandler enemyHandler;
			IMarioCollisionHandler marioHandler;
			IBlockCollisionHandler pipeHandler;
            IProjectileCollisionHandler projectileCollisionHandler;
			CollisionDetecter collisionDetecter = new CollisionDetecter();

            //TO DO: make gameobject interface and make lists with objects in the screen

            foreach (IProjectile projectile in gameObjectListsByType["Projectile"])
            {
                foreach (IBlock block in gameObjectListsByType["Block"])
                {
                    collisionFound = collisionDetecter.Collision(projectile.Box, block.Box);
                    intersection = collisionDetecter.intersection;
                    projectileCollisionHandler = new FireballBlockCollisionHandler(block, intersection, collisionFound);
                    projectileCollisionHandler.HandleCollision(projectile);
                }
                foreach (IEnemy enemy in gameObjectListsByType["Enemy"])
                {

                    projectileCollisionHandler = new FireballEnemyCollisionHandler(enemy);
                    enemyHandler = new EnemyProjectileCollisionHandler(projectile);
                    collisionFound = collisionDetecter.Collision(enemy.Box, projectile.Box);
                    if (collisionFound != Direction.None)
                    {
                        enemyHandler.HandleCollision(enemy, collisionFound);
                        projectileCollisionHandler.HandleCollision(projectile);
                    }
                }
            }
            foreach (IItem obj in gameObjectListsByType["Item"])
			{
				collisionFound = collisionDetecter.Collision(Mario.Box, obj.Box);
				if (collisionFound != Direction.None && !Mario.IsDead())
				{
					intersection = collisionDetecter.intersection;
					itemHandler = new ItemMarioCollisionHandler();
					itemHandler.HandleCollision(obj);
					CallMarioItemHandler(obj, collisionFound, intersection);
				}
			}
			foreach (IBlock block in gameObjectListsByType["Block"])
            {
                collisionFound = collisionDetecter.Collision(Mario.Box, block.Box);
                if (!Mario.IsDead())
                {
                    intersection = collisionDetecter.intersection;
                    blockHandler = new BlockHandler(Mario);
                    blockHandler.HandleCollision(block, Mario, collisionFound);
                    CallMarioBlockHandler(block, collisionFound, intersection);
                }
            }
            foreach (IEnemy enemy in gameObjectListsByType["Enemy"])
            {
                foreach (IBlock block in gameObjectListsByType["Block"])
                {
                    collisionFound = collisionDetecter.Collision(block.Box, enemy.Box);
                    intersection = collisionDetecter.intersection;
                    if (collisionFound != Direction.None)
                    {
                        enemyHandler = new EnemyBlockCollisionHandler(block,intersection);
                        enemyHandler.HandleCollision(enemy, collisionFound);
                    }
                }
            }
            foreach (IEnemy enemy in gameObjectListsByType["Enemy"])
            {

                collisionFound = collisionDetecter.Collision(Mario.Box, enemy.Box);
                if (collisionFound != Direction.None && !Mario.IsDead())
                {
                    enemyHandler = new EnemyMarioCollisionHandler(Mario);
                    intersection = collisionDetecter.intersection;
                    enemyHandler.HandleCollision(enemy, collisionFound);
                    marioHandler = new MarioEnemyCollisionHandler(enemy);
                    marioHandler.HandleCollision(Mario, collisionFound, intersection);
                }
            }
            foreach (IBlock pipe in gameObjectListsByType["Pipe"])
            {
                collisionFound = collisionDetecter.Collision(Mario.Box, pipe.Box);
                if (collisionFound != Direction.None && !Mario.IsDead())
                {
                    pipeHandler = new BlockHandler(Mario);
                    intersection = collisionDetecter.intersection;
                    pipeHandler.HandleCollision(pipe, Mario, collisionFound);
                    marioHandler = new MarioBlockHandler();
                    marioHandler.HandleCollision(Mario, collisionFound, intersection);

                }
            }
            //fix Mario position so that Mario can't go back based on Camera
            //STILL neeed to change
            float difference = (float)(Mario.Getposition().X - ItemManager.instance.CameraMario.Location.X);
            if ( difference <= 5 && difference>=0)
            {
                mario.Getposition().X += difference;
            }

        }
        public void CallMarioItemHandler(IItem obj, Direction collisionFound, Rectangle intersection)
        {
            IMarioCollisionHandler marioHandler;
            switch (obj.Type)
            {
                case ItemType.FireFlower:
                    marioHandler = new MarioFireFlowerCollisionHandler();
                    marioHandler.HandleCollision(Mario, collisionFound, intersection);
                    break;
                case ItemType.Starman:
                    marioHandler = new MarioStarmanCollisionHandler();
                    marioHandler.HandleCollision(Mario, collisionFound, intersection);
                    break;
                case ItemType.MagicMushroom:
                    marioHandler = new MarioMagicMushroomCollisionHandler();
                    marioHandler.HandleCollision(Mario, collisionFound, intersection);
                    break;
                default:
                    break;
            }
        }
        public void CallMarioBlockHandler(IBlock block, Direction collisionFound, Rectangle intersection)
        {
            IMarioCollisionHandler marioHandler;
            switch (block.Type)
            {
                case BlockType.Hidden:
                    marioHandler = new MarioHiddenBlockHandler(block);
                    marioHandler.HandleCollision(Mario, collisionFound, intersection);
                    break;
                default:
                    marioHandler = new MarioBlockHandler();
                    marioHandler.HandleCollision(Mario, collisionFound, intersection);
                    break;
            }
        }
        //add a big mushroom, star, 1plus mushroom, or a coin behind the block
        public void AddNormalItem(IBlock block)
        {
            Random rnd = new Random();
            int itemChoose = rnd.Next(1, 8);
            switch (itemChoose)
            {
                case 1:
                    gameObjectListsByType["Item"].Add(ItemFactory.Instance.GetGameObject("Coin", new Vector2(block.Getposition().X, block.Getposition().Y-20)));
                    break;
                case 2:
                    gameObjectListsByType["Item"].Add(ItemFactory.Instance.GetGameObject("Starman", new Vector2(block.Getposition().X, block.Getposition().Y - 20)));
                    break;
                case 3:
                    gameObjectListsByType["Item"].Add(ItemFactory.Instance.GetGameObject("OneUpMushroom", new Vector2(block.Getposition().X, block.Getposition().Y - 20)));
                    break;

                case 4:
                case 5:
                case 6:
                case 7:
                    gameObjectListsByType["Item"].Add(ItemFactory.Instance.GetGameObject("MagicMushroom", new Vector2(block.Getposition().X, block.Getposition().Y - 20)));
                    break;
            }
        }
        //add a fire flower, 1plus mushroom, or a coin behind the block
        public void AddBigItem(IBlock block)
        {
            Random rnd = new Random();
            int itemChoose = rnd.Next(1, 5);
            switch (itemChoose)
            {
                case 1:
                    gameObjectListsByType["Item"].Add(ItemFactory.Instance.GetGameObject("Coin", new Vector2(block.Getposition().X, block.Getposition().Y - 20)));
                    break;
                case 2:
                    gameObjectListsByType["Item"].Add(ItemFactory.Instance.GetGameObject("FireFlower", new Vector2(block.Getposition().X, block.Getposition().Y - 20)));
                    break;
                case 3:
                    gameObjectListsByType["Item"].Add(ItemFactory.Instance.GetGameObject("Starman", new Vector2(block.Getposition().X, block.Getposition().Y - 20)));
                    break;
                case 4:
                    gameObjectListsByType["Item"].Add(ItemFactory.Instance.GetGameObject("OneUpMushroom", new Vector2(block.Getposition().X, block.Getposition().Y - 20)));
                    break;
            }
        }
        public void Update()
        {
			TestingCollision();
			foreach(IController controller in ControllerList)
			{
				controller.Update();
			}
			foreach(string key in gameObjectListsByType.Keys)
			{
				foreach(IGameObject gameObj in gameObjectListsByType[key])
				{
					gameObj.Update();
				}
			}
            CameraController.Update();
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
			foreach (string key in gameObjectListsByType.Keys)
			{
				foreach(IGameObject gameObj in gameObjectListsByType[key])
				{
					gameObj.Draw(spriteBatch);
				}
			}
        }

    }
}
