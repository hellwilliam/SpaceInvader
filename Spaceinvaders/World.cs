using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace Spaceinvaders
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class World : Game
    {
        GraphicsDeviceManager m_graphics;
        SpriteBatch m_spriteBatch;

        public List<Entity> m_entities = new List<Entity>();

        public KeyboardState m_prevKeyboardState;
        public MouseState m_prevMouseState;

        public Vector2 m_screenRes = new Vector2(800.0f, 600.0f);

        public SpriteFont m_font;

        public Texture2D m_texPlayer;
        public Texture2D m_texEnemy1;
        public Texture2D m_texEnemy2;
        public Texture2D m_texEnemy3;
        public Texture2D m_texSpaceship;
        public Texture2D m_texBullet;
       
        public World()
        {
            m_graphics = new GraphicsDeviceManager(this);

            m_graphics.PreferredBackBufferWidth = (int)m_screenRes.X;
            m_graphics.PreferredBackBufferHeight = (int)m_screenRes.Y;

            m_graphics.ApplyChanges();

            Content.RootDirectory = "Content";

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            m_spriteBatch = new SpriteBatch(GraphicsDevice);

            //m_texEnemy1 = Content.Load<Texture2D>(" ");
            //m_texEnemy2 = Content.Load<Texture2D>(" ");
            //m_texEnemy3 = Content.Load<Texture2D>(" ");
            m_texPlayer = Content.Load<Texture2D>("player");
            //m_texSpaceship = Content.Load<Texture2D>(" ");
            m_texBullet = Content.Load<Texture2D>("bullet");

            //m_font = Content.Load<SpriteFont>(" ");

            m_entities.Add(new Player(this, m_screenRes * 0.5f, new Vector2(32, 16), m_texPlayer));
            //m_entities.Add(new Enemys(this, m_screenRes * 0.5f, new Vector2(32, 32), m_texPlayer));

        // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            List<Entity> tmp = new List<Entity>(m_entities);
            foreach (Entity e in tmp)
                e.Update(gameTime);

            base.Update(gameTime);

            m_prevKeyboardState = Keyboard.GetState();

            m_prevMouseState = Mouse.GetState();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            m_spriteBatch.Begin(SpriteSortMode.BackToFront,
                               BlendState.AlphaBlend,
                               SamplerState.PointClamp);

            foreach (Entity e in m_entities)
                e.Draw(gameTime, m_spriteBatch);

            m_spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
