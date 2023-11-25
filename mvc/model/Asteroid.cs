namespace DefaultNamespace
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

public class Asteroid : Sprite
{
    private static readonly int LargeRadius = 110;

    public Asteroid(int size)
    {
        Radius = size == 0 ? LargeRadius : LargeRadius / (size * 2);
        Team = Movable.Team.Foe;
        Color = Color.White;
        Spin = SomePosNegValue(10);
        DeltaX = SomePosNegValue(10);
        DeltaY = SomePosNegValue(10);
        Cartesians = GenerateVertices();
    }

    public Asteroid(Asteroid explodedAsteroid) : this(explodedAsteroid.GetSize() + 1)
    {
        Center = explodedAsteroid.Center;
        int newSmallerSize = explodedAsteroid.GetSize() + 1;
        DeltaX = explodedAsteroid.DeltaX / 1.5 + SomePosNegValue(5 + newSmallerSize * 2);
        DeltaY = explodedAsteroid.DeltaY / 1.5 + SomePosNegValue(5 + newSmallerSize * 2);
    }

    public int GetSize()
    {
        return Radius switch
        {
            LargeRadius => 0,
            LargeRadius / 2 => 1,
            LargeRadius / 4 => 2,
            _ => 0
        };
    }

    private Point[] GenerateVertices()
    {
        const int maxRadiansX1000 = 6283;
        const double precision = 100.0;
        Random r = Game.R;
        int vertices = r.Next(7) + 25;

        return Enumerable.Range(0, vertices)
            .Select(_ => new PolarPoint((800 + r.Next(200)) / 1000.0, r.Next(maxRadiansX1000) / 1000.0))
            .OrderBy(pp => pp.Theta)
            .Select(pp => new Point((int)(pp.R * precision * Math.Sin(pp.Theta)), 
                                    (int)(pp.R * precision * Math.Cos(pp.Theta))))
            .ToArray();
    }

    public override void Draw(Graphics g)
    {
        RenderVector(g);
    }

    public override void Remove(LinkedList<Movable> list)
    {
        base.Remove(list);
        SpawnSmallerAsteroidsOrDebris(this);
        CommandCenter.Instance.Score += 10L * (GetSize() + 1);
        Sound.PlaySound("kapow.wav");
    }

    private void SpawnSmallerAsteroidsOrDebris(Asteroid originalAsteroid)
    {
        // Implementation of spawning logic
    }
}

// Other necessary classes, such as Movable, Sprite, CommandCenter, Game, Sound, and PolarPoint, should be defined in your C# project.
