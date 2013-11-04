#region Using directives

using System;
using System.Windows.Forms;

#endregion

namespace TheGame
{
    static class Engine_Program
    {
        [STAThread]
        static void Main()
        {
            using (Spillet MyGame = new Spillet())
                MyGame.Run();
        }
    }
}