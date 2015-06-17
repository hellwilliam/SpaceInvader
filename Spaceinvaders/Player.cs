using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Spaceinvaders
{
    public class Player
    {
        Texture2D m_TexPlayer;

        Vector2 m_PlayerPos;
        Vector2 m_PlayerVel;

        Game1 m_world;

        public void LoadContent()
        {
            m_TexPlayer = m_world.Content.Load <Texture2D>("player");
        }

        public void Update() 
        {
            Vector2 dir = Vector2.Zero;

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                dir.X -= 1.0f;

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                dir.X += 1.0f;
        }

        public void Draw(GameTime gametime)
        {

        }
    }
}
