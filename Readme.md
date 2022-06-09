# Run Rat Run

A simple implemenation of a runner combined with platformer mechanics

<p align="center">
  <img src="/GithubMedia/banner.jpg" alt="Rat Platformer">
</p>

## Description

This repository contains all scripts wrote on a C# for the game "Run Rat Run". This game was created for publishing on [Yandex.Games], you can try it there.
In creation of this game there was not any aim to reach, or to write a good solution. It was created just for fun. On this page you can read about different aspects 
of this game.

## Development

Firstly, this project was a concept consisted of a bunch of sprites. That concept was made by my girlfriend as a study project in animation:

<p align="center">
  <img src="/GithubMedia/animation.gif" alt="Concept">
</p>

Then, we decided to turn her concept to a real game, and to publish it somewhere. So that's what we did.

## Repository information

You can find these following scripts:
* EnemyController.cs
This script handles enemy behavior. And also health points, by getting info from "HitCheck.cs".
* HitCheck.cs
This script manages collision between player and 2D collider on the enemy body.
* MiniLevelsHandler.cs
MiniLevelsHandler spawns obstacles, from premade array.
* MoveObjects.cs
This script moves gameobjects in disired direction, and also it handles basic animation.
* PlayerController.cs
Allows player to controll the character, and also serves getting damage logic.
* ScrollingBackground.cs
Like as mentioned "MoveObjects", this script moves objects in desired direction, but doesn't serve any animation logic.

## Links

[Yandex.Games] [Telegram] [Youtube]

[Youtube]: https://www.youtube.com/channel/UC3kV-wnqBE3Y2tdtdSrjvGQ
[Telegram]: https://t.me/exeersitus
[Yandex.Games]: https://yandex.ru/games/developer?name=HZG

