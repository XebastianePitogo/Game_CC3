using System;
using AsciiArt;
using game;
namespace Combat;
    public class CombatProgram
    {
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
    Win winscene = new Win();
    Death deathScene = new Death();
    Console.WriteLine("You find yourself unable to run, and the only way out is to... spill blood.");

    while (playerHP > 0 && enemyHP > 0)
    {
        DisplayStats();
        PlayerTurn();

        if (enemyHP <= 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(winscene.Winart());
            Console.WriteLine("You stand tall and won in battle, you get to see another day of suffering");
            Console.ResetColor();
            break;
        }

        EnemyTurn();

        if (playerHP <= 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(deathScene.SkullArt());
            Console.WriteLine("You succumbed during battle, and now, the God of Netherhelm beckons for the arrival of your lost soul");
            Console.ResetColor();
            break;
        } 
    }
}
        public void DisplayStats()
        {
            Console.WriteLine(player.username + $"'s HP: {playerHP} | Left Hand: {playerLeftHand} | Right Hand: {playerRightHand}");
            Console.WriteLine($"Enemy HP: {enemyHP} | Left Hand: {enemyLeftHand} | Right Hand: {enemyRightHand}");
        }

    static void PlayerTurn()
    {
            Console.WriteLine("================================");
            Console.WriteLine("||Your Turn!| Choose an Action:|");
            Console.WriteLine("|==============================|");
            Console.WriteLine("| 1. Attack                    |");
            Console.WriteLine("| 2. Defend                    |");
            Console.WriteLine("================================");

        int choice = GetValidInput(1, 2);

        if (choice == 1)
        {
            Console.WriteLine("Choose target limb:");
            Console.WriteLine("1. Left Hand");
            Console.WriteLine("2. Right Hand");

            int targetLimb = GetValidInput(1, 2);

            if ((targetLimb == 1 && !playerLeftHandLost) || (targetLimb == 2 && !playerRightHandLost))
            {
                AttackEnemy(targetLimb);
            }

        }
        else
        {
            Defend();
        }
    }

    static void EnemyTurn()
    {
        Random random = new Random();
        int choice = random.Next(1, 3);

        if (choice == 1 && !enemyLeftHandLost)
        {
            int targetLimb = 1;
            AttackPlayer(targetLimb);
        }
        else if (choice == 2 && !enemyRightHandLost)
        {
            int targetLimb = 2;
            AttackPlayer(targetLimb);
        }
        else
        {
            Defend();
        }
    }

static void AttackPlayer(int targetLimb)
{
    int damage = new Random().Next(3, 7);
    string limb = targetLimb == 1 ? "Left Hand" : "Right Hand";

    Console.WriteLine($"The enemy attacks your {limb} and deals {damage} damage!");

if (targetLimb == 1 && !playerLeftHandLost)
{
    if (playerLeftHand == 0)
    {
        playerLeftHandLost = true;
        Console.WriteLine("Your left hand is now disabled. Damage reduction will be applied on your attacks.");
        damage = (0);
    }
    playerLeftHand = Math.Max(0, playerLeftHand - damage);
}
else if (targetLimb == 2 && !playerRightHandLost)
{
    if (playerRightHand == 0)
    {
        playerRightHandLost = true;
        Console.WriteLine("Your right hand is now disabled. Damage reduction will be applied on your attacks.");
        damage = (0);
    }
    playerRightHand = Math.Max(0, playerRightHand - damage);
}

    UpdatePlayerHP();
}

static void AttackEnemy(int targetLimb)
{
    int damage = new Random().Next(5, 10);
    string limb = targetLimb == 1 ? "Left Hand" : "Right Hand";

    Console.WriteLine($"You attack the enemy's {limb} and deal {damage} damage!");

if (targetLimb == 1 && !enemyLeftHandLost)
{
    if (enemyLeftHand == 0)
    {
        enemyLeftHandLost = true;
        Console.WriteLine($"The enemy's left hand is now disabled. Damage reduction will be applied on its attacks.");
        damage = (0);
    }
    enemyLeftHand = Math.Max(0, enemyLeftHand - damage);
}
else if (targetLimb == 2 && !enemyRightHandLost)
{
    if (enemyRightHand == 0)
    {
        enemyRightHandLost = true;
        Console.WriteLine($"The enemy's right hand is now disabled. Damage reduction will be applied on its attacks.");
        damage = (0);
    }
    enemyRightHand = Math.Max(0, enemyRightHand - damage);
}

    UpdateEnemyHP();
}

    static void Defend()
    {
        Console.WriteLine("You choose to defend. You take reduced damage on the next attack.");
    }

    static void UpdatePlayerHP()
    {
        playerHP = (playerLeftHandLost ? 0 :playerLeftHand) + (playerRightHandLost ? 0 : enemyRightHand);
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
            Console.Write("Enter your choice>> ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= minValue && choice <= maxValue)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid option.");
            }
        }
        return choice;
    }
}
