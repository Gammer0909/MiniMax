using System;
using System.Collections.Generic;
using Gammer0909.MiniMax.Boards;


public class ChessBoard : Board {

    public ChessBoard() {
        this.data = new char[8, 8];
        this.data = new char[8, 8] {
            {'r', 'n', 'b', 'q', 'k', 'b', 'n', 'r'},
            {'p', 'p', 'p', 'p', 'p', 'p', 'p', 'p'},
            {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {'P', 'P', 'P', 'P', 'P', 'P', 'P', 'P'},
            {'R', 'N', 'B', 'Q', 'K', 'B', 'N', 'R'}
        };
    }

    public ChessBoard(char[,] data) {
        this.data = data;
    }

    public override bool CheckWhoWins(Board board, char playingAs) {
        throw new NotImplementedException();
    }

    public override bool IsGameOver(char playingAs) {
        throw new NotImplementedException();
    }

    public override Board Clone() {
        char[,] newData = new char[8, 8];
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {
                newData[i, j] = this.data[i, j];
            }
        }
        return new ChessBoard(newData);
    }

    public char[,] GetBoard() {
        return this.data;
    }

    public void SetBoard(char[,] data) {
        this.data = data;
    }

    public void PrintBoard() {
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {
                Console.Write(this.data[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public void MovePiece((int, int) from, (int, int) to) {
        this.data[to.Item1, to.Item2] = this.data[from.Item1, from.Item2];
        this.data[from.Item1, from.Item2] = ' ';
    }

    public void SetPiece((int, int) pos, char piece) {
        this.data[pos.Item1, pos.Item2] = piece;
    }

    public List<(int, int)> GetPiecePositions(char piece) {
        List<(int, int)> positions = new List<(int, int)>();
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {
                if (this.data[i, j] == piece) {
                    positions.Add((i, j));
                }
            }
        }
        return positions;
    }

    private List<(int, int)> GetLegalMovesForPiece(char piece, (int, int) position) {
        List<(int, int)> legalMoves = new List<(int, int)>();

        switch (char.ToLower(piece)) {
            case 'p': // Pawn
                // For simplicity, assuming pawns can only move forward and capture diagonally
                int direction = char.IsUpper(piece) ? -1 : 1; // White pawns move up, black pawns move down
                int startRow = char.IsUpper(piece) ? 6 : 1; // Starting row for pawns
                int forwardOne = position.Item2 + direction;
                int forwardTwo = position.Item2 + 2 * direction;

                // Move one square forward
                if (IsValidPosition(position.Item1, forwardOne) && this.GetBoard()[position.Item1, forwardOne] == ' ') {
                    legalMoves.Add((position.Item1, forwardOne));

                    // Move two squares forward from starting position
                    if (position.Item2 == startRow && this.GetBoard()[position.Item1, forwardTwo] == ' ') {
                        legalMoves.Add((position.Item1, forwardTwo));
                    }
                }

                // Capture diagonally
                int[] captureCols = { position.Item1 - 1, position.Item1 + 1 };
                foreach (int col in captureCols)
                {
                    if (IsValidPosition(col, forwardOne) && this.GetBoard()[col, forwardOne] != ' ' && 
                        char.IsUpper(piece) != char.IsUpper(this.GetBoard()[col, forwardOne]))
                    {
                        legalMoves.Add((col, forwardOne));
                    }
                }
                break;

            case 'r': // Rook
                legalMoves.AddRange(GetStraightLineMoves(position, 0, 1)); // Moves up
                legalMoves.AddRange(GetStraightLineMoves(position, 0, -1)); // Moves down
                legalMoves.AddRange(GetStraightLineMoves(position, 1, 0)); // Moves right
                legalMoves.AddRange(GetStraightLineMoves(position, -1, 0)); // Moves left
                break;

            case 'n': // Knight
                int[] knightRowMoves = { -2, -1, 1, 2 };
                int[] knightColMoves = { -1, -2, -2, -1, 1, 2, 2, 1 };

                for (int i = 0; i < knightRowMoves.Length; i++)
                {
                    int newRow = position.Item1 + knightRowMoves[i];
                    int newCol = position.Item2 + knightColMoves[i];
                    if (IsValidPosition(newRow, newCol))
                    {
                        legalMoves.Add((newRow, newCol));
                    }
                }
                break;

            case 'b': // Bishop
                legalMoves.AddRange(GetDiagonalMoves(position, 1, 1)); // Moves up-right
                legalMoves.AddRange(GetDiagonalMoves(position, 1, -1)); // Moves up-left
                legalMoves.AddRange(GetDiagonalMoves(position, -1, 1)); // Moves down-right
                legalMoves.AddRange(GetDiagonalMoves(position, -1, -1)); // Moves down-left
                break;

            case 'q': // Queen
                legalMoves.AddRange(GetStraightLineMoves(position, 0, 1)); // Moves up
                legalMoves.AddRange(GetStraightLineMoves(position, 0, -1)); // Moves down
                legalMoves.AddRange(GetStraightLineMoves(position, 1, 0)); // Moves right
                legalMoves.AddRange(GetStraightLineMoves(position, -1, 0)); // Moves left
                legalMoves.AddRange(GetDiagonalMoves(position, 1, 1)); // Moves up-right
                legalMoves.AddRange(GetDiagonalMoves(position, 1, -1)); // Moves up-left
                legalMoves.AddRange(GetDiagonalMoves(position, -1, 1)); // Moves down-right
                legalMoves.AddRange(GetDiagonalMoves(position, -1, -1)); // Moves down-left
                break;

            case 'k': // King
                int[] kingRowMoves = { -1, -1, -1, 0, 0, 1, 1, 1 };
                int[] kingColMoves = { -1, 0, 1, -1, 1, -1, 0, 1 };

                for (int i = 0; i < kingRowMoves.Length; i++)
                {
                    int newRow = position.Item1 + kingRowMoves[i];
                    int newCol = position.Item2 + kingColMoves[i];
                    if (IsValidPosition(newRow, newCol))
                    {
                        legalMoves.Add((newRow, newCol));
                    }
                }
                break;
        }

        return legalMoves;
    }


    private List<(int, int)> GetStraightLineMoves((int, int) position, int rowIncrement, int colIncrement) {
        List<(int, int)> straightLineMoves = new List<(int, int)>();
        int newRow = position.Item1 + rowIncrement;
        int newCol = position.Item2 + colIncrement;

        while (IsValidPosition(newRow, newCol)) {
            straightLineMoves.Add((newRow, newCol));
            newRow += rowIncrement;
            newCol += colIncrement;
        }

        return straightLineMoves;
    }

    private List<(int, int)> GetDiagonalMoves((int, int) position, int rowIncrement, int colIncrement) {
        List<(int, int)> diagonalMoves = new List<(int, int)>();
        int newRow = position.Item1 + rowIncrement;
        int newCol = position.Item2 + colIncrement;

        while (IsValidPosition(newRow, newCol)) {
            diagonalMoves.Add((newRow, newCol));
            newRow += rowIncrement;
            newCol += colIncrement;
        }

        return diagonalMoves;
    }

    private bool IsValidPosition(int row, int col) {
        return row >= 0 && row < 8 && col >= 0 && col < 8;
    }

}