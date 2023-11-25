namespace DefaultNamespace
using System;
using System.Collections.Generic;
using System.Drawing;

public class NukeFloater : Floater
{
    public static readonly int SpawnNukeFloater = Game.FramesPerSecond * 50;

    public NukeFloater()
    {
        Color = Color.Yellow;
        Expiry = 120;
    }

    public override void Remove(LinkedList<Movable> list)
    {
        base.Remove(list);
        if (Expiry > 0)
        {
            Sound.PlaySound("nuke-up.wav");
            CommandCenter.Instance.Falcon.NukeMeter = Falcon.MaxNuke;
        }
    }
}

// Other necessary classes (e.g., Floater, CommandCenter, Game, Sound, Falcon) should be defined in your C# project.
