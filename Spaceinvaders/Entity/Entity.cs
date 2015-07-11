using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Spaceinvaders
{
    public class Entity
    {
        public GraphicsDeviceManager m_graphics;

        public bool isVisible;

        public Vector2 m_screenRes = new Vector2(448, 512);

        public World m_world;

        public Entity(World world) { m_world = world; }

        public virtual void LoadContent() { }

        public virtual void Update(GameTime gameTime) { }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch) { }
    }
}
