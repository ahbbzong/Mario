using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game1;
using Mario.Enums;
using Mario.Collision;
using Mario.Collision.ItemCollisionHandler;
using Mario.Collision.MarioCollisionHandler.MarioItemCollisionHandler;
using Mario.Collision.MarioCollisionHandler.MarioBlockCollisionHandler;
using Mario.Collision.EnemyCollisionHandler;
using Mario.Collision.MarioCollisionHandler.MarioEnemyCollisionHandler;

namespace Mario.XMLRead
{
    public sealed class ItemManager
    {
        private static IList<IItem> itemList = new List<IItem>();
        private static IList<IEnemy> enemyList = new List<IEnemy>();
        private static IList<IBlock> blockList =  new List<IBlock>();
        private static IList<IBlock> pipeList = new List<IBlock>();
        private static IList<IBackground> backgroundList = new List<IBackground>();
        private static Vector2 playerMario = new Vector2();
        private static IMario mario = new Mario(playerMario);
        public static IList<IItem> ItemList { get { return itemList; } }
        public static IList<IEnemy> EnemyList { get { return enemyList; } }
        public static IList<IBlock> BlockList { get { return blockList; } }
        public static IList<IBlock> PipeList { get { return pipeList; } }
        public static IList<IBackground> BackgroundList { get { return backgroundList; } }
        public static Vector2 PlayerMario { get; set; }
        public static IMario Mario { get { return mario; } }
        private ItemManager()
        {
        }
        public static void TestingCollision(IMario MarioInGame)

        {
            mario = MarioInGame;
            Direction collisionFound;
            Rectangle intersection;
            IBlockCollisionHandler blockHandler;
            IItemCollisionHandler itemHandler;
            IEnemyCollisionHandler enemyHandler;
            IMarioCollisionHandler marioHandler;
            IBlockCollisionHandler pipeHandler;
            CollisionDetecter collisionDetecter = new CollisionDetecter();
           
            //TO DO: make gameobject interface and make lists with objects in the screen
            foreach (IItem obj in itemList)
            {
                collisionFound = collisionDetecter.Collision(Mario.Box, obj.Box);
                if (collisionFound != Direction.None && !Mario.IsDead())
                {
                    intersection = collisionDetecter.intersection;
                    itemHandler = new ItemMarioCollisionHandler();
                    itemHandler.HandleCollision(obj);
                    //call the handler for mario using current objects
                    CallMarioItemHandler(obj,collisionFound,intersection);
                }
            }
            foreach (IBlock block in blockList)
            {
                collisionFound = collisionDetecter.Collision(Mario.Box, block.Box);
                if (collisionFound != Direction.None && !Mario.IsDead())
                {
                    intersection = collisionDetecter.intersection;
                    blockHandler = new BlockHandler(Mario);

                    //call the handler for mario using current objects
                    blockHandler.HandleCollision(block, collisionFound);
                    CallMarioBlockHandler(block, collisionFound, intersection);
                }
            }
            foreach (IEnemy enemy in enemyList)
            {
                collisionFound = collisionDetecter.Collision(Mario.Box, enemy.Box);
                if (collisionFound != Direction.None && !Mario.IsDead())
                {
                    enemyHandler = new EnemyMarioCollisionHandler(Mario);
                    intersection = collisionDetecter.intersection;

                    //call the handler for mario using current objects
                    enemyHandler.HandleCollision(enemy, collisionFound);
                    marioHandler = new MarioEnemyCollisionHandler(enemy);
                    marioHandler.HandleCollision(Mario, collisionFound, intersection);
                }
            }
            foreach (IBlock pipe in pipeList)
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
        public static void CallMarioItemHandler(IItem obj, Direction collisionFound, Rectangle intersection)
        {
            IMarioCollisionHandler marioHandler;
            switch (obj.Type)
            {
                case GameObjectType.FireFlower:
                    marioHandler = new MarioFireFlowerCollisionHandler();
                    marioHandler.HandleCollision(Mario, collisionFound, intersection);
                    break;
                case GameObjectType.Starman:
                    marioHandler = new MarioStarmanCollisionHandler();
                    marioHandler.HandleCollision(Mario, collisionFound, intersection);
                    break;
                case GameObjectType.MagicMushroom:
                    marioHandler = new MarioMagicMushroomCollisionHandler();
                    marioHandler.HandleCollision(Mario, collisionFound, intersection);
                    break;
                default:
                    break;
            }
        }
        public static void CallMarioBlockHandler(IBlock block, Direction collisionFound, Rectangle intersection)
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
        public static void Update()
        {
            foreach (IBackground obj in backgroundList)
            {
                obj.Update();
            }
            foreach (IBlock obj in BlockList)
            {
                obj.Update();
            }
            foreach (IEnemy obj in enemyList)
            {
                obj.Update();
            }
            foreach (IItem obj in itemList)
            {
                obj.Update();
            }
            foreach (IBlock obj in pipeList)
            {
                obj.Update();
            }
        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (IBackground obj in backgroundList)
            {
                obj.Draw(spriteBatch);
            }
            foreach (IBlock obj in blockList)
            {
                obj.Draw(spriteBatch);
            }
            foreach (IEnemy obj in enemyList)
            {
                obj.Draw(spriteBatch);
            }
            foreach (IItem obj in itemList)
            {
                obj.Draw(spriteBatch);
            }
            foreach (IBlock obj in pipeList)
            {
                obj.Draw(spriteBatch);
            }
        }

    }
}
