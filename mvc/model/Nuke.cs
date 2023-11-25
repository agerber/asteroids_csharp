namespace DefaultNamespace
using System;
using System.Collections.Generic;
using System.Drawing;

public class Nuke : Sprite
{
    private static readonly int Expire = 60;
    private int nukeState = 0;

    public Nuke(Falcon falcon)
    {
        Center = falcon.Center;
        Color = Color.Yellow;
        Expiry = Expire;
        Radius = 0;
        Team = Movable.Team.Friend;

        const double FirePower = 11.0;
        double vectorX = Math.Cos(Math.ToRadians(falcon.Orientation)) * FirePower;
        double vectorY = Math.Sin(Math.ToRadians(falcon.Orientation)) * FirePower;

        DeltaX = falcon.DeltaX + vectorX;
        DeltaY = falcon.DeltaY + vectorY;
    }

    public override void Draw(Graphics g)
    {
        g.Color = Color;
        g.DrawEllipse(new Pen(Color), Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
    }

    public override void Move()
    {
        base.Move();
        if (Expiry % (Expire / 6) == 0) nukeState++;
        switch (nukeState)
        {
            case 0:
                Radius = 2;
                break;
            case 1:
            case 2:
            case 3:
                Radius += 8;
                break;
            case 4:
            case 5:
            default:
                Radius -= 11;
                break;
        }
    }

    public override void Add(LinkedList<Movable> list)
    {
        if (CommandCenter.Instance.Falcon.NukeMeter > 0)
        {
            list.Add(this);
            Sound.PlaySound("nuke.wav");
            CommandCenter.Instance.Falcon.NukeMeter = 0;
        }
    }

    public override void Remove(LinkedList<Movable> list)
    {
        if (Expiry == 0) list.Remove(this);
    }

    // Conversion of Math.toRadians is done inline as there's no direct method in C#
    // Other necessary methods and properties, like Math.ToRadians, should be defined in your C# project.
}

// Other necessary classes (e.g., Sprite, Movable, Falcon, CommandCenter, Sound) should be defined in your C# project.
