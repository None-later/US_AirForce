#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


#endregion



/*/////////////////////////////////////////////////////////////

 * 
 * 
 *  For at programmet skal kjøre må man slå av LoaderLock. Dette henger sammen med 
 *  en eldre kode (Managed C#). Gjør følgende
 *  Trykk ctrl D-E, naviger til "Managed Debuging Assistant" og ta bort haken vedsiden av LoaderLock
 *  
 *  Husk, Rebuild etter denne endring.
 * 
 * 
 * 
 * 
*/

namespace TheGame
{
    public class Spillet: Engine_Game
    {
        public static Engine_Sprite Hero;
        public static ufo UFO;

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
        
            Engine_Picture background = new Engine_Picture("Background.bmp", Color.FromArgb(0,255,0));
            Engine_Game.Add(background);
            Frame backGroundFrame = new Frame(background, 0);
            Engine_Animation backGroundAnimation = new Engine_Animation();
            backGroundAnimation.Add(backGroundFrame);
        
            Background bg = new Background();
            bg.Add(backGroundAnimation);
            bg.Position = new Point(800/2, 600/2);
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
            Engine_Sprite Plane = new Engine_Sprite();
            Plane.Add(PlaneAnimation);
            Plane.Position = new Point((800-16)/2, 550);
            Engine_Game.Add(Plane);
            Hero = Plane;

      
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

            Engine_Picture UFOExplosion01 = new Engine_Picture("ufo_bang1.bmp",
            Color.FromArgb(0, 255, 0));
            Engine_Game.Add(UFOExplosion01);
            Engine_Picture UFOExplosion02 = new Engine_Picture("ufo_bang2.bmp",
            Color.FromArgb(0, 255, 0));
            Engine_Game.Add(UFOExplosion02);
            Engine_Picture UFOExplosion03 = new Engine_Picture("ufo_bang3.bmp",
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
            ufo ufo = new ufo();
            ufo.Add(UFOAnimation);
            ufo.Add(UFOExplosion);
            UFO = ufo;
            
            #endregion
        }

    public override void Update()
    {
      m_GameLoops++;
      if (m_GameLoops % 200 == 0)
      {
      }
    }

    #region Public_code
    //Type the code here to add the objects prototype.
    #endregion

    #region PrivateData
    Random m_Random = new Random();
    int m_GameLoops;
    #endregion
  }
}
