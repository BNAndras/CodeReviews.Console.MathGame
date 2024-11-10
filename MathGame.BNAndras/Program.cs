using MathGame.BNAndras;
using MathGame.BNAndras.Models;

Random rnd = new();
List<IGame> games = [];
while (true)
{
    char selection = Menu.GetSelection();
    if (selection is 'Q')
    {
        break;
    }

    if (selection is 'P')
    {
        Menu.PrintResults(games);
        Console.WriteLine("Type any key to continue.");
        Console.ReadKey();
        continue;
    }
    
    if (selection is 'R')
    {
        const string modes = "ASMD";
        selection = modes[rnd.Next(modes.Length)];
    }

    IGame game = selection switch
    {
        'A' => new Game(GameMode.Addition),
        'S' => new Game(GameMode.Subtraction),
        'M' => new Game(GameMode.Multiplication),
        'D' => new Game(GameMode.Division),
        _ => throw new ArgumentOutOfRangeException()
    };

    Menu.Play(game);
    Menu.DisplayResult(game);
    games.Add(game);

    Console.WriteLine("Type any key to continue.");
    Console.ReadKey();
}
