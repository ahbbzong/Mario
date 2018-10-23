﻿using System;
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
using Mario.BlocksClasses;
using Mario.ItemClasses;
using System.Diagnostics;
using Mario.GameObjects.Block;

namespace Mario.XMLRead
{
    public class ItemManager
    {
		private static ItemManager instance = new ItemManager();
		public static ItemManager Instance { get=>instance; set=> instance = value; }
		private static IList<IController> ControllerList { get => Game1.Instance.controllerList; }
		public Dictionary<Type, IList<IGameObject>> gameObjectListsByType = new Dictionary<Type, IList<IGameObject>>();
        public IMario Mario { get { return (IMario)gameObjectListsByType[typeof(IMario)][0]; } set { gameObjectListsByType[typeof(IMario)][0] = value; } }
        public ICamera CameraMario { get; set; }
        public ICameraController CameraController { get; set; }

		public GameTime CurrentGameTime { get; set; }
        private ItemManager()
        {
            gameObjectListsByType = new Dictionary<Type, IList<IGameObject>>
            {

                {typeof(IBackground), new List<IGameObject>() },
                {typeof(IItem),new List<IGameObject>() },
                {typeof(IPipe), new List<IGameObject>() },
                {typeof(IBlock), new List<IGameObject>() },
                {typeof(IProjectile), new List<IGameObject>() },
                {typeof(IEnemy), new List<IGameObject>() },
                {typeof(IMario),new List<IGameObject>() }
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
			Debug.WriteLine("SpriteFactory Loaded");
			ItemFactory.Instance.LoadContent(Game1.Instance.Content);
			BlockFactory.Instance.LoadContent(Game1.Instance.Content);
			EnemyFactory.Instance.LoadContent(Game1.Instance.Content);
			BackgroundFactory.Instance.LoadContent(Game1.Instance.Content);
            ProjectileFactory.Instance.LoadContent(Game1.Instance.Content);
            MarioFactory.Instance.LoadContent(Game1.Instance.Content);

			LevelLoader.Instance.LoadFile("XMLFile1.xml");

            foreach (IController controller in ControllerList)
            {
                controller.Initialize((IMario)gameObjectListsByType[typeof(IMario)][0]);
            }
		}
        public void TestingCollision()

        {
            IMario mario = (IMario)gameObjectListsByType[Type.GetType("IMario")][0];
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

            //CHECK with camera
            collisionFound = collisionDetecter.Collision(mario.Box, CameraMario.InnerBox);
            intersection = collisionDetecter.intersection;
            if (!collisionFound.Equals(Direction.None))
            { 
                 mario.Position += new Vector2( intersection.Width,0);
            }

            //other checking
            foreach (IProjectile projectile in gameObjectListsByType[Type.GetType("IProjectile")])
            {
                foreach (IBlock block in gameObjectListsByType[Type.GetType("IBlock")])
                {
                    collisionFound = collisionDetecter.Collision(projectile.Box, block.Box);
                    intersection = collisionDetecter.intersection;
                    projectileCollisionHandler = new FireballBlockCollisionHandler(block, intersection, collisionFound);
                    projectileCollisionHandler.HandleCollision(projectile);
                }
                foreach (IEnemy enemy in gameObjectListsByType[Type.GetType("IEnemy")])
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
            foreach (IItem obj in gameObjectListsByType[Type.GetType("IItem")])
			{
				collisionFound = collisionDetecter.Collision(Mario.Box, obj.Box);
				if (collisionFound != Direction.None && !Mario.IsDead())
				{
					intersection = collisionDetecter.intersection;
					itemHandler = new ItemMarioCollisionHandler();
					itemHandler.HandleCollision(obj);
					CallMarioItemHandler(obj, collisionFound, intersection);
				}
                foreach (IBlock block in gameObjectListsByType[Type.GetType("IBlock")])
                {
                    collisionFound = collisionDetecter.Collision(obj.Box, block.Box);
                    intersection = collisionDetecter.intersection;
                    itemHandler = new ItemBlockCollisionHandler(block,intersection,collisionFound);
                    itemHandler.HandleCollision(obj);
                }
                foreach (IBlock pipe in gameObjectListsByType[Type.GetType("IPipe")])
                {
                    collisionFound = collisionDetecter.Collision(obj.Box, pipe.Box);
                    intersection = collisionDetecter.intersection;
                    itemHandler = new ItemBlockCollisionHandler(pipe, intersection, collisionFound);
                    itemHandler.HandleCollision(obj);
                }

            }
			foreach (IBlock block in gameObjectListsByType[Type.GetType("IBlock")])
            {
                collisionFound = collisionDetecter.Collision(Mario.Box, block.Box);
                if (!Mario.IsDead())
                {
                    float storedLocation = block.Position.Y;
                    intersection = collisionDetecter.intersection;
                    blockHandler = new BlockHandler(Mario);
                    blockHandler.HandleCollision(block, Mario, collisionFound);
                    CallMarioBlockHandler(block, collisionFound, intersection);
                }
            }
            foreach (IEnemy enemy in gameObjectListsByType[Type.GetType("IEnemy")])
            {
                foreach (IBlock block in gameObjectListsByType[Type.GetType("IBlock")])
                {
                    collisionFound = collisionDetecter.Collision(enemy.Box, block.Box);
                    intersection = collisionDetecter.intersection;
                  
                        enemyHandler = new EnemyBlockCollisionHandler(block,intersection);
                        enemyHandler.HandleCollision(enemy, collisionFound);
                    
                }
                foreach (IBlock pipe in gameObjectListsByType[Type.GetType("IPipe")])
                {
                    collisionFound = collisionDetecter.Collision(enemy.Box, pipe.Box);
                    intersection = collisionDetecter.intersection;

                    enemyHandler = new EnemyBlockCollisionHandler(pipe, intersection);
                    enemyHandler.HandleCollision(enemy, collisionFound);

                }
            }
                       foreach (IEnemy enemy in gameObjectListsByType[Type.GetType("IEnemy")])
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
                        foreach (IEnemy anotherEnemy in gameObjectListsByType[Type.GetType("IEnemy")])
                            {
                    if (!enemy.Equals(anotherEnemy))
                    {
                        collisionFound = collisionDetecter.Collision(enemy.Box, anotherEnemy.Box);
                        intersection = collisionDetecter.intersection;
                        enemyHandler = new EnemyEnemyCollisionHandler(anotherEnemy,intersection);
                        enemyHandler.HandleCollision(enemy, collisionFound);
                    }
                }
                    }
                
            
            foreach (IBlock pipe in gameObjectListsByType[Type.GetType("IPipe")])
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
			Type IItemType = Type.GetType("IItem");
            Random rnd = new Random();
            int itemChoose = rnd.Next(1, 8);
            switch (itemChoose)
            {
                case 1:
                    gameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(Type.GetType("Coin"), new Vector2(block.Position.X, block.Position.Y-30)));
                    break;
                case 2:
                    gameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(Type.GetType("Starman"), new Vector2(block.Position.X, block.Position.Y - 30)));
                    break;
                case 3:
                    gameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(Type.GetType("OneUpMushroom"), new Vector2(block.Position.X, block.Position.Y - 30)));
                    break;

