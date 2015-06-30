using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Spaceinvaders
{
    public class Dynamic : Entity
    {
        public Vector2 m_pos;
        public Vector2 m_size;
        public Texture2D m_tex;

        public bool m_inverse;

        public Dynamic(World world, Vector2 pos, Vector2 size, Texture2D tex) : base(world)
        {
            m_pos = pos;
            m_size = size;
            m_tex = tex;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            Vector2 texSize = new Vector2(m_tex.Width, m_tex.Height);

            Vector2 scale = m_size / texSize;

            Vector2 origin = texSize * 0.5f;

            spriteBatch.Draw(m_tex, m_pos, null, null, origin, 0.0f, scale, Color.White);
        }
    }
}
