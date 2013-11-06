/*
 *  Mikael Bendiksen 
 *  500694
 *  Høgskolen i Narvik
 *  2013
*/


#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.DirectX.DirectInput;
using Microsoft.DirectX;

#endregion


using System.Windows.Forms;

namespace TheGame
{
    public class Hero : Engine_Sprite
    {
        int m_shots;
      

        public override void Update()
        {
            
            int vx = 0, vy = 0;

            if (Position.Y > 50 && Engine_Keyboard.IsPressed(Key.UpArrow))
            {
                vy = -2;
                
            }
            if (Position.Y < 550 && Engine_Keyboard.IsPressed(Key.DownArrow))
            {
                vy = 2;
                
            }
            if (Position.X > 30 && Engine_Keyboard.IsPressed(Key.LeftArrow))
            {
                vx = -2;
                ScaleX = 1;
            }

            if (Position.X < 770 && Engine_Keyboard.IsPressed(Key.RightArrow))
            {
                vx = 2;
                ScaleX = -1;
            }
            if (Engine_Keyboard.IsPressed(Key.LeftShift))
            {
                vx *= 2;
                vy *= 2;
            }

            if (Engine_Keyboard.IsTriggered(Key.Space))
            {
                Shoot fire = (Shoot)Spillet.Fire.Clone();
                fire.Position = new PointF(Position.X, Position.Y - 32);
                fire.Velocity = new Vector2(0, -4);
                Spillet.Add(fire);

                Spillet.Shoot.Play();
                m_shots++;
                
                Spillet.Shots.Text = "Shots: " + m_shots.ToString();
                
            }

            Velocity = new Vector2(vx, vy);
        }
    }

    public class BadGuy : Engine_Sprite
    {
        public BadGuy()
        {
        }

        protected BadGuy(BadGuy MeanCreature): base(MeanCreature)
        {
        }

        public override Object Clone()
        {
            return new BadGuy(this);
        }

        
        public override void Update()
        {


            Pilot P = Spillet.Pilot;
            Hero H = Spillet.Hero_plane;
            
            Vector2 v = new Vector2(H.Position.X - this.Position.X, H.Position.Y - this.Position.Y);
            v.Normalize();
            v = v * 1.5f;
            Velocity = v;

            if (CollisionWithHero)
            {
                CollisionWithHereoTest();
                return;
            }

            if (AnimationIndex == 1)
            {
                if (Animation.PlayingLastFrame)
                    Spillet.Remove(this);
            }
            else
            {

                List<Engine_Sprite> sprites = Spillet.GetCollidedSprites(this);
                if (sprites != null)
                {
                    foreach (Engine_Sprite s in sprites)
                    {
                        if (s is Shoot)
                        {
                            CollisionScore++;
                            Spillet.Score.Text = "Score: " + CollisionScore.ToString();
                            Spillet.Die.Play();
                            trigger++;
                            if (trigger == 5)
                            {
                                Spillet.HeroHitsUFO.Play();
                                trigger = 0;
                            }
                            AnimationIndex = 1;
                            Spillet.Remove(s);
                            break;

                        }
                        else if (s is Hero)
                        {
                            CollisionScore--;
                            Spillet.Score.Text = "Score: " + CollisionScore.ToString();
                            Spillet.UFO_Hits_HERO.Play();
                            Animation.Stop();
                            CollisionWithHero = true;
                            P.AnimationIndex = 1;
                            Spillet.Ekstraliv--;
                            
                        }
                    }
                }
            }

            
            //Bruk CollisionWithHero og CollisionScore her i stede for 
            //m_Score og CollideSprites
        }
        private void CollisionWithHereoTest()
        {
            Opacity -= 1;
            if (ScaleX < 0)
            {
                ScaleX += 0.01f;
                Rotation -= 0.02f;
            }
            else
            {
                ScaleX -= 0.01f;
                Rotation += 0.03f;
            }
            ScaleY -= 0.01f;
            if (Opacity <= 0)
                Engine_Game.Remove(this);
        }

        bool CollisionWithHero = false;
        public static int CollisionScore;
        public static int trigger;
    }
    
    public class Shoot : Engine_Sprite
    {
        public Shoot()
        {

        }

        protected Shoot(Shoot Projectile): base(Projectile)
        {

        }

        public override Object Clone()
        {
            return new Shoot(this);
        }

        public override void Update()
        {
            float y = Position.Y;
            if (y < -100)
                Engine_Game.Remove(this);
            ScaleX = ScaleY = 1 + Math.Abs(0.001f * (600 - Position.Y));
        }
    }

    public class Pilot : Engine_Sprite
    {
        public Pilot()
        {

        }

        protected Pilot(Pilot Projectile)
            : base(Projectile)
        {

        }

        public override void Update()
        {
            if (this.AnimationIndex == 1)
            {
                if (this.Animation.PlayingLastFrame)
                    this.AnimationIndex = 0;
            }
        }
        
    }

}