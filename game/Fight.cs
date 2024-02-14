using System;
using AsciiArt;
using Game;
namespace Combat;
public class CombatProgram
{
    Death deathScene = new Death();
    Win winscene = new Win();
    private Player player;

    static int playerHP = 100;
    static int playerLeftHand = 20;
    static int playerRightHand = 20;

    static int enemyHP = 100;
    static int enemyLeftHand = 20;
    static int enemyRightHand = 20;

    static bool playerLeftHandLost = false;
    static bool playerRightHandLost = false;

    static bool enemyLeftHandLost = false;
    static bool enemyRightHandLost = false;

    public CombatProgram(Player player)
    {
        this.player = player;
    }

    public void StartGame()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("You find yourself unable to run, and the only way out is to... spill blood.");

        while (playerHP > 0 && enemyHP > 0)
        {
            DisplayStats();
            PlayerTurn();

            if (enemyHP <= 0 && enemyLeftHand <= 0 && enemyRightHand <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nEnemy Main HP fell to <0>!");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nThe enemy fell in battle, you felt a sense of pity, yet there was no guilt for the slain soul.");
                Console.WriteLine("\nYou stand tall and won in the aftermath of the battle, you are granted another day to endure the relentless suffering that awaits for your destiny... ");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("\n" + winscene.winart());
                Console.ResetColor();
                break;
            }

            EnemyTurn();

            if (playerHP <= 0 && playerLeftHand <= 0 && playerRightHand <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n{player.username} Main HP fell to <0>!");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYou succumbed during battle, You have finally embraced bliss after enduring the prolonged suffering of battle...");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n" + deathScene.skullArt());
                Console.ResetColor();
                break;
            }
        }
    }
    public void DisplayStats()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\n======================================================================");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(player.username + $"'s Main HP: <{playerHP}>     |   Left Limb: <{playerLeftHand}>   |   Right Limb: <{playerRightHand}>");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("----------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Enemy Main HP: <{enemyHP}>     |   Left Limb: <{enemyLeftHand}>   |   Right Limb: <{enemyRightHand}>");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("======================================================================");
        Console.ResetColor();
    }

    static void PlayerTurn()
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
                AttackEnemy(targetLimb);
            }

        }
        else if (choice == 2)
        {
            Defend();
        }
    }

    static void EnemyTurn()
    {
        Random random = new Random();

        if (enemyLeftHandLost && enemyRightHandLost)
        {
            enemyDefend();
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


    private static void AttackPlayer(int targetLimb)
    {
        string limb = targetLimb == 1 ? "Left Limb" : "Right Limb";
        int damage = new Random().Next(3, 7);

        Console.WriteLine("----------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\nThe enemy attacks your <{limb}> and deals <{damage}> damage!\n");
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


    private static void AttackEnemy(int targetLimb)
    {
        string limb = targetLimb == 1 ? "Left Limb" : "Right Limb";
        int damage = new Random().Next(3, 8);
        Console.WriteLine("\n----------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"\nYou attack the enemy's <{limb}> and deal <{damage}> damage!\n");
        Console.ResetColor();
        UpdateEnemyHP();

        if (targetLimb == 1)
        {
            enemyLeftHand = Math.Max(0, enemyLeftHand - damage);
            if (enemyLeftHand == 0 && !enemyLeftHandLost)
            {
                enemyLeftHandLost = true;
                Console.WriteLine("----------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nThe enemy's left hand is now fatally damaged. Damage reduction of 25% will be applied on its attacks.\n");
                Console.ResetColor();
                damage = (int)(damage * 0.75);
                UpdateEnemyHP();
            }
        }
        else if (targetLimb == 2)
        {
            enemyRightHand = Math.Max(0, enemyRightHand - damage);
            if (enemyRightHand == 0 && !enemyRightHandLost)
            {
                enemyRightHandLost = true;
                Console.WriteLine("----------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nThe enemy's right hand is now fatally damaged. Damage reduction of 25% will be applied on its attacks.\n");
                Console.ResetColor();
                damage = (int)(damage * 0.75);
                UpdateEnemyHP();
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

    private static void enemyDefend()
    {
        Console.WriteLine("----------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nEnemy chose to defend. The enemy takes reduced damage on the next attack.");
        Console.ResetColor();
    }

    static void UpdatePlayerHP()
    {
        playerHP = (playerLeftHandLost ? 0 : playerLeftHand) + (playerRightHandLost ? 0 : enemyRightHand);
    }

    static void UpdateEnemyHP()
    {
        enemyHP = (enemyLeftHandLost ? 0 : enemyLeftHand) + (enemyRightHandLost ? 0 : enemyRightHand);
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
