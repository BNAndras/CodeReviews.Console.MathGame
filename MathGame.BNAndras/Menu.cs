using MathGame.BNAndras.Models;
using System.Diagnostics;

namespace MathGame.BNAndras;

public class Menu
{
    public static char GetSelection()
    {
        Console.Clear();
        char selection;
        do
        {
            Console.WriteLine("""
                              Hello, user! Please make a selection using the first letter of your choice:
                              (A)ddition
                              (S)ubtraction
                              (D)ivision
                              (M)ultiplication

                              (R)andom
                              (P)rint
                              (Q)uit
                              """);
            selection = char.ToUpperInvariant(Console.ReadKey().KeyChar);
        } while (selection is not ('A' or 'S' or 'D' or 'M' or 'R' or 'P' or 'Q'));

        Console.WriteLine();
        return selection;
    }

    public static void PrintResults(List<IGame> games)
    {
        if (games.Count is 0)
        {
            Console.WriteLine("No games played yet!");
        }
        else
        {
            for (int i = 0; i < games.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {games[i]}");
            }
        }
    }

    public static void Play(IGame game)
    {
        Console.Clear();
        Console.Write($"{game.Puzzle} ");

        Stopwatch timer = new();
        timer.Start();
        bool isNumber;
        int guess;
        do
        {
            isNumber = int.TryParse(Console.ReadLine(), out guess);
            if (!isNumber)
            {
                Console.WriteLine("Sorry, that was not a number. Try again!");
            }
        } while (!isNumber);
        timer.Stop();

        game.Play(guess);
        game.Elapsed = timer.Elapsed;
    }

    public static void DisplayResult(IGame game)
    {
        Console.WriteLine(game.State is GameState.Won ? "That's correct!" : "Sorry. That's incorrect.");
    }
}