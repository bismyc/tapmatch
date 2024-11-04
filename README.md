**ReadMe**


**Tap Match**
- A game prototype made with Unity 6.

![tapmatch](https://github.com/user-attachments/assets/733c250c-64f1-4091-acc8-b5b03caa4cea)

by Bismy on November 04

The game can be played by tapping on any cell.  Different parameters of the game can easily be configured using Unity scriptable objects. See reference below.


<img width="351" alt="Screenshot 2024-11-03 at 20 28 21" src="https://github.com/user-attachments/assets/514e6351-d689-4ee7-8d4a-0a25b33d47f2">
<img width="350" alt="Screenshot 2024-11-03 at 20 26 51" src="https://github.com/user-attachments/assets/6a95ee09-89f1-4252-b2d2-27f1ed0ee263">


**- Game**

This is the main class that controls the game board overall flow. It creates the game board and reacts to user inputs by finding matches and changing the game board.


**- Board**

This maintains the list of cells in the game board in a 2D array data structure which is suitable to perform an efficient search function of neighboring cells. It also controls the destruction and creation of colored items in the cells. It uses object pooling technique to minimize the amount of game objects created in the game by reducing the load to the garbage collector.


**- CommandInvoker**

The game is using the command design pattern to schedule the falling action of items in the game board. This is excellent to keep track of different time bound animating actions taking place in the game. For example it can also help detect the stability (idle) of the game board by looking at the number pending commands at a certain time.


**- EventSystem**

This is a custom event system developed to ensure smooth communication flow that avoids unnecessary coupling between classes. It is used to listen to user inputs.


**- MatchFinder**

This using the BreadthFirstSearch searching algorithm to quickly find the matching items closed the cell that the user tapped. The 2D array represents a graph where each element is connected to 4 other elements. BFS is an efficient algorithm to traverse a graph data structure. 


**- RandomWeightedColor & Color Palette**

This is using the weighted random picker algorithm to pick a random color based on the weights assigned to it. This is good for adjusting the difficulty of a particular level by making some colors appear more often than others.

