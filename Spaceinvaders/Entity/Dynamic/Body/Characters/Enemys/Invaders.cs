using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Spaceinvaders
{
    public class Invaders : Characters
    {
        Vector2 m_screenRes = new Vector2(800.0f, 600.0f);

       public Invaders(World world, Vector2 pos, Vector2 size, Texture2D tex,
                   float maxVel = 0.0f, float accel = 0.0f, float friction = 0.0f)
            : base(world, pos, size, tex, maxVel, accel, friction) { }

       public override void Update(GameTime gameTime)
        {
           if ((m_pos.X >= 0) && (m_pos.X <= m_screenRes.X)) 
               m_pos.X += 1;

            base.Update(gameTime);  
        }
    }
}
