﻿using Game1;
using Mario.BlocksClasses;
using Mario.Classes.BackgroundClasses;
using Mario.EnemyClasses;
using Mario.Enums;
using Mario.Factory;
using Mario.GameObjects.Block;
using Mario.Interfaces.GameObjects;
using Mario.ItemClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Mario.XMLRead
{
    public sealed class LevelLoader
    {
        public IList<IGameObject> projectileList = new List<IGameObject>();
        private static LevelLoader instance = new LevelLoader();
		public static LevelLoader Instance { get => instance; set => instance = value; }

        static readonly XmlSerializer blockSerializer = new XmlSerializer(typeof(List<BlockXML>), new XmlRootAttribute("Map"));
        static readonly XmlSerializer enemySerializer = new XmlSerializer(typeof(List<EnemyXML>), new XmlRootAttribute("Map"));
        static readonly XmlSerializer itemSerializer = new XmlSerializer(typeof(List<ItemXML>), new XmlRootAttribute("Map"));
        static readonly XmlSerializer pipeSerializer = new XmlSerializer(typeof(List<PipeXML>), new XmlRootAttribute("Map"));
        static readonly XmlSerializer playerSerializer = new XmlSerializer(typeof(List<PlayerXML>), new XmlRootAttribute("Map"));
        static readonly XmlSerializer backSerializer = new XmlSerializer(typeof(List<BackgroundXML>), new XmlRootAttribute("Map"));
        static readonly XmlSerializer projectileSerializer = new XmlSerializer(typeof(List<ProjectileXML>), new XmlRootAttribute("Map"));


        public Dictionary<string, XmlSerializer> xmlSerializersByType;

		private Dictionary<Type, Func<string, IList<IGameObject>>> LoadFunctionByType = new Dictionary<Type, Func<string, IList<IGameObject>>>
		{
			{typeof(IBlock),LoadBlock },
			{typeof(IItem), LoadItem },
			{typeof(IEnemy), LoadEnemy },
			{typeof(IBackground), LoadBackground },
			{typeof(IPipe), LoadPipe },
			{typeof(IMario), LoadPlayer },
            {typeof(IProjectile), LoadProjectile }
        };
         private LevelLoader()
        {
        }
        public void LoadFile(string file)
        {
			Queue<KeyValuePair<Type, Func<string, IList<IGameObject>>>> queuedChanges = new Queue<KeyValuePair<Type, Func<string, IList<IGameObject>>>>();
			foreach(Type key in ItemManager.Instance.gameObjectListsByType.Keys)
			{
				queuedChanges.Enqueue(new KeyValuePair<Type, Func<string, IList<IGameObject>>>(key, LoadFunctionByType[key]));
			}
			while(queuedChanges.Count > 0)
			{
				KeyValuePair<Type,Func<string,IList<IGameObject>>> item = queuedChanges.Dequeue();
				ItemManager.Instance.gameObjectListsByType[item.Key] = item.Value(file);
			}
        }
        public static IList<IGameObject> LoadBlock(string file)
        {
            IList<BlockXML> myBlockObject = new List<BlockXML>();
            using (XmlReader reader = XmlReader.Create(file))
            {
                myBlockObject = (IList<BlockXML>)blockSerializer.Deserialize(reader);
            }

			IList < IGameObject > blockList = new List<IGameObject>();
            foreach (BlockXML block in myBlockObject)
            {

                if (!GetType(block.BlockType).Equals(typeof(FloorBlock)) && !GetType(block.BlockType).Equals(typeof(UnbreakableBlock)))
                {
					Debug.WriteLine(block.BlockType + " is not a floor block and not an unbreakable block");
                    blockList.Add(BlockFactory.Instance.GetGameObject(GetType(block.BlockType), new Vector2(block.XLocation, block.YLocation)));
                }
                else if (GetType(block.BlockType).Equals(typeof(FloorBlock)))
                {
                    //add the box to item manager
                    
                    Rectangle floorLocationBox = new Rectangle(block.XLocation,block.YLocation,block.Length*32 ,block.Height*32);
                    ItemManager.Instance.FloorBoxPosition.Add(floorLocationBox);
                    //add floor(without boxes to the item manager)
					Debug.WriteLine(block.BlockType + " is a floor block");
                    int count = 0;
                    int count2 = 0;
                    int startLocation = block.XLocation;
                    while (count < block.Height)
                    {
                        while (count2 < block.Length)
                        {
                            blockList.Add(BlockFactory.Instance.GetGameObject(GetType(block.BlockType), new Vector2(block.XLocation, block.YLocation)));
                            block.XLocation += 32;
                            count2++;
                        }
                        block.YLocation = block.YLocation + 32;
                        count++;
                        count2 = 0;
                        block.XLocation = startLocation;
                    }
                }
                else
                {
                    if (block.Height > 0)
                    {
                        int count = block.Length;
                        int differentBetween = block.Length - block.Height;

                        while (count > differentBetween)
                        {
                            int startX = block.XLocation;
                            for (int i = 0; i < count; i++)
                            {
                                blockList.Add(BlockFactory.Instance.GetGameObject(GetType(block.BlockType), new Vector2(block.XLocation, block.YLocation)));
                                block.XLocation = block.XLocation + 32;
                            }
                            block.YLocation = block.YLocation - 32;
                            block.XLocation = startX + 32;
                            count--;
                        }
                    }
                    else
                    {
                        int count = block.Length;
                        int differentBetween = block.Length + block.Height;

                        while (count > differentBetween)
                        {
                            int startX = block.XLocation;
                            for (int i = 0; i < count; i++)
                            {
                                blockList.Add(BlockFactory.Instance.GetGameObject(GetType(block.BlockType), new Vector2(block.XLocation, block.YLocation)));
                                block.XLocation = block.XLocation + 32;
                            }
                            block.YLocation = block.YLocation - 32;
                            block.XLocation = startX;
                            count--;
                        }
                    }
                }
            }
            
			return blockList;
        }
        public static IList<IGameObject> LoadEnemy(string file)
        {
            IList<EnemyXML> myEnemyObject = new List<EnemyXML>();
            using (XmlReader reader = XmlReader.Create(file))
            {
                myEnemyObject = (IList<EnemyXML>)enemySerializer.Deserialize(reader);
            }
			IList<IGameObject> enemyList = new List<IGameObject>();
            foreach (EnemyXML enemy in myEnemyObject)
            {
				enemyList.Add(EnemyFactory.Instance.GetGameObject(GetType(enemy.EnemyType), new Vector2(enemy.XLocation, enemy.YLocation)));
                
            }
			return enemyList;
        }
        public static IList<IGameObject> LoadItem(string file)
        {
            IList<ItemXML> myItemObject = new List<ItemXML>();
            using (XmlReader reader = XmlReader.Create(file))
            {
                myItemObject = (IList<ItemXML>)itemSerializer.Deserialize(reader);
            }

			IList<IGameObject> itemList = new List<IGameObject>();
            foreach (ItemXML item in myItemObject)
            {
				
				itemList.Add(ItemFactory.Instance.GetGameObject(GetType(item.GameObjectType), new Vector2(item.XLocation, item.YLocation)));
            }
			return itemList;
        }

        public static IList<IGameObject> LoadPipe(string file)
        {
            IList<PipeXML> myPipeObject = new List<PipeXML>();
            using (XmlReader reader = XmlReader.Create(file))
            {
                myPipeObject = (IList<PipeXML>)pipeSerializer.Deserialize(reader);
            }
			IList<IGameObject> pipeList = new List<IGameObject>();
            foreach (PipeXML pipe in myPipeObject)
            {
                if(GetType(pipe.BlockType).Equals(typeof(Pipe)))
                    pipeList.Add(BlockFactory.Instance.GetGameObject(GetType("Pipe"),new Vector2(pipe.XLocation, pipe.YLocation)));
            }
			return pipeList;
        }
        public static IList<IGameObject> LoadBackground(string file)
        {
            IList<BackgroundXML> myBackgroundObject = new List<BackgroundXML>();
            using (XmlReader reader = XmlReader.Create(file))
            {
                myBackgroundObject = (IList<BackgroundXML>)backSerializer.Deserialize(reader);
            }
			IList<IGameObject> backgroundList = new List<IGameObject>();
            foreach (BackgroundXML back in myBackgroundObject)
            {
				backgroundList.Add(BackgroundFactory.Instance.GetGameObject(GetType(back.BackgroundType), new Vector2( back.XLocation, back.YLocation)));
            }
			return backgroundList;
        }
        public static IList<IGameObject> LoadProjectile(string file)
        {
            IList<ProjectileXML> myProjectileObject = new List<ProjectileXML>();
            using (XmlReader reader = XmlReader.Create(file))
            {
                myProjectileObject = (IList<ProjectileXML>)projectileSerializer.Deserialize(reader);
            }
            
            foreach (ProjectileXML projectile in myProjectileObject)
            {
                Instance.projectileList.Add(ProjectileFactory.Instance.GetGameObject(GetType(projectile.projectileType), new Vector2(projectile.XLocation, projectile.YLocation)));
            }
            return Instance.projectileList;
        }
        public static IList<IGameObject> LoadPlayer(string file)
        {
            IList<PlayerXML> myPlayerObject = new List<PlayerXML>();
            using (XmlReader reader = XmlReader.Create(file))
            {
                myPlayerObject = (IList<PlayerXML>)playerSerializer.Deserialize(reader);
            }
            IList<IGameObject> marioList = new List<IGameObject>();
            foreach (PlayerXML player in myPlayerObject)
            {
                marioList.Add(MarioFactory.Instance.GetGameObject(typeof(IMario), new Vector2(player.XLocation, player.YLocation)));

            }
            return marioList;
        }
		private static IDictionary<string, Type> typeDictionary = new Dictionary<string, Type>
			{
				{typeof(IMario).Name, typeof(IMario) },
				{typeof(IBlock).Name, typeof(IBlock) },
				{typeof(IBackground).Name,typeof(IBackground) },
				{typeof(IEnemy).Name, typeof(IEnemy) },

				{typeof(BushSingle).Name, typeof(BushSingle) },
				{typeof(BushTriple).Name, typeof(BushTriple) },
				{typeof(CloudSingle).Name, typeof(CloudSingle) },
				{typeof(CloudTriple).Name, typeof(CloudTriple) },
				{typeof(MountainBig).Name, typeof(MountainBig) },
				{typeof(MountainSmall).Name, typeof(MountainSmall) },

				{typeof(BreakableBlock).Name, typeof(BreakableBlock) },
				{typeof(FloorBlock).Name, typeof(FloorBlock) },
				{typeof(HiddenBlock).Name, typeof(HiddenBlock) },
				{typeof(Pipe).Name, typeof(Pipe) },
				{typeof(QuestionBlock).Name, typeof(QuestionBlock) },
				{typeof(UnbreakableBlock).Name,typeof(UnbreakableBlock) },

				{typeof(Koopa).Name, typeof(Koopa) },
				{typeof(Goomba).Name, typeof(Goomba) },

				{typeof(Coin).Name, typeof(Coin) },
				{typeof(FireFlower).Name, typeof(FireFlower) },
				{typeof(MagicMushroom).Name, typeof(MagicMushroom) },
				{typeof(OneUpMushroom).Name,typeof(OneUpMushroom) },
				{typeof(Starman).Name, typeof(Starman) },

				{typeof(Mario).Name, typeof(Mario) },

				{typeof(Fireball).Name, typeof(Fireball) }
			};
		public static Type GetType(string typeName)
		{
			try
			{
				return typeDictionary[typeName];
			}catch(System.Collections.Generic.KeyNotFoundException )
			{
				Debug.WriteLine(typeName + " is not a valid type");
			}
			return null;
		}
	}
}