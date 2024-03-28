using System;
using Gammer0909.MiniMax.Bots;
using Gammer0909.MiniMax.Boards;


namespace Gammer0909.MiniMax;

public class Program {
    public static void Main() {
        
        // A mess of OOP spaghetti for a C L E A N main method :happy:
        TicTacToeGame game = new TicTacToeGame();
        game.Start();

    }
}