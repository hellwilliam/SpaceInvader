using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Spaceinvaders
{
    public class Bullet : Characters
    {
        public Bullet(World world, Vector2 pos, Vector2 size, Texture2D tex, float maxVel = 200.0f, float accel = 1000.0f, float friction = 0.0f) 
            : base(world, pos, size, tex, maxVel, accel, friction) { }

        public override void Update (GameTime gameTime)
        {
            m_pos -= new Vector2(0.0f, 6.5f);

            if (m_pos.Y < 0)
                isBulletVisible = "No";
            
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (isBulletVisible != "No")
            {
                base.Draw(gameTime, spriteBatch);
            }
        }
        
    }
}
