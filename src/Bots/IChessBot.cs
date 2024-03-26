using System;
using Gammer0909.MiniMax.Chess;
using Gammer0909.MiniMax.Boards;

namespace Gammer0909.MiniMax.Bots;

public interface IChessBot {

    public Move Think(ChessBoard board, int depth);

}