# About this test

This is a submission for Metaverse VR, where a Unity project has been created in the folder "Jonathan Byrne - Metaverse VR Test" which contains the following: a scene with a skybox, directional lighting, a bloom post processing effect and a water shader. 
A player boat has been created that has acceleration, deceleration and steering inertia. Sunseeker boats have been implemented and their paths have been created through the use of Bezier Curves. Collisions between the player, sunseekers and island have been established.
Static wall objects have also been created to contain the play area, with collisions also implemented. There is an objective zone marked for the player to dock and the player must dock portside to successfully pass the simulation. A third person perspective is used.

<br>Unity packages used: Cinemachine, Post Processing, Universal Rendering Pipeline, Input System, TextMeshPro
<br>Unity version used: Unity 2021.3.45f1 LTS

# Build

This project also contains a build which runs in Windows. The build is found in the releases section of the repo, where a zip file can be downloaded that contains the executable. The player can use WASD or the arrow keys to move the boat. Pressing W will ensure that the camera shows the player what is in front of them whilst
pressing S switches the camera so that the player can see behind them when reversing. Acceleration and deceleration occurs when pressing W/S/Up Arrow/Down Arrow, whilst turning is implemented by pressing A/D/Left Arrow/Right Arrow whilst accelerating or decelerating. The scene can be reset if the boat has capsized by 
pressing R and the application can be exited by pressing ESC. On completion of the game a UI panel will display with a button to reset the game, this button can be pressed using the mouse.

# Guidance

C# files are commented and any tutorial videos followed are listed in the comments.
