# 3D-Platformer

It's a platformer that I made with use of standard rigidbody capsule and 3rd person player view.

## Table of contents
  * [Guidelines](https://github.com/Minal06/3D-Platformer/tree/main#guidelines)
  * [Mechanics](https://github.com/Minal06/3D-Platformer/tree/main#mechanics)
  * [Gameplay](https://github.com/Minal06/3D-Platformer/tree/main#gameplay)
  * [Scripts](https://github.com/Minal06/3D-Platformer/tree/main#scripts)

### Guidelines
It should be a game prototype with basic Unity engine physics. 

It should have two towers with 4 levels each, between floors there should be obstacles, stairs, and moving platforms.

Player should move in all directions, could jump, and shoot some basic projectiles. 

When the game starts, Player starts on the ground level in front of two towers. They have to choose one and use elevator inside to go on a choosen floor.

After the obstacle course, in the end zone there is a shooting range for player.

In-game UI shows how many times player jumped, how many target did they shot, and the timer.


### Mechanics
Player can use wsad/arrow to move, space to jump, and shot by LMB.


### Gameplay
![prt](https://user-images.githubusercontent.com/94176489/178335252-6312f878-7904-4108-9057-95fa5346ddee.jpg)

![platf](https://user-images.githubusercontent.com/94176489/178338335-4eab49d1-89e3-4bfc-bcc6-acf3cfa42e97.gif)

![platf2](https://user-images.githubusercontent.com/94176489/178339474-96de6b08-63f6-4242-93b6-b36b2bdca53a.gif)

### Scripts
All the scripts can be found in Assets. 
Bullets shoot by player are spawned from *ObjectPooler* script, and the logic is hold by *BulletLogic* script.

*Elevator* script is responsible for chosen button and moving platform to selected floor.

All the interactions are made directly from *PlayerMovement* script.


