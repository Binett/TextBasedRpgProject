using System;
using System.Collections.Generic;
using System.Text;

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
            int potionPower;
            int armorPower;
            int weaponPower;
           
            
                potionPower = 20 + 10 * player.Level;
                armorPower = 100 * (player.ArmorValue + 1);
                weaponPower = 100 * (player.WeaponValue+1);
            while (true)
            {
                Console.Clear();
                Utilitys.ShopLogo();
                Utilitys.PrintYellow("----------------------------");
                Utilitys.PrintYellow(" 1. Weapon            $" + weaponPower + " |");
                Utilitys.PrintYellow(" 2. Armor             $" + armorPower + " |");
                Utilitys.PrintYellow(" 3. Potion            $" + potionPower + "  |");
                Utilitys.PrintYellow("----------------------------");
                Utilitys.PrintYellow(player.ToString());
                char input = Console.ReadKey().KeyChar;
                switch (input)
                {
                    case '1':
                        TryBuy('1', weaponPower, player);
                        break;
                    case '2':
                        TryBuy('2', armorPower, player);
                        break;
                    case '3':
                        TryBuy('3', potionPower, player);
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
                    player.WeaponValue++;
                }                    
                else if (item == '2')
                {
                    player.ArmorValue++;
                }                    
                else if (item == '3')
                {
                    player.Potions++;
                }
                player.Gold-= cost;
            }
            else
            {
                Console.WriteLine("You dont have enough gold");
                Console.ReadKey();
            }
        }

    }
}


