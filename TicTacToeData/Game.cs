using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeData
{
    public class Game
    {
        public const int Size = 3;
        private FieldTypeEnum[,] _board = new FieldTypeEnum[Size, Size];
        private bool _isXPlaying;

        public Game()
        {
            Start();
        }

        public string ActivePlayer
        {
            get
            {
                return _isXPlaying ? "X" : "O";
            }
        }

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

        public GameResultEnum PlaceCheckMark(int row, int col)
        {
            CheckIfFieldIsValid(row, col);

            if(_board[row, col] != FieldTypeEnum.Empty)
            {
                return GameResultEnum.Continue;
            }

            _board[row, col] = _isXPlaying ? FieldTypeEnum.X : FieldTypeEnum.O;

            _isXPlaying = !_isXPlaying;

            return CheckWinner();
        }

        public FieldTypeEnum GetFieldValue(int row, int col)
        {
            CheckIfFieldIsValid(row, col);

            return _board[row, col];
        }

        private static void CheckIfFieldIsValid(int row, int col)
        {
            if (row < 0 || row > Size - 1 || col < 0 || col > Size - 1)
            {
                throw new ArgumentException("No such row or colum");
            }
        }

        private GameResultEnum CheckWinner()
        {
            return GameResultEnum.Continue;
        }
    }
}
