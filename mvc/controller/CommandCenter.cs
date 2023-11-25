namespace DefaultNamespace
using System.Collections.Generic;

public class CommandCenter
{
    public int NumFalcons { get; set; }
    public int Level { get; set; }
    public long Score { get; set; }
    public bool Paused { get; set; }
    public bool Muted { get; set; }

    public long Frame { get; private set; } // Only a getter for Frame, as it's incremented internally

    // Assuming Falcon and other types are defined elsewhere in your C# code
    public Falcon Falcon { get; } = new Falcon();

    public LinkedList<Movable> MovDebris { get; } = new LinkedList<Movable>();
    public LinkedList<Movable> MovFriends { get; } = new LinkedList<Movable>();
    public LinkedList<Movable> MovFoes { get; } = new LinkedList<Movable>();
    public LinkedList<Movable> MovFloaters { get; } = new LinkedList<Movable>();

    public GameOpsQueue OpsQueue { get; } = new GameOpsQueue();

    private static CommandCenter _instance;

    private CommandCenter() { }

    public static CommandCenter GetInstance()
    {
        if (_instance == null)
        {
            _instance = new CommandCenter();
        }
        return _instance;
    }

    public void InitGame()
    {
        ClearAll();
        GenerateStarField();
        Level = 0;
        Score = 0;
        Paused = false;
        NumFalcons = 4; // Assuming 4 as the starting number of falcons
        Falcon.DecrementFalconNumAndSpawn();
        OpsQueue.Enqueue(Falcon, GameOp.Action.Add);
    }

    private void GenerateStarField()
    {
        int count = 100;
        while (count-- > 0)
        {
            OpsQueue.Enqueue(new Star(), GameOp.Action.Add);
        }
    }

    public void IncrementFrame()
    {
        Frame = Frame < long.MaxValue ? Frame + 1 : 0;
    }

    private void ClearAll()
    {
        MovDebris.Clear();
        MovFriends.Clear();
        MovFoes.Clear();
        MovFloaters.Clear();
    }

    public bool IsGameOver()
    {
        return NumFalcons < 1;
    }
}

// Definitions for Movable, GameOpsQueue, Falcon, Star, GameOp, etc., need to be included or referenced.
