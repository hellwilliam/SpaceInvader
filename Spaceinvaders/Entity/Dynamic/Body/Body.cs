using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Spaceinvaders
{
    class Body
    {
        public float m_maxVel;
        public float m_accel;
        public float m_friction;

        public Vector2 m_vel;
        public Vector2 m_dir;

        public Body(World world, Vector2 pos, Vector2 size, Texture2D tex,
                    float maxVel = 200.0f, float accel = 1000.0f, float friction = 5.0f)
            : base(world, pos, size, tex)
        {
            m_maxVel = maxVel;
            m_accel = accel;
            m_friction = friction;

            m_vel = Vector2.Zero;
            m_dir = Vector2.Zero;
        }
    }
}
