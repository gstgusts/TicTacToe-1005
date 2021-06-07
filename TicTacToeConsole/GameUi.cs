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
        
        public void Show()
        {
            while(true)
            {
                PrintBoard();

                var userInput = Console.ReadLine().ToUpper();

                switch(userInput)
                {
                    case "N":
                        _game.Start();
                        break;
                    case "E":
                        return;
                    case "P":
                        var result = PlaceCheckMark();

                        switch (result)
                        {
                            case GameResultEnum.Continue:
                                break;
                            case GameResultEnum.Duece:
                                Console.WriteLine("Duece");
                                break;
                            case GameResultEnum.XWon:
                                Console.WriteLine("X Won!!!");
                                break;
                            case GameResultEnum.OWon:
                                Console.WriteLine("O Won!!!");
                                break;
                        }

                        break;
                    default:
                        Console.WriteLine("No such option");
                        break;
                }
            }
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

        private GameResultEnum PlaceCheckMark()
        {
            int row = GetNumber("Please enter row: ");
            int col = GetNumber("Please enter column: ");
            return _game.PlaceCheckMark(row - 1, col - 1);
        }

        private int GetNumber(string prompt)
        {
            while(true)
            {
                Console.Write(prompt);
                var userInput = Console.ReadLine();

                int val;

                var result = int.TryParse(userInput, out val);

                Console.WriteLine();

                if(result)
                {
                    return val;
                }

                Console.WriteLine("Input is not a valid number");
            }
        }
    }
}
