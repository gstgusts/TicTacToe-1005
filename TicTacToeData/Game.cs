using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeData
{
    [Serializable]
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

        public bool IsXPlaying
        {
            get
            {
                return _isXPlaying;
            }

            set
            {
                _isXPlaying = value;
            }
        }

        public FieldTypeEnum[,] Board
        {
            get
            {
                return _board;
            }
            set
            {
                _board = value;
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

        public GameResultEnum CheckWinner()
        {
            // this method should check for winner or for the end of the game;
            bool isWinner = false;

            // checking horizontal lines
            if (_board[0, 0] == _board[0, 1] && _board[0, 1] == _board[0, 2] && _board[0, 0] != FieldTypeEnum.Empty)
            {
                isWinner = true;
            }
            else if (_board[1, 0] == _board[1, 1] && _board[1, 1] == _board[1, 2] && _board[1, 0] != FieldTypeEnum.Empty)
            {
                isWinner = true;
            }
            else if (_board[2, 0] == _board[2, 1] && _board[2, 1] == _board[2, 2] && _board[2, 0] != FieldTypeEnum.Empty)
            {
                isWinner = true;
            }

            // checking vertical lines
            else if (_board[0, 0] == _board[1, 0] && _board[1, 0] == _board[2, 0] && _board[0, 0] != FieldTypeEnum.Empty)
            {
                isWinner = true;
            }
            else if (_board[0, 1] == _board[1, 1] && _board[1, 1] == _board[2, 1] && _board[0, 1] != FieldTypeEnum.Empty)
            {
                isWinner = true;
            }
            else if (_board[0, 2] == _board[1, 2] && _board[1, 2] == _board[2, 2] && _board[0, 2] != FieldTypeEnum.Empty)
            {
                isWinner = true;
            }

            // checking diagonals
            else if (_board[0, 0] == _board[1, 1] && _board[1, 1] == _board[2, 2] && _board[0, 0] != FieldTypeEnum.Empty)
            {
                isWinner = true;
            }
            else if (_board[0, 2] == _board[1, 1] && _board[1, 1] == _board[2, 0] && _board[0, 2] != FieldTypeEnum.Empty)
            {
                isWinner = true;
            }

            if (isWinner)
            {
                // buttons have to be disabled -
                if (_isXPlaying)
                {
                    return GameResultEnum.OWon;
                }
                else
                {
                    return GameResultEnum.XWon;
                }
            }
            else
            {
                foreach (var item in _board)
                {
                    if(item == FieldTypeEnum.Empty)
                    {
                        return GameResultEnum.Continue;
                    }
                }

                return GameResultEnum.Duece;
            }
        }
    }
}
