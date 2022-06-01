namespace Bowling.Frames {
    internal class TenPinFrame : IBowlingFrame
    {
        public int[] Pins { get; set; }

        public int BallsThrown { get; set; }

        public IBowlingFrame NextFrame { get; set;}

        public const int MaxPinsPerFrame = 10;

        public const int MaxThrowsPerFrame = 2;

        public TenPinFrame(IBowlingFrame next) {
            this.Pins = new int[MaxThrowsPerFrame];
            this.BallsThrown = 0;
            this.NextFrame = next;
        }

        public bool IsFrameComplete() {
            return this.Pins.Sum() == MaxPinsPerFrame || this.BallsThrown == MaxThrowsPerFrame;
        }

        public void ThrowBall(int pins) {
            if (this.Pins.Sum() + pins > MaxPinsPerFrame || pins < 0) {
                throw new ArgumentException("Number of pins knocked down is not possible.");
            }

            this.Pins[this.BallsThrown] = pins;
            this.BallsThrown++;
        }

        public int FrameScore() {
            if (!this.IsFrameComplete()) {
                return 0;
            }
            
            int sum = this.Pins.Sum();
            int score = 0;
            if (this.Pins[0] == MaxPinsPerFrame) {
                // Strike
                int ballsToScore = 2;
                int strikeScore = MaxPinsPerFrame;
                IBowlingFrame next = this.NextFrame;
                while (next != null && ballsToScore > 0) {
                    for (int i = 0; i < next.BallsThrown; i++) {
                        strikeScore += next.Pins[i];
                        ballsToScore--;
                        if (ballsToScore <= 0) {
                            score = strikeScore;
                            break;
                        }
                    }
                    next = next.NextFrame;
                }
            } else if (sum == MaxPinsPerFrame) {
                // Spare
                int ballsToScore = 1;
                int spareScore = MaxPinsPerFrame;
                IBowlingFrame next = this.NextFrame;
                while (next != null && ballsToScore > 0) {
                    for (int i = 0; i < next.BallsThrown; i++) {
                        spareScore += next.Pins[i];
                        ballsToScore--;
                        if (ballsToScore <= 0) {
                            score = spareScore;
                            break;
                        }
                    }
                    next = next.NextFrame;
                }
            } else {
                // Open Frame
                score = sum;
            }

            return score;
        }
    }
}