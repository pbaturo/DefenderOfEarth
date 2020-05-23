using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefenderOfEarth.Game
{
    class BulletFactory
    {

        private int _width;
        private int _height;
        private int _gameHorizontalSize;

        public BulletFactory(int width, int height, int gameHorizontalSize)
        {
            _width = width;
            _height = height;
            _gameHorizontalSize = gameHorizontalSize;
        }
        
        public Bullet Create()
        {
            return new Bullet(_width, _height, _gameHorizontalSize);
        }
    }
}
