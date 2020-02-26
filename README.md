# Bollocks

A game where you play with balls to make profit.

## Build Info:

* The WebGL build is under /Builds/WebGL
* Link to Web deployment at https://ee.cooper.edu/~nakhimov/BollocksV1/
* All assets are under /Assets

Note: the folder ./Assets/Yapp is a script I download for painting prefabs. It
plays no role in the mechanics of the game but made placing the coins around
much easier.

## Controls/Gameplay:

Player 1 (blue) moves around with WSAD and jumps with spacebar.
Player 2 (red) moves around with arrow keys and jumps with the numpad 0.

The objective for each player is to get as many points as possible:
* +1 point per coin collected
* +4 points for jumping on other player
* -4 points for being jumped on by other player (can't go below 0)
* -1 point for touching the wall

The more points a player collects the larger their core grows and the faster
and higher they can jump. Once two minutes are over, no player can collect more
points but they can continue to move around, collect coins, and grow their
core, speed, and jump height. If at any point one of the players manages to
jump out of bounds of the walls, the other player and the walls are all
destroyed and the camera focuses on the escaped player. The escaped player can
use the controls of the other player to pan and tilt the camera and can zoom in
and out by scrolling (mouse or trackpad). The escaped player can then explore
the world and collect as many coins as he likes. Basically, if one escapes
before the two minute mark, they are almost gauranteed to win.

## Extra Credit and More
* The only announcment I have in the game is when the time runs out it shows
  Game Over.
* Multiplayer uses the same keyboard, I tested using a joystick as well but I
  wasn't sure how I wanted to implement camera zoom in a comfortable way so I
  didn't include joystick in the final build.
* I originally wanted to make a racing game so I included my race track as a
  surprise if one of the players jumps out of bounds. However, I didn't feel
  like messing with split screen functionality and I didn't want to make walls
  all along the racetrack for the players to bump into to lose points as I had
  already painted terrain and it would look weird.
