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
