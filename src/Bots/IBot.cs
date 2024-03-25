using System;
using System.Reflection.PortableExecutable;
using Gammer0909.MiniMax.Boards;

namespace Gammer0909.MiniMax.Bots;

/// <summary>
/// The main interface for MiniMax bots
/// </summary>
public interface IBot {

    protected int MiniMax(Board board, char player, bool isMax); 

}