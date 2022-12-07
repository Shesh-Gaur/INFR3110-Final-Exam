# INFR3110-Final-Exam
Win Condition: Get all 4 pellets

Lose Condition: Touch a Ghost

Controls: WASD to Move, [I] to add ghost, [O] to remove ghost



Object Pooling Explanation:
To begin, I created a class called GhostPooling. It has a list of GameObjects called Pool, as well as the number of ghosts to be created, and the prefab for a ghost. On Start(), it creates defined number of objects, adds them to the pool, and deactivates them.
There's a function called CreateGhost(), which looks for a object in the pool that's deactivated, activates it, and returns it to the client. If there are no deactivated objects available, It'll create a new one, and add it to the pool. There's also RemoveGhost(), which simply looks for an activated object in the pool, and deactivates it. You can also use [I] to add ghosts and [O] to remove ghosts to test it out.


Overall Object Pooling here can help when it comes to memory allocation. If you were to just spawn objects and remove ghosts constantly, you would be performing unnecessary memory allocation / deallocation. By creating all the objects at the beginning, and pre-allocating the memory upfront, you can dramatically reduce the amount of activity in memory, which can significantly improve performance.

Here's Before Object Pooling: (images on canvas)
Here, you can see that object count is 5.78k, with 503mb in memory.

Here's After Object Pooling (with 1000 objects pooled):
In Comparison, you can see there are 11.39k object count, with around the same total memory usage.

Game Manager Explanation:
Note: Since I created my project from scratch, I am not implementing this question. If I were to implement it, here's how I would do it:

I would have implemented a game manager class. This would be a singleton class (would have a static reference to an instance), with functions like GameOver() and Win(). It would primarily handle playing these sequences when called, as well as containing a timer for the game, and the total score (with their own corresponding functions). Since this is a singleton, it can be called from any class in the game allowing for easy access, and removing the need to constantly find a Game Manager instance from the player and pellet classes. This manager class would also help decouple classes from each other, and keep things organized. For example, I currently have functions like GameOver() in the player class, but continuing implementation here is both messy, and means that if any object in the world wants to cause a GameOver(), they need a reference to the player.
