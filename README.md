Homework 3 – Team 5 Game Development CSC 631 Professor – Omar Shaikh

Group Members

Cynthia Chao Jeffrey Ilar Kendrick Kwok

Instructions :

The object of the game is to kill two girls and one giant girl. There is music and five animations: Running, Idle, Attacking, Dying, and Winning. You can move the camera using WASD keys.  If it stops, you would have to click the player and click on any part of the map to make it move. You cannot go through the mountains because of Navmesh and Navmesh Agent. Follow the dirt path to find the location of the three girls to kill. The enemy only moves when the player is in range of detection, and you can only do damage when you are close to the enemy. To do damage, click on the enemy after selecting the player once they are close!  Once all the girls are all killed you win the game. 

#HW3 (team project)

##3D Real time strategy game

You will be building a simple 3D Real time strategy game. Think of games like 'Age of Empires', 'Command & Conquer', 'Starcraft' etc.

Theme

You can decide on the theme of the game. Which means all the content such as type of terrain, player models, AI assets and other assets can be based on the theme. Don't randomly add meaningless assets.

####Terrain:

Sufficiently large for a few minutes of gameplay
Has terrain specific details such as trees,(other asset items based on your theme; Get creative!).
Use Navmesh for AI/Player movements.
Has hilly areas(the navmesh will take care of navigation).
You can optionally use the terrain from HW1.
The terrain should be complex enough so that Navmesh navigation is obvious(Look at the link on Navmesh).
####Functionality:

The user shall be able to click on the player and select it.
The user shall be able to click on a location on the map. If the player was selected, then the player will start moving towards that location.
AI characters in the scene will start chasing the player(using the navmesh).
The player health will detoriate when close to the AI enemy.
The player can be instructed to attack a specific enemy.
There will be multiple AI components.
Basic assignment requires only two animations for the player. Enemy AI animation will be extra credit.
Try to use 3D assets that come packaged with Animations.
####Camera

Movement in the XZ plane (y is global up in unity).
Sufficient distance above the terrain.
Movement controlled by w a s d keys
####Mouse

Use raycasts for detecting mouse clicks.
Once the character is selected, the user can use the mouse to click a point in the terrain for the character to start moving towards it.
The user can also use the mouse to start attacking an enemy
####Player(main character)

There needs to be atleast two Animations for the character(example: idle and walking)
Extra credit:

Advanced and smoother camera movements (could use Lerp)
More than 2 animations for the player and the AI characters.(idle, walking, attacking,etc)
Rich and detailed terrain.
More functionality than originally required.
Grading Rubric:

Is the game fun to play
Does the game run properly and does not have bugs
Does the game look good.
Extra credit: (Look at the extra credit section in the description above.)
Relevant links

Unity Navigation docs: https://docs.unity3d.com/Manual/Navigation.html
Unity Navmesh(part of the link above):
Lerp: https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html
Raycasts: https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
Notes

Post questions on Piazza if you have any. This class encourages collaboration and discussions.
Never copy-paste code.
If you do use open-source code, make sure you mention it at the bottom of this README.
If you want to add external notes(aside from comments in code), then just add it into this readme. The staff may not be able to find any other text files in your project.
Also start thinking about the flexible project(that will be the final/last project).
