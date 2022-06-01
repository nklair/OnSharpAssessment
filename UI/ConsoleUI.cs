namespace Bowling.UI {
    using System.Linq;
    using Bowling.Frames;
    using Bowling.Game;

    public class ConsoleUI {
        private IBowlingGame game;

        public ConsoleUI(IBowlingGame game) {
            this.game = game;
        }

        public void PlayGame() {
            this.DisplayScore();
            while (!this.game.IsGameOver()) {
                Console.Write("Pins knocked down:");
                bool valid = false;
                while(!valid)
                try {
                    this.game.ThrowBall(Int32.Parse(Console.ReadLine()));
                    valid = true;
                }
                catch {
                    Console.Write("Invalid input, please enter the number of pins that were knocked down:");
                }
                
                this.DisplayScore();
            }
            Console.WriteLine($"Final Score: {game.GetCurrentScore()}. Press any button to exit.");
            Console.ReadLine();
        }

        private void DisplayScore() {
            Console.Clear();
            Console.WriteLine($"Current Game score: {this.game.GetCurrentScore()}");
            int length = 0;
            List<FrameInfo> frames = this.game.GetFrames();
            foreach(FrameInfo frame in frames) {
                length += frame.Pins.Count() * 2 + 2;
            }
            length++;

            for (int i = 0; i < length; i++) {
                Console.Write("_");
            }
            Console.WriteLine("");

            foreach (FrameInfo frame in frames) {
                List<string> asStrings = new List<string>();
                if (frame.Pins.Count() == 2) {
                    if (frame.Pins[0] == 10) {
                        asStrings.Add(" ");
                        asStrings.Add("X");
                    } else if (frame.Pins.Sum() == 10) {
                        asStrings.Add(frame.Pins[0].ToString());
                        asStrings.Add("/");
                    } else {
                        asStrings.Add(frame.Pins[0].ToString());
                        asStrings.Add(frame.Pins[1].ToString());
                    }
                } else {
                    for (int i = 0; i < frame.Pins.Count(); i++) {
                        if (frame.Pins[i] == 10) {
                            asStrings.Add("X");
                        } else if ( i > 0 && frame.Pins[i] + frame.Pins[i-1] == 10 && frame.Pins[i] != 0){
                            asStrings.Add("/");
                        } else {
                            asStrings.Add(frame.Pins[i].ToString());
                        }
                    }
                }

                Console.Write($"| |{string.Join('|', asStrings)}");
            }
            Console.WriteLine("|");

            foreach (FrameInfo frame in frames) {
                int digits = 1;
                int frameScore = frame.FrameScore;
                while (frameScore > 9) {
                    frameScore = frameScore / 10;
                    digits++;
                }
                Console.Write($"|");
                for (int i = 0; i < (frame.Pins.Count()*2+1) - digits; i++) {
                    Console.Write(" ");
                }
                Console.Write(frame.FrameScore);
            }
            Console.WriteLine("|");

            foreach (FrameInfo frame in frames) {
                int digits = 1;
                int frameScore = frame.CumulativeScore;
                while (frameScore > 9) {
                    frameScore = frameScore / 10;
                    digits++;
                }
                Console.Write($"|");
                for (int i = 0; i < (frame.Pins.Count()*2+1) - digits; i++) {
                    Console.Write(" ");
                }
                Console.Write(frame.CumulativeScore);
            }
            Console.WriteLine("|");

            for (int i = 0; i < length; i++) {
                Console.Write("_");
            }
            Console.WriteLine("");
        }
    }
}