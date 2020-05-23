using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefenderOfEarth.Game
{
    class Enemy
    {

        public Enemy(int gameVerticalSize, int gameHorizontalSize, int enemyWidth, int enemyHeight)
        {
            if (gameVerticalSize <= 0)
            {
                throw new ArgumentException("Argument {0} must be positive value!", nameof(gameVerticalSize));
            }
            if (gameHorizontalSize <= 0)
            {
                throw new ArgumentException("Argument {0} must be positive value!", nameof(gameHorizontalSize));
            }
            if (enemyWidth <= 0)
            {
                throw new ArgumentException("Argument {0} must be positive value!", nameof(enemyWidth));
            }
            if (enemyHeight <= 0)
            {
                throw new ArgumentException("Argument {0} must be positive value!", nameof(enemyHeight));
            }

            PositionX = 10;
            PositionY = 10;
            _gameVerticalSize = gameVerticalSize;
            _enemyHeight = enemyHeight;
            _gameHorizontalSize = gameHorizontalSize;
            _enemyWidth = enemyWidth;
            _stepHorizontal = 1;
        }

        public int PositionX { get; protected set; } = 0;
        public int PositionY { get; protected set; } = 0;

        private readonly int _gameVerticalSize;
        private readonly int _gameHorizontalSize;
        private readonly int _enemyHeight;
        private readonly int _enemyWidth;
        private int _stepHorizontal;

        public void Move()
        {
            if (_stepHorizontal > 0)
            {
                if (PositionX < _gameHorizontalSize - _enemyWidth - 10)
                {
                    PositionX += CountStepHorizontal();
                }
                else
                {
                    PositionY += CountStepVertical();
                    Reverse();
                }
            }
            else
            {
                if (PositionX > 10)
                {
                    PositionX += CountStepHorizontal();
                }
                else
                {
                    PositionY += CountStepVertical();
                    Reverse();
                }
            }
            
        }

        private int CountStepHorizontal()
        {
            return _stepHorizontal;
        }

        private int CountStepVertical()
        {
            return _enemyHeight;
        }

        private void Reverse()
        {
            _stepHorizontal = -_stepHorizontal;
        }

    }
}
