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

namespace Mario.XMLRead
{
    public class ItemManager
    {
		private static ItemManager instance = new ItemManager();
		public static ItemManager Instance { get=>instance; set=> instance = value; }
		private static IList<IController> ControllerList { get => Game1.Instance.controllerList; }
		public Dictionary<string, IList<IGameObject>> gameObjectListsByType;
		private IMario mario;
        public IMario Mario { get { return (IMario)gameObjectListsByType["Mario"][0]; } }
		private ItemManager()
        {
			gameObjectListsByType = new Dictionary<string, IList<IGameObject>>
			{
				{"Mario",new List<IGameObject>() },
				{"Item",new List<IGameObject>() },
				{"Enemy", new List<IGameObject>() },
				{"Block", new List<IGameObject>() },
				{"Pipe", new List<IGameObject>() },
				{"Background", new List<IGameObject>() }

			};
        }
		
		public void LoadContent(SpriteBatch spriteBatch)
		{
			SpriteFactory.Instance.LoadAllTextures(Game1.Instance.Content);
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
			CollisionDetecter collisionDetecter = new CollisionDetecter();

			//TO DO: make gameobject interface and make lists with objects in the screen
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
                if (collisionFound != Direction.None && !Mario.IsDead())
                {
                    intersection = collisionDetecter.intersection;
                    blockHandler = new BlockHandler(Mario);
                    blockHandler.HandleCollision(block, collisionFound);
                    CallMarioBlockHandler(block, collisionFound, intersection);
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
                    pipeHandler.HandleCollision(pipe, collisionFound);
                    marioHandler = new MarioBlockHandler();
                    marioHandler.HandleCollision(Mario, collisionFound, intersection);

                }
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
