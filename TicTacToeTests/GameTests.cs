using System;
using TicTacToeData;
using Xunit;

namespace TicTacToeTests
{
    public class GameTests
    {
        [Fact]
        public void Test_If_First_Row_Won_X()
        {
            var game = new Game();

            game.PlaceCheckMark(0, 0); // x - played
            game.PlaceCheckMark(1, 0); // o - played
            game.PlaceCheckMark(0, 1); // x - played
            game.PlaceCheckMark(2, 0); // o - played
            game.PlaceCheckMark(0, 2); // x - played

            var result = game.CheckWinner();

            Assert.True(result == GameResultEnum.XWon);
        }

        [Fact]
        public void Test_If_Diagnal_Won_X()
        {
            var game = new Game();

            game.PlaceCheckMark(0, 0); // x - played
            game.PlaceCheckMark(1, 0); // o - played
            game.PlaceCheckMark(1, 1); // x - played
            game.PlaceCheckMark(2, 0); // o - played
            game.PlaceCheckMark(2, 2); // x - played

            var result = game.CheckWinner();

            Assert.True(result == GameResultEnum.XWon);
        }

        [Fact]
        public void Test_If_Diagnal_2_Won_X()
        {
            var game = new Game();

            game.PlaceCheckMark(2, 0); // x - played
            game.PlaceCheckMark(0, 0); // o - played
            game.PlaceCheckMark(1, 1); // x - played
            game.PlaceCheckMark(0, 1); // o - played
            game.PlaceCheckMark(0, 2); // x - played

            var result = game.CheckWinner();

            Assert.True(result == GameResultEnum.XWon);
        }

        [Fact]
        public void Test_If_Have_To_Continue()
        {
            var game = new Game();

            game.PlaceCheckMark(2, 0); // x - played

            var result = game.CheckWinner();

            Assert.True(result == GameResultEnum.Continue);
        }
    }
}
