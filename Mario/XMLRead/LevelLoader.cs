using Game1;
using Mario.BlocksClasses;
using Mario.Classes.BackgroundClasses;
using Mario.EnemyClasses;
using Mario.Enums;
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
        static readonly XmlSerializer blockSerializer = new XmlSerializer(typeof(List<BlockXML>), new XmlRootAttribute("Map"));
        static readonly XmlSerializer enemySerializer = new XmlSerializer(typeof(List<EnemyXML>), new XmlRootAttribute("Map"));
        static readonly XmlSerializer itemSerializer = new XmlSerializer(typeof(List<ItemXML>), new XmlRootAttribute("Map"));
        static readonly XmlSerializer pipeSerializer = new XmlSerializer(typeof(List<PipeXML>), new XmlRootAttribute("Map"));
        static readonly XmlSerializer playerSerializer = new XmlSerializer(typeof(List<PlayerXML>), new XmlRootAttribute("Map"));
        static readonly XmlSerializer backSerializer = new XmlSerializer(typeof(List<BackgroundXML>), new XmlRootAttribute("Map"));

         private LevelLoader()
        {
        }
        public static void LoadFile(string file)
        {
            LoadBackground(file);
            LoadBlock(file);
            LoadEnemy(file);
            LoadItem(file);
            LoadPipe(file);
            LoadPlayer(file);
        }
        public static void LoadPlayer(string file)
        {
            IList<PlayerXML> myPlayerObject = new List<PlayerXML>();
            using (XmlReader reader = XmlReader.Create(file))
            {
                myPlayerObject = (IList<PlayerXML>)playerSerializer.Deserialize(reader);
            }
            foreach (PlayerXML player in myPlayerObject)
            {
                if (player.PlayerName.Equals("Mario"))
                {
                    Vector2 location = new Vector2(player.XLocation, player.YLocation);
                    ItemManager.PlayerMario = location;
                    break;
                }
            }
        }
        public static void LoadBlock(string file)
        {
            IList<BlockXML> myBlockObject = new List<BlockXML>();
            using (XmlReader reader = XmlReader.Create(file))
            {
                myBlockObject = (IList<BlockXML>)blockSerializer.Deserialize(reader);
            }
            foreach (BlockXML block in myBlockObject)
            {
                switch (block.BlockType)
                {
                    case BlockType.Breakable:
                        ItemManager.BlockList.Add(new BreakableBlock(new Vector2(block.XLocation, block.YLocation)));
                        break;
                    case BlockType.Floor:
                        ItemManager.BlockList.Add(new FloorBlock(new Vector2(block.XLocation, block.YLocation)));
                        break;
                    case BlockType.Hidden:
                        ItemManager.BlockList.Add(new HiddenBlock(new Vector2(block.XLocation, block.YLocation)));
                        break;
                    case BlockType.Question:
                        ItemManager.BlockList.Add(new QuestionBlock(new Vector2(block.XLocation, block.YLocation)));
                        break;
                    case BlockType.Unbreakable:
                        ItemManager.BlockList.Add(new UnbreakableBlock(new Vector2(block.XLocation, block.YLocation)));
                        break;
                }
            }

        }
        public static void LoadEnemy(string file)
        {
            IList<EnemyXML> myEnemyObject = new List<EnemyXML>();
            using (XmlReader reader = XmlReader.Create(file))
            {
                myEnemyObject = (IList<EnemyXML>)enemySerializer.Deserialize(reader);
            }
            foreach (EnemyXML enemy in myEnemyObject)
            {
                switch (enemy.EnemyType)
                {
                    case EnemyType.Goomba:
                        ItemManager.EnemyList.Add(new Goomba(new Vector2(enemy.XLocation, enemy.YLocation)));
                        break;
                    case EnemyType.Koopa:
                        ItemManager.EnemyList.Add(new Koopa(new Vector2(enemy.XLocation, enemy.YLocation)));
                        break;
                }
            }
        }
        public static void LoadItem(string file)
        {
            IList<ItemXML> myItemObject = new List<ItemXML>();
            using (XmlReader reader = XmlReader.Create(file))
            {
                myItemObject = (IList<ItemXML>)itemSerializer.Deserialize(reader);
            }
            foreach (ItemXML item in myItemObject)
            {
                switch (item.GameObjectType)
                {
                    case GameObjectType.Coin:
                        ItemManager.ItemList.Add(new Coin(new Vector2(item.XLocation, item.YLocation)));
                        break;
                    case GameObjectType.FireFlower:
                        ItemManager.ItemList.Add(new FireFlower(new Vector2(item.XLocation, item.YLocation)));
                        break;
                    case GameObjectType.MagicMushroom:
                        ItemManager.ItemList.Add(new MagicMushroom(new Vector2(item.XLocation, item.YLocation)));
                        break;
                    case GameObjectType.OneUpMagicMushroom:
                        ItemManager.ItemList.Add(new OneUpMushroom(new Vector2(item.XLocation, item.YLocation)));
                        break;
                    case GameObjectType.Starman:
                        ItemManager.ItemList.Add(new Starman(new Vector2(item.XLocation, item.YLocation)));
                        break;
                }
            }
        }
        public static void LoadPipe(string file)
        {
            IList<PipeXML> myPipeObject = new List<PipeXML>();
            using (XmlReader reader = XmlReader.Create(file))
            {
                myPipeObject = (IList<PipeXML>)pipeSerializer.Deserialize(reader);
            }
            foreach (PipeXML pipe in myPipeObject)
            {
                if(pipe.BlockType==BlockType.Pipe)
                    ItemManager.PipeList.Add(new Pipe(new Vector2(pipe.XLocation, pipe.YLocation)));
            }
        }
        public static void LoadBackground(string file)
        {
            IList<BackgroundXML> myBackgroundObject = new List<BackgroundXML>();
            using (XmlReader reader = XmlReader.Create(file))
            {
                myBackgroundObject = (IList<BackgroundXML>)backSerializer.Deserialize(reader);
            }
            foreach (BackgroundXML back in myBackgroundObject)
            {
                switch (back.BackgroundType)
                {
                    case BackgroundType.BushSingle:
                        ItemManager.BackgroundList.Add(new BushSingle(new Vector2(back.XLocation, back.YLocation)));
                        break;
                    case BackgroundType.BushTriple:
                        ItemManager.BackgroundList.Add(new BushTriple(new Vector2(back.XLocation, back.YLocation)));
                        break;
                    case BackgroundType.CloudSingle:
                        ItemManager.BackgroundList.Add(new CloudSingle(new Vector2(back.XLocation, back.YLocation)));
                        break;
                    case BackgroundType.CloudTriple:
                        ItemManager.BackgroundList.Add(new CloudTriple(new Vector2(back.XLocation, back.YLocation)));
                        break;
                    case BackgroundType.MountainBig:
                        ItemManager.BackgroundList.Add(new MountainBig(new Vector2(back.XLocation, back.YLocation)));
                        break;
                    case BackgroundType.MountainSmall:
                        ItemManager.BackgroundList.Add(new MountainSmall(new Vector2(back.XLocation, back.YLocation)));
                        break;
                }
            }
        }
    }
}