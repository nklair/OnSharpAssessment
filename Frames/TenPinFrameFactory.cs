namespace Bowling.Frames {
    internal class TenPinFrameFactory : IBowlingFrameFactory {
        public IBowlingFrame CreateStandardFrame(IBowlingFrame nextFrame) {
            return new TenPinFrame(nextFrame);
        }

        public IBowlingFrame CreateFinalFrame() {
            return new TenPinFinalFrame();
        }
    }
}