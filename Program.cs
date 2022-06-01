namespace Bowling
{
    using System;
    using Bowling.Frames;
    using Bowling.Game;
    using Bowling.UI;

    internal class Program
    {
        static void Main(string[] args)
        {
            IBowlingFrameFactory frameFactory = new TenPinFrameFactory();
            IBowlingGameFactory gameFactory = new StandardGameFactory(frameFactory);

            IBowlingGame game = gameFactory.CreateGame();
            ConsoleUI ui = new ConsoleUI(game);
            ui.PlayGame();
        }
    }
}