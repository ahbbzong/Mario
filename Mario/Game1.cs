using Game1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Mario.XMLRead;
using Mario.Factory;
using Mario.Sound;

[assembly: System.CLSCompliant(true)]

namespace Mario
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public bool isPause;
        private IList<IController> controllerList = new List<IController>();
		private static Game1 instance;
		public static Game1 Instance { get => instance; set => instance = value; }
        public Game1()
        {
			instance = this;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            isPause = false;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

			base.Initialize();
			controllerList.Add(new Keyboards());

			graphics.PreferredBackBufferWidth = 1440;
            graphics.PreferredBackBufferHeight = 900;
            graphics.ApplyChanges();
            GameObjectManager.Instance.SetInitialValuesCamera();
          

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
			base.LoadContent();
			spriteBatch = new SpriteBatch(GraphicsDevice);
			GameObjectManager.Instance.LoadContent();
            MotionEffect.Instance.loadcontent();
			GameObjectManager.Instance.LoadContent("XMLFile1.xml");
           
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();

            // TODO: Add your update logic herr.
                GameObjectManager.Instance.CurrentGameTime = gameTime;
                GameObjectManager.Instance.Update();
                base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
			GameObjectManager.Instance.CurrentGameTime = gameTime;
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, null, GameObjectManager.Instance.CameraMario.Transform);

            GameObjectManager.Instance.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        public void Reset()
        {
            GameObjectManager.Instance.SetInitialValuesCamera();
            LoadContent();
        }
       
    }
}
