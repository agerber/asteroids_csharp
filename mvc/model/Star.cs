namespace DefaultNamespace

using System.Drawing;
using System.Collections.Generic;

public class Star : Movable
{
    public Point Center { get; private set; }
    public Color Color { get; private set; }

    public Star()
    {
        // Center is some random point in the game space
        Center = new Point(Game.R.Next(Game.Dim.Width), Game.R.Next(Game.Dim.Height));
        int bright = Game.R.Next(226); // Stars are muted at max brightness of 225 out of 255
        Color = Color.FromArgb(bright, bright, bright); // Some grey value
    }

    public void Draw(Graphics g)
    {
        g.Color = Color;
        g.DrawEllipse(new Pen(Color), Center.X, Center.Y, GetRadius(), GetRadius());
    }

    public Point GetCenter()
    {
        return Center;
    }

    public int GetRadius()
    {
        return 1;
    }

    public Movable.Team GetTeam()
    {
        return Movable.Team.Debris;
    }

    public void Move()
    {
        // Do nothing
    }

    public void Add(LinkedList<Movable> list)
    {
        list.Add(this);
    }

    public void Remove(LinkedList<Movable> list)
    {
        list.Remove(this);
    }
}

// The Game class, along with its R (Random) and Dim (Dimension) fields, should be defined elsewhere in your C# project.
