namespace MathGame.BNAndras.Models;

public class Game : IGame
{
    private static Random Random { get; } = new();

    public GameState State { get; set; } = GameState.InProgress;

    private GameMode Mode { get; }

    private int Operand1 { get; }

    private int Operand2 { get; }
    
    private int Result { get; }

    public TimeSpan Elapsed { get;  set; }

    public string Puzzle
    {
        get
        {
            string sign = Mode switch
            {
                GameMode.Addition => "+",
                GameMode.Subtraction => "-",
                GameMode.Multiplication => "*",
                GameMode.Division => "/",
                _ => throw new ArgumentOutOfRangeException()
            };

            return $"{Operand1} {sign} {Operand2} = ?";
        }
    }

    public int Guess { get; private set; }


    public Game(GameMode mode)
    {
        Mode = mode;
        Operand1 = Random.Next(1, 100);
        Operand2 = Random.Next(1, 100);

        if (Mode is GameMode.Subtraction)
        {
            Operand1 = Random.Next(Operand2, 100);
        }

        Result = Mode switch
        {
            GameMode.Addition => Operand1 + Operand2,
            GameMode.Subtraction => Operand1 - Operand2,
            GameMode.Multiplication => Operand1 * Operand2,
            GameMode.Division => Random.Next(1, 100),
            _ => throw new ArgumentOutOfRangeException()
        };

        if (Mode is GameMode.Division)
        {
            Operand1 = Operand2 * Result;
        }
    }

    public void Play(int guess)
    {
        if (State is not GameState.InProgress)
        {
            return;
        }

        Guess = guess;

        State = Guess == Result ? GameState.Won : GameState.Lost;
    }

    public override string ToString() => $"[{State}]: {Mode} ({Elapsed.Seconds} seconds)";
}