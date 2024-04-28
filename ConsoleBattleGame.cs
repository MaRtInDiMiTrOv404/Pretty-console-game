//using System;

using System.Security.Cryptography.X509Certificates;

namespace ConsoleBattleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Console Battle Game!");
            Console.WriteLine("Press any key to start the battle...");
            Console.ReadKey();

            // Initialize player stats
            int playerHealth = 1000;
            int playerMoney = 500;
            int playerUpgrade = 0;

            // Main game loop
            while (playerHealth > 0)
            {
                // Enemy's stats
                int enemyHealth = 100;
                int enemyMoney  = new Random().Next(10, 21); // Random money earned from defeating enemy

                // Battle loop
                while (playerHealth > 0 && enemyHealth > 0)
                {
                    // Player's turn
                    Console.WriteLine("Your turn! Press 'a' to attack the enemy or 's' to shop:");
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.KeyChar == 'a')
                    {
                        int damageDealt = new Random().Next(11, 32); // Random damage between 5 and 15
                        int totalDamage = damageDealt + playerUpgrade;
                        enemyHealth -= totalDamage;
                        Console.WriteLine($"You dealt {totalDamage} damage to the enemy. Enemy health: {enemyHealth}");
                    }
                    else if (keyInfo.KeyChar == 's')
                    {
                        Shop(ref playerHealth, ref playerMoney, ref playerUpgrade);
                    }

                    // Check if enemy is defeated
                    if (enemyHealth <= 0)
                    {
                        Console.WriteLine($"Congratulations! You defeated the enemy and earned {enemyMoney} money!");
                        playerMoney += enemyMoney;
                        break; // Exit the battle loop
                    }

                    // Enemy's turn
                    int enemyDamage = new Random().Next(5, 16); // Random damage between 5 and 15
                    playerHealth -= enemyDamage;
                    Console.WriteLine($"The enemy dealt {enemyDamage} damage to you. Your health: {playerHealth}");

                    // Check if player is defeated
                    if (playerHealth <= 0)
                    {
                        Console.WriteLine("Game over! You were defeated by the enemy.");
                        break; // Exit the battle loop
                    }
                }
            }

            Console.WriteLine("Thanks for playing Console Battle Game!");
        }

        // Shop method
        static void Shop(ref int playerHealth, ref int playerMoney, ref int playerUpgrade)
        {
            Console.WriteLine($"Welcome to the shop! You have {playerMoney} money.");
            Console.WriteLine("What would you like to buy?");
            Console.WriteLine("1. Health Potion (10 money)");
            Console.WriteLine("2. Weapon Upgrade (20 money)");
            Console.WriteLine("3. Exit Shop");

            // Get user input
            int choice;
            bool isValidChoice = int.TryParse(Console.ReadLine(), out choice);

            // Check if the input is valid
            if (!isValidChoice)
            {
                Console.WriteLine("Invalid choice. Please enter a number.");
                return;
            }

            // Process user choice
            switch (choice)
            {
                case 1:
                    if (playerMoney >= 10)
                    {
                        playerHealth += 60; // Increase player's health by 20
                        playerMoney -= 10; // Decrease player's money by 10
                        Console.WriteLine("You bought a Health Potion. Your health has increased by 20.");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you don't have enough money to buy a Health Potion.");
                    }
                    break;
                case 2:
                    if (playerMoney >= 20)
                    {
                        // Implement weapon upgrade logic here
                        playerUpgrade += 10;
                        playerMoney -= 20; // Decrease player's money by 20
                        
                        
                        
                        Console.WriteLine("You bought a Weapon Upgrade and your ATK is + 10");
                    }
                    
                    else
                    {
                        Console.WriteLine("Sorry, you don't have enough money to buy a Weapon Upgrade.");
                    }
                    break;
                case 3:
                    Console.WriteLine("Exiting shop...");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
