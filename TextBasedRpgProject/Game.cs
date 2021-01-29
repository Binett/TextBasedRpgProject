using System;
using System.Threading;
using System.Xml.XPath;
using TextBasedRpgProject.Enemies;


namespace TextBasedRpgProject
{
    class Game
    {
        Enemy currentEnemy;
        Player player = new Player();


        /*|-----------------------------------------------------------------------------------------------------------------------------------------------------|
         *|---------------------------------------------------------> Start up the game <-----------------------------------------------------------------------|
         *|-----------------------------------------------------------------------------------------------------------------------------------------------------|*/

        public void StartGame()
        {
            Console.Title = "Magic Mayhem";
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
         *|-----------------------------------> Battle or flee method, 10 percents chance of not fighting <-----------------------------------------------------|
         *|-----------------------------------------------------------------------------------------------------------------------------------------------------|*/

        private void GoAdventure()
        {
            Random rand = new Random();
            int fightOrFlee = rand.Next(1, 10);
            if (fightOrFlee == 1)
            {
                Utilitys.PrintGreen("You see nothing but trees, but you gaines 30 experience");
                player.Xp += 30;
                if (player.CanLevelUp())
                {                    
                    player.LevelUp();
                    player.MaxHpPlayer();
                }
            }
            else
            {
                Battle();
            }
        }

        /*|-----------------------------------------------------------------------------------------------------------------------------------------------------|
         *|-----------------------------------------------> Encounters for the battles <------------------------------------------------------------------------|
         *|-----------------------------------------------------------------------------------------------------------------------------------------------------|*/


        private void Battle()
        {
            if (currentEnemy == null)            
            {
                var rand = new Random().Next(0, 3);
                switch (rand)
                {
                    case 0:
                        currentEnemy = new Wizard(player);
                        break;
                    case 1:
                        currentEnemy = new Grunt(player);
                        break;
                    case 2:
                        currentEnemy = new Vampire(player);
                        break;
                }
            }
            Utilitys.PrintRed($"You see a wild {currentEnemy.Type} called {currentEnemy.Name} Lurking in the shadows, you raise your blade ready to charge the enemy!\n");
            currentEnemy.ShowChar();
            Console.WriteLine("[Press enter to continue]");
            Console.ReadKey();
            Console.Clear();      
            currentEnemy.EnemyLevel();
            currentEnemy.MaxHpEnenmy();
            while (currentEnemy.Alive)
            {

                Utilitys.BattleLogo();              
                var playerDamage = player.Attack();
                var enemyDamage = currentEnemy.Attack();
                Utilitys.PrintGreen($"You slash your sword at {currentEnemy.Name} For {playerDamage} dmg!");
                Utilitys.PrintRed($"{currentEnemy.Name} hits {player.Name} for {enemyDamage} dmg!");
                player.Hp -= enemyDamage;
                currentEnemy.Hp -= playerDamage;
                ShowBattle(currentEnemy, player);
                Utilitys.PrintYellow("(H)eal");
                Console.Write("[Press enter to continue]");
                char input = Console.ReadKey().KeyChar;
                if (input == 'h')
                {
                    player.Heal();
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
            Console.Clear();
            player.Gold += player.GetGold();
            player.Xp += currentEnemy.GiveXp();
            Utilitys.PrintGreen($"{currentEnemy.Name} is defeated, you gain {currentEnemy.Xp} XP and {player.GetGold()} gold");
            currentEnemy = null;
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
                Console.WriteLine($"You are now level 10, you have {player.Xp} XP and {player.MaxHp} HP\n Congratulations! You won the game :)");
                Console.ReadKey();
                Environment.Exit(0);
            }
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
