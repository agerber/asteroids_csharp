namespace DefaultNamespace
using System;
using System.Windows.Forms;
using System.Drawing;

public class GameFrame : Form
{
    private readonly TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();

    public GameFrame()
    {
        InitializeComponent();
    }

    // Component initialization
    private void InitializeComponent()
    {
        this.tableLayoutPanel.Dock = DockStyle.Fill;
        this.Controls.Add(this.tableLayoutPanel);

        this.Closing += new System.ComponentModel.CancelEventHandler(this.GameFrame_Closing);
    }

    // Overridden to handle the window closing event
    private void GameFrame_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        Application.Exit();
    }
}
