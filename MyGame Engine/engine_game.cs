#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX.DirectInput;
using Microsoft.DirectX.DirectSound;
using D3DSprite = Microsoft.DirectX.Direct3D.Sprite;
using DGDevice = Microsoft.DirectX.Direct3D.Device;
using DIDevice = Microsoft.DirectX.DirectInput.Device;
using DSDevice = Microsoft.DirectX.DirectSound.Device;
using System.Diagnostics;



#endregion

namespace TheGame
{
    public class Engine_Game: IDisposable
    {
        public virtual void Dispose()
        {
            foreach(Engine_Picture picture in m_Pictures)
                picture.Dispose();
            m_Pictures.Clear();

            foreach(Engine_Font font in m_Fonts)
                font.Dispose();
            m_Fonts.Clear();

            foreach(Engine_Sound sound in m_Sounds)
                sound.Dispose();
            m_Sounds.Clear();

            foreach (Engine_Music music in m_Music)
                music.Dispose();
            m_Music.Clear();

            dIDevice.Dispose();
            dIDevice = null;
// Kommenter ut disse 2 linjer under "dsDevice..." om du ikke har lydkort
            dsDevice.Dispose();
            dsDevice = null;
            DXSprite.Dispose();
            DXSprite = null;
            dGDevice.Dispose();
            dGDevice = null;
            m_GameWindow.Dispose();
            m_GameWindow = null;
            m_Disposed = true;
        }

        public bool Disposed
        {
            get
            {
                return m_Disposed;
            }
        }

        public virtual void InitializeResources()
        {

        }

        public void Run()
        {
            Initialize();

            InitializeResources();

            while (m_Running)
            {
                m_StopWatch.Reset();
                m_StopWatch.Start();
                Application.DoEvents();
                Engine_Keyboard.Update();
                InternalUpdate();
                Render();

                m_StopWatch.Stop();
                m_CurrentFrameTime = (double)m_StopWatch.ElapsedTicks;

                double delta = m_FrameTime - m_CurrentFrameTime;


                if (delta > 0)
                {
                    m_StopWatch.Reset();
                    m_StopWatch.Start();
                    while ((double)m_StopWatch.ElapsedTicks < delta) ;
                    m_StopWatch.Stop();
                    m_CurrentFrameTime += m_StopWatch.ElapsedTicks;
                }
            }
         }

        public virtual void Update()
        {

        }

        public static void Add(Engine_Sprite sprite)
        {
            m_AddedSprites.Add(sprite);
        }

        public static void Remove(Engine_Sprite sprite)
        {
            m_DeletedSprites.Add(sprite);
        }

        public static void Add(Text2D text2D)
        {
            m_AddedText2Ds.Add(text2D);
        }

        public static void Remove(Text2D text2D)
        {
            m_DeletedText2Ds.Add(text2D);
        }

        public static void Add(Engine_Picture picture)
        {
            m_Pictures.Add(picture);
        }

        public static void Add(Engine_Font font)
        {
            m_Fonts.Add(font);
        }

        public static void Add(Engine_Sound sound)
        {
            m_Sounds.Add(sound);
        }

        public static void Add(Engine_Music music)
        {
            m_Music.Add(music);
        }

        public static List<Engine_Sprite> GetCollidedSprites(Engine_Sprite sprite)
        {
            List<Engine_Sprite> collisionList = new List<Engine_Sprite>();
            foreach (Engine_Sprite s in m_Sprites)
            {
                if (s != sprite && s.CollidesWith(sprite))
                    collisionList.Add(s);
            }

            if (collisionList.Count != 0)
                return collisionList;
            return null;
        }

        public static Size Resolution
        {
            set
            {
                m_Resolution = value;
            }
            get
            {
                return m_GameWindow.ClientSize;
            }
        }

        public static int FrameRate
        {
            set
            {
                m_FrameRate = value;
                m_FrameTime = Stopwatch.Frequency / (double)m_FrameRate;
            }
            get
            {
                return m_FrameRate;
            }
        }

        public static int CurrentFrameRate
        {
            get
            {
                return (int)Math.Ceiling(Stopwatch.Frequency / m_CurrentFrameTime);
            }
        }

        public static void Quit()
        {
            m_Running = false;
        }

        public static void Render()
        {
            dGDevice.Clear(ClearFlags.Target, System.Drawing.Color.Black, 1.0f, 0);
            dGDevice.BeginScene();
            
            m_ZOrderedSprites.Sort(Engine_Sprite.ComparisonZOrder);
            foreach (Engine_Sprite s in m_ZOrderedSprites)
                s.Render();

            foreach (Text2D t in m_Text2Ds)
                t.Render();

            dGDevice.EndScene();
            dGDevice.Present();
        }

        public static DGDevice Device
        {
            get
            {
                return dGDevice;
            }
        }

        public static DGDevice DGDevice
        {
            get
            {
                return dGDevice;
            }
        }

