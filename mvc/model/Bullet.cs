namespace DefaultNamespace
using System;
using System.Collections.Generic;
using System.Drawing;

public class Bullet : Sprite
{
    public Bullet(Falcon falcon)
    {
        Team = Movable.Team.Friend;
        Color = Color.Orange;
        Expiry = 20;
        Radius = 6;

        Center = falcon.Center;
        Orientation = falcon.Orientation;

        const double FirePower = 35.0;
        double vectorX = Math.Cos(Math.toRadians(Orientation)) * FirePower;
        double vectorY = Math.Sin(Math.toRadians(Orientation)) * FirePower;

        DeltaX = falcon.DeltaX + vectorX;
        DeltaY = falcon.DeltaY + vectorY;

        const double KickBackDivisor = 36.0;
        falcon.DeltaX -= vectorX / KickBackDivisor;
        falcon.DeltaY -= vectorY / KickBackDivisor;

        var listPoints = new List<Point>
        {
            new Point(0, 3), // Top point
            new Point(1, -1), // Right bottom
            new Point(0, 0),
            new Point(-1, -1) // Left bottom
        };

        Cartesians = listPoints.ToArray();
    }

    public override void Draw(Graphics g)
    {
        RenderVector(g);
    }

    public override void Add(LinkedList<Movable> list)
    {
        base.Add(list);
        Sound.PlaySound("thump.wav");
    }
}

// Other necessary classes (e.g., Sprite, Movable, Falcon, Sound) should be defined in your C# project.
