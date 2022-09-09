# Ball-Physics-Game
Full Unity project game where players must control a ball and reach a goal.

The objective of this game is to roll a ball through a vertically scrolling platform. This game is a 3D game in perspective using native Unity physics. The player can push positive obstacles of the same color as themself around, and must avoid Danger obstacles. If the player touches a Danger obstacle, or if they are pushed over the edge of the platform, they lose the game. Neutral obstacles cannot be pushed by the player but can be pushed indirectly by pushing a positive obstacle into the neutral obstacle. Danger obstacles can be pushed the same way. Fixed obstacles will not be able to move directly or indirectly. The player collects points from point pickups that disappear when touched. The player can sometimes find a powerup that, when picked up, will change all obstacles currently on screen to the player’s color.
Groups of obstacles are spawned randomly. The player controls the speed and direction of the ball. The player needs to reach a goal area or checkpoint before a timer runs out and picks up points along the way. The raises slowly during the level.

The game has a gamecontroller that can start, pause, or end a game. From the pause menu the player can restart the game from the start of the level. If the player goes gameover or finishes the level they will be prompted to play again. Once the game is ended, the player dies, or the level is finished by the player, the gamecontroller will save a .json file that contains the following information:
● The name of the game
● The time played in seconds
● The timecode of when the score file was generated
● The score the player earned

{
"timePlayed": 83,
"timeJsonMade": 1662035655,
"gameName": "blocky-pushy",
"score": 1337
}

Oh and there is also a Big Obstacle which you need to use to push other obstacles.
