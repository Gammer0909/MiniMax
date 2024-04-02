import requests
import chess
import time

def get_best_move(fen):
    # Replace all spaces with the %20
    url = 'https://www.chessdb.cn/cdb.php?action=querybest&board=' + fen.replace(' ', '%20')
    response = requests.get(url)
    # Get everything after the ':'
    response = response.text.split(':')[-1].replace('\x00', '')
    return response

def write_board(board: chess.Board):
    # Write ABCDEFGH
    print("   A  B  C  D  E  F  G  H", end="")
    # Loop through the board, writing the numbers
    for i in range(7, -1, -1):
        print()
        print(i + 1, end=" ")
        # Loop through the board, writing the pieces
        for j in range(8):
            piece = board.piece_at(i * 8 + j)
            if piece is None:
                print(" # ", end="")
            else:
                print(f' {piece.symbol()}', end=" ")

    print()


def main():
    board = chess.Board()
    write_board(board)
    while not board.is_game_over():
        # Get the player's move in a san
        player_move = input("Enter your move: ")
        if player_move == "q":
            break
        # I'll be inputting the moves so its ok, we don't need to check them.
        try:
            board.push_san(player_move)
        except:
            print("Invalid Move")
            continue
        write_board(board)
        # Get the best move for the computer
        best_move = get_best_move(board.fen())
        # Push the best move to the board
        board.push_san(best_move)
        clear() # Clear the screen
        write_board(board)

    print("Game Over")

def clear():
    print("\033[H\033[J")

if __name__ == "__main__":
    main()