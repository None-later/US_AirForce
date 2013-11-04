#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;

#endregion

namespace TheGame
{
    public class Background: Engine_Sprite
    {
        public Background()
        {

        }

        protected Background(Background background): base(background)
        {

        }

        public override Object Clone()
        {
            return new Background(this);
        }

        public override void Update()
        {
            PointF position = Position;
            position.Y++;
            if (position.Y == 600 + 300)
                position.Y = -300;
            Position = position;
        }
    }
}
