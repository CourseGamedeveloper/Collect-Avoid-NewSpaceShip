### About:
the space ship need to get score 100 to win the game,the space ship can take the red heart for healing 
### How to Play the Game:
Arrows-> Move the spaceShip

left click on mouse-> spaceship shoot laser

---
### How to run the code:
1. first do get clone for the code:https://github.com/CourseGamedeveloper/Collect-Avoid-NewSpaceShip.git
2. open the code in unity
3. open the Scene Game in the prject and click on buttom play
4. another opation to play the game in link below
---
### Summary of Classes in the Project:
1. PlayerController:

 This class manages the player's movement, health, and actions:

Responsibilities:

 Handles player movement using Unity's InputSystem.
 Tracks the player's health and allows healing or taking damage.
 Fires lasers upon user input (mouse click).
 Interacts with UI to update the health bar dynamically.

2. UIManager:

 The class responsible for managing the user interface elements:

Responsibilities:

 Displays the player's current score and updates it dynamically.
 Manages and updates the health bar.
 Listens for health and score changes using events.

3. Constants:

 Defines global constants used across the project:

 Responsibilities:

 Holds player movement speed and laser speed values.
 Simplifies adjusting gameplay parameters from one location.

4. Enemybase:

 Manages enemy interactions and behavior:

 Responsibilities:

 Handles collisions with the player or player's laser.
 Reduces player health upon collision and destroys itself upon interaction.
 Updates the player's score when destroyed by a laser.

5. SpwanManager:

 Controls the spawning of enemies:

 Responsibilities:

 Periodically spawns enemies at defined intervals.
 Limits the maximum number of enemies in the scene.
 Resets spawn timers after each spawn cycle.

6. GameManager:

 Handles the overall game logic and transitions:

 Responsibilities:
 
 Tracks player progress and checks for win or game-over conditions.
 Switches scenes based on game events like reaching a target score or health depletion.

7. CollectibleItem

 Manages collectible items like health power-ups:

 Responsibilities:

 Detects collisions with the player and applies healing effects.
 Destroys itself upon collection.

8. Laser:

Defines the behavior of lasers fired by the player:

Responsibilities:

Moves the laser upward at a predefined speed.
Deactivates itself upon leaving the screen boundaries.

9. PlayerSpawner
This class, PlayerSpawner, spawns a player character at a random position within a specified range when a new player joins the game, ensuring the local player spawns only once using Fusion's PlayerRef.
--- 
### UML Diagram:
![UML Diagram ](https://github.com/user-attachments/assets/401e171e-917e-4886-807f-b98560d4dead)

---
### Links:
Link to the game:https://ibrahem-hurani.itch.io/spaceship-multiplayer
