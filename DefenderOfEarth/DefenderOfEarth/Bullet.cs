using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefenderOfEarth.Game
{
    class Bullet
    {
        public int PositionX { get; protected set; }

        public int PositionY { get; protected set; }

        public int Width { get; protected set; }

        public int Height { get; protected set; }

        private int _gameHorizontalSize;

        public bool Visible { get; protected set; } = true;

        public Bullet(int width, int height, int gameHorizontalSize)
        {
            
            this.Width = width;
            this.Height = height;
            this._gameHorizontalSize = gameHorizontalSize;
        }

        public void Fire(int x, int y)
        {
            this.PositionX = x;
            this.PositionY = y;
            this.Visible = true;
        }

        public void Move()
        {
            if (!Visible)
            {
                return;
            }
            this.PositionY -= 10;
            if (this.PositionY < -this.Height)
            {
                this.Visible = false;
            }
        }
    }
}
