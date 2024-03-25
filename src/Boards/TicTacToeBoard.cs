using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Gammer0909.MiniMax.Boards;

public class TicTacToeBoard : Board {

    public TicTacToeBoard(char[,] data) {

        base.data = data;

    }

    public TicTacToeBoard() {
        base.data = new[,] {
            {' ', ' ', ' '},
            {' ', ' ', ' '},
            {' ', ' ', ' '}
        };
    }

    public void MakeMove(char player, (int, int) square) {
        base.data[square.Item1, square.Item2] = player;
    }

    public override bool CheckWhoWins(Board board, char playingAs) {
        if ((base.data[0, 0] == playingAs && base.data[0, 1] == playingAs && base.data[0, 2] == playingAs)
        || (base.data[1, 0] == playingAs && base.data[1, 1] == playingAs && base.data[1, 2] == playingAs)
        || (base.data[2, 0] == playingAs && base.data[2, 1] == playingAs && base.data[2, 2] == playingAs)
        || (base.data[0, 0] == playingAs && base.data[1, 0] == playingAs && base.data[2, 0] == playingAs)
        || (base.data[0, 1] == playingAs && base.data[1, 1] == playingAs && base.data[2, 1] == playingAs)
        || (base.data[0, 2] == playingAs && base.data[1, 2] == playingAs && base.data[2, 2] == playingAs)
        || (base.data[0, 0] == playingAs && base.data[1, 1] == playingAs && base.data[2, 2] == playingAs)
        || (base.data[0, 2] == playingAs && base.data[1, 1] == playingAs && base.data[2, 0] == playingAs))
            return true;
        else
            return false;
    }

    public int GetOpenSquares() {
        int ret = 0;
        for (int x = 0; x < 3; x++) {
            for (int y = 0; y < 3; y++) {
                if (this.data[x, y] == ' ')
                    ret++;
            }
        }
        return ret;
    }

    public override bool IsGameOver(char playingAs) {
    
        if (CheckWhoWins(this, playingAs))
            return true;

        // are all spots on base.data are filled?
        foreach (char c in base.data) {
            if (c == ' ')
                return false;

        }
        return true;
    
    }

    public override Board Clone() {
        return new TicTacToeBoard((char[,])base.data.Clone() ?? throw new NullReferenceException("Board data is null"));
    }
}