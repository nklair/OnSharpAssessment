namespace Bowling.Frames {
    public interface IBowlingFrame {
        int[] Pins { get; }

        int BallsThrown { get; }

        IBowlingFrame NextFrame { get; }

        bool IsFrameComplete();

        void ThrowBall(int pins);

        int FrameScore();
    } 
}
