namespace DefaultNamespace
public class GameOp
{
    // Enum definition is similar in C#
    public enum Action
    {
        Add, Remove
    }

    // Properties for Movable and Action
    public Movable Movable { get; set; }
    public Action Action { get; set; }

    // All-arguments constructor
    public GameOp(Movable movable, Action action)
    {
        Movable = movable;
        Action = action;
    }
}

// Assuming Movable is defined elsewhere in your C# code.
