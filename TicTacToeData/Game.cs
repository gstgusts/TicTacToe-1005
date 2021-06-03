using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeData
{
    public class Game
    {
        private const int Size = 3;
        private FieldTypeEnum[,] _board = new FieldTypeEnum[Size, Size];
        private bool _isXPlaying;

        public void Start()
        {
            _isXPlaying = true;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    _board[i, j] = FieldTypeEnum.Empty;
                }
            }
        }

        public void PlaceCheckMark(int row, int col)
        {
            if(row < 0 || row > Size - 1 || col < 0 || col > Size - 1)
            {
                throw new ArgumentException("No such row or colum");
            }

            if(_board[row, col] != FieldTypeEnum.Empty)
            {
                return;
            }

            _board[row, col] = _isXPlaying ? FieldTypeEnum.X : FieldTypeEnum.O;

            _isXPlaying = !_isXPlaying;

            CheckWinner();
        }

        private void CheckWinner()
        {
            throw new NotImplementedException();
        }
    }
}
