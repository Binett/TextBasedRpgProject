using System;
using System.Threading;
using TextBasedRpgProject.Enemies;

namespace TextBasedRpgProject
{
    public class Player
    {
        static Random rand = new Random();
        private string name;
        private int hp = 200;


        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value == "Robin".ToLower()||value == "Kakashi".ToLower())
                {
                    EnableGodMode();
                }
                name = value;
            }
        }
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
        public int MaxHp { get; set; }
        public int Xp { get; set; } = 0;
        public int Level { get; set; } = 1;
        public int ArmorValue { get; set; } = 0;
        public int WeaponValue { get; set; } = 0;
        public int Potions { get; set; } = 0;


        public int Attack()
        {
            return rand.Next(20, 30) * (WeaponValue + 1);
        }
        public int GetGold()
        {
            return rand.Next(30, 50) * Level;
        }
        public override string ToString()
        {
            return $"Name: {Name}\n" +
                $"Level: {Level}\n" +
                $"Gold: {Gold}\n" +
                $"Potions {Potions}\n" +
                $"Armor {ArmorValue}\n" +
                $"Weapon {WeaponValue}\n";
        }
        public int XpToLevel()
        {
            return 100 * Level +50;
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
            MaxHp = 200 * Level;
            Hp = MaxHp;
        }
        public void Heal()
        {
            if (this.Potions == 0)
            {
                Console.WriteLine("You dont have any potions");
                Thread.Sleep(2000);
            }
            else
            {
                hp = MaxHp;
                Potions--;
            }

        }
        private void EnableGodMode()
        {
            ArmorValue = 100;
            WeaponValue = 100;
            Potions = 20;
            Level = 8;
        }

    }
}
