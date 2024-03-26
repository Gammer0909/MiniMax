using System;

namespace Gammer0909.MiniMax.Chess;

/// <summary>
/// Represents a chess piece.
/// </summary>
public struct Piece {

    public char Symbol { get; }
    public bool IsWhite { get; }

    public Piece(char symbol, bool isWhite) {
        Symbol = symbol;
        IsWhite = isWhite;
    }

}