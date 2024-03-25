using System;
using System.ComponentModel;
using Gammer0909.MiniMax.Boards;
using Gammer0909.MiniMax.Frontend;

namespace Gammer0909.MiniMax.Bots;

public class TicTacToeBot : IBot {

    private TicTacToeBoard board;
    private char playingAs;

    public TicTacToeBot(TicTacToeBoard board, char playingAs) {
        this.board = board;
        this.playingAs = playingAs;
    }

    public (int, int) GetMove() {
        int bestScore = int.MinValue;
        (int, int) bestMove = (0, 0);
        for (int x = 0; x < 3; x++) {
            for (int y = 0; y < 3; y++) {
                if (board.GetBoard()[x, y] == ' ') {
                    board.GetBoard()[x, y] = playingAs;
                    int score = MiniMax(board, GetOpponent(this.playingAs), false);
                    Console.WriteLine($"Move: {(x, y)} Score: {score}");
                    board.GetBoard()[x, y] = ' ';

                    if (score > bestScore) {
                        bestScore = score;
                        bestMove = (x, y);
                    }

                }
            }
        }
        Console.WriteLine(bestMove);
        return bestMove;
    }

    public (int, int) GetMove(char playingAs) {
        int bestScore = int.MinValue;
        (int, int) bestMove = (-1, -1);
        for (int x = 0; x < 3; x++) {
            for (int y = 0; y < 3; y++) {
                if (board.GetBoard()[x, y] == ' ') {
                    board.GetBoard()[x, y] = playingAs;
                    int score = MiniMax(board, playingAs, true);
                    board.GetBoard()[x, y] = ' ';
                    Console.WriteLine($"Move: {(x, y)} Score: {score}");
                    int before = bestScore;
                    bestScore = Math.Max(score, bestScore);
                    bestMove = bestScore == before ? (-1, -1) : (x, y);
                }
            }
        }
        return bestMove;
    }

    private char GetOpponent(char player) {
        return player == 'x' ? 'o' : 'x';
    }

    public int MiniMax(Board board, char player, bool isMax) {

        if (board.IsGameOver(player)) {
            return Evaluate(board);
        }

        if (isMax) {
            int bestScore = int.MinValue;
            for (int x = 0; x < 3; x++) {
                for (int y = 0; y < 3; y++) {
                    if (board.GetBoard()[x, y] == ' ') {
                        TicTacToeBoard newBoard = (TicTacToeBoard) board.Clone();
                        newBoard.GetBoard()[x, y] = player;
                        int score = MiniMax(newBoard, GetOpponent(player), false);
                        bestScore = Math.Max(bestScore, score);
                    }
                }
            }
            return bestScore;
        } else {
            int bestScore = int.MaxValue;
            for (int x = 0; x < 3; x++) {
                for (int y = 0; y < 3; y++) {
                    if (board.GetBoard()[x, y] == ' ') {
                        TicTacToeBoard newBoard = (TicTacToeBoard) board.Clone();
                        newBoard.GetBoard()[x, y] = player;
                        int score = MiniMax(newBoard, player, true);
                        bestScore = Math.Min(bestScore, score);
                    }
                }
            }
            return bestScore;
        }

    }

    private int Evaluate(Board b) {

        var board = (TicTacToeBoard) b.Clone();

        if (board.CheckWhoWins(b, this.playingAs)) {
            return 10 + board.GetOpenSquares();
        } else if (board.CheckWhoWins(b, GetOpponent(this.playingAs))) {
            return -10 - board.GetOpenSquares();
        } else {
            return 0;
        }
    }
}