# Machine_Learning-Unity

The game consists in a player that is represented by a purple rectangle and the goal is to collect all 3 cubes in order(red, green and blue). The player can move in all 4 directions and if he touches the borders of the map he loses. <br>
The player and the square spawns always in a random poisition and after the player loses or collects all 3 squares the game restarts. The player can't collect the squares in the wrong order. <br> <br>

I used <a href="https://unity.com/products/machine-learning-agents"> ML-Agents </a> to create an AI that learned how to play the game by using <a href="https://en.wikipedia.org/wiki/Deep_reinforcement_learning"> deep reinforcement learning </a>. When the player collects the squares it gets a ever-increasing reward based on how many squares it collected and when he loses he gets a negative reward. This encourages the player to only collect the squares in the particular order.
