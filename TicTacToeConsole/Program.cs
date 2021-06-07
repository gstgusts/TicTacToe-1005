using System;
using TicTacToeData;

namespace TicTacToeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            var gameUi = new GameUi(game);

            gameUi.Show();
        }
    }
}
