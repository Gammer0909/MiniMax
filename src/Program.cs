using System;
using Gammer0909.MiniMax.Bots;
using Gammer0909.MiniMax.Boards;


namespace Gammer0909.MiniMax;

public class Program {
    public static void Main() {

        // TicTacToeGame game = new TicTacToeGame();
        // game.Start();
        var b = new TicTacToeBoard(new[,] {
            {' ', ' ', 'x'},
            {' ', ' ', ' '},
            {'o', ' ', 'x'}
        });
        TicTacToeBot bot = new TicTacToeBot(b, 'o');
        (int, int) move = bot.GetMove();
        b.GetBoard()[move.Item1, move.Item2] = 'o';
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                Console.Write(b.GetBoard()[i, j] + " ");
            }
            Console.WriteLine();
        }


    }
}