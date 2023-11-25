namespace DefaultNamespace
{
    public class Game: Runnable, KeyListener
    {
        public static readonly Random R = new Random();

        public const int ANIMATION_DELAY = 40; // milliseconds between frames

        public const int FRAMES_PER_SECOND = 1000 / ANIMATION_DELAY;

        private readonly Thread animationThread;

        //key-codes
        private const int
            PAUSE = 80, // p key
            QUIT = 81, // q key
            LEFT = 37, // rotate left; left arrow
            RIGHT = 39, // rotate right; right arrow
            UP = 38, // thrust; up arrow
            START = 83, // s key
            FIRE = 32, // space key
            MUTE = 77, // m-key mute
            NUKE = 78; // n-key mute

        // for possible future use
        // HYPER = 68, // D key
        //ALIEN = 65; // A key
        // SPECIAL = 70; // fire special weapon;  F key

        private readonly Clip soundThrust;
        private readonly Clip soundBackground;
    }
    
    public Game()
    {
        gamePanel = new GamePanel(DIM);
        gamePanel.AddKeyListener(this); //Game object implements KeyListener
        soundThrust = Sound.ClipForLoopFactory("whitenoise.wav");
        soundBackground = Sound.ClipForLoopFactory("music-background.wav");

        //fire up the animation thread
        animationThread = new Thread(this); // pass the animation thread a runnable object, the Game object
        animationThread.IsBackground = true;
        animationThread.Start();
    }
    
    // Run method
    private void Run()
    {
        // Animation logic
        while (Thread.CurrentThread == animationThread)
        {
            // Game logic
            // Sleep logic
        }
    }

    // Key event handling
    protected override void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);
        int keyCode = e.KeyValue;

        // Key handling logic
    }

    protected override void OnKeyUp(KeyEventArgs e)
    {
        base.OnKeyUp(e);
        int keyCode = e.KeyValue;

        // Key handling logic
    }

    // Main method
    [STAThread]
    public static void Main()
    {
        Application.Run(new Game());
    }
}