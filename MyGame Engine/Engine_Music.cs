#region Using directives

using System;
using Microsoft.DirectX.AudioVideoPlayback;

#endregion

namespace TheGame
{
    public class Engine_Music: IDisposable
    {
        public Engine_Music(string fileName)
        {
            m_Audio = new Audio(Engine_Game.MusicPath + fileName, false);
        }

        public virtual void Dispose()
        {
            m_Audio.Stop();
            m_Audio.Dispose();
            m_Audio = null;
            m_Disposed = true;
        }

        public bool Disposed
        {
            get
            {
                return m_Disposed;
            }
        }

        public void Play()
        {
            m_Audio.Play();
        }

        public void Stop()
        {
            m_Audio.Stop();
        }

        public bool IsPlaying
        {
            get
            {
                if (m_Audio.CurrentPosition >= m_Audio.Duration)
                    m_Audio.Stop();
                return m_Audio.Playing;
            }
        }

        #region PrivateData

        private Audio m_Audio;
        private bool m_Disposed;

        #endregion
    }
}
