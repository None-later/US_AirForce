#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;


#endregion

namespace TheGame
{
    partial class GameWindow : Form
    {
        public GameWindow()
        {
            InitializeComponent();
            SetStyle(ControlStyles.Opaque | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
        }

        
        private void MainWindow_Paint(object sender, PaintEventArgs e)
        {
            Engine_Game.Render();
        }

        private void GameWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Engine_Game.Quit();
        }
    }
}



