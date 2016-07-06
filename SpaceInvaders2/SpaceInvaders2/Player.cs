using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders2
{
    public class Player
    {

        public Player (int gameVerticalSize)
        {
            if (gameVerticalSize<=0)
            {
                throw new ArgumentException("Argument {0} must be positive value!", nameof(gameVerticalSize));
            }
            PositionX = gameVerticalSize / 2;
            _gameVerticalSize = gameVerticalSize;
        }

        public int PositionX { get; protected set; } = 0;
        private int _gameVerticalSize;
        public void MoveLeft()
        {
            if (PositionX > 0)
            {
                PositionX--;
            }
        }

        public void MoveRight()
        {
            if (PositionX < _gameVerticalSize)
            {
                PositionX++;
            }
        }
    }
}
