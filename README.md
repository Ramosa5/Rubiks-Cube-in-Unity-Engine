# Rubiks Cube in Unity
A Rubiks Cube created in Unity Engine using c#

## Overview
The app allows users to play with a Rubiks Cube. Click and drag your mouse to move cube's sides. Use arrows to rotate the cube. Press R to undo your move. After finishing your scramble you can view the whole process by pressing E button. A and D keys control the moves history.

<p align="center">
  <img src="https://github.com/Ramosa5/Rubiks-Cube-in-Unity-Engine/assets/108287744/1b6752c1-ff99-43f9-beae-9461eff46337" width="400" alt="App view">
</p>

## Features
- A unity app symulating a Rubiks cube
- Undoing moves and saving playing history
- Precise and intuitive cube control with mouse and keyboard

<p align="center">
  <img src="https://github.com/Ramosa5/Rubiks-Cube-in-Unity-Engine/assets/108287744/1a0d25f2-7651-43fc-9b82-51a7a92ed762" width="400" alt="Sample move">
</p>

## How it works
The cube consists of 26 smaller cubes. Moving side of the cube merges 9 small cubes for the move duration. To make the moves feel smoother after releasing mouse1 button the move is cut and the angle is rounded to the closest iteration of 90 degrees.

<p align="center">
  <img src="https://github.com/Ramosa5/Rubiks-Cube-in-Unity-Engine/assets/108287744/13d410d3-ad8b-4e3c-be4c-b20b85bc4dd1" width="400" alt="Sample code">
</p>

To undo the move moves history is checked and the opposite move is applied to the cube. The cube is again set to move freely afterwards.

<p align="center">
  <img src="https://github.com/Ramosa5/Rubiks-Cube-in-Unity-Engine/assets/108287744/450ae67c-bc2d-4662-87ef-d9f3f7ad3f1b" width="400" alt="Sample code">
</p>
