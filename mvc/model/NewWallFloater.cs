namespace DefaultNamespace
using System;
using System.Collections.Generic;
using System.Drawing;

public class NewWallFloater : Floater
{
    private static readonly Color Maroon = Color.FromArgb(186, 0, 22);
    public static readonly int SpawnNewWallFloater = Game.FramesPerSecond * 40;

    public NewWallFloater()
    {
        Color = Maroon;
        Expiry = 230;
    }

    public override void Remove(LinkedList<Movable> list)
    {
        base.Remove(list);
        if (Expiry > 0)
        {
            Sound.PlaySound("insect.wav");
            BuildWall();
        }
    }

    private void BuildWall()
    {
        const int BrickSize = Game.Dim.Width / 30;
        const int Rows = 2;
        const int Cols = 20;
        const int XOffset = BrickSize * 5;
        const int YOffset = 50;

        for (int nCol = 0; nCol < Cols; nCol++)
        {
            for (int nRow = 0; nRow < Rows; nRow++)
            {
                var brick = new Brick(
                    new Point(nCol * BrickSize + XOffset, nRow * BrickSize + YOffset),
                    BrickSize);
                CommandCenter.Instance.OpsQueue.Enqueue(brick, GameOp.Action.Add);
            }
        }
    }
}

// Other necessary classes (e.g., Floater, Brick, Movable, CommandCenter, Game, Sound, GameOp) should be defined in your C# project.
