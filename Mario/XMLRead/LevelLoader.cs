using Game1;
using Mario.BlocksClasses;
using Mario.Classes.BackgroundClasses;
using Mario.EnemyClasses;
using Mario.Enums;
using Mario.Factory;
using Mario.Interfaces.GameObjects;
using Mario.ItemClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
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

		private Dictionary<string, Func<string, IList<IGameObject>>> LoadFunctionByType = new Dictionary<string, Func<string, IList<IGameObject>>>
		{
			{"Block",LoadBlock },
			{"Item", LoadItem },
			{"Enemy", LoadEnemy },
			{"Background", LoadBackground },
			{"Pipe", LoadPipe },
			{"Mario", LoadPlayer },
            {"Projectile", LoadProjectile }
        };
         private LevelLoader()
        {
        }
        public void LoadFile(string file)
        {
			Queue<KeyValuePair<string, Func<string, IList<IGameObject>>>> queuedChanges = new Queue<KeyValuePair<string, Func<string, IList<IGameObject>>>>();
			foreach(string key in ItemManager.Instance.gameObjectListsByType.Keys)
			{
				queuedChanges.Enqueue(new KeyValuePair<string, Func<string, IList<IGameObject>>>(key, LoadFunctionByType[key]));
			}
			while(queuedChanges.Count > 0)
			{
				KeyValuePair<string,Func<string,IList<IGameObject>>> item = queuedChanges.Dequeue();
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
                if (block.BlockType != BlockType.Floor)
                {
                    blockList.Add(BlockFactory.Instance.GetGameObject(block.BlockType.ToString(), new Vector2(block.XLocation, block.YLocation)));
                }
                else
                {
                    int count = 0;
                    int count2 = 0;

                    while (count < block.Height)
                    {
                        while (count2 < block.Length)
                        {
                            blockList.Add(BlockFactory.Instance.GetGameObject(block.BlockType.ToString(), new Vector2(block.XLocation, block.YLocation)));
                            block.XLocation = block.XLocation + 32;
                            count2++;
                        }
                        block.YLocation = block.YLocation + 32;
                        count++;
                        count2 = 0;
                        block.XLocation = 0;
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
				enemyList.Add(EnemyFactory.Instance.GetGameObject(enemy.EnemyType.ToString(), new Vector2(enemy.XLocation, enemy.YLocation)));
                
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
				itemList.Add(ItemFactory.Instance.GetGameObject(item.GameObjectType.ToString(), new Vector2(item.XLocation, item.YLocation)));
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
                if(pipe.BlockType==BlockType.Pipe)
                    pipeList.Add(BlockFactory.Instance.GetGameObject(BlockType.Pipe.ToString(),new Vector2(pipe.XLocation, pipe.YLocation)));
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
				backgroundList.Add(BackgroundFactory.Instance.GetGameObject(back.BackgroundType.ToString(), new Vector2( back.XLocation, back.YLocation)));
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
                LevelLoader.Instance.projectileList.Add(ProjectileFactory.Instance.GetGameObject(projectile.projectileType.ToString(), new Vector2(projectile.XLocation, projectile.YLocation)));
            }
            return LevelLoader.Instance.projectileList;
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
                marioList.Add(MarioFactory.Instance.GetGameObject(player.PlayerName.ToString(), new Vector2(player.XLocation, player.YLocation)));

            }
            return marioList;
        }
    }
}