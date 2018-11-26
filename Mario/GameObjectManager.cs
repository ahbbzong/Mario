﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Mario.Interfaces.GameObjects;
using Mario.Factory;
using Mario.CameraClasses;
using Mario.GameObjects.Block;
using Game1;
using Mario.Collision.CollisionManager;
using System.Diagnostics;
using Mario.EnemyClasses;
using Mario.EnemyStates.GoombaStates;
using Mario.HeadUpDesign;
using Mario.XMLRead;
using Mario.Display;
using Mario.Sprite;
using Microsoft.Xna.Framework.Media;
using Mario.Sound;

namespace Mario
{
	
    public class GameObjectManager
    {
		private static GameObjectManager instance = new GameObjectManager();
		public static GameObjectManager Instance { get=>instance; set=> instance = value; }
		private static IList<IController> ControllerList { get; set; }
		private readonly IDictionary<Type, IList<IGameObject>> gameObjectListsByType;
		
		public IDictionary<Type, IList<IGameObject>> GameObjectListsByType { get => gameObjectListsByType; }
        public IMario Mario { get { return (IMario)GameObjectListsByType[typeof(IMario)][0]; } set { GameObjectListsByType[typeof(IMario)][0] = value; } }
        public ICamera CameraMario { get; set; }
        public ICameraController CameraController { get; set; }
        public IList<Rectangle> FloorBoxPositions { get; }
		public GameTime CurrentGameTime { get; set; }
        private HeadsUpDisplayBoard headUpDisplayBoard;
        private IDisplay lifeDisplay;
        private IDisplay gameOverDisplay;
        public IList<ITextSprite> UITextSprites { get;  }

        public float EndOfLevelXPosition { get; set; }


        private GameObjectManager()
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
			ControllerList = new List<IController>
			{
				new Keyboards()
			};
            FloorBoxPositions = new List<Rectangle>();

            UITextSprites = new List<ITextSprite>();
        }
        public void SetInitialValuesCamera()
        {
			SoundManager.Instance.PlayBGM("marioBGM");
            CameraMario = new Camera();
            CameraController = new CameraController(CameraMario);
        }
        public void  LoadContent()
        {

            ItemFactory.Instance.LoadContent(Game1.Instance.Content);
            BlockFactory.Instance.LoadContent(Game1.Instance.Content);
            EnemyFactory.Instance.LoadContent(Game1.Instance.Content);
            BackgroundFactory.Instance.LoadContent(Game1.Instance.Content);
            ProjectileFactory.Instance.LoadContent(Game1.Instance.Content);
            MarioFactory.Instance.LoadContent(Game1.Instance.Content);
            TextSpriteFactory.Instance.LoadAllTextures(Game1.Instance.Content);
            LevelLoader.Instance.LoadFile("XMLFile1.xml");
            
            foreach (IController controller in ControllerList)
            {
                controller.Initialize((IMario)GameObjectListsByType[typeof(IMario)][0]);
            }
            if(LifeCounter.Instance.Life==LifeUtil.minLife)
            gameOverDisplay = new GameOverDisplay();
            lifeDisplay = new LifeDisplay();
            headUpDisplayBoard = new HeadsUpDisplayBoard();
        }
   
      
        public void Update()
        {
			foreach(IController controller in ControllerList)
			{
				controller.Update();
			}
            if (!Game1.Instance.IsPause)
            {
                for (int j = GameObjectListsByType.Count - 1; j >= 0; j--)
                {
                    Type gameObjectType = GameObjectListsByType.ElementAt(j).Key;
                    for (int i = GameObjectListsByType[gameObjectType].Count - 1; i >= 0; i--)
                    {
                        if (!CameraMario.IsOffSideOfScreen(gameObjectListsByType[gameObjectType][i].Box))
                        {
                            gameObjectListsByType[gameObjectType][i].Update();
                        }
                    }
                    if (CameraMario.IsOffTopOrBottomOfScreen(Mario.Box))
                    {
                        Mario.BeDead();
                        LifeCounter.Instance.DecreaseLife();
                        SetInitialValuesCamera();
                        LoadContent();
                        Timer.ResetTimer();
                        Timer.StartTimer();
                    }
                }
                CollisionDetector.Instance.Update();
                CameraController.Update();
            }
            if (LifeCounter.Instance.LifeRemains()>0)
            {
                lifeDisplay.Update();
 
            }
          
            else if (LifeCounter.Instance.LifeRemains() == 0)
            {
                gameOverDisplay.Update();
            }
            headUpDisplayBoard.Update();
            FloatingScoreBar.Update();
            ScoringSystem.Instance.SetMarioEnemyHitThisIterationToFalse();
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            for (int j = 0; j < GameObjectListsByType.Count; j++)
            {
                Type gameObjectType = GameObjectListsByType.ElementAt(j).Key;
                for(int i = 0; i < GameObjectListsByType[gameObjectType].Count; i++)
                { 
                    IGameObject gameObj = GameObjectListsByType[gameObjectType].ElementAt(i);
                    gameObj.Draw(spriteBatch);
				}
			}
            if (LifeCounter.Instance.LifeRemains() > 0)
            {
                lifeDisplay.Draw(spriteBatch);
            }
            else if (LifeCounter.Instance.LifeRemains() == 0)
            {
                gameOverDisplay.Draw(spriteBatch);
            }
            headUpDisplayBoard.Draw(spriteBatch);
            FloatingScoreBar.Draw(spriteBatch);
        }
        

    }
}
