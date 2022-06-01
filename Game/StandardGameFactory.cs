namespace Bowling.Game {
    using Bowling.Frames;

    internal class StandardGameFactory : IBowlingGameFactory {

        private IBowlingFrameFactory frameFactory;

        public StandardGameFactory(IBowlingFrameFactory frameFactory) {
            this.frameFactory = frameFactory;
        }

        public IBowlingGame CreateGame() {
            // A standard game has 10 frames, 9 of the same frames followed by one final frame.
            IBowlingFrame frame10 = this.frameFactory.CreateFinalFrame();
            IBowlingFrame frame9 = this.frameFactory.CreateStandardFrame(frame10);
            IBowlingFrame frame8 = this.frameFactory.CreateStandardFrame(frame9);
            IBowlingFrame frame7 = this.frameFactory.CreateStandardFrame(frame8);
            IBowlingFrame frame6 = this.frameFactory.CreateStandardFrame(frame7);
            IBowlingFrame frame5 = this.frameFactory.CreateStandardFrame(frame6);
            IBowlingFrame frame4 = this.frameFactory.CreateStandardFrame(frame5);
            IBowlingFrame frame3 = this.frameFactory.CreateStandardFrame(frame4);
            IBowlingFrame frame2 = this.frameFactory.CreateStandardFrame(frame3);
            IBowlingFrame frame1 = this.frameFactory.CreateStandardFrame(frame2);

            return new TenPinGame(frame1);
        }
    }
}