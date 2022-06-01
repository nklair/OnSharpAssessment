namespace Bowling.Game {

    using Bowling.Frames;

    internal class TenPinGame : IBowlingGame {

        private IBowlingFrame frames;

        private IBowlingFrame currentFrame;
        public TenPinGame (IBowlingFrame headFrame) {
            this.frames = headFrame;
            this.currentFrame = headFrame;
        }

        public void ThrowBall(int pins) {
            if (this.currentFrame == null) {
                Console.WriteLine("The game is over");
                return;
            }
            this.currentFrame.ThrowBall(pins);
            if (this.currentFrame.IsFrameComplete()) {
                this.currentFrame = this.currentFrame.NextFrame;
            }
        }

        public List<FrameInfo> GetFrames() {
            List<FrameInfo> frames = new List<FrameInfo>();
            IBowlingFrame curr = this.frames;
            int sumScore = 0;
            while (curr != null) {
                sumScore += curr.FrameScore();
                frames.Add(new FrameInfo() {
                    Pins = curr.Pins.ToList(),
                    CumulativeScore = curr.IsFrameComplete() ? sumScore : 0,
                    FrameScore = curr.FrameScore()
                });    
                curr = curr.NextFrame;
            }
            return frames;
        }

        public int GetCurrentScore() {
            int score = 0;
            IBowlingFrame curr = this.frames;
            while (curr != null) {
                score += curr.FrameScore();
                curr = curr.NextFrame;
            }

            return score;
        }

        public bool IsGameOver() {
            return this.currentFrame == null;
        }
    }
}