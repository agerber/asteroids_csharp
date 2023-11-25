namespace DefaultNamespace
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

public class GamePanel : Panel
{
    private readonly Font fontNormal = new Font("SansSerif", FontStyle.Bold, 12);
    private readonly Font fontBig = new Font("SansSerif", FontStyle.Bold | FontStyle.Italic, 36);
    private FontMetrics fontMetrics;
    private int fontWidth;
    private int fontHeight;
    private readonly Point[] pntShipsRemaining;

    private Image imgOff;
    private Graphics grpOff;

    public GamePanel(Size dim)
    {
        GameFrame gameFrame = new GameFrame();
        gameFrame.Controls.Add(this);

        // Rest of the initialization and ship design
        // ...

        gameFrame.ClientSize = dim;
        gameFrame.Text = "Game Base";
        gameFrame.FormBorderStyle = FormBorderStyle.FixedDialog;
        gameFrame.MaximizeBox = false;
        gameFrame.ShowInTaskbar = false;
        gameFrame.StartPosition = FormStartPosition.CenterScreen;
        gameFrame.Visible = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        // Double-buffering logic
        // ...

        base.OnPaint(e);
    }

    // Methods for drawing game elements (moveDrawMovables, drawFalconStatus, etc.)
    // ...
}

// Other necessary classes (e.g., CommandCenter, Game, Utils, Movable) should be defined in your C# project.
