using System;

namespace Gammer0909.MiniMax.Boards;

/// <summary>
/// The main class for each board
/// </summary>
public abstract class Board {
    
    protected char[,]? data;

    public char[,] GetBoard() {
        return this.data ?? throw new NullReferenceException("Board data is null");
    }

    public abstract bool CheckWhoWins(Board board, char playingAs);

    public abstract bool IsGameOver(char playingAs);

    public abstract Board Clone();

}