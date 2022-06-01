namespace Bowling.Frames {
    public interface IBowlingFrameFactory {
        IBowlingFrame CreateStandardFrame(IBowlingFrame nextFrame);

        IBowlingFrame CreateFinalFrame();
    }
}