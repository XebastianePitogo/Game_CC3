using System;
using System.Threading;
using Dialogue;
using AsciiArt;
using Combat;
using CombatTwo;


//check
namespace Game
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
            DisplayIntroduction();
            MainMenu();
        }

        public static void DisplayIntroduction()
        {
            Console.ResetColor();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPlaying the game at full screen is advised for optimized gameplay.");
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
                Console.WriteLine(myTitle.titleArt());
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\t\t\"Through Mud and Blood\"");
                Console.WriteLine("\t\ta Turn-Based Dungeon Crawler Game");
                Console.WriteLine("\t\tMade by Pitogo, Xebastiane\n\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t\t<1> >> Play <<\n");
                Console.WriteLine("\t\t<2> >> Credits <<\n");
                Console.WriteLine("\t\t<3> >> Quit <<\n");
                Console.Write("\t\t>> ");
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
            FightEncoutner fight = new FightEncoutner();
            Places place = new Places();
            Player player = new Player();
            CombatProgram combat = new CombatProgram(player);
            CombatProgramTwo combatTwo = new CombatProgramTwo(player);
            Dialouge dial = new Dialouge(player);
            DialogueArt dialArt = new DialogueArt();

            Console.WriteLine(dialArt.hedgeStone());
            Console.ResetColor();
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
                //Thread.Sleep(500);
            }
            Console.Clear();
            Console.WriteLine(dialArt.hungry());
            Console.ResetColor();
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
            Console.Clear();
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

        spreading fear at the sight of his wide smile with a glowing tooth. Whose visionary barbaric leadership raised an
        
        empire that stretched across continents, toppling numerous rival sovereignties in its wake. Though his passing 
        
        waned the empire's dominion, the legacy of Ogenhei-Uzal endured, influence and legacy enduring through the 
        
        passage of time through a story shared by parents to scare their children to not go out at night.";

                foreach (char c in text)
                {
                    Console.Write(c);
                    //Thread.Sleep(1);
                }
                Console.ResetColor();
                Console.WriteLine(place.jettaiah());
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

        a legend whose courage and bravery is feared among opposing forces. Han-Changgul, identifiable with his
        
        glowing ring and tall stature, a warrior of raw resolve, His heroic defense of the dynasty's main city 
        
        against relentless assault and outnumbered by tenfold forces has planted his story and respect among 
        
        the commoners and higher-ranking individuals alike. Accounts of his heroic defense are now sculpted, in
        
        the Palace walls.";
                foreach (char c in text)
                {
                    Console.Write(c);
                    Thread.Sleep(1);
                }
                Console.ResetColor();
                Console.WriteLine(place.yuandao());
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

        At the heart of this kingdom lies the legend of Creyn Eardwulf, a hero whose name is known by every person who aspires to be righteous.

        His epic tale spans the realms of myth and reality, from extracting the fabled Sword of Trinity from the ruins of ancient kingdoms, charging 
        
        towards enemy lines with a glowing necklace to the liberation of Francia Burna, once a land deprived of hope. Now transformed into a sanctuary 
        
        where individuals of diverse backgrounds and statuses coexist in harmony, Francia Burna stands as a beacon of peace, shielded from the cruelty
        
        of war, plague, and injustice. Eardwulf embodies the virtues of courage, righteousness, and nobility. His deeds immortalized in the ballads sung
        
        by bards across the land. Eardwulf stands as a ray of hope in a world beset by darkness, his tale sung by every Angevin Victornia's people
         
        during times of crisis.
        
        ";
                foreach (char c in text)
                {
                    Console.Write(c);
                    Thread.Sleep(1);
                }
                Console.ResetColor();
                Console.WriteLine(place.victornia());
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n\nPress [Enter] ");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }
            ///
            combatTwo.StartGameTwo(chosenCountry);
            ///
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
                    //Thread.Sleep(500);
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
                    //Thread.Sleep(500);
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.ResetColor();
            Console.Clear();

            for (int i = 0; i < dial.DialogueIntroTwo(chosenCountry).Length; i++)
            {
                Console.WriteLine(dial.DialogueIntroTwo(chosenCountry)[i] + "\n");

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

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nIts, ");
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
            Console.ResetColor();

            for (int i = 0; i < dial.DialogueIntroThree(chosenCountry).Length; i++)
            {
                Console.WriteLine(dial.DialogueIntroThree(chosenCountry)[i] + "\n");

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
            Console.WriteLine(dialArt.fortaare());
            Console.ResetColor();
            for (int i = 0; i < dial.DialogueIntroThreepart().Length; i++)
            {
                Console.WriteLine(dial.DialogueIntroThreepart()[i] + "\n");

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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nBattle Encounter!");
            Console.WriteLine($"So you're Captain {player.username}, prepare to die for my country!\n");
            Console.WriteLine(fight.warrior());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nPress [Enter] >> ");
            Console.ReadKey();
            Console.ResetColor();
            Console.Clear();
            combat.StartGame();
            Console.Clear();
            Console.ResetColor();
            for (int i = 0; i < dial.DialogueOne(chosenCountry).Length; i++)
            {
                Console.WriteLine(dial.DialogueOne(chosenCountry)[i] + "\n");

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

            Console.WriteLine(dialArt.farm());
            Console.ResetColor();
            for (int i = 0; i < dial.DialogueTwo(chosenCountry).Length; i++)
            {
                Console.WriteLine(dial.DialogueTwo(chosenCountry)[i] + "\n");

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

            static string ChooseDecisionTwo(Player player)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Help Eoghann to find Lysander? <y> (yes) or <n> (no)\n");
                Console.ResetColor();
                Console.Write(">> ");
                string choice = Console.ReadLine();
                Console.WriteLine("");
                switch (choice)
                {
                    case "y":
                        return "You helped Eoghann.";
                    case "n":
                        return "You did not helped Eoghann.";
                    default:
                        Console.Clear();
                        Console.WriteLine($"\"It's up to you whether you'll rejoin us and find Lysander or not, and I'll respect your decision no matter what, Captain— Sir {player.username}.\"\n");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Invalid choice. Please enter 'y' or 'n'\n");
                        Console.ResetColor();
                        return ChooseDecisionTwo(player);
                }
            }

            string chosenDecisionTwo = ChooseDecisionTwo(player);
            Console.WriteLine(chosenDecisionTwo);

            if (chosenDecisionTwo == "You helped Eoghann.") {
                for (int i = 0; i < dial.DialogueThreeDecisionOne(chosenCountry).Length; i++)
                {
                    Console.WriteLine(dial.DialogueThreeDecisionOne(chosenCountry)[i] + "\n");

                    if ((i + 1) % DialoguePerClear == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Press [Enter] to continue...");
                        Console.ResetColor();
                        Console.ReadLine();
                        Console.Clear();
                    }
                    Console.WriteLine("Ending C - God of Liberation");
                    Console.WriteLine(dialArt.endingC());
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\nPress [Enter] >> ");
                    Console.ReadKey();
                    Console.ResetColor();
                    Console.Clear();
                    MainMenu();
                }
            }

            if (chosenDecisionTwo == "You did not helped Eoghann.") {
                for (int i = 0; i < dial.DialogueThreeDecisionTwo(chosenCountry).Length; i++)
                {
                    Console.WriteLine(dial.DialogueThreeDecisionTwo(chosenCountry)[i] + "\n");

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
                Console.WriteLine("Ending A - Peaceful life");
                Console.WriteLine(dialArt.endingA());
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nPress [Enter] >> ");
                Console.ReadKey();
                Console.ResetColor();
                Console.Clear();
                MainMenu();
            }

            string opposedCountry = "";
            if (chosenCountry == "Jahanid Jettaiah Sovereignty")
            {
                opposedCountry = "Angevin Victornia Kingdom";
            }
            else if (chosenCountry == "Rising Yuandao Dynasty")
            {
                opposedCountry = "Jahanid Jettaiah Sovereignty";
            }
            else if (chosenCountry == "Angevin Victornia Kingdom")
            {
                opposedCountry = "Rising Yuandao Dynasty";
            }

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\nBattle Encounter!");
            Console.WriteLine($"That DAMNED Kin of Lionheart and their cursed Lysander with his antics!{player.username}\n");
            Console.WriteLine($"In the name of mother {opposedCountry} and God, our sword will bear answer this!\n");
            Console.WriteLine(fight.knight());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nPress [Enter] >> ");
            Console.ReadKey();
            Console.ResetColor();
            Console.Clear();
            combatTwo.StartGameTwo(chosenCountry);
            Console.Clear();
            Console.ResetColor();
        }
        private static void Credits()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nDon Harl - Teaching C# Basics");
            Console.WriteLine("\nMichael Hadley (@mikewesthad) - Gamedev tutorials");
            Console.WriteLine("\nDaFluffyPotato (@DaFluffyPotato) - Gamedev tutorials");
            Console.WriteLine("\n(www.ascii.co.uk) SSt/JaWa - Window ASCII art");
            Console.WriteLine("\n\"www.asciiart.eu\" - For provided ASCII arts");
            Console.WriteLine("\n\"www.loveascii.com\" - Castle tower ASCII art");
            Console.WriteLine("\n\"www.asciiart.eu\" - For provided ASCII arts");
            Console.WriteLine("\n\t(www.asciiart.eu) Tua Xiong - Knight, Warrior ASCII art");
            Console.WriteLine("\n\t(www.asciiart.eu) Marcin Glinski - Castle ASCII art");
            Console.WriteLine("\n\t(www.asciiart.eu) Glory Moon - Temple ASCII art");
            Console.Write("\n>> ");
            Console.ReadKey();
            Console.ResetColor();
            Console.Clear(); 
        }
    }
}
