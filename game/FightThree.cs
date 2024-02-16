using System;
using AsciiArt;
using Game;

namespace CombatTwo;
public class CombatProgramThree
{
    Death deathScene = new Death();
    Win winscene = new Win();
    private Player player;

    public int playerHP = 400;
    public int playerLeftHand = 200;
    public int playerRightHand = 200;

    public int lysanderHP = 400;
    public int lysanderLeftHand = 200;
    public int lysanderRightHand = 200;

    public bool playerLeftHandLost = false;
    public bool playerRightHandLost = false;

    public bool lysanderLeftHandLost = false;
    public bool lysanderRightHandLost = false;

    public CombatProgramThree(Player player)
    {
        this.player = player;
    }

    public void StartGameTwo(string chosenCountry)
    {
        FightEncoutner fight = new FightEncoutner();
        CombatProgramThree combatTwo = new CombatProgramThree(player);
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("You find yourself unable to run, and the only way out is to... spill blood.");

        while (playerHP > 0 && lysanderHP > 0)
        {
            DisplayStats();
            PlayerTurn();
            if (lysanderHP <= 0 && lysanderLeftHand <= 0 && lysanderRightHand <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nGunterius the lysander Main HP fell to <0>!");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\"It has to be this way... Alisa, Chip I'm follow both of you.\"");
                Console.WriteLine("\nGunterius the lysander fell in battle while holding a portrait of his wife, You felt guilt yet it had to be done.");
                Console.WriteLine("\nYou stand tall and won in the aftermath of the battle, You move closer to your inevitable suffering that lies in your destiny... ");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("\n" + winscene.winart());
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Proceed?");
                Console.Write(">> ");
                Console.ReadKey();
                break;
            }

            lysanderTurn();

            if (playerHP <= 0 && playerLeftHand <= 0 && playerRightHand <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n{player.username} Main HP fell to <0>!");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\"Seems you were Lysander's pawn after all, Alisa, Chip I've finally avanged both of you...\"");
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
                    Console.WriteLine($"That DAMNED Kin of Lionheart and their cursed Lysander with his antics!{player.username}\n");
                    Console.WriteLine($"In the name of mother \\ and God, our sword will bear answers!\n");
                    Console.WriteLine(fight.Lysander());
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
        Console.WriteLine($"Lysander the Liberator's Main HP: <{lysanderHP}>     |   Left Limb: <{lysanderLeftHand}>   |   Right Limb: <{lysanderRightHand}>");
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
                Attacklysander(targetLimb);
            }

        }
        else if (choice == 2)
        {
            Defend();
        }
    }

    void lysanderTurn()
    {
        Random random = new Random();

        if (lysanderLeftHandLost && lysanderRightHandLost)
        {
            lysanderDefend();
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
        int damage = new Random().Next(28, 43);

        Console.WriteLine("----------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine($"\nGunterius the lysander attacks your <{limb}> and deals <{damage}> damage!\n");
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


    private void Attacklysander(int targetLimb)
    {
        string limb = targetLimb == 1 ? "Left Limb" : "Right Limb";
        int damage = new Random().Next(31, 41);
        Console.WriteLine("\n----------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"\nYou attack the Gunterius the lysander's <{limb}> and deal <{damage}> damage!\n");
        Console.ResetColor();
        UpdatelysanderHP();

        if (targetLimb == 1)
        {
            lysanderLeftHand = Math.Max(0, lysanderLeftHand - damage);
            if (lysanderLeftHand == 0 && !lysanderLeftHandLost)
            {
                lysanderLeftHandLost = true;
                Console.WriteLine("----------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nGunterius the lysander's left hand is now fatally damaged. Damage reduction of 25% will be applied on its attacks.\n");
                Console.ResetColor();
                damage = (int)(damage * 0.75);
                UpdatelysanderHP();
            }
        }
        else if (targetLimb == 2)
        {
            lysanderRightHand = Math.Max(0, lysanderRightHand - damage);
            if (lysanderRightHand == 0 && !lysanderRightHandLost)
            {
                lysanderRightHandLost = true;
                Console.WriteLine("----------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nGunterius the lysander's right hand is now fatally damaged. Damage reduction of 25% will be applied on its attacks.\n");
                Console.ResetColor();
                damage = (int)(damage * 0.75);
                UpdatelysanderHP();
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

    private static void lysanderDefend()
    {
        Console.WriteLine("----------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nGunterius the lysander's chose to defend. The Gunterius the lysander's  takes reduced damage on the next attack.");
        Console.ResetColor();
    }

    void UpdatePlayerHP()
    {
        playerHP = (playerLeftHandLost ? 0 : playerLeftHand) + (playerRightHandLost ? 0 : lysanderRightHand);
    }

    void UpdatelysanderHP()
    {
        lysanderHP = (lysanderLeftHandLost ? 0 : lysanderLeftHand) + (lysanderRightHandLost ? 0 : lysanderRightHand);
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