# AstroiderProject
AstroidShooter Assignment

## The DOTS and hardware aware part

The code uses DOTS via the Jobs system to multithread physics. This utilizes more of the computers CPU by using multiple threads, as normal Unity is single threaded.

## The performace improvement based on observation part

The naive version ran terribly at 5000 bullets, with 16 000ms per frame. Most of the time was spent on physics, which i managed to improve by turning on multithreaded physics.
It made it run at ca 3000ms per frame.

I added the enemies and changed them to a pooling system. So instead of instantiating all the enemies eatch time they spawn, i instead deactivate them and reactivate them when needed.
This lowered enemy spawn time from 133ms due to instantiation, to 26ms. The higher spawn time still happened at game start, but if the game progresses to 5000 enemies naturally, it wouldnt due to only one enemy instatiating eatch round.

I did also slightly increase the fixed time step slightly from 0.02 to 0.03 for a slight boost in speed overall. This did however not decrease the still prevelant physics peaks due to the mass amount of circle colliders existing.

Therefor i removed the circle colliders completly from the enemies and instead did a distance check on the bullet and enemies.
This let me go to 200 fps with 5000 enemies, and around 120-80fps when a bullet was colliding with enemies.

Due to the code always checking all the enemies per bullet, it meant that bullets became immensly expensive. I solved this by only checking collisions when it could possibly be close enough to any bullet.
I also did various other improvements to the bullet checking code which netted me a 2ms improvement for eatch bullet.

The last improvement was to remove interpolate from the enemies. This removed 9ms from the physics loop at 15000 enemies.

The total framerate with 5000 enemies became around 250 - 190 fps.

The Unity garbage collector never caused any performance problems for me, so I didnt change any code to improve it.
While alot of my data was stored on the heap, i rarely if ever, removed references and such. This is most likely why the garbage collector never was an issue due to it not having alot of garbage to collect.

Note: In my testing and such i started by testing the bullets and later switched to the enemies. This is because they are easier to improve and are more likely to actually end up at an unresonable number.
My bullet code although ending up making the performance worse for them, is a valuable tradeoff due to enemies being the bigger problem, and that it's hard/impossible to spawn enough to make a significant performance problem.


## Final thougths part

If i had more time i'd most likely learnt to use entities and jobs with the burst compiler to better improve my bullet checking code, as multithreading that would have been a huge performance improvement.


Also, in your grading, please include how much you liked my homemade assets <3
