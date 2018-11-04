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
using Mario.BlockStates;
using Mario.Collision.CollisionManager;

namespace Mario.XMLRead
{
	
    public class GameObjectManager
    {
		private static GameObjectManager instance = new GameObjectManager();
		public static GameObjectManager Instance { get=>instance; set=> instance = value; }
		private static IList<IController> ControllerList { get; set; }
		private IDictionary<Type, IList<IGameObject>> gameObjectListsByType = new Dictionary<Type, IList<IGameObject>>();
		public IDictionary<Type, IList<IGameObject>> GameObjectListsByType { get => gameObjectListsByType; set => gameObjectListsByType = value; }
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
        public void LoadContent(string filename)
        {
            ItemFactory.Instance.LoadContent(Game1.Instance.Content);
            BlockFactory.Instance.LoadContent(Game1.Instance.Content);
            EnemyFactory.Instance.LoadContent(Game1.Instance.Content);
            BackgroundFactory.Instance.LoadContent(Game1.Instance.Content);
            ProjectileFactory.Instance.LoadContent(Game1.Instance.Content);
            MarioFactory.Instance.LoadContent(Game1.Instance.Content);
            LevelLoader.Instance.LoadFile(filename);
            foreach (IController controller in ControllerList)
            {
                controller.Initialize((IMario)GameObjectListsByType[typeof(IMario)][0]);
            }
        }
   
      
        public void Update()
        {
			foreach(IController controller in ControllerList)
			{
				controller.Update();
			}
            if (!Game1.Instance.isPause)
            {
                for (int j = GameObjectListsByType.Count - 1; j >= 0; j--)
                {
                    Type gameObjectType = GameObjectListsByType.ElementAt(j).Key;
                    for (int i = GameObjectListsByType[gameObjectType].Count - 1; i >= 0; i--)
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
                CollisionDetector.Instance.Update();
                CameraController.Update();
            }
            
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
