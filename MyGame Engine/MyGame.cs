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
using System.Windows.Forms;


#endregion



namespace TheGame
{
    public class Spillet : Engine_Game
    {


        public Spillet()
        {
            FrameRate = 60;
            Resolution = new Size(800, 600);
            //Resolution = new Size(640, 480);

            PicturesPath = Application.StartupPath + "\\MyGame\\Pictures\\";
            MusicPath = Application.StartupPath + "\\MyGame\\Music\\";
            SoundPath = Application.StartupPath + "\\MyGame\\Sounds\\";
        }

        public override void InitializeResources()
        {
            #region Background

            Engine_Picture background = new Engine_Picture("Background.bmp", Color.FromArgb(0, 255, 0));
            Engine_Game.Add(background);
            Frame backGroundFrame = new Frame(background, 0);
            Engine_Animation backGroundAnimation = new Engine_Animation();
            backGroundAnimation.Add(backGroundFrame);

            Background bg = new Background();
            bg.Add(backGroundAnimation);
            bg.Position = new Point(800 / 2, 600 / 2);
            bg.ScaleX = 800.0f / background.Width;
            bg.ScaleY = 600.0f / background.Height;
            bg.ZOrder = 10;
            Engine_Game.Add(bg);

            Background bg2 = new Background();
            bg2.Add(backGroundAnimation);
            bg2.Position = new Point(800 / 2, -600 / 2);
            bg2.ScaleX = 800.0f / background.Width;
            bg2.ScaleY = 600.0f / background.Height;
            bg2.ZOrder = 10;
            Engine_Game.Add(bg2);

            #endregion

            #region Hero

            Engine_Picture plane1 = new Engine_Picture("plane1.bmp", Color.FromArgb(0, 255, 0));
            Engine_Game.Add(plane1);
            Engine_Picture plane2 = new Engine_Picture("plane2.bmp", Color.FromArgb(0, 255, 0));
            Engine_Game.Add(plane2);
            Engine_Picture plane3 = new Engine_Picture("plane3.bmp", Color.FromArgb(0, 255, 0));
            Engine_Game.Add(plane3);
            Engine_Picture plane4 = new Engine_Picture("plane4.bmp", Color.FromArgb(0, 255, 0));
            Engine_Game.Add(plane4);
            Engine_Picture plane5 = new Engine_Picture("plane5.bmp", Color.FromArgb(0, 255, 0));
            Engine_Game.Add(plane5);
            Engine_Picture plane6 = new Engine_Picture("plane6.bmp", Color.FromArgb(0, 255, 0));
            Engine_Game.Add(plane6);
            Frame afPlane1 = new Frame(plane1, 5);
            Frame afPlane2 = new Frame(plane2, 5);
            Frame afPlane3 = new Frame(plane3, 5);
            Frame afPlane4 = new Frame(plane4, 5);
            Frame afPlane5 = new Frame(plane5, 5);
            Frame afPlane6 = new Frame(plane6, 5);
            Engine_Animation PlaneAnimation = new Engine_Animation();
            PlaneAnimation.Add(afPlane1);
            PlaneAnimation.Add(afPlane2);
            PlaneAnimation.Add(afPlane3);
            PlaneAnimation.Add(afPlane4);
            PlaneAnimation.Add(afPlane5);
            PlaneAnimation.Add(afPlane6);
            PlaneAnimation.Play();
            PlaneAnimation.Loop = true;
            Hero Plane = new Hero();
            Plane.Add(PlaneAnimation);
            Plane.Position = new Point(368, 550);
            Engine_Game.Add(Plane);
            Hero_plane = Plane;


            #endregion

            #region pilot

            Engine_Picture pilot1 = new Engine_Picture("pilot1.bmp", Color.FromArgb(0, 255, 0));
            Engine_Game.Add(pilot1);
            Engine_Picture pilot2 = new Engine_Picture("pilot2.bmp", Color.FromArgb(0, 255, 0));
            Engine_Game.Add(pilot2);
            Engine_Picture pilot3 = new Engine_Picture("pilot3.bmp", Color.FromArgb(0, 255, 0));
            Engine_Game.Add(pilot3);

            Frame afPilot1 = new Frame(pilot1, 5);
            Frame afPilot2 = new Frame(pilot2, 5);
            Frame afPilot3 = new Frame(pilot3, 5);

            Engine_Animation PilotAnimation = new Engine_Animation();
            PilotAnimation.Add(afPilot1);
            PilotAnimation.Add(afPilot2);
            PilotAnimation.Add(afPilot3);

            PilotAnimation.Play();
            PilotAnimation.Loop = true;

            Engine_Picture PilotHIT1 = new Engine_Picture("pilot1_hit.bmp", Color.FromArgb(0, 255, 0));
            Engine_Game.Add(PilotHIT1);
            Frame afPilotHIT1 = new Frame(PilotHIT1, 10);
            Engine_Animation PilotHitAnimation = new Engine_Animation();
            PilotHitAnimation.Add(afPilotHIT1);
            PilotHitAnimation.Add(afPilotHIT1);
            PilotHitAnimation.Add(afPilotHIT1);
            PilotHitAnimation.Add(afPilotHIT1);

            PilotHitAnimation.Play();
                        
            Pilot pilot = new Pilot();
            pilot.Add(PilotAnimation);
            pilot.Add(PilotHitAnimation);
            pilot.Position = new Point(45, 105);
            Engine_Game.Add(pilot);
            Pilot = pilot;
            

            #endregion

            #region BadGuy

            Engine_Picture ufo1 = new Engine_Picture("ufo1.bmp", Color.FromArgb(0, 255, 0));
            Engine_Game.Add(ufo1);
            Engine_Picture ufo2 = new Engine_Picture("ufo2.bmp", Color.FromArgb(0, 255, 0));
            Engine_Game.Add(ufo2);
            Engine_Picture ufo3 = new Engine_Picture("ufo3.bmp", Color.FromArgb(0, 255, 0));
            Engine_Game.Add(ufo3);
            Engine_Picture ufo4 = new Engine_Picture("ufo4.bmp", Color.FromArgb(0, 255, 0));
            Engine_Game.Add(ufo4);
            Frame afUFO1 = new Frame(ufo1, 5);
            Frame afUFO2 = new Frame(ufo2, 5);
            Frame afUFO3 = new Frame(ufo3, 5);
            Frame afUFO4 = new Frame(ufo4, 5);
            Engine_Animation UFOAnimation = new Engine_Animation();
            UFOAnimation.Add(afUFO1);
            UFOAnimation.Add(afUFO2);
            UFOAnimation.Add(afUFO3);
            UFOAnimation.Add(afUFO4);
            UFOAnimation.Play();
            UFOAnimation.Loop = true;

            Engine_Picture UFOExplosion01 = new Engine_Picture("ufo_bang1_2.bmp",
            Color.FromArgb(0, 255, 0));
            Engine_Game.Add(UFOExplosion01);
            Engine_Picture UFOExplosion02 = new Engine_Picture("ufo_bang2_2.bmp",
            Color.FromArgb(0, 255, 0));
            Engine_Game.Add(UFOExplosion02);
            Engine_Picture UFOExplosion03 = new Engine_Picture("ufo_bang3_2.bmp",
            Color.FromArgb(0, 255, 0));
            Engine_Game.Add(UFOExplosion03);
            Frame afUFOExplosion01 = new Frame(UFOExplosion01, 4);
            Frame afUFOExplosion02 = new Frame(UFOExplosion02, 3);
            Frame afUFOExplosion03 = new Frame(UFOExplosion03, 4);
            Engine_Animation UFOExplosion = new Engine_Animation();
            UFOExplosion.Add(afUFOExplosion01);
            UFOExplosion.Add(afUFOExplosion02);
            UFOExplosion.Add(afUFOExplosion03);
            UFOExplosion.Play();
            
            BadGuy ufo = new BadGuy();
            ufo.Add(UFOAnimation);
            ufo.Add(UFOExplosion);
            UFO = ufo;

            #endregion

            #region Fire

            Engine_Picture fire01 = new Engine_Picture("fire01.bmp", Color.FromArgb(0, 255, 0));
            Engine_Game.Add(fire01);
            Engine_Picture fire02 = new Engine_Picture("fire02.bmp", Color.FromArgb(0, 255, 0));
            Engine_Game.Add(fire02);

            Frame affire01 = new Frame(fire01, 5);
            Frame affire02 = new Frame(fire02, 5);

            Engine_Animation fireAnimation = new Engine_Animation();
            fireAnimation.Add(affire01);
            fireAnimation.Add(affire02);
            fireAnimation.Loop = true;
            fireAnimation.Play();

            Shoot fire = new Shoot();
            fire.ZOrder = -10;
            fire.Add(fireAnimation);

            Fire = fire;


            #endregion

            #region sound

            Shoot = new Engine_Sound("shoot.wav");
            Spillet.Add(Shoot);

            Die = new Engine_Sound("die.wav");
            Spillet.Add(Die);

            HeroHitsUFO = new Engine_Sound("HeroHitsUFO.wav");
            Spillet.Add(HeroHitsUFO);

            UFO_Hits_HERO = new Engine_Sound("UFO_Hits_Hero.wav");
            Spillet.Add(UFO_Hits_HERO);

            Music = new Engine_Music("music.mp3");
            Spillet.Add(Music);
            Music.Play();

            #endregion

            #region text

            Engine_Font font = new Engine_Font("Courier New", 14.0f, FontStyle.Regular);
            Spillet.Add(font);

            FrameRate fRate = new FrameRate(font);
            Spillet.Add(fRate);


            Text2D Shots = new Text2D(font);
            Shots.Text = "Shots: 0";
            Shots.Position = new Point(0, 0);
            Shots.Color = Color.DarkGreen;
            Spillet.Shots = Shots;
            Spillet.Add(Shots);

            Text2D Score = new Text2D(font);
            Score.Text = "Score: 0";
            Score.Position = new Point(0, 15);
            Score.Color = Color.DarkGreen;
            Spillet.Score = Score;
            Spillet.Add(Score);

            Text2D Level = new Text2D(font);
            Level.Text = "Level 1";
            Level.Position = new Point((800/2)-40, 0);
            Level.Color = Color.DarkGreen;
            Spillet.Level = Level;
            Spillet.Add(Level);

            Text2D Life = new Text2D(font);
            Life.Text = "Ekstraliv: " + Ekstraliv.ToString();
            Life.Position = new Point(0, 30);
            Life.Color = Color.DarkGreen;
            Spillet.Life = Life;
            Spillet.Add(Life);

            #endregion
        }

