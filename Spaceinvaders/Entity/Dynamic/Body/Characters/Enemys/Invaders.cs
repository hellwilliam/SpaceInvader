using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Spaceinvaders
{
    public class Invaders : Characters
    {
        //enum TDirection { left, right, down };
        bool isDescending;
        bool isRight;
        
        int count; //Timer for the invaders
        const int moveNow = 30; // How many seconds you want to move the invaders
        const int step = 16; //How many pixels you want the invaders to move

        public Invaders(World world, Vector2 pos, Vector2 size, Texture2D tex)
            : base(world, pos, size, tex) { }
               
        public override void Update(GameTime gameTime)
        {
            if ((m_pos.X >= 0) && (m_pos.X <= m_screenRes.X - 16))
            {
                if (count % moveNow == 0)
                    m_pos.X += step;
            }

            count += 1;
         //{
         //   if (count % moveNow == 0)
         //   {
         //       if (!isDescending)
         //       {
         //           if (isRight)
         //               m_pos.X += step;

         //           else m_pos.X -= step;

         //           bool hitLeft = m_pos.X == 0;
         //           bool hitRight = m_pos.X + 32 == -800;
         //           //bool hitRight = m_pos.X + 32 == m_screenRes;

         //           if ((hitLeft) || (hitRight))
         //           {
         //               isRight = !isRight;
         //               isDescending = true; 
         //           }
         //           else
         //           {
         //               m_pos.Y += 4;
         //               isDescending = false;
         //           }
         //       }
         //   }

            count += 1;

           base.Update(gameTime);  
         }
    }
}
