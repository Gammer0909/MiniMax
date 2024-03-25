using System;
using System.Collections.Generic;
using Gammer0909.MiniMax.Boards;
using Gammer0909.MiniMax.Frontend;
using Gammer0909.MiniMax.Bots;
using System.Net;

namespace Gammer0909.MiniMax;

public class TicTacToeGame {

    private TicTacToeBoard board;
    private TicTacToeBot bot;
    private bool playerTurn = true;

    public TicTacToeGame() {
        board = new TicTacToeBoard();
        bot = new TicTacToeBot(this.board, 'o');
    }

    public void Start() {
        while (!board.IsGameOver('x') && !board.IsGameOver('o')) {
            this.DisplayBoard();
            if (playerTurn) {
                AnsiConsole.WriteLine("Write the first coordinate of your move (0-2): ");
                int x = int.Parse(Console.ReadLine().Trim());
                AnsiConsole.WriteLine("Write the second coordinate of your move (0-2): ");
                int y = int.Parse(Console.ReadLine());
                if (x > 2 || y > 2) {
                    AnsiConsole.WriteLine("Invalid move!", Color.Red);
                    continue;
                }
                board.MakeMove('x', (x, y));
                playerTurn = false;
            } else {
                (int, int) move = bot.GetMove();
                board.MakeMove('o', move);
                playerTurn = true;
            }
        }
        this.DisplayBoard();
        if (board.CheckWhoWins(board, 'x')) {
            AnsiConsole.WriteLine("You win!", Color.Green);
        } else if (board.CheckWhoWins(board, 'o')) {
            AnsiConsole.WriteLine("You lose!", Color.Red);
        } else {
            AnsiConsole.WriteLine("It's a tie!", Color.Yellow);
        }
    }

    private void DisplayBoard() {
        Console.Clear();
        AnsiConsole.Write("---------\n");
        for (int x = 0; x < 3; x++) {
            AnsiConsole.Write("|");
            for (int y = 0; y < 3; y++) {
                AnsiConsole.Write(board.GetBoard()[x, y] + " |");
            }
            AnsiConsole.WriteLine("\n---------");
        }
    }

    public void DisplayBoard(Board b) {
        Console.Clear();
        AnsiConsole.Write("---------\n");
        for (int x = 0; x < 3; x++) {
            AnsiConsole.Write("|");
            for (int y = 0; y < 3; y++) {
                AnsiConsole.Write(b.GetBoard()[x, y] + " |");
            }
            AnsiConsole.WriteLine("\n---------");
        }
    }

}