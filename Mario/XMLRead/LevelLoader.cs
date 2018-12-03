﻿using Game1;
using Mario.BlocksClasses;
using Mario.BlockStates;
using Mario.CameraClasses;
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
		private readonly IList<IGameObject> projectileList = new List<IGameObject>();
		public IList<IGameObject> ProjectileList { get => projectileList;  }
		private static LevelLoader instance = new LevelLoader();
		private static IList<Type> gameObjectSubTypes = new List<Type>
		{
			typeof(IBlock),
			typeof(IItem),
			typeof(IEnemy),
			typeof(IBackground),
			typeof(IPipe),
			typeof(IProjectile),
			typeof(IMario)

		};
		public static LevelLoader Instance { get => instance; set => instance = value; }
        public static IList<int> NumberList = new List<int>();
        public static int firstChunkDisplay;
        public static int secondChunkDisplay;
        public static int thirdChunkDisplay;

        static readonly XmlSerializer pipeSerializer = new XmlSerializer(typeof(List<PipeXML>), new XmlRootAttribute("Map"));
        static readonly XmlSerializer blockSerializer = new XmlSerializer(typeof(List<BlockXML>), new XmlRootAttribute("Map"));
        static readonly XmlSerializer enemySerializer = new XmlSerializer(typeof(List<EnemyXML>), new XmlRootAttribute("Map"));
        static readonly XmlSerializer itemSerializer = new XmlSerializer(typeof(List<ItemXML>), new XmlRootAttribute("Map"));
        static readonly XmlSerializer playerSerializer = new XmlSerializer(typeof(List<PlayerXML>), new XmlRootAttribute("Map"));
        static readonly XmlSerializer backSerializer = new XmlSerializer(typeof(List<BackgroundXML>), new XmlRootAttribute("Map"));
        static readonly XmlSerializer projectileSerializer = new XmlSerializer(typeof(List<ProjectileXML>), new XmlRootAttribute("Map"));


		private Dictionary<string, XmlSerializer> xmlSerializersByType;
		public Dictionary<string, XmlSerializer> XmlSerializersByType { get => xmlSerializersByType; set => xmlSerializersByType = value; }

		private readonly Dictionary<Type, Func<string, IList<IGameObject>>> LoadFunctionByType = new Dictionary<Type, Func<string, IList<IGameObject>>>
		{
            {typeof(IPipe), LoadPipe },
            {typeof(IBlock),LoadBlock },
			{typeof(IItem), LoadItem },
			{typeof(IEnemy), LoadEnemy },
			{typeof(IBackground), LoadBackground },
			{typeof(IMario), LoadPlayer },
            {typeof(IProjectile), LoadProjectile }
        };
         private LevelLoader()
        {
        }
        public void LoadFile(string file)
        {
            NumberList = RandomNumber();
            firstChunkDisplay = NumberList.ElementAt(0);
         secondChunkDisplay = NumberList.ElementAt(1);
       thirdChunkDisplay = NumberList.ElementAt(2);

        Queue<KeyValuePair<Type, Func<string, IList<IGameObject>>>> queuedChanges = new Queue<KeyValuePair<Type, Func<string, IList<IGameObject>>>>();
			foreach(Type gameObjectType in gameObjectSubTypes)
			{
				queuedChanges.Enqueue(new KeyValuePair<Type, Func<string, IList<IGameObject>>>(gameObjectType, LoadFunctionByType[gameObjectType]));
			}
			while(queuedChanges.Count > LevelLoaderUtil.zero)
			{
				KeyValuePair<Type,Func<string,IList<IGameObject>>> item = queuedChanges.Dequeue();
				GameObjectManager.Instance.GameObjectList.AddListByType(item.Key,item.Value(file));
			}
			GameObjectManager.Instance.GameObjectList.DisplayElementsToConsole();
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
                if (GetType(pipe.BlockType).Equals(typeof(Pipe)))
                {
                    int findOffSet = FindNumberInList(pipe.Chunk);

                    pipeList.Add(BlockFactory.Instance.GetGameObject(GetType("Pipe"), new Vector2(pipe.XLocation + findOffSet* CameraUtil.resolutionWidth, pipe.YLocation)));
                    ((IPipe)pipeList.Last<IGameObject>()).SetToUnderground(pipe.IsToUnderground);
                }
                    
            }
            return pipeList;
        }
        public static IList<IGameObject> LoadBlock(string file)
        {
            IList<BlockXML> myBlockObject = new List<BlockXML>();
            using (XmlReader reader = XmlReader.Create(file))
            {
                myBlockObject = (IList<BlockXML>)blockSerializer.Deserialize(reader);
            }


            IList< IGameObject > blockList = new List<IGameObject>();
            foreach (BlockXML block in myBlockObject)
            {
                int findOffSet = FindNumberInList(block.Chunk);
                if (!GetType(block.BlockType).Equals(typeof(FloorBlockState)) && !GetType(block.BlockType).Equals(typeof(UnbreakableBlockState)))
                {
                    blockList.Add(BlockFactory.Instance.GetGameObject(GetType(block.BlockType), new Vector2(block.XLocation + findOffSet*CameraUtil.resolutionWidth, block.YLocation)));
                    ((IBlock)blockList.Last<IGameObject>()).ItemContained = block.ItemContains;
                }
                else if (GetType(block.BlockType).Equals(typeof(FloorBlockState)))
                {
                    
                    Rectangle floorLocationBox = new Rectangle(block.XLocation,block.YLocation,block.Length*32 ,block.Height*32);
                    GameObjectManager.Instance.FloorBoxPositions.Add(floorLocationBox);
                    int count = LevelLoaderUtil.zero;
                    int count2 = LevelLoaderUtil.zero;
                    int startLocation = block.XLocation;
                    while (count < block.Height)
                    {
                        while (count2 < block.Length)
                        {
                            blockList.Add(BlockFactory.Instance.GetGameObject(GetType(block.BlockType), new Vector2(block.XLocation, block.YLocation)));
                            block.XLocation += LevelLoaderUtil.blockOffset;
                            count2++;
                        }
                        block.YLocation = block.YLocation + LevelLoaderUtil.blockOffset;
                        count++;
                        count2 = LevelLoaderUtil.zero;
                        block.XLocation = startLocation;
                    }
                }
                else
                {
                    if (block.Height > LevelLoaderUtil.zero)
                    {
                        int count = block.Length;
                        int differentBetween = block.Length - block.Height;

                        while (count > differentBetween)
                        {
                            int startX = block.XLocation;
                            for (int i = LevelLoaderUtil.zero; i < count; i++)
                            {
                                blockList.Add(BlockFactory.Instance.GetGameObject(GetType(block.BlockType), new Vector2(block.XLocation + findOffSet * CameraUtil.resolutionWidth, block.YLocation)));
                                block.XLocation = block.XLocation + LevelLoaderUtil.blockOffset;
                            }
                            block.YLocation = block.YLocation - LevelLoaderUtil.blockOffset;
                            block.XLocation = startX + LevelLoaderUtil.blockOffset;
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
                            for (int i = LevelLoaderUtil.zero; i < count; i++)
                            {
                                blockList.Add(BlockFactory.Instance.GetGameObject(GetType(block.BlockType), new Vector2(block.XLocation + findOffSet * CameraUtil.resolutionWidth, block.YLocation)));
                                block.XLocation = block.XLocation + LevelLoaderUtil.blockOffset;
                            }
                            block.YLocation = block.YLocation - LevelLoaderUtil.blockOffset;
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
                int findOffSet = FindNumberInList(enemy.Chunk);
                enemyList.Add(EnemyFactory.Instance.GetGameObject(GetType(enemy.EnemyType), new Vector2(enemy.XLocation+findOffSet*CameraUtil.resolutionWidth, enemy.YLocation)));
                
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
                int findOffSet = FindNumberInList(item.Chunk);

                itemList.Add(ItemFactory.Instance.GetGameObject(GetType(item.GameObjectType), new Vector2(item.XLocation+findOffSet*CameraUtil.resolutionWidth, item.YLocation)));
            }
			return itemList;
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
                int findOffSet = FindNumberInList(back.Chunk);
                if (back.BackgroundType.Equals("Flag")){
					GameObjectManager.Instance.EndOfLevelXPosition = back.XLocation;
				}
				backgroundList.Add(BackgroundFactory.Instance.GetBackgroundObject(back.BackgroundType, new Vector2( back.XLocation+findOffSet*CameraUtil.resolutionWidth, back.YLocation)));
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
                Instance.ProjectileList.Add(ProjectileFactory.Instance.GetGameObject(GetType(projectile.projectileType), new Vector2(projectile.XLocation, projectile.YLocation)));
            }
            return Instance.ProjectileList;
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
		private static readonly IDictionary<string, Type> typeDictionary = new Dictionary<string, Type>
			{
				{typeof(IMario).Name, typeof(IMario) },
				{typeof(IBlock).Name, typeof(IBlock) },
				{typeof(IBackground).Name,typeof(IBackground) },
				{typeof(IEnemy).Name, typeof(IEnemy) },
				{typeof(FloorBlockState).Name, typeof(FloorBlockState) },
				{typeof(HiddenBlockState).Name, typeof(HiddenBlockState) },
				{typeof(Pipe).Name, typeof(Pipe) },
				{typeof(QuestionBlockState).Name, typeof(QuestionBlockState) },
				{typeof(UnbreakableBlockState).Name,typeof(UnbreakableBlockState) },
				{typeof(BrickBlockState).Name, typeof(BrickBlockState) },

				{typeof(Koopa).Name, typeof(Koopa) },
				{typeof(Goomba).Name, typeof(Goomba) },

				{typeof(Coin).Name, typeof(Coin) },
				{typeof(FireFlower).Name, typeof(FireFlower) },
				{typeof(MagicMushroom).Name, typeof(MagicMushroom) },
				{typeof(OneUpMushroom).Name,typeof(OneUpMushroom) },
				{typeof(Starman).Name, typeof(Starman) },
                {typeof(UnderGroundCoin).Name, typeof(UnderGroundCoin) },


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
        //move to somewhere else late
        public static List<int> RandomNumber()
        {
            Random rand = new Random();
            List<int> listNumbers = new List<int>();
            int number;
            for (int i = 0; i < 3; i++)
            {
                do
                {
                    number = rand.Next(2,5);
                } while (listNumbers.Contains(number));
                listNumbers.Add(number);
            }
            return listNumbers;
        }
        public static int FindNumberInList(int chunk)
        {
            int returnTheNumber;
            if (chunk == 5 || chunk == 1||chunk==6)
            {
                returnTheNumber = 0;
            }
            else if (chunk == firstChunkDisplay)
            {
                returnTheNumber = 1;
            }
            else if (chunk == secondChunkDisplay)
            {
                returnTheNumber = 2;
            }
            else
            {
                returnTheNumber = 3;
            }
            return returnTheNumber;
        }

    }
}