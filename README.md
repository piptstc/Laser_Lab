# Laser Lab

This is a simple laser puzzle game built in Unity. The goal of each level is to use a variety of board objects to redirect a laser around obstacles, adjust its color and power levels, and ultimately direct it into the appropriate receiver.

## Download & Testing

[Windows (Installer)](https://github.com/piptstc/Laser_Lab/raw/master/Builds/Full%20Game/Installer/Laser%20Lab%20-%20x86%20Setup.exe)

[Windows (Zip)](https://github.com/piptstc/Laser_Lab/raw/master/Builds/Full%20Game/Zipped/Laser%20Lab%20-%20Windows.zip)

[Mac (Zip)](https://github.com/piptstc/Laser_Lab/raw/master/Builds/Full%20Game/Zipped/Laser%20Lab%20-%20Mac.zip)

[Linux (Zip)](https://github.com/piptstc/Laser_Lab/raw/master/Builds/Full%20Game/Zipped/Laser%20Lab%20-%20Linux.zip)

To run the game on Windows, either download the zip version, extract all the files into a folder, and run "Laser Lab.exe", or download the installer version and run the installer. 

To run the game on Mac, download the Mac zip file and unzip it, then open "Laser Lab - Mac.app".

To run the game on Linux, download the Linux zip file and unzip it, then open "Laser Lab - Linux.x86_64".

## Current Game State

As of 4/10/20, the project has been marked complete. A game demo has also been made available, and the finalized project is available on [itch.io](https://mantisstudios.itch.io/laser-lab) as well.

In each level, the user is shown a board with at least one laser and at least one receiver. The aim of the game is to direct the laser to the receiver using the variety of board pieces the user has at their disposal. 

Simple pieces, such as one sided mirrors, two sided mirrors, blocks, and tiles all do as expected. 

![Simple Game Pieces](https://user-images.githubusercontent.com/61722674/78993023-c26c7a80-7b0a-11ea-9946-7b14bdded106.PNG)

More complex pieces, such as prisms, two way mirrors, one way mirrors, and diffraction grids help the user to split up the power or colors of the laser, should the receiver have special requirements it needs met.

![Complex Game Pieces](https://user-images.githubusercontent.com/61722674/78993073-e465fd00-7b0a-11ea-945b-bd135a2ad1c0.PNG)

Depending on the level, pieces can be restricted by only allowing certain forms of user interraction, such as limitations on movement and rotation. Pieces can also be set to already be placed upon level load-in, creating obstacles for the user.


## Built With

* Unity 2019.3.1

## Authors

* **Max Allen** - *GUI, laser scripts, level system, game management, 3D art, music* - [mjbgtaad56](https://github.com/mjbgtaad56)
* **Olivia Jacques-Baker** - *board and wall object scripts, level design, 2D art* - [piptstc](https://github.com/piptstc)

## Acknowledgments

* Project inspired by the boardgame Laser Maze from MindWare.
