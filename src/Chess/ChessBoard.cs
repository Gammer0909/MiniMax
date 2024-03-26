using System;
using Gammer0909.MiniMax.Chess;

namespace Gammer0909.MiniMax.Boards;

public class ChessBoard {

    char[,] data = new char[8, 8] {
        {'r', 'n', 'b', 'q', 'k', 'b', 'n', 'r'},
        {'p', 'p', 'p', 'p', 'p', 'p', 'p', 'p'},
        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        {'P', 'P', 'P', 'P', 'P', 'P', 'P', 'P'},
        {'R', 'N', 'B', 'Q', 'K', 'B', 'N', 'R'}
    };

    int[,] colors = new[,] {
        {0, 1, 0, 1, 0, 1, 0, 1},
        {1, 0, 1, 0, 1, 0, 1, 0},
        {0, 1, 0, 1, 0, 1, 0, 1},
        {1, 0, 1, 0, 1, 0, 1, 0},
        {0, 1, 0, 1, 0, 1, 0, 1},
        {1, 0, 1, 0, 1, 0, 1, 0},
        {0, 1, 0, 1, 0, 1, 0, 1},
        {1, 0, 1, 0, 1, 0, 1, 0}
    };

    public ChessBoard() { }

    // Now, the HARD PART!
    public List<Move> GetLegalMoves(bool CapturesOnly) {

        List<Move> ret = new List<Move>();

        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {
                char c = data[i, j];
                if (c == ' ') continue;
                if (char.IsUpper(c)) continue;
            }
        }


        return ret;
    }

    private List<Move> GetLegalMovesForPiece(char c, (int, int) position) {
        List<Move> ret = new List<Move>();
        
        const int rows = 8;
        const int cols = 8;


        Dictionary<char, int[][]> directions = new Dictionary<char, int[][]> {
            {'P', new int[][] {new int[] {-1, 0}}},  // Pawn moves forward
            {'p', new int[][] {new int[] {1, 0}}},   // Pawn moves forward for black
            {'N', new int[][] {new int[] {-2, -1}, new int[] {-2, 1}, new int[] {-1, -2}, new int[] {-1, 2},
                               new int[] {1, -2}, new int[] {1, 2}, new int[] {2, -1}, new int[] {2, 1}}},  // Knight moves
            {'n', new int[][] {new int[] {-2, -1}, new int[] {-2, 1}, new int[] {-1, -2}, new int[] {-1, 2},
                               new int[] {1, -2}, new int[] {1, 2}, new int[] {2, -1}, new int[] {2, 1}}},  // Knight moves for black
            {'B', new int[][] {new int[] {-1, -1}, new int[] {-1, 1}, new int[] {1, -1}, new int[] {1, 1}}},  // Bishop moves diagonally
            {'b', new int[][] {new int[] {-1, -1}, new int[] {-1, 1}, new int[] {1, -1}, new int[] {1, 1}}},  // Bishop moves diagonally for black
            {'R', new int[][] {new int[] {-1, 0}, new int[] {1, 0}, new int[] {0, -1}, new int[] {0, 1}}},  // Rook moves horizontally and vertically
            {'r', new int[][] {new int[] {-1, 0}, new int[] {1, 0}, new int[] {0, -1}, new int[] {0, 1}}},  // Rook moves horizontally and vertically for black
            {'Q', new int[][] {new int[] {-1, -1}, new int[] {-1, 0}, new int[] {-1, 1}, new int[] {1, -1},
                               new int[] {1, 0}, new int[] {1, 1}, new int[] {0, -1}, new int[] {0, 1}}},  // Queen moves in all directions
            {'q', new int[][] {new int[] {-1, -1}, new int[] {-1, 0}, new int[] {-1, 1}, new int[] {1, -1},
                               new int[] {1, 0}, new int[] {1, 1}, new int[] {0, -1}, new int[] {0, 1}}}   // Queen moves in all directions for black
        };

        foreach (var direction in directions[c]) {
            int dx = direction[0];
            int dy = direction[1];
            int x = position.Item1;
            int y = position.Item2;
            while (true) {
                x += dx;
                y += dy;
                if (x < 0 || x >= rows || y < 0 || y >= cols) break;

                // Pawns can't take pieces in front of them
                if (c == 'P' && dx == -1 && data[x, y] != ' ') break;

                char piece = data[x, y];
                if (piece == ' ') {
                    ret.Add(new Move(position, (x, y)));
                } else {
                    if (char.IsUpper(c) != char.IsUpper(piece)) {
                        ret.Add(new Move(position, (x, y), true, false, false, false, false, null, new Piece(piece, char.IsUpper(piece))));
                    }
                    break;
                }
            }
        }

    }

    public char this[int x, int y] {
        get => data[x, y];
        set => data[x, y] = value;
    }

    public int GetColor(int x, int y) => colors[x, y];

    public override string ToString() {
        string result = "";
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {
                result += data[i, j];
            }
            result += "\n";
        }
        return result;
    }

}