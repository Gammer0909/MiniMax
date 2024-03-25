# MiniMax

An implementation of the MiniMax algorithm, written in C#. (However, It is currently VERY bugged)
This was made for my school's Math Fair, where we have to present something with math, and me and my team chose minimax, because it's

1. Math Related
2. Interactive

But anyway, I'll detail the algorithm and my implementation (Mostly because I have to write about it for a grade)

## Algorithm and Implementation

### Algorithm Explanation

First, I'll go over the algorithm:
## $$V_i = \max_{a_i}\min_{a_-1}V_i(a_i, a_-i)$$

This looks scary and very hard, but the algorithm is actually not hard, let's dive into it:

1. First, get your terminal states. For Tic-Tac-Toe, this is A win, A loss, and A draw, and assign scores to each (+10, -10, 0)
2. Next, your bot will iterate over every available move, returning a score for each. The way this works is as follows:
   - Check if the space is open
   - Create a new, hypothetical board to run the move on
   - Pass the new board into the `MiniMax()` function again, but playing as the opponent. ([Recursion!](https://www.google.com/search?q=recursion&rlz=1C1GCEU_enUS1103&oq=recursion&gs_lcrp=EgZjaHJvbWUyDAgAEEUYORixAxiABDITCAEQLhiDARjHARixAxjRAxiABDINCAIQABiDARixAxiABDIHCAMQABiABDIHCAQQABiABDIHCAUQABiABDIKCAYQLhixAxiABDINCAcQABiDARixAxiABDIHCAgQABiABDIKCAkQABixAxiABNIBCDIxNTlqMGo3qAIAsAIA&sourceid=chrome&ie=UTF-8&safe=active&ssui=on))
   - Get the score from that recursive call, and compare it with the best score so far
   - Return the best score, where the highest is either the best of the worst, or a win. (The scoring system *should* try for a draw if it can't win, however my implementation is bugged rn)
   - Basically, this looks through the hypothetical future of each move, and sees if it will lead to a win or loss. This is more efficient in something like Tic-Tac-Toe, where the possible bad things that can happen are fewer than chess.
  
That's it! That's the algorithm is surprisingly simple.

Next, let's look at my implementation.

### Implementation

Because I'm not done with the chess implementation (I might not finish, like ever, however I do have a [ConsoleChess](https://Github.com/Gammer0909/ConsoleChess) game that I might add it to this summer) I'll go over the Tic-Tac-Toe implementation, which will give you a basic idea.

(This is in [TicTacToeBot.cs](https://github.com/Gammer0909/MiniMax/blob/main/src/TicTacToe/TicTacBot.cs))

First, the bot is prompted with the `(int, int) GetMove()` function, which:
1. Goes through all available spots to place an 'o'
2. Gets the MiniMax score for each move, and if the score is better than the best one so far it is the new best score
3. Returns the best move, `(x, y)`

The minimax function works as follows:
1. If the Game is over, `Evaluate()` the board, returning a -10 (- the number of open squares on a loss, a +10 (+ the number of open squares) on a win and a 0 on a draw.
2. Because the game isn't over (the `IsGameOver()` returned false), we need to see if the current player is Maximizing the score or not
   - If we are maximizing the score:
        - for each square on the board
            - If the square is empty
               - Create a new, hypothetical board and run the move on this board
               - Recursively call the `MiniMax()` function as the opponent, to go down a hypothetical of what the game would look like if we did this, and give it a score
               - if the score given from the recursive call is compared to the current best score, and the biggest one is set as the best Score
   - If we are minimizing the score (as the opponent)
        - Do the same as the maximizing, but backwards for the opponent.   

