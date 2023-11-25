namespace DefaultNamespace
using System.Drawing;
using System.Collections.Generic;

public interface Movable
{
    enum Team { Friend, Foe, Floater, Debris }

    // For the game to move and draw movable objects.
    void Move();
    void Draw(Graphics g);

    // For collision detection
    Point GetCenter();
    int GetRadius();
    Team GetTeam();

    // Callbacks which occur before or after this object is added or removed from the game-space.
    void Add(LinkedList<Movable> list);
    void Remove(LinkedList<Movable> list);
}
