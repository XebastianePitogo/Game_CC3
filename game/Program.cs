using System;
using System.Threading;
using Dialogue;
using AsciiArt;
using Combat;

namespace game{
    public class Player
    {
        public string? username { get; set; }
    }


public class MudAndBloodGame
{
    private const int DialoguePerClear = 5;

    public static void Main(string[] args)
    {   
        Player hero = new Player();
        DisplayIntroduction();
        MainMenu();
    }

    public static void DisplayIntroduction()
    {
        Console.Clear();
        Console.WriteLine("\nPlaying the game at full screen is advised for optimized gameplay.");
       // Thread.Sleep(5000);
        Console.Clear();
        Console.Write("\"While many can pursue their dreams in solitude, other dreams are like great storms blowing hundreds,\n" +
            "even thousands of dreams apart in their wake. Dreams breathe life into men and can cage them in suffering." +
            "\nMen live and die by their dreams. But long after they have been abandoned they still smolder deep in men's hearts.\n" +
            "Some see nothing more than life and death. They are dead, for they have no dreams.\" \n\n" +
            "\t- Griffith\n\tBerserk (1997)\n\tKentaro Miura");
       // Thread.Sleep(10000);
        Console.Clear();
    }

    public static void MainMenu()
    {
        Title myTitle = new Title();
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(myTitle.TitleArt());
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("\"Through Mud and Blood\"");
            Console.WriteLine("a Turn-Based Dungeon Crawler Game");
            Console.WriteLine("Made by Pitogo, Xebastiane\n\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[1] >> Play <<\n");
            Console.WriteLine("[2] >> Credits <<\n");
            Console.WriteLine("[3] >> Quit <<");
            Console.Write("\n>> ");
            Console.ResetColor();
            string userInput = Console.ReadLine() ?? string.Empty;

            switch (userInput)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Starting game...");
                    Thread.Sleep(1000);
                    Console.Clear();
                    PlayGame();
                    break;
                case "2":
                    Console.Clear();
                    Credits();
                    break;
                case "3":
                    Console.Clear();
                    Environment.Exit(0);
                    break;

                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Invalid choice! Please enter [1] or [2]\n");
                    Console.ResetColor();
                    break;
            }
        }
    }

    public static void PlayGame()
    {
        Player player = new Player();
        IntroDialouge intdial = new IntroDialouge(player);
        
        for (int i = 0; i < intdial.DialogueZero().Length; i++)
        {
            Console.WriteLine(intdial.DialogueZero()[i] + "\n");

            if ((i + 1) % DialoguePerClear == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Press [Enter] to continue...");
                Console.ResetColor();
                Console.ReadLine();
                Console.Clear();
            }
            Thread.Sleep(1500);
        }
        
        for (int i = 0; i < intdial.DialogueOne().Length; i++)
        {
            Console.WriteLine(intdial.DialogueOne()[i] + "\n");

            if ((i + 1) % DialoguePerClear == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Press [Enter] to continue...");
                Console.ResetColor();
                Console.ReadLine();
                Console.Clear();
            }
            Thread.Sleep(1500);
        }

        Console.Write("Its... ");
        string input = Console.ReadLine() ?? string.Empty;
        player.username = !string.IsNullOrWhiteSpace(input) ? input : string.Empty;

        while (string.IsNullOrWhiteSpace(player.username))
        {
            Console.WriteLine("\nHuh, I dont quite hear it?");
            Console.Write("Its, ");
            input = Console.ReadLine() ?? string.Empty;
            player.username = !string.IsNullOrWhiteSpace(input) ? input : string.Empty;
        }

        Console.WriteLine($"I am {player.username}...");

        CombatProgram combat = new CombatProgram(player);
        combat.StartGame();
        Console.ReadKey();
     }
private static void Credits()
    {
    }
}
}
