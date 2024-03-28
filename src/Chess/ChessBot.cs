using Chess;

namespace Gammer0909.MiniMax.Chess;

public class ChessBot {
    private Move move;
    private ChessBoard board;
    private int[] values = { 1, 3, 3, 5, 9, 1000 };

    public ChessBot(ChessBoard board) {
        this.board = board;
    }

    public Move GetBestMove() {
        move = null;
        MiniMax(3, true);
        return move;
    }

    private int MiniMax(int depth, bool isMaximizing) {
        if (depth == 0) {
            return Evaluate();
        }

        Move[] moves = board.Moves();
        int bestValue = isMaximizing ? int.MinValue : int.MaxValue;

        foreach (Move move in moves) {
            var newBoard = board.
            board.Move(move);
            int value = MiniMax(depth - 1, !isMaximizing);
            board.UndoMove(move);

            if (isMaximizing) {
                bestValue = Math.Max(bestValue, value);
                if (depth == 3 && bestValue == value) {
                    this.move = move;
                }
            } else {
                bestValue = Math.Min(bestValue, value);
            }
        }

        return bestValue;
    }

    private Evaluate() {
        int score = 0;
        foreach (Piece piece in board.Pieces) {
            score += values[(int)piece.Type];
        }
        return score;
    }

}