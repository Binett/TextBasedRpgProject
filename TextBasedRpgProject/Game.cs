using System;
using System.Collections.Generic;
using System.Threading;
using TextBasedRpgProject.Enemies;

namespace TextBasedRpgProject
{
    class Game
    {
        List<Enemy> listOfEnemies = new List<Enemy>();
        Player player = new Player();

        /*|-----------------------------------------------------------------------------------------------------------------------------------------------------|
         *|---------------------------------------------------------> Start up the game <-----------------------------------------------------------------------|
         *|-----------------------------------------------------------------------------------------------------------------------------------------------------|*/

        public void StartGame()
        {
            Console.Title = "Magic Mayhem";
            SetupGame();
            Logo();
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
                Console.WriteLine("You see nothing but trees, boring as fuck");
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
            Utilitys.PrintRed(@"  			,---.
                       /    |
                      /     |

                   /      |
                    /       |
               ___, '        |
             < -'          :
              `-.__..--'``-,_\_
                 | o / ` :,.)_`>
                 :/ `     ||/)
                 (_.).__,-` |\
                 / ( `.``   `| :
                 \'`-.)  `  ; ;
                 | `       / -<
                 |     `  /   `.
 ,-_ - ..____ /|  `    :__..-'\

/,'-.__\\  ``-./ :`      ;       \
`\ `\  `\\  \ :  (   `  /  ,   `. \
  \` \   \\   |  | `   :  :     .\ \
   \ `\_  ))  :  ;     |  |      ): :
  (`-.- '\ ||  |\ \   ` ;  ;       | |
   \-_   `; ;._( `  /  / _ | |
     `-.-.// ,'`-._\__/_,'         ; |
       \:: :     /     `     ,   /  |
 
         || | (        , ' /   /   |
         ||                , '   /    |");

            Console.WriteLine("[Press enter to continue]");
            Console.ReadKey();
            Console.Clear();
            while (enemy.Alive())
            {
                Utilitys.PrintRed(@"██████╗  █████╗ ████████╗████████╗██╗     ███████╗
██╔══██╗██╔══██╗╚══██╔══╝╚══██╔══╝██║     ██╔════╝
██████╔╝███████║   ██║      ██║   ██║     █████╗  
██╔══██╗██╔══██║   ██║      ██║   ██║     ██╔══╝  
██████╔╝██║  ██║   ██║      ██║   ███████╗███████╗
╚═════╝ ╚═╝  ╚═╝   ╚═╝      ╚═╝   ╚══════╝╚══════╝
");
                Utilitys.PrintGreen($"You slash your sword at {enemy.Name} dealing {player.Attack(enemy)} damage\n");
                Utilitys.PrintRed($"The {enemy.Name} strikes you for {enemy.Attack(player)}\n");
                ShowBattle(enemy, player);
                Console.WriteLine("[Press enter to continue]");
                Console.ReadKey();
                if (!enemy.Alive())
                {
                    player.Gold += player.GetGold();
                    Utilitys.PrintGreen($"{enemy.Name} is defeated, you gain {enemy.GiveXp() * player.level} XP and {player.GetGold()} gold");
                    player.Xp += enemy.Xp * player.level;
                    enemy.Heal();
                    Console.WriteLine("[Press enter to continue]");
                    Console.ReadKey();
                    Console.Clear();

                    if (player.CanLevelUp())
                    {
                        player.Hp = 0;
                        player.LevelUp();
                        player.MaxHp();
                    }
                    return;
                }
                if (player.level >= 10)
                {
                    Console.WriteLine($"You are now level 10, you have {player.Xp} XP and {player.Hp}\n Congratulations! You won the game :)");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else if (player.Hp <= 0)
                {
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
            Console.WriteLine($"Your health\t\t\tHP:{player.Hp}/{player.maxHp}");
            Utilitys.HealtBar(player, (decimal)player.Hp / (decimal)player.maxHp, 40);
            Console.WriteLine($"Enemies health\t\t\tHP:{enemy.Hp}/{enemy.MaxHp}");
            Utilitys.HealtBar(enemy, (decimal)enemy.Hp / (decimal)enemy.MaxHp, 40);
        }

        /*|-----------------------------------------------------------------------------------------------------------------------------------------------------|
         *|-----------------------------------------------> Show details about the player <---------------------------------------------------------------------|
         *|-----------------------------------------------------------------------------------------------------------------------------------------------------|*/

        private void PlayerStats()
        {

            Logo();
            Console.WriteLine(player.ToString());
            Console.WriteLine($"Your health\t\t\tHP:{player.Hp}/{player.maxHp}");
            Utilitys.HealtBar(player, (decimal)player.Hp / (decimal)player.maxHp, 40);
            Utilitys.ProgressBar(player, (decimal)player.Xp / (decimal)player.XpToLevel(), 40);
            Console.ReadKey();
            Console.Clear();
        }

        /*|-----------------------------------------------------------------------------------------------------------------------------------------------------|
         *|------------------------------------------------------> Go shopping :) <-----------------------------------------------------------------------------|
         *|-----------------------------------------------------------------------------------------------------------------------------------------------------|*/

        private void GoToShop()
        {

        }

        /*------------------------------------------------------------------------------------------------------------------------------------------------------|
         * -----------------------------------* Show menu and call the progressbar from the utility class  *----------------------------------------------------|
         * -----------------------------------------------------------------------------------------------------------------------------------------------------|*/

        private void PrintMenu()
        {
            Logo();
            Console.WriteLine();
            Console.WriteLine("1. Go adventuring");
            Console.WriteLine("2. Show details about your character");
            Console.WriteLine("3. Shop");
            Console.WriteLine("4. Exit game\n");
            Utilitys.ProgressBar(player, (decimal)player.Xp / (decimal)player.XpToLevel(), 40);
            Console.WriteLine($"Current HP:\t\t {player.hp}/{player.maxHp}");
            Utilitys.HealtBar(player, (decimal)player.hp / (decimal)player.maxHp, 40);
        }

        private void Logo()
        {
            Console.WriteLine();
            Utilitys.PrintYellow(@"███╗   ███╗ █████╗  ██████╗ ██╗ ██████╗    ███╗   ███╗ █████╗ ██╗   ██╗██╗  ██╗███████╗███╗   ███╗
████╗ ████║██╔══██╗██╔════╝ ██║██╔════╝    ████╗ ████║██╔══██╗╚██╗ ██╔╝██║  ██║██╔════╝████╗ ████║
██╔████╔██║███████║██║  ███╗██║██║         ██╔████╔██║███████║ ╚████╔╝ ███████║█████╗  ██╔████╔██║
██║╚██╔╝██║██╔══██║██║   ██║██║██║         ██║╚██╔╝██║██╔══██║  ╚██╔╝  ██╔══██║██╔══╝  ██║╚██╔╝██║
██║ ╚═╝ ██║██║  ██║╚██████╔╝██║╚██████╗    ██║ ╚═╝ ██║██║  ██║   ██║   ██║  ██║███████╗██║ ╚═╝ ██║
╚═╝     ╚═╝╚═╝  ╚═╝ ╚═════╝ ╚═╝ ╚═════╝    ╚═╝     ╚═╝╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝╚══════╝╚═╝     ╚═╝
");

        }


    }
}
