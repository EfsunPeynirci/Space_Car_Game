# Space Car Game 🚀

**Space Car Game** is a mobile arcade game developed using Unity and C#. Players control a spaceship, shoot incoming enemies, and avoid collisions. This project was created during the Udemy course *"Mobile Game Development: Unity Essentials"* by **Yücel Bayram**.

---

## Features 🕹️

- **Start Menu**: Displays `SCORE`, `HIGH SCORE`, and a "Start" button.
- **Spaceship Movement**: Move left or right using touch or mouse input.
- **Enemy Spawning**: Enemies spawn dynamically and move toward the player.
- **Shooting**: The spaceship fires bullets automatically.
- **Game Over**: Restart the game when the spaceship collides with an enemy.
- **Scoring System**: Earn points for destroying enemies; `HIGH SCORE` is saved.

---

## Technologies 🛠️

- **Unity**: Game development platform.
- **C#**: For game mechanics.
- **PlayerPrefs**: For saving high scores.
- **Singleton Pattern**: To manage game states.

---

## Space Car Game - Live Demo 🎮

https://github.com/user-attachments/assets/ba965ebd-06b3-40f6-a0c6-0a0a087dc3f2

---

## Screenshots 📸

![1](https://github.com/user-attachments/assets/e17ed7f4-03fa-43cd-b289-727dedc110e9)

![2](https://github.com/user-attachments/assets/d4a10445-6b19-4287-8f62-2c8d569b6679)

![3](https://github.com/user-attachments/assets/6a935376-0b5e-4346-87d1-31e4d4e7c7ce)

---

## Scripts 📜

- **EnemyController.cs**:
  Manages enemy ship movement, collision handling, and destruction. Increases the score when enemies are hit by bullets and triggers game over if the player's spaceship collides with an enemy.
- **EnemySpawnerController.cs**:
  Controls the spawning of enemy ships at random positions using predefined spawn points. Uses coroutines to spawn enemies at regular intervals and manages the start/stop of enemy creation during gameplay.
- **GameManager.cs**:
  Manages the overall game flow, including starting, restarting, and ending the game. Tracks the player's score, updates the high score, and controls the visibility of UI panels like the start menu and fail menu.
- **SpaceShipController.cs**:
  Handles the movement of the player's spaceship, restricting it within defined boundaries. Manages the shooting mechanism, allowing the spaceship to fire bullets at regular intervals.

---

## Course 🎓

Developed as part of the Udemy course:  
*"Mobile Game Development: Unity Essentials"* by **Yücel Bayram**.
