﻿using System;
using System.Threading;
using Dialogue;
using AsciiArt;
using Combat;

namespace game
{
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
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("\nPlaying the game at full screen is advised for optimized gameplay.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n\nPress [Enter] ");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
            Console.Write("\"While many can pursue their dreams in solitude, other dreams are like great storms blowing hundreds,\n" +
                "even thousands of dreams apart in their wake. Dreams breathe life into men and can cage them in suffering." +
                "\nMen live and die by their dreams. But long after they have been abandoned they still smolder deep in men's hearts.\n" +
                "Some see nothing more than life and death. They are dead, for they have no dreams.\" \n\n" +
                "\t- Griffith\n\tBerserk (1997)\n\tKentaro Miura");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n\nPress [Enter] ");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }

        public static void MainMenu()
        {
            Title myTitle = new Title();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(myTitle.TitleArt());
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine("\"Through Mud and Blood\"");
                Console.WriteLine("a Turn-Based Dungeon Crawler Game");
                Console.WriteLine("Made by Pitogo, Xebastiane\n\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("<1> >> Play <<\n");
                Console.WriteLine("<2> >> Credits <<\n");
                Console.WriteLine("<3> >> Quit <<\n");
                Console.Write(">> ");
                Console.ResetColor();
                string userInput = Console.ReadLine() ?? string.Empty;

                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Starting game...");
                        //
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
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Invalid choice! Please enter [1], [2], [3]\n");
                        Console.ResetColor();
                        break;
                }
            }
        }

        public static void PlayGame()
        {
            Places place = new Places();
            Player player = new Player();
            Dialouge dial = new Dialouge(player);

            for (int i = 0; i < dial.DialogueZero().Length; i++)
            {
                Console.WriteLine(dial.DialogueZero()[i] + "\n");

                if ((i + 1) % DialoguePerClear == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Press [Enter] to continue...");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                }
                //
            }


            for (int i = 0; i < dial.DialogueIntro().Length; i++)
            {
                Console.WriteLine(dial.DialogueIntro()[i] + "\n");

                if ((i + 1) % DialoguePerClear == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Press [Enter] to continue...");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                }
                //Thread.Sleep(500);
            }

            static string ChooseCountry()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nChoose which country's mercenaries you would like to serve:");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n<1> Jahanid Jettaiah Sovereignty");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n<2> Rising Yuandao Dynasty");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n<3> Angevin Victornia Empire");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n>> ");
                Console.ResetColor();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        return "Jahanid Jettaiah Sovereignty";
                    case "2":
                        return "Rising Yuandao Dynasty";
                    case "3":
                        return "Angevin Victornia Kingdom";
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("\nInvalid choice. Please enter a number between 1 and 3.");
                        Console.ResetColor();
                        return ChooseCountry();
                }
            }

            string chosenCountry = ChooseCountry();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nYou have chosen to serve the " + chosenCountry);
            Console.ResetColor();

            if (chosenCountry == "Jahanid Jettaiah Sovereignty")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string text = @"
        The Jahanid Jettaiah Sovereignty stands as a bastion of authoritarian rule,

        its foundation deeply entrenched in the art of warfare—be it through cunning guerrilla tactics of

        the harsh desert or masterful army strategies. At its birth once stood the formidable Warlord Ogenhei-Uzal,

        whose visionary leadership raised an empire that stretched across continents, toppling numerous rival

        sovereignties in its wake. Though his passing waned the empire's dominion,

        the legacy of Ogenhei-Uzal endured, influence and legacy enduring through the passage of time..";

                foreach (char c in text)
                {
                    Console.Write(c);
                    Thread.Sleep(2);
                }
                Console.ResetColor();
                Console.WriteLine(place.Jettaiah());
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n\nPress [Enter] ");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }

            else if (chosenCountry == "Rising Yuandao Dynasty")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                string text = @"
        Once a part of the grand empire of Li-Hindei, the Rising Yuandao Dynasty has risen from the ashes of

        familial strife and internal discord. Amidst the chaos of dynasty wars, the Yuandao Dynasty emerged

        from its conservatism and political prowess, Their unwavering dedication to traditional values and

        clever governance propelled them to the forefront of power struggles. One figure shines brightly—

        a legend whose courage and bravery is feared among opposing forces. Han-Changgul, a warrior of raw resolve,

        His heroic defense of the dynasty's main city against relentless assault and outnumbered by tenfold forces

        has planted his story and respect among the commoners and higher-ranking individuals alike.";
                foreach (char c in text)
                {
                    Console.Write(c);
                    Thread.Sleep(2);
                }
                Console.ResetColor();
                Console.WriteLine(place.Yuandao());
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n\nPress [Enter] ");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }

            else if (chosenCountry == "Angevin Victornia Kingdom")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                string text = @"
        the Angevin Victornia Kingdom prides as a realm steeped in chivalry, honor, and the echoes of ancient glory.

        Its castles stand as proud reminder of a bygone era, where knights uphold the code of chivalry with unwavering devotion.

        At the heart of this kingdom lies the legend of Eardwulf, a hero whose name is known by every person who aspires to be righteous.

        His epic tale spans the realms of myth and reality, from extracting the fabled Sword of Trinity from the ruins of ancient kingdoms to

        the liberation of Francia Burna, once a land deprived of hope. Now transformed into a sanctuary where individuals of diverse backgrounds

        and statuses coexist in harmony, Francia Burna stands as a beacon of peace, shielded from the cruelty of war, plague, and injustice. 

        Eardwulf embodies the virtues of courage, righteousness, and nobility. His deeds immortalized in the ballads sung by bards across the land.

        Eardwulf stands as a ray of hope in a world beset by darkness, his tale weaving itself into the very fabric of Angevin Victornia's storied history.";
                foreach (char c in text)
                {
                    Console.Write(c);
                    Thread.Sleep(2);
                }
                Console.ResetColor();
                Console.WriteLine(place.Victornia());
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n\nPress [Enter] ");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }

            for (int i = 0; i < dial.DialogueIntroOne().Length; i++)
            {
                Console.WriteLine(dial.DialogueIntroOne()[i] + "\n");

                if ((i + 1) % DialoguePerClear == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Press [Enter] to continue...");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                }
                //Thread.Sleep(500);
            }

            static string ChooseDecisionOne()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Help the Children? <y> (yes) or <n> (no)\n");
                Console.ResetColor();
                Console.Write(">> ");
                string choice = Console.ReadLine();
                Console.WriteLine("");
                switch (choice)
                {
                    case "y":
                        return "You Helped the children.";
                    case "n":
                        return "You Ignored the children.";
                    default:
                        Console.Clear();
                        Console.WriteLine("The mercenary, angered again. Raised his sword, to strike down the eldest child with a lethal blow.");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Invalid choice. Please enter 'y' or 'n'\n");
                        Console.ResetColor();
                        return ChooseDecisionOne();
                }
            }

            string chosenDecisionOne = ChooseDecisionOne();
            Console.WriteLine(chosenDecisionOne);

            if (chosenDecisionOne == "You Helped the children.") {
                for (int i = 0; i < dial.DialogueIntroOneDecisionOne().Length; i++)
                {
                    Console.WriteLine(dial.DialogueIntroOneDecisionOne()[i] + "\n");

                    if ((i + 1) % DialoguePerClear == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Press [Enter] to continue...");
                        Console.ResetColor();
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
            }

            if (chosenDecisionOne == "You Ignored the children.") {
                for (int i = 0; i < dial.DialogueIntroOneDecisionTwo().Length; i++)
                {
                    Console.WriteLine(dial.DialogueIntroOneDecisionTwo()[i] + "\n");

                    if ((i + 1) % DialoguePerClear == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Press [Enter] to continue...");
                        Console.ResetColor();
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n\nPress [Enter] ");
            Console.ReadKey();
            Console.ResetColor();
            Console.Clear();
            for (int i = 0; i < dial.DialogueOne().Length; i++)
            {
                Console.WriteLine(dial.DialogueOne()[i] + "\n");

                if ((i + 1) % DialoguePerClear == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Press [Enter] to continue...");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                }

            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nIts, ");
            Console.ResetColor();
            string input = Console.ReadLine() ?? string.Empty;
            player.username = !string.IsNullOrWhiteSpace(input) ? char.ToUpper(input[0]) + input.Substring(1).ToLower() : string.Empty;

            while (string.IsNullOrWhiteSpace(player.username) || player.username.Length > 11)
            {
                if (player.username.Length > 11)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nUsername cannot be longer than 11 characters.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nPlease enter a username.");
                    Console.ResetColor();
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nIts, ");
                Console.ResetColor();
                input = Console.ReadLine() ?? string.Empty;
                player.username = !string.IsNullOrWhiteSpace(input) ? char.ToUpper(input[0]) + input.Substring(1).ToLower() : string.Empty;
            }

            Console.WriteLine($"\nI am {player.username}, Lord...");


            for (int i = 0; i < dial.DialogueTwo().Length; i++)
            {
                Console.WriteLine(dial.DialogueTwo()[i] + "\n");

                if ((i + 1) % DialoguePerClear == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Press [Enter] to continue...");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                }

            }

            CombatProgram combat = new CombatProgram(player);
            combat.StartGame();
            Console.ReadKey();
        }
        private static void Credits()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nwww.asciiart.eu - For provided ASCII arts");
            Console.WriteLine("\nDon Harl - Teaching C# Basics");
            Console.WriteLine("\nMichael Hadley (@mikewesthad) - Gamedev tutorials");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear(); 
        }
    }
}