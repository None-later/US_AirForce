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
        public override void Update()
        {
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
            Hero H = Spillet.Hero_plane;
            Vector2 v = new Vector2(H.Position.X - Position.X, H.Position.Y - Position.Y);
            v.Normalize();
            Velocity = v;


            
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
        static int CollisionScore;
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
            if (y < 100)
                Engine_Game.Remove(this);
            ScaleX = ScaleY = 1 + Math.Abs(0.001f * (600 - Position.Y));
        }
    }
}