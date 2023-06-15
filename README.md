# Space-Crysis
A Game-Dev project of Astronaut and Survival.


![Alt text](Screenshot_2023-06-13_19-26-41.png)
![Alt text](Screenshot_2023-06-13_19-26-50.png)
![Alt text](Screenshot_2023-06-13_19-26-57.png)  
![Alt text](Screenshot_2023-06-13_19-27-26.png) 
![Alt text](Screenshot_2023-06-13_19-27-43.png) 
![Alt text](Screenshot_2023-06-13_19-28-08.png)
![Alt text](Screenshot_2023-06-13_19-28-36.png) 

# Play on itch.io
[Play](https://by-games.itch.io/space-crysis)

# Watch the trailer
[Space Crysis | Official Trailer
](https://www.youtube.com/watch?v=Rh7hFUMkDNg)


# Overview
Space Crysis is a puzzle game that tells the story of an astronaut who finds himself on a damaged spaceship that is about to crash. As he drifts through space, exhausted and with only a few tools at his disposal, he must use them wisely to navigate his way through the ship and reach the emergency switches before it's too late.

This game is a single-player platformer designed for players aged 7 and up with low to medium puzzle-solving skills.

# Objective
The objective of the game is to complete each level as quickly as possible while limited on recourses.

# How to Play
Drag your mouse on the screen to apply throwing force of your tools, use the right angle and power to make the most accurate moves.

# Features

- Multiple levels with increasing difficulty
- Puzzle game that requires the player to think strategically.
- The game will present prominent objects to assist the player.
- Learn how to play with ease thanks to our helpful tutorial.
- Never get stuck for long with the reload button that allows you to reset the level at any time.
- Receive helpful feedback every time you successfully complete a level!


# Code 

The game includes 11 scenes,1 Opening, 2 Tutorials, and 9-level scenarios.

* [AnstonautController](Assets/Scripts/AstronautController.cs) handles the movement mechanics of the astronaut. It captures the mouse position while pressed down to determine the range of the shot's swing. When the mouse press is released, the distance and direction are calculated and added to the Rigidbody force, which is then multiplied by a custom force adder chosen by the developer.


* In one of the levels, there is a pipe object that will push the player toward the end of the pipe, the pipe object contains a collider at the start point to detect collision and an end point for applying navigation. in [PipeThrower](Assets/Scripts/PipeThrower.cs), the OnCollisionEnter2D method will send the player to the end point of the pipe and add a force on the player's rigid body related to the relative velocity of the impact plus custom pipe property force set by the developer.

* In one of the levels, there is a saw object that poses a threat to the player. The saw can kill the player.

* Another level features electricity that can kill the player.

* One of the levels includes a black hole, which exerts a gravitational force on nearby objects. The black hole's influence affects the player and other interactable elements within its range. 

* Game Manager
The game employs a [GameManager.cs](https://github.com/BY-Games/Space-Crysis/blob/main/Assets/Scripts/Managers/GameManager.cs) script to detect and manage the state of the game. This script is responsible for overseeing game logic, such as tracking player progress, handling level transitions, and managing overall game flow.

* Level Manager
To facilitate level switching and progression, the game utilizes a [LevelManager.cs](https://github.com/BY-Games/Space-Crysis/blob/main/Assets/Scripts/Managers/LevelManager.cs) script. This script manages the loading and unloading of scenes, ensuring smooth transitions between levels and maintaining the appropriate sequence of gameplay.

* Sound Manager
The sound effects and audio elements in the game are controlled by a [SoundManager](https://github.com/BY-Games/Space-Crysis/blob/main/Assets/Scripts/Managers/SoundManager.cs) script. This script allows for the management and manipulation of various audio components, such as background music, sound effects, and ambient sounds, to enhance the overall gaming experience.


# Credits
Space Crysis Game was developed by [Yosef](https://github.com/YosefKahlon) and [Barak](https://github.com/barakdf).

# Editor version
2021.3.18f1

## Assets
- [2D Character - Astronaut](https://assetstore.unity.com/packages/2d/characters/2d-character-astronaut-182650)
- [Dotted Arrow](https://assetstore.unity.com/packages/tools/gui/dotted-arrow-213121)
- [Basic Icons](https://assetstore.unity.com/packages/2d/gui/icons/basic-icons-139575)
- [Lightning Bolt Effect for Unity](https://assetstore.unity.com/packages/tools/particles-effects/lightning-bolt-effect-for-unity-59471)

