namespace Bowling.Frames {
    internal class TenPinFinalFrame : IBowlingFrame
    {
        public int[] Pins { get; set; }

        public int BallsThrown { get; set; }

        public IBowlingFrame NextFrame { get; }

        public const int MaxThrowsPerFrame = 3;

        private int maxThrows;

        private int highestPossibleNextThrow;

        public TenPinFinalFrame() {
            this.Pins = new int[MaxThrowsPerFrame];
            this.BallsThrown = 0;
            this.NextFrame = null;
            this.highestPossibleNextThrow = 10;
            this.maxThrows = 2; // start at 2 until a strike or spare is scored.
        }

        public bool IsFrameComplete() {
            return this.BallsThrown == this.maxThrows;
        }

        public void ThrowBall(int pins) {
            if (this.highestPossibleNextThrow < pins || pins < 0) {
                throw new ArgumentException("Number of pins knocked down is not possible.");
            }

            this.Pins[this.BallsThrown] = pins;
            this.BallsThrown++;
            this.highestPossibleNextThrow -= pins;

            if (this.highestPossibleNextThrow == 0) {
                this.maxThrows = 3;
                this.highestPossibleNextThrow = 10;
            }
        }
        public int FrameScore() {
            if (!this.IsFrameComplete()) {
                return 0;
            }

            int score = 0;
            if (this.Pins[0] == 10) {
                // strike in first throw
                if (this.BallsThrown == 3) {
                    score = this.Pins.Sum();
                } 
            } else if (this.Pins[0] + this.Pins[1] == 10) {
                // spare on second throw
                if (this.BallsThrown == 3) {
                    score = this.Pins.Sum();
                }
            } else {
                score = this.Pins.Sum();
            }

            return score;
        }
    }
}