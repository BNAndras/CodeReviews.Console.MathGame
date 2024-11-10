using MathGame.BNAndras.Models;

namespace MathGame.BNAndras
{
    public interface IGame
    {
        public GameState State { get; set; }

        public string Puzzle { get; }

        public void Play(int guess);

        public TimeSpan Elapsed { get; set; }
    }
}
