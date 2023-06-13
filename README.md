# Space-Crisis
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




# Overview
Space Crisis is a puzzle game that tells the story of an astronaut who finds himself on a damaged spaceship that is about to crash. As he drifts through space, exhausted and with only a few tools at his disposal, he must use them wisely to navigate his way through the ship and reach the emergency switches before it's too late.

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

The game includes 4 scenes, 2 Tutorial, and 2 level scenarios.

[AnstonautController](Assets/Scripts/AstronautController.cs) Handle the movement mechanic of the astronaut, capture the mouse position while pressed down to determine the range of the swing of the shot. when the mouse press has released the distance and direction will be calculated and added to the Rigidbody-force multiplied by the custom force adder from the developer's choice.


In level 1, there is a pipe object that will push the player toward the end of the pipe, the pipe object contain collider at the start point to detect collision and an end point for applying navigation. in [PipeThrower](Assets/Scripts/PipeThrower.cs), the OnCollisionEnter2D method will send the player to the end point of the pipe and add a force on the player's rigid body related to the relative velocity of the impact plus custom pipe property force set by the developer.



# Credits
Space Crisis Game was developed by [Yosef](https://github.com/YosefKahlon) and [Barak](https://github.com/barakdf).

## Assets
- [2D Character - Astronaut](https://assetstore.unity.com/packages/2d/characters/2d-character-astronaut-182650)
- [Dotted Arrow](https://assetstore.unity.com/packages/tools/gui/dotted-arrow-213121)
- [Basic Icons](https://assetstore.unity.com/packages/2d/gui/icons/basic-icons-139575)

