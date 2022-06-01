namespace Bowling.Game {
    using Bowling.Frames;
    public interface IBowlingGame {
        void ThrowBall(int pins);

        List<FrameInfo> GetFrames();

        int GetCurrentScore();

        bool IsGameOver();
    }
}