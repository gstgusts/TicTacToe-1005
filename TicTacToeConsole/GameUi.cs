using System;
using System.Collections.Generic;
using System.Text;
using TicTacToeData;

namespace TicTacToeConsole
{
    public class GameUi
    {
        private Game _game;

        public GameUi(Game game)
        {
            _game = game;
        }

        public void PrintBoard()
        {
            for (int i = 0; i < Game.Size; i++)
            {
                Console.WriteLine("-------------");

                for (int j = 0; j < Game.Size; j++)
                {
                    Console.Write("|" +  GetFieldValue(_game.GetFieldValue(i, j)));
                }

                Console.WriteLine("|");
                //Console.WriteLine();
            }


            Console.WriteLine("-------------");
            Console.WriteLine();
            PrintMenu();
        }

        private void PrintMenu()
        {
            Console.WriteLine("-------------");
            Console.WriteLine($"Player {_game.ActivePlayer} is active now");
            Console.WriteLine("-------------");
            Console.WriteLine("N - New game");
            Console.WriteLine("E - Exit game");
            Console.WriteLine("P - Enter position");
            Console.WriteLine("-------------");
        }

        private string GetFieldValue(FieldTypeEnum value)
        {
            if(value == FieldTypeEnum.Empty)
            {
                return "   ";
            }

            return $" {value} ";
        }
    }
}
