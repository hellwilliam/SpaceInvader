using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Spaceinvaders
{
    class Spaceship : Characters
    {
        //bool m_inverse;

        public Spaceship(World world, Vector2 pos, Vector2 size, Texture2D tex,
                   float maxVel = 200.0f, float accel = 10000.0f, float friction = 5.0f, bool inverse = false)
            : base(world, pos, size, tex, maxVel, accel, friction) {
                
            m_inverse = inverse;
        }

        public override void Update(GameTime gameTime)
        {
            if (m_inverse)
            {
                if (m_pos.X > -m_size.X)
                {
                    m_pos -= (new Vector2(1.5f, 0));
                }
            }
            else
            {
                if (m_pos.X < m_world.m_screenRes.X + m_size.X)
                {
                    m_pos += (new Vector2(1.5f, 0));
                }
            }
            base.Update(gameTime);                     
        }  
    }
}
