using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TextBasedRpgProject
{
    class Shop
    {
        public static void LoadShop(Player player)
        {
            RunShop(player);
        }

        public static void RunShop(Player player)
        {
            int PotionPrice;
            int armorPrice;
            int weaponPrice;
           
            
                PotionPrice = 20 + 20 * player.Level;
                armorPrice = 100 * (player.ArmorValue + 1);
                weaponPrice = 100 * (player.WeaponValue+1);
            while (true)
            {
                Console.Clear();
                Utilitys.ShopLogo();
                Utilitys.PrintYellow("----------------------------");
                Utilitys.PrintYellow(" 1. Weapon            $" + weaponPrice + " |");
                Utilitys.PrintYellow(" 2. Armor             $" + armorPrice + " |");
                Utilitys.PrintYellow(" 3. Potion            $" + PotionPrice + "  |");
                Utilitys.PrintYellow(" 4. Go back to menu        |");
                Utilitys.PrintYellow("----------------------------");
                Utilitys.PrintYellow(player.ToString());
                char input = Console.ReadKey().KeyChar;
                switch (input)
                {
                    case '1':
                        TryBuy('1', weaponPrice, player);
                        break;
                    case '2':
                        TryBuy('2', armorPrice, player);
                        break;
                    case '3':
                        TryBuy('3', PotionPrice, player);
                        break;
                    case '4':
                        Console.Clear();
                        return;                     

                }
                
            }
            
        }
        static void TryBuy(char item, int cost, Player player)
        {
            if (player.Gold >= cost)
            {
                if (item == '1')
                {
                    Utilitys.PrintGreen("Your weapon now becomes even more powerfull");
                    Console.ReadKey();
                    player.WeaponValue++;
                }                    
                else if (item == '2')
                {
                    Utilitys.PrintGreen("You gain some armor :)");
                    Console.ReadKey();
                    player.ArmorValue++;
                }                    
                else if (item == '3')
                {
                    Utilitys.PrintGreen($"You bought a potion ");
                    Console.ReadKey();
                    player.Potions++;
                }
                player.Gold-= cost;
            }
            else
            {
                Utilitys.PrintRed("You dont have enough gold");
                Console.ReadKey();
            }
        }

    }
}


