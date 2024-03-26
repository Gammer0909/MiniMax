using System;

namespace Gammer0909.MiniMax.Chess;

/// <summary>
/// Represents a move in chess.
/// </summary>
public class Move {

    public (int, int) From { get; }
    public (int, int) To { get; }
    public bool IsCapture { get; }
    public bool IsCheck { get; }
    public bool IsCheckmate { get; }
    public bool IsStalemate { get; }
    public bool IsPromotion { get; }
    public Piece? PromotionPiece { get; }
    public Piece? CapturedPiece { get; }

    public Move((int, int) from, (int, int) to, bool isCapture, bool isCheck, bool isCheckmate, bool isStalemate, bool isPromotion, Piece? promotionPiece, Piece? capturedPiece) {
        From = from;
        To = to;
        IsCapture = isCapture;
        IsCheck = isCheck;
        IsCheckmate = isCheckmate;
        IsStalemate = isStalemate;
        IsPromotion = isPromotion;
        PromotionPiece = promotionPiece;
        CapturedPiece = capturedPiece;
    }

    /// <summary>
    /// Creates a new move, with no special properties.
    /// </summary>
    /// <param name="from">The place the piece starts from</param>
    /// <param name="to">The place the piece being moved is going to</param>
    public Move((int, int) from, (int, int) to) : this(from, to, false, false, false, false, false, null, null) { }

    public override string ToString() {
        return $"{From} -> {To}";
    }

    public override bool Equals(object? obj) {
        if (obj is Move move) {
            return From == move.From && To == move.To;
        }
        return false;
    }    

}