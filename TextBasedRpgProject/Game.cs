using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using TextBasedRpgProject.Enemies;


namespace TextBasedRpgProject
{
    class Game
    {
        List<Enemy> listOfEnemies = new List<Enemy>();
        static Player player = new Player();
        

        /*|-----------------------------------------------------------------------------------------------------------------------------------------------------|
         *|---------------------------------------------------------> Start up the game <-----------------------------------------------------------------------|
         *|-----------------------------------------------------------------------------------------------------------------------------------------------------|*/

        public void StartGame()
        {
            Console.Title = "Magic Mayhem";
            SetupGame();
            Utilitys.MainLogo();
            Console.Write("Enter your Name:");
            Console.ForegroundColor = ConsoleColor.Green;
            player.Name = Console.ReadLine();    
            
            player.MaxHpPlayer();

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
                        Utilitys.PrintGreen("Thanks for playing, please come again!!!");
                        Console.WriteLine();
                        Environment.Exit(0);
                        break;
                }
            }
        }

        /*|-----------------------------------------------------------------------------------------------------------------------------------------------------|
         *|-------------------------------------------------> objects of the enemies <--------------------------------------------------------------------------|
         *|-----------------------------------------------------------------------------------------------------------------------------------------------------|*/

        private void SetupGame()
        {
            Grunt micke = new Grunt();
            Wizard jonas = new Wizard();
            listOfEnemies.Add(jonas);
            listOfEnemies.Add(micke);
        }

        /*|-----------------------------------------------------------------------------------------------------------------------------------------------------|
         *|-----------------------------------> Battle or flee method, 10 percents chance of not fighting <-----------------------------------------------------|
         *|-----------------------------------------------------------------------------------------------------------------------------------------------------|*/

        private void GoAdventure()
        {
            Random rand = new Random();
            int fightOrFlee = rand.Next(1, 10);
            if (fightOrFlee == 1)
            {
                Console.WriteLine("You see nothing but trees, but you gaines some experience");
                
            }
            else
            {
                int value = rand.Next(listOfEnemies.Count);              
                Battle(listOfEnemies[value], player);
            }
        }

        /*|-----------------------------------------------------------------------------------------------------------------------------------------------------|
         *|-----------------------------------------------> Encounters for the battles <------------------------------------------------------------------------|
         *|-----------------------------------------------------------------------------------------------------------------------------------------------------|*/


        private void Battle(Enemy enemy, Player player)
        {           
            Utilitys.PrintRed("You see a wild " + enemy.Name + " Lurking in the shadows, you raise your blade ready to charge the enemy!\n");
            enemy.ShowChar();
            Console.WriteLine("[Press enter to continue]");
            Console.ReadKey();
            Console.Clear();
            enemy.EnemyLevel(player);
            enemy.MaxHpEnemy();
            while (enemy.EnemyAlive())
            {
                
                Utilitys.PrintRed(@"██████╗  █████╗ ████████╗████████╗██╗     ███████╗
██╔══██╗██╔══██╗╚══██╔══╝╚══██╔══╝██║     ██╔════╝
██████╔╝███████║   ██║      ██║   ██║     █████╗  
██╔══██╗██╔══██║   ██║      ██║   ██║     ██╔══╝  
██████╔╝██║  ██║   ██║      ██║   ███████╗███████╗
╚═════╝ ╚═╝  ╚═╝   ╚═╝      ╚═╝   ╚══════╝╚══════╝
");
                enemy.Hp -= player.Attack();
                player.Hp -= enemy.Attack(player);
                Utilitys.PrintGreen($"You slash your sword at {enemy.Name} For {player.Damage} dmg!");
                Utilitys.PrintRed($"{enemy.Name} hits {player.Name} for {enemy.Damage} dmg!");
                ShowBattle(enemy, player);
                Utilitys.PrintYellow("(H)eal");
                Console.Write("[Press enter to continue]");
                char input = Console.ReadKey().KeyChar;
                if (input == 'h')
                {
                    player.Heal(player);
                }


                if (!enemy.EnemyAlive())
                {
                    Console.Clear();
                    player.Gold += player.GetGold();
                    player.Xp += enemy.GiveXp(player);
                    Utilitys.PrintGreen($"{enemy.Name} is defeated, you gain {enemy.Xp} XP and {player.GetGold()} gold");                   
                    enemy.Heal();
                    Console.WriteLine("[Press enter to continue]");
                    Console.ReadKey();
                    Console.Clear();

                    if (player.CanLevelUp())
                    {
                        player.Hp = 0;
                        player.LevelUp();
                        player.MaxHpPlayer();
                    }
                    if (player.Level >= 10)
                    {
                        Console.WriteLine($"You are now level 10, you have {player.Xp} XP and {player.Hp}\n Congratulations! You won the game :)");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                    return;

                }
                else if (player.Hp <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("You are dead ");
                    Thread.Sleep(1500);
                    Environment.Exit(0);
                }
                Console.Clear();
            }

            Console.ReadKey();
        }

        /*|------------------------------------------------------------------------------------------------------------------------------------------------------|
         *|------------------------------------------------> Player and Enemy healthbars <-----------------------------------------------------------------------|
         *|------------------------------------------------------------------------------------------------------------------------------------------------------|*/

        private void ShowBattle(Enemy enemy, Player player)
        {
            Console.WriteLine($"Your health\t\t\tHP:{player.Hp}/{player.MaxHp}");
            Utilitys.HealtBar(player, (decimal)player.Hp / (decimal)player.MaxHp, 40);
            Console.WriteLine($"Enemies health\t\t\tHP:{enemy.Hp}/{enemy.MaxHp}");
            Utilitys.HealtBar(enemy, (decimal)enemy.Hp / (decimal)enemy.MaxHp, 40);
        }

        /*|-----------------------------------------------------------------------------------------------------------------------------------------------------|
         *|-----------------------------------------------> Show details about the player <---------------------------------------------------------------------|
         *|-----------------------------------------------------------------------------------------------------------------------------------------------------|*/

        private void PlayerStats()
        {

            Utilitys.MainLogo();
            Console.WriteLine(player.ToString());
            Console.WriteLine($"Your health\t\t\tHP:{player.Hp}/{player.MaxHp}");
            Utilitys.HealtBar(player, (decimal)player.Hp / (decimal)player.MaxHp, 40);
            Utilitys.ProgressBar(player, (decimal)player.Xp / (decimal)player.XpToLevel(), 40);
            Console.ReadKey();
            Console.Clear();
        }

        /*|-----------------------------------------------------------------------------------------------------------------------------------------------------|
         *|------------------------------------------------------> Go shopping :) <-----------------------------------------------------------------------------|
         *|-----------------------------------------------------------------------------------------------------------------------------------------------------|*/

        private void GoToShop()
        {
            Shop.LoadShop(player);
        }

        /*------------------------------------------------------------------------------------------------------------------------------------------------------|
         * ---------------------------* Show menu and call the progressbar and health bar from the utility class  *---------------------------------------------|
         * -----------------------------------------------------------------------------------------------------------------------------------------------------|*/

        private void PrintMenu()
        {
            Utilitys.MainLogo();
            Console.WriteLine();
            Console.WriteLine("1. Go adventuring");
            Console.WriteLine("2. Show details about your character");
            Console.WriteLine("3. Shop");
            Console.WriteLine("4. Exit game\n");
            Utilitys.ProgressBar(player, (decimal)player.Xp / (decimal)player.XpToLevel(), 40);
            Console.WriteLine($"Current HP:\t\t {player.Hp}/{player.MaxHp}");
            Utilitys.HealtBar(player, (decimal)player.Hp / (decimal)player.MaxHp, 40);
        }


    }
}
