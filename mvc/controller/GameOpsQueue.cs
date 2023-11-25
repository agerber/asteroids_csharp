namespace DefaultNamespace
using System.Collections.Concurrent;

public class GameOpsQueue
{
    private readonly ConcurrentQueue<GameOp> _queue = new ConcurrentQueue<GameOp>();

    public void Enqueue(Movable mov, GameOp.Action action)
    {
        _queue.Enqueue(new GameOp(mov, action));
    }

    public bool Dequeue(out GameOp gameOp)
    {
        return _queue.TryDequeue(out gameOp);
    }
}

// The GameOp and Movable classes should be defined as per your project's requirements.
