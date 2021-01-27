using System;
using System.Text.RegularExpressions;
using System.Threading;
using TextBasedRpgProject.Enemies;

namespace TextBasedRpgProject
{
    public class Player
    {
        //TODO: Skapa godmode
        static Random rand = new Random();        
       
        private string name;
        private int maxHp=250;
        private int damage;
        private int level = 1;
        public int hp = 200;
        private int xp = 0;
        private int armorValue=0;
        private int weaponValue=0;
        private int potions = 0;
             


        public int Hp 
        {
            get
            {
                return hp;
            }
            set
            {
                if (value > 0)
                {
                    hp = value;
                }
                else
                {
                     hp = 0;
                }
            }
        }        
        public int Gold { get; set; }
        public int Damage { get => damage; set => damage = value; }
        public int MaxHp { get => maxHp; set => maxHp = value; } 
        public string Name { get => name; set => name = value; }
        public int Xp { get => xp; set => xp = value; }
        public int Level { get => level; set => level = value; }
        public int ArmorValue { get => armorValue; set => armorValue = value; }       
        public int WeaponValue { get => weaponValue; set => weaponValue = value; }
        public int Potions { get => potions; set => potions = value; }
  

        public int Attack()
        {
            if (WeaponValue<=0)
            {
                return Damage = rand.Next(20, 30);
            }
            else
            {
                return Damage = rand.Next(20, 30) * (weaponValue+1);
            }
        }
        public int GetGold()
        {
            return rand.Next(30, 50)*Level;            
        }       
        public override string ToString()
        {
            return $"Name: {Name}\n" +
                $"Level: {Level}\n" +
                $"Gold: {Gold}\n" +
                $"Potions {Potions}\n" +
                $"Armor {ArmorValue}\n" +
                $"Weapon {weaponValue}\n";
        }
        public int XpToLevel()
        {
            return 100 * Level;
        }
        public bool CanLevelUp()
        {
            if (Xp >= XpToLevel())
            {
                return true;
            }
            else
            {
                return false;
            }     
        }
        public void LevelUp()
        {
            while (CanLevelUp())
            {
                Xp -= XpToLevel();
                MaxHp += Hp * Level;
                Level++;
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Utilitys.PrintGreen("Congratulations you've now reached " + Level + " !");
            Console.ResetColor();
        }
        public void MaxHpPlayer()
        {
            maxHp = 200*Level;
            Hp = MaxHp;
        }
        public void Heal(Player player)
        {
            if (player.potions == 0)
            {
                Console.WriteLine("You dont have any potions");
                Thread.Sleep(2000);          
            }
            else
            {
                hp = maxHp;
                potions--;
            }          
                
        }
 
    }
}
