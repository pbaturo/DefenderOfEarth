using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceInvaders2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class SpaceInvadersGame : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        #region Textures
        Texture2D _backgroundTexture;
        Texture2D _playerTexture;
        #endregion

        Player _player;
        public SpaceInvadersGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures. 
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _backgroundTexture = Content.Load<Texture2D>(@"Textures\space-tiled-background-256x256");
            _playerTexture = Content.Load<Texture2D>(@"Textures\SpaceShipSmall");

            _player = new Player(_graphics.PreferredBackBufferWidth);
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

            // TODO: Add your update logic here
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                _player.MoveLeft();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                _player.MoveRight();
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            DrawBackground();
            this._spriteBatch.Begin();
            this._spriteBatch.Draw(_playerTexture, new Vector2(_player.PositionX, _graphics.PreferredBackBufferHeight - _playerTexture.Height), Color.White);
            this._spriteBatch.End();
            base.Draw(gameTime);
        }

        private void DrawBackground()
        {
            this._spriteBatch.Begin();
            int width = _backgroundTexture.Width;
            int height = _backgroundTexture.Height;
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    this._spriteBatch.Draw(_backgroundTexture, new Rectangle(i * width, j * height, _backgroundTexture.Width, _backgroundTexture.Height), Color.White);
                }
            }
            this._spriteBatch.End();
        }
    }
}
