using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace DefenderOfEarth.Game
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class DefenderOfEarth : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        #region Sound Effects
        SoundEffect _laserSound;
        #endregion

        #region Textures
        Texture2D _backgroundTexture;
        Texture2D _playerTexture;
        Texture2D _bulletTexture;
        Texture2D _enemyTexture;
        #endregion

        Player _player;
        BulletFactory _bulletFactory;
        Shooting _shooting;
        Enemy _enemy;

        public DefenderOfEarth()
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
            _bulletTexture = Content.Load<Texture2D>(@"Textures\Bullet");
            _enemyTexture = Content.Load<Texture2D>(@"Textures\enemy");
            _bulletFactory = new BulletFactory(_bulletTexture.Width, _bulletTexture.Height, _graphics.PreferredBackBufferHeight);
            _shooting = new Shooting(_bulletFactory);
            _player = new Player(_shooting, _graphics.PreferredBackBufferWidth - _playerTexture.Width, _graphics.PreferredBackBufferHeight, _playerTexture.Width, _playerTexture.Height);
            _enemy = new Enemy(_graphics.PreferredBackBufferHeight, _graphics.PreferredBackBufferWidth, _enemyTexture.Width, _enemyTexture.Height);

            _laserSound = Content.Load<SoundEffect>(@"SoundEffects\laser");
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
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                //_bullet.Fire(_player.PositionX + _playerTexture.Width/2 - _bulletTexture.Width/2, _graphics.PreferredBackBufferHeight - _playerTexture.Height - _bulletTexture.Height);
                if (_player.Shoot())
                {
                    _laserSound.Play();
                }
            }
            _shooting.Move();
            _enemy.Move();
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
            foreach (Bullet bullet in _shooting.Bullets)
            {
                if (bullet.Visible)
                {
                    this._spriteBatch.Draw(_bulletTexture, new Vector2(bullet.PositionX, bullet.PositionY), Color.White);
                }
            }
            this._spriteBatch.Draw(_enemyTexture, new Vector2(_enemy.PositionX, _enemy.PositionY), Color.White);
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