        public static DIDevice DIDevice
        {
            get
            {
                return dIDevice;
            }
        }

        public static DSDevice DSDevice
        {
            get
            {
                return dsDevice;
            }
        }

        public static D3DSprite D3DSprite
        {
            get
            {
                return DXSprite;
            }
        }

        public static string PicturesPath
        {
            set
            {
                m_PicturesPath = value;
            }
            get
            {
                return m_PicturesPath;
            }
        }

        public static string MusicPath
        {
            set
            {
                m_MusicPath = value;
            }
            get
            {
                return m_MusicPath;
            }
        }

        public static string SoundPath
        {
            set
            {
                m_SoundPath = value;
            }
            get
            {
                return m_SoundPath;
            }
        }

        void InternalUpdate()
        {
            foreach (Engine_Sprite s in m_AddedSprites)
            {
                m_Sprites.Add(s);
                m_ZOrderedSprites.Add(s);
            }
            m_AddedSprites.Clear();

            foreach (Engine_Sprite s in m_DeletedSprites)
            {
                m_Sprites.Remove(s);
                m_ZOrderedSprites.Remove(s);
            }
            m_DeletedSprites.Clear();

            foreach (Engine_Sprite s in m_Sprites)
                s.InternalUpdate();

            foreach (Engine_Sprite s in m_Sprites)
                s.Update();


            foreach (Text2D t in m_AddedText2Ds)
                m_Text2Ds.Add(t);
            m_AddedText2Ds.Clear();

            foreach (Text2D t in m_DeletedText2Ds)
                m_Text2Ds.Remove(t);
            m_DeletedText2Ds.Clear();

            foreach (Text2D t in m_Text2Ds)
                t.InternalUpdate();

            Update();
        }

        static void Initialize()
        {
            m_GameWindow = new GameWindow();
            m_GameWindow.ClientSize = m_Resolution;

            InitializeGraphics();
            InitializeInput();
            InitializeSound();

            m_GameWindow.Show();
        }

        static void InitializeGraphics()
        {
            PresentParameters presentParams = new PresentParameters();
            presentParams.Windowed = true;
            presentParams.SwapEffect = SwapEffect.Discard;
            presentParams.PresentationInterval = PresentInterval.One;

            dGDevice = new DGDevice(0, Microsoft.DirectX.Direct3D.DeviceType.Hardware, m_GameWindow, CreateFlags.SoftwareVertexProcessing, presentParams);

            dGDevice.RenderState.ReferenceAlpha = 0;
            dGDevice.RenderState.AlphaFunction = Compare.NotEqual;

            DXSprite = new D3DSprite(Engine_Game.Device);
        }

        static void InitializeInput()
        {
            dIDevice = new DIDevice(SystemGuid.Keyboard);
            dIDevice.SetCooperativeLevel(m_GameWindow, CooperativeLevelFlags.Background | CooperativeLevelFlags.NonExclusive);
            dIDevice.Acquire();
        }

        static void InitializeSound()
        {
// Om du ikke har lydkort, kommenter bort disse 2 linjer under
            dsDevice = new DSDevice();
            dsDevice.SetCooperativeLevel(m_GameWindow, CooperativeLevel.Normal);
        }

        #region PrivateData

        static DGDevice dGDevice;
        static DIDevice dIDevice;
        static DSDevice dsDevice;
       
        static string m_PicturesPath = Application.StartupPath;
        static string m_MusicPath = Application.StartupPath;
        static string m_SoundPath = Application.StartupPath;

        static D3DSprite DXSprite;

        static GameWindow m_GameWindow;
        
//        static Size m_Resolution = new Size(640, 480);
        static Size m_Resolution = new Size(800, 600); 

        static List<Engine_Sprite> m_Sprites = new List<Engine_Sprite>();
        static List<Engine_Sprite> m_ZOrderedSprites = new List<Engine_Sprite>();
        static List<Engine_Sprite> m_DeletedSprites = new List<Engine_Sprite>();
        static List<Engine_Sprite> m_AddedSprites = new List<Engine_Sprite>();

        static List<Text2D> m_Text2Ds = new List<Text2D>();
        static List<Text2D> m_DeletedText2Ds = new List<Text2D>();
        static List<Text2D> m_AddedText2Ds = new List<Text2D>();

        static List<Engine_Picture> m_Pictures = new List<Engine_Picture>();
        static List<Engine_Font> m_Fonts = new List<Engine_Font>();
        static List<Engine_Sound> m_Sounds = new List<Engine_Sound>();
        static List<Engine_Music> m_Music = new List<Engine_Music>();

        static Stopwatch m_StopWatch = new Stopwatch();

        static double m_CurrentFrameTime = 1;
        static double m_FrameTime = 1;
        static int m_FrameRate;
        static bool m_Running = true;

        bool m_Disposed = false;

        #endregion
    }
}
