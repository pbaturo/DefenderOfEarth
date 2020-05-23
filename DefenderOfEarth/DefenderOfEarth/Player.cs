using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefenderOfEarth.Game
{
    class Player
    {
        private readonly Shooting _shooting;

        public Player(Shooting shooting, int gameVerticalSize, int gameHorizontalSize, int spaceshipWidth, int spaceshipHeight)
        {
            if (gameVerticalSize<=0)
            {
                throw new ArgumentException("Argument {0} must be positive value!", nameof(gameVerticalSize));
            }
            if (gameHorizontalSize <= 0)
            {
                throw new ArgumentException("Argument {0} must be positive value!", nameof(gameHorizontalSize));
            }
            if (spaceshipWidth <= 0)
            {
                throw new ArgumentException("Argument {0} must be positive value!", nameof(spaceshipWidth));
            }
            if (spaceshipHeight <= 0)
            {
                throw new ArgumentException("Argument {0} must be positive value!", nameof(spaceshipHeight));
            }
            _shooting = shooting ?? throw new ArgumentNullException(nameof(shooting));
            PositionX = gameVerticalSize / 2;
            _gameVerticalSize = gameVerticalSize;
            _spaceshipHeight = spaceshipHeight;
            _gameHorizontalSize = gameHorizontalSize;
            _spaceshipWidth = spaceshipWidth;
        }

        public int PositionX { get; protected set; } = 0;

        private readonly int _gameVerticalSize;
        private readonly int _gameHorizontalSize;
        private readonly int _spaceshipHeight;
        private readonly int _spaceshipWidth;

        public void MoveLeft()
        {
            if (PositionX > 0)
            {
                PositionX-=2;
            }
        }

        public void MoveRight()
        {
            if (PositionX < _gameVerticalSize)
            {
                PositionX+=2;
            }
        }

        public bool Shoot()
        {
            return _shooting.Fire(PositionX + _spaceshipWidth/2 - _shooting.BulletWidth/2 - 1, _gameHorizontalSize - _spaceshipHeight - _shooting.BulletHeight);
        }

    }
}
