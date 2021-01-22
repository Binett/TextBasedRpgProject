using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using TextBasedRpgProject.Enemies;

namespace TextBasedRpgProject
{
    class Game
    {        
        List<Enemy> listOfEnemies = new List<Enemy>();
        Player player = new Player();
        
        public void StartGame()
        {
            SetupGame();
            Console.WriteLine("***********************");
            Console.WriteLine("*   Hells Dungeouns   *");
            Console.WriteLine("***********************");
            Console.Write("Enter your Name:");
            Console.ForegroundColor = ConsoleColor.Green;
            player.name = Console.ReadLine();
            if (player.level == 1)
            {
                player.MaxHp();
            }
            Console.ResetColor();
            Console.Clear();

            while (true)
            {
                PrintMenu();
                char input = Console.ReadKey().KeyChar;
                Console.Clear();
                switch (input)
                {
                    case '1':
                        GoAdventure();
                        break;
                    case '2':
                        PlayerStats();
                        break;
                    case '3':
                        GoToShop();
                        break;
                    case '4':
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private void SetupGame()
        {
            Grunt micke = new Grunt();
            Wizard kalle = new Wizard();
            Wizard jonas = new Wizard();
            listOfEnemies.Add(kalle);
            listOfEnemies.Add(jonas);
            listOfEnemies.Add(micke);
        }

        private void GoAdventure()
        {
            Random rand = new Random();
            int fightOrFlee = rand.Next(1, 10);
            if (fightOrFlee == 1)
            {
                Console.WriteLine("You see nothing but trees, boring as fuck");
            }
            else
            {
                int value = rand.Next(listOfEnemies.Count);
                Battle(listOfEnemies[value]);
            }
        }

        private void Battle(Enemy enemy)
        {
            Console.WriteLine("You see a wild " + enemy.Name + " Lurking in the shadows, you raise your blade ready to charge the enemy!");
            Console.ReadKey();
            while (enemy.Alive())
            {            
                Console.Clear();
                Utilitys.PrintGreen($"Your HP:    {player.Hp}");
                Utilitys.PrintRed($"Enemies HP: {enemy.Hp}");               
                Utilitys.PrintGreen("You slash your sword at " + enemy.Name + " dealing " + player.Attack(enemy) + " damage");
                Utilitys.PrintGreen(enemy.Name + " hp is now " + enemy.Hp);
                if (!enemy.Alive())
                {
                    Console.WriteLine(enemy.Name + " is defeated you gain " + enemy.GiveXp() + " XP" + $" and {player.GetGold()} gold");
                    player.GetGold();
                    player.Xp += enemy.Xp;                    
                    enemy.Heal();
                    if (player.CanLevelUp())
                    {
                        player.Hp = 0;
                        player.LevelUp();
                        player.MaxHp();
                    }
                    return;
                } 
                if (player.level == 10)
                {
                    Console.WriteLine($"You are now level 10, you have {player.Xp} XP and {player.Hp}\n\n Congratulations! You won the game :)");
                    Console.ReadKey();
                }
                else if (player.Hp <= 0)
                {
                    Console.WriteLine("You are dead ");
                    Thread.Sleep(1500);
                    Environment.Exit(0);
                }
                Utilitys.PrintRed("The " + enemy.Name + " strikes you for " + enemy.Attack(player));
                Utilitys.PrintRed("Your hp is now " + player.Hp);
                Console.WriteLine("[Press enter to continue]");
                Console.ReadKey();
            }
            Console.ReadKey();
            
        }

        private void PlayerStats()
        {
            Console.WriteLine();
            Console.WriteLine(player.ToString());
            Console.ReadKey();
        }
        private void GoToShop()
        {

        }
        private void PrintMenu()
        {
            Console.WriteLine("1. Go adventuring");
            Console.WriteLine("2. Show details about your character");
            Console.WriteLine("3. Shop");
            Console.WriteLine("4. Exit game");
        }

    }
}
