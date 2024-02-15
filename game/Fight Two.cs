using System;
using AsciiArt;
using Game;

namespace CombatTwo;
public class CombatProgramTwo
{
    Death deathScene = new Death();
    Win winscene = new Win();
    private Player player;

    public int playerHP = 400;
    public int playerLeftHand = 200;
    public int playerRightHand = 200;

    public int knightHP = 400;
    public int knightLeftHand = 200;
    public int knightRightHand = 200;

    public bool playerLeftHandLost = false;
    public bool playerRightHandLost = false;

    public bool knightLeftHandLost = false;
    public bool knightRightHandLost = false;

    public CombatProgramTwo(Player player)
    {
        this.player = player;
    }

    public void StartGameTwo(string chosenCountry)
    {
        FightEncoutner fight = new FightEncoutner();
        CombatProgramTwo combatTwo = new CombatProgramTwo(player);
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("You find yourself unable to run, and the only way out is to... spill blood.");

        while (playerHP > 0 && knightHP > 0)
        {
            DisplayStats();
            PlayerTurn();
            if (knightHP <= 0 && knightLeftHand <= 0 && knightRightHand <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nGunterius the Knight Main HP fell to <0>!");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nGunterius the Knight fell in battle, you felt a sense of pity for his blinded chivalrous act, yet it had to be done.");
                Console.WriteLine("\nYou stand tall and won in the aftermath of the battle, You move closer to your inevitable suffering that lies in your destiny... ");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("\n" + winscene.winart());
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Proceed?");
                Console.Write(">> ");
                Console.ReadKey();
                break;
            }

            knightTurn();

            if (playerHP <= 0 && playerLeftHand <= 0 && playerRightHand <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n{player.username} Main HP fell to <0>!");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\"May your soul find solace in heaven...\"");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYou succumbed during battle, You have finally embraced bliss after enduring the prolonged suffering of battle...");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n" + deathScene.skullArt());
                Console.ForegroundColor = ConsoleColor.Yellow;

                string userTry;
                do
                {
                    Console.WriteLine("Restart fight? <y>(Yes) or <n>(No)");
                    Console.Write(">> ");
                    userTry = Console.ReadLine().ToLower();
                } while (userTry != "y" && userTry != "n");