                case 4:
                case 5:
                case 6:
                case 7:
                    gameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(Type.GetType("MagicMushroom"), new Vector2(block.Position.X, block.Position.Y - 30)));
                    break;
            }
        }
        //add a fire flower, 1plus mushroom, or a coin behind the block
        public void AddBigItem(IBlock block)
        {
			Type IItemType = Type.GetType("IItem");
            Random rnd = new Random();
            int itemChoose = rnd.Next(1, 5);
            switch (itemChoose)
            {
                case 1:
                    gameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(Type.GetType("Coin"), new Vector2(block.Position.X, block.Position.Y - 30)));
                    break;
                case 2:
                    gameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(Type.GetType("FireFlower"), new Vector2(block.Position.X, block.Position.Y - 30)));
                    break;
                case 3:
                    gameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(Type.GetType("Starman"), new Vector2(block.Position.X, block.Position.Y - 30)));
                    break;
                case 4:
                    gameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(Type.GetType("OneUpMushroom"), new Vector2(block.Position.X, block.Position.Y - 30)));
                    break;
            }
        }
        public void Update()
        {
			foreach(IController controller in ControllerList)
			{
				controller.Update();
			}
			for(int j =  gameObjectListsByType.Count -1; j>= 0;j--) 
			{
				Type key = gameObjectListsByType.ElementAt(j).Key;
				for(int i = gameObjectListsByType[key].Count - 1; i >= 0 ; i--)
				{
					gameObjectListsByType[key][i].Update();
				}
				
			}
			TestingCollision();
			CameraController.Update();
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
			foreach (Type key in gameObjectListsByType.Keys)
			{
				foreach(IGameObject gameObj in gameObjectListsByType[key])
				{
					gameObj.Draw(spriteBatch);
				}
			}
        }

		
    }
}
