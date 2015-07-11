using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Spaceinvaders
{
    class Shield : Dynamic
    {
       public Shield(World world, Vector2 pos, Vector2 size, Texture2D tex)
            : base(world, pos, size, tex) { }

       //bool collides;

        public override void Update(GameTime gameTime)
        {
            Vector2 myMin = m_pos - m_size * 0.5f;
            Vector2 myMax = m_pos + m_size * 0.5f;

            bool collides = false;

            foreach (Entity e in m_world.m_entities)
            {
                if ((e is Dynamic) && (e != this))
                {
                    if (((Dynamic)e).TestOverlapRect(myMin, myMax))
                    {
                        collides = true;
                        ((Bullet)e).isBulletVisible = "No";
                        break;
                    }
                }
            }

            if (collides)
                m_color = Color.Red;
            else
                m_color = Color.White;

            base.Update(gameTime);
        }
    }
}
