namespace DefaultNamespace
using System;
using System.Collections.Generic;
using System.Drawing;

public class ShieldFloater : Floater
{
    public static readonly int SpawnShieldFloater = Game.FramesPerSecond * 25;

    public ShieldFloater()
    {
        Color = Color.Cyan;
        Expiry = 260;
    }

    public override void Remove(LinkedList<Movable> list)
    {
        base.Remove(list);
        if (Expiry > 0)
        {
            Sound.PlaySound("shieldup.wav");
            CommandCenter.Instance.Falcon.Shield = Falcon.MaxShield;
        }
    }
}

// Other necessary classes (e.g., Floater, CommandCenter, Game, Sound, Falcon) should be defined in your C# project.
