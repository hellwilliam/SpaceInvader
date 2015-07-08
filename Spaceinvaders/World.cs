﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace Spaceinvaders
{
   public class World : Game
    {
        public GraphicsDeviceManager m_graphics;
        public SpriteBatch m_spriteBatch;

        public List<Entity> m_entities = new List<Entity>();
                           
        public KeyboardState m_prevKeyboardState;
        public MouseState m_prevMouseState;

        public Vector2 m_screenRes = new Vector2(800.0f, 600.0f);
       
        public SpriteFont m_font;
       
        public Texture2D m_texPlayer;
        public Texture2D m_texInvader1;
        public Texture2D m_texInvader2;
        public Texture2D m_texInvader3;
        public Texture2D m_texSpaceship;
        public Texture2D m_texBullet;
        public Texture2D m_shield;

        public Rectangle[,] m_recInvaders;
        public int rows = 5;
        public int cols = 10;

        public double m_timeStart = 0.0f;

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
            
            m_texInvader1 = Content.Load<Texture2D>("invaders");
            //m_texInvader2 = Content.Load<Texture2D>(" ");
            //m_texInvader3 = Content.Load<Texture2D>(" ");
            m_texPlayer = Content.Load<Texture2D>("player");
            m_texSpaceship = Content.Load<Texture2D>("spaceship");
            m_texBullet = Content.Load<Texture2D>("bullet");
            m_shield = Content.Load<Texture2D>("shield");

            //m_font = Content.Load<SpriteFont>(" ");

            //m_recInvaders = new Rectangle[rows, cols];
            
            //for (int r = 0; r < rows; r += 1)
            //    for (int c = 0; c < cols; c += 1)
            //    {
            //        m_recInvaders[r, c].Width = m_texInvader1.Width;
            //        m_recInvaders[r, c].Height = m_texInvader1.Height;
            //        m_recInvaders[r, c].X = 25 * c;
            //        m_recInvaders[r, c].Y = 25 * r;
            //    }

            m_entities.Add(new Player(this, new Vector2 (m_screenRes.X * 0.5f, m_screenRes.Y * 0.85f), new Vector2(32, 16), m_texPlayer, 125.0f, 10000.0f, 50.0f));
            //m_entities.Add(new Spaceship(this, new Vector2(m_screenRes.X + 32f, m_screenRes.Y * 0.10f), new Vector2(32, 14), m_texSpaceship, 125.0f, 10000.0f, 50.0f, true));
            //m_entities.Add(new Invaders(this, new Vector2 (m_screenRes.X * 0.5f, m_screenRes.Y * 0.1f), new Vector2(16, 16), m_texInvader1));
            m_entities.Add(new Shield(this, new Vector2(m_screenRes.X * 0.12f, m_screenRes.Y * 0.76f), new Vector2(60, 45), m_shield));
            m_entities.Add(new Shield(this, new Vector2(m_screenRes.X * 0.37f, m_screenRes.Y * 0.76f), new Vector2(60, 45), m_shield));
            m_entities.Add(new Shield(this, new Vector2(m_screenRes.X * 0.62f, m_screenRes.Y * 0.76f), new Vector2(60, 45), m_shield));
            m_entities.Add(new Shield(this, new Vector2(m_screenRes.X * 0.87f, m_screenRes.Y * 0.76f), new Vector2(60, 45), m_shield));
             
        }

        protected override void UnloadContent()
        {

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
            GraphicsDevice.Clear(Color.Black);

            m_spriteBatch.Begin(SpriteSortMode.BackToFront,
                               BlendState.AlphaBlend,
                               SamplerState.PointClamp);

            //for (int r = 0; r < rows; r += 1)
            //    for (int c = 0; c < cols; c += 1)
            //        m_spriteBatch.Draw(m_texInvader1, m_recInvaders[r, c], Color.Yellow);

            foreach (Entity e in m_entities)
                e.Draw(gameTime, m_spriteBatch);

            m_spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
