using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Spaceinvaders
{
    public class Invaders : Characters
    {
        const int ROWS = 5;
        const int COLS = 11;

        //string isAlienAlive = "Yes";

        int count; //Timer for the invaders
        const int moveNow = 30; // How many seconds you want to move the invaders
        int step = 8; //How many pixels you want the invaders to move
        public Rectangle[,] m_recInvaders;
        
        bool IsGoingLeft;
      
        public Invaders(World world, Vector2 pos, Vector2 size, Texture2D tex)
            : base(world, pos, size, tex) {

                m_recInvaders = new Rectangle[ROWS, COLS];

                for (int r = 0; r < ROWS; r += 1)
                    for (int c = 0; c < COLS; c += 1)
                    {
                        m_recInvaders[r, c].Width = m_world.m_texInvader1.Width;
                        m_recInvaders[r, c].Height = m_world.m_texInvader1.Height;
                        m_recInvaders[r, c].X = 30 * c;
                        m_recInvaders[r, c].Y = 25 * r;
                    }
        }
               
        public override void Update(GameTime gameTime)
        {
            Move();

            FireBullets();

            Collision();

            SpeedUp();

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

        void Move()
        {
            var rightside = (int)m_screenRes.X; // Que bruxaria foi essa que o (int) antes do argumento deu certo???
            int leftside = 16;

            bool changedirection = false;

            if (count % moveNow == 0)
            {
                for (int r = 0; r < ROWS; r += 1)
                    for (int c = 0; c < COLS; c += 1)
                        if (IsGoingLeft)
                            m_recInvaders[r, c].X -= step;
                        else
                            m_recInvaders[r, c].X += step;

                for (int r = 0; r < ROWS; r += 1)
                    for (int c = 0; c < COLS; c += 1)
                    {
                        if (m_recInvaders[r, c].X + m_recInvaders[r, c].Width > rightside)
                        {
                            IsGoingLeft = true;
                            changedirection = true;
                        }
                        if (m_recInvaders[r, c].X < leftside)
                        {
                            IsGoingLeft = false;
                            changedirection = true;
                        }
                    }

                if (changedirection)
                {
                    for (int r = 0; r < ROWS; r += 1)
                        for (int c = 0; c < COLS; c += 1)
                        {
                            m_recInvaders[r, c].Y = m_recInvaders[r, c].Y + 32;
                            if (IsGoingLeft)
                                m_recInvaders[r, c].X -= step;

                            else
                                m_recInvaders[r, c].X += step;
                        }
                }
            }
            count += 1;
        }

        void FireBullets()
        {
            //Colocar a lógica das "bullets" dos invaders aqui.
        }

        void Collision()
        {

            if (m_world.m_texInvader1.Bounds.Intersects(m_world.m_texBullet.Bounds))
            {

            }

            //Vector2 myMin = m_pos - m_size * 0.5f;
            //Vector2 myMax = m_pos + m_size * 0.5f;

            //bool collides = false;

            //foreach (Entity e in m_world.m_entities)
            //{
            //    if ((e is Dynamic) && (e != this))
            //    {
            //        if (((Dynamic)e).TestOverlapRect(myMin, myMax))
            //        {
            //            collides = true;
            //            ((Bullet)e).isBulletVisible = "No";
            //            break;
            //        }
            //    }
            //}

            //if (collides)
            //    m_color = Color.Yellow;
            //else
            //    m_color = Color.Red;
        }

        void SpeedUp()
        {
        //    //Prepara o terreno para os invaders acelerarem
        //    int count = 0;
        //    for (int r = 0; r < ROWS; r += 1)
        //        for (int c = 0; c < COLS; c += 1)
        //            if (invadersalive[r, c].Equals("Yes"))
        //                count = count + 1;

        //    //Verifica se metade dos invaders esta vivo
        //    if (count > (ROWS * COLS / 2))
        //        step = 16;

        //    if (count < (ROWS * COLS / 3))
        //        step = step + 4;

        //    if (count < (ROWS * COLS / 5))
        //        step = step + 8;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            for (int r = 0; r < ROWS; r += 1)
                for (int c = 0; c < COLS; c += 1)
                    //if (isAlienAlive.Equals("Yes"))
                        m_world.m_spriteBatch.Draw(m_world.m_texInvader1, m_recInvaders[r, c], Color.Yellow);
        }
    }
}
