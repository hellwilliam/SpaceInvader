using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Spaceinvaders
{
    public class Player : Characters
    {
        public Player(World world, Vector2 pos, Vector2 size, Texture2D tex,
                   float maxVel = 200.0f, float accel = 1000.0f, float friction = 5.0f)
            : base(world, pos, size, tex, maxVel, accel, friction) { }

        public override void Update(GameTime gameTime)
        {
            m_dir = Vector2.Zero;

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                m_dir.X += 1.0f;

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                m_dir.X -= 1.0f;

            //if (Keyboard.GetState().IsKeyDown(Keys.Up))
            //    m_dir.Y -= 1.0f;

            //if (Keyboard.GetState().IsKeyDown(Keys.Down))
            //    m_dir.Y += 1.0f;

            //Put bullets here
            //if (Keyboard.GetState().IsKeyDown(Keys.Space) &&
            //    !m_world.m_prevKeyboardState.IsKeyDown(Keys.Space)) {

            //    m_world.m_entities.Add(
            //        new NPC(m_world, m_pos, new Vector2(16, 16), m_world.m_texNPC,
            //            100.0f, 500.0f, 5.0f)
            //    );
            //}

            if (Keyboard.GetState().IsKeyDown(Keys.Space) &&
                !m_world.m_prevKeyboardState.IsKeyDown(Keys.Space))
            {

                m_world.m_entities.Add(
                    new Bullet(m_world, m_pos, new Vector2(4, 8), m_world.m_texBullet,
                        200.0f, float.MaxValue, 0.0f)
                );
            }

            base.Update(gameTime);
            {

            }
        }
    }
}