        public override void Update()
        {
            Life.Text = "Ekstraliv: " + Ekstraliv.ToString();

            if (GameLive)
            {
                #region LEVEL

                m_GameLoops++;
                if (Spawned == 10)
                {
                    Level.Text = "Level 2";
                    SpawnTime = 150;
                }
                if (Spawned == 30)
                {
                    Level.Text = "Level 3";
                    SpawnTime = 100;
                }
                if (Spawned == 60)
                {
                    Level.Text = "Level 4";
                    SpawnTime = 50;
                }
                if (Spawned > 100)
                {
                    Level.Text = "Level 5";
                    SpawnTime = 20;
                }

                #endregion

                #region SPAWN

                if (m_GameLoops % SpawnTime == 0)
                {
                    Spawned++;
                    BadGuy EnemyUFO = (BadGuy)UFO.Clone();
                    EnemyUFO.Position = new Point(m_Random.Next(-100, 800), -150);
                    Engine_Game.Add(EnemyUFO);

                }

                #endregion

                if (!Music.IsPlaying)
                    Music.Play();

                if (Ekstraliv < 0)
                {
                    GameLive = false;
                }
            }
            else
            {
                GameOver();
            }
        }

        #region GameOver
        public static void GameOver()
        {
            Music.Stop();
            
            Spillet.Remove(Hero_plane);
            Spillet.Remove(UFO);
            Spillet.Remove(Fire);
            Spillet.Remove(Pilot);
            Spillet.Remove(Life);
           

            Engine_Picture GameOver = new Engine_Picture("GameOver.bmp", Color.FromArgb(0, 255, 0));
            Engine_Game.Add(GameOver);

            Frame afGameOver = new Frame(GameOver, 5);

            Engine_Animation GameOverAnimation = new Engine_Animation();
            GameOverAnimation.Add(afGameOver);
            GameOverAnimation.Play();
            GameOverAnimation.Loop = true;
            Engine_Sprite gameover = new Engine_Sprite();
            gameover.Add(GameOverAnimation);
            gameover.Position = new Point(800 / 2, 600 / 2);
            gameover.ScaleX = 800.0f / GameOver.Width;
            gameover.ScaleY = 600.0f / GameOver.Height;
            gameover.ZOrder = -10;
            Engine_Game.Add(gameover);

            Shots.Position = new Point((800 / 2) - 40, 350);
            Level.Position = new Point((800 / 2) - 40, 365);
            Score.Position = new Point((800 / 2) - 40, 380);
            
        }
        #endregion

        #region Public_code
        //Type the code here to add the objects prototype.

        public static Hero Hero_plane;
        public static BadGuy UFO;
        public static Shoot Fire;
        public static Pilot Pilot;

        public static Engine_Sound Shoot;
        public static Engine_Sound Die;
        public static Engine_Sound HeroHitsUFO;
        public static Engine_Music Music;
        public static Engine_Sound UFO_Hits_HERO;

        public static Text2D Shots;
        public static Text2D Score;
        public static Text2D Level;
        public static Text2D Life;
        public static int Spawned;
        public static int SpawnTime = 200;
        public static int Ekstraliv = 5;
        public static bool GameLive = true;

        #endregion

        #region PrivateData
        Random m_Random = new Random();
        int m_GameLoops;
        #endregion
    }
}
