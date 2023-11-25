namespace DefaultNamespace
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

public class Falcon : Sprite
{
    // Static fields
    public static readonly int TurnStep = 11;
    public static readonly int InitialSpawnTime = 46;
    public static readonly int MaxShield = 200;
    public static readonly int MaxNuke = 600;
    public static readonly int MinRadius = 28;

    // Image states
    public enum ImageState
    {
        FalconInvisible,
        Falcon,
        FalconThr,
        FalconPro,
        FalconProThr
    }

    // Instance fields
    public int Shield { get; set; }
    public int NukeMeter { get; set; }
    public int Invisible { get; set; }
    public bool MaxSpeedAttained { get; set; }
    public int ShowLevel { get; set; }
    public bool Thrusting { get; set; }
    public TurnState TurnState { get; set; } = TurnState.Idle;

    // Constructor
    public Falcon()
    {
        Team = Movable.Team.Friend;
        Radius = MinRadius;

        // Load images and set up rasterMap
        RasterMap = new Dictionary<ImageState, Bitmap>();
        // Load images using LoadGraphic method
        // RasterMap[ImageState.FalconInvisible] = null;
        // RasterMap[ImageState.Falcon] = LoadGraphic("path_to_falcon_image");
        // ...
    }

    public override void Move()
    {
        // Movement logic
    }

    public override void Draw(Graphics g)
    {
        // Drawing logic
    }

    private void DrawShield(Graphics g)
    {
        // Shield drawing logic
    }

    public override void Remove(LinkedList<Movable> list)
    {
        // Removal logic
    }

    public void DecrementFalconNumAndSpawn()
    {
        // Decrement number of falcons and spawn logic
    }

    // Other methods as required

    // Enum for turn state
    public enum TurnState
    {
        Idle, Left, Right
    }

    // LoadGraphic method and other utility methods
    // ...
}

// Other necessary classes and enums (e.g., Movable, Game, Sound) should be defined in your C# project.
