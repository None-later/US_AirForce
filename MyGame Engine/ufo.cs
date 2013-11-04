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
    public class ufo : Engine_Sprite
    {
        public ufo()
        {
        }
        protected ufo(ufo ufo)
            : base(ufo)
        {
        }
        public override Object Clone()
        {
            return new ufo(this);
        }
        public override void Update()
        {
        }
    }
}