                if (userTry == "y")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nBattle Encounter!");
                    Console.WriteLine($"You're the Traitor in the band of Kin of Lionhearth and {chosenCountry}! {player.username}, in the name of God and Iron Dragons, you shall be purged!\n");
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
                else if (userTry == "n")
                {
                    Console.Clear();
                    MudAndBloodGame.MainMenu();
                }
                else
                {
                    Console.Clear();
                }
            }
        }
    }
    public void DisplayStats()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\n================================================================================");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(player.username + $"'s Main HP: <{playerHP}>     |   Left Limb: <{playerLeftHand}>   |   Right Limb: <{playerRightHand}>");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--------------------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Gunterius the Knight's Main HP: <{knightHP}>     |   Left Limb: <{knightLeftHand}>   |   Right Limb: <{knightRightHand}>");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("================================================================================");
        Console.ResetColor();
    }

    void PlayerTurn()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n===================================");
        Console.WriteLine("| |Your Turn!|    Choose an Action:|");
        Console.WriteLine("|==================================|");
        Console.WriteLine("| <1> Attack                       |");
        Console.WriteLine("|----------------------------------|");
        Console.WriteLine("| <2> Defend                       |");
        Console.WriteLine("====================================");
        Console.ResetColor();

        int choice = GetValidInput(1, 2);

        if (choice == 1)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n==================================");
            Console.WriteLine("| Choose target limb:           |");
            Console.WriteLine("|===============================|");
            Console.WriteLine("| <1> Left Limb                 |");
            Console.WriteLine("|-------------------------------|");
            Console.WriteLine("| <2> Right Limb                |");
            Console.WriteLine("=================================");
            Console.ResetColor();

            int targetLimb = GetValidInput(1, 2);

            if ((targetLimb == 1) || (targetLimb == 2))
            {
                Attackknight(targetLimb);
            }

        }
        else if (choice == 2)
        {
            Defend();
        }
    }

    void knightTurn()
    {
        Random random = new Random();

        if (knightLeftHandLost && knightRightHandLost)
        {
            knightDefend();
            return;
        }
        if (playerLeftHandLost)
        {
            AttackPlayer(2);
            return;
        }
        else if (playerRightHandLost)
        {
            AttackPlayer(1);
            return;
        }

        int choice = random.Next(1, 3);
        AttackPlayer(choice);
    }


    private void AttackPlayer(int targetLimb)
    {
        string limb = targetLimb == 1 ? "Left Limb" : "Right Limb";
        int damage = new Random().Next(25, 30);

        Console.WriteLine("----------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine($"\nGunterius the Knight attacks your <{limb}> and deals <{damage}> damage!\n");
        Console.ResetColor();
        Console.WriteLine("----------------------------------------------------------------------");
        UpdatePlayerHP();

        if (targetLimb == 1)
        {
            playerLeftHand = Math.Max(0, playerLeftHand - damage);
            if (playerLeftHand == 0 && !playerLeftHandLost)
            {
                playerLeftHandLost = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nYour left hand is now fatally damaged. Damage reduction of 25% will be applied on your attacks.\n");
                Console.ResetColor();
                Console.WriteLine("----------------------------------------------------------------------");
                damage = (int)(damage * 0.75);
                UpdatePlayerHP();
            }
        }
        else if (targetLimb == 2)
        {
            playerRightHand = Math.Max(0, playerRightHand - damage);
            if (playerRightHand == 0 && !playerRightHandLost)
            {
                playerRightHandLost = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nYour right hand is now fatally damaged. Damage reduction of 25% will be applied on your attacks.\n");
                Console.ResetColor();
                Console.WriteLine("----------------------------------------------------------------------");
                damage = (int)(damage * 0.75);
                UpdatePlayerHP();
            }
        }
    }


    private void Attackknight(int targetLimb)
    {
        string limb = targetLimb == 1 ? "Left Limb" : "Right Limb";
        int damage = new Random().Next(30, 35);
        Console.WriteLine("\n----------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"\nYou attack the Gunterius the Knight's <{limb}> and deal <{damage}> damage!\n");
        Console.ResetColor();
        UpdateknightHP();

        if (targetLimb == 1)
        {
            knightLeftHand = Math.Max(0, knightLeftHand - damage);
            if (knightLeftHand == 0 && !knightLeftHandLost)
            {
                knightLeftHandLost = true;
                Console.WriteLine("----------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nGunterius the Knight's left hand is now fatally damaged. Damage reduction of 25% will be applied on its attacks.\n");
                Console.ResetColor();
                damage = (int)(damage * 0.75);
                UpdateknightHP();
            }
        }
        else if (targetLimb == 2)
        {
            knightRightHand = Math.Max(0, knightRightHand - damage);
            if (knightRightHand == 0 && !knightRightHandLost)
            {
                knightRightHandLost = true;
                Console.WriteLine("----------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nGunterius the Knight's right hand is now fatally damaged. Damage reduction of 25% will be applied on its attacks.\n");
                Console.ResetColor();
                damage = (int)(damage * 0.75);
                UpdateknightHP();
            }
        }
    }


    private static void Defend()
    {
        Console.WriteLine("----------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nYou chose to defend. You take reduced damage on the next attack.\n");
        Console.ResetColor();

    }

    private static void knightDefend()
    {
        Console.WriteLine("----------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nGunterius the Knight's chose to defend. The Gunterius the Knight's  takes reduced damage on the next attack.");
        Console.ResetColor();
    }

    void UpdatePlayerHP()
    {
        playerHP = (playerLeftHandLost ? 0 : playerLeftHand) + (playerRightHandLost ? 0 : knightRightHand);
    }

    void UpdateknightHP()
    {
        knightHP = (knightLeftHandLost ? 0 : knightLeftHand) + (knightRightHandLost ? 0 : knightRightHand);
    }

    static int GetValidInput(int minValue, int maxValue)
    {
        int choice;
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n [Enter your choice] >> ");
            Console.ResetColor();
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= minValue && choice <= maxValue)
            {
                break;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nInvalid input. Please enter a valid option.");
                Console.ResetColor();
            }
        }
        return choice;
    }
}
