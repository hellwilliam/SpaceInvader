using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Spaceinvaders
{
    public class Invaders : Characters
    {
        int count; //Timer for the invaders
        const int moveNow = 30; // How many seconds you want to move the invaders
        const int step = 16; //How many pixels you want the invaders to move

        public Invaders(World world, Vector2 pos, Vector2 size, Texture2D tex)
            : base(world, pos, size, tex) { }
               
        public override void Update(GameTime gameTime)
        {
            int rightside = (int)m_screenRes.X; // Que bruxaria foi essa que o (int) antes do argumento deu certo???
            int leftside = 16;

            string changedirection = "N";

            if (count % moveNow == 0)
            {
                for (int r = 0; r < m_world.rows; r += 1)
                    for (int c = 0; c < m_world.cols; c += 1)
                    {
                        if (direction.Equals("Right"))
                            m_world.m_recInvaders[r, c].X += step;

                        if (direction.Equals("Left"))
                            m_world.m_recInvaders[r, c].X -= step;
                    }

                for (int r = 0; r < m_world.rows; r += 1)
                    for (int c = 0; c < m_world.cols; c += 1)
                    {
                        if (m_world.m_recInvaders[r, c].X + m_world.m_recInvaders[r, c].Width > rightside)
                        {
                            direction = "Left";
                            changedirection = "Y";
                        }
                        if (m_world.m_recInvaders[r, c].X < leftside)
                        {
                            direction = "Right";
                            changedirection = "Y";
                        }
                    }

                if (changedirection.Equals("Y"))
                {
                    for (int r = 0; r < m_world.rows; r += 1)
                        for (int c = 0; c < m_world.cols; c += 1)
                            m_world.m_recInvaders[r, c].Y = m_world.m_recInvaders[r, c].Y + 32;
                }
            }
            count += 1;

            //Colocar a lógica das "bullets" dos invaders aqui.


//----------------------------------------------------------------------------------------------------------------
            //if ((m_pos.X >= 0) && (m_pos.X <= m_screenRes.X - 32))
            //{
            //    if (count % moveNow == 0)
            //        m_pos.X += step;
            //}

            //count += 1;
//----------------------------------------------------------------------------------------------------------------         
            //if (count % moveNow == 0)
            //{
            //    if (!isDescending)
            //    {
            //        if (isRight)
            //            m_pos.X += step;

            //        else m_pos.X -= step;

            //        bool hitLeft = m_pos.X == 0;
            //        //bool hitRight = m_pos.X + 32 == 800;
            //        //bool hitRight = m_pos.X + 32 == m_screenRes;
                    
            //        if ((hitLeft) || (hitRight))
            //        {
            //            isRight = !isRight;
            //            isDescending = true;
            //        }
            //        else
            //        {
            //            m_pos.Y += 4;
            //            isDescending = false;
            //        }
            //    }
            //}

            //count += 1;
//--------------------------------------------------------------------------------------------------------------
           base.Update(gameTime);  
         }
        
        //public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        //{


        //    base.Draw(gameTime, spriteBatch);
        //}
    }
}
