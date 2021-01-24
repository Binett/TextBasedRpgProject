using System;
using TextBasedRpgProject.Enemies;

namespace TextBasedRpgProject
{
    public class Player
    {
        static Random rand = new Random(); 
        
        public string name;
        public int maxHp;
        public int damage;
        public int level = 1;
        public int hp;
        public int xp = 0;

        public int Level { get; set; } = 1;        
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
        public int Xp { get; set; }
        public int Damage { get; set; }
        public int Gold { get; set; }

        public int GetGold()
        {
            return rand.Next(30, 50)*level;
            
        }
        public int Attack(Enemy enemy)
        {
            enemy.TakeDamage(rand.Next(20,40));
            return Damage;
        }
        public void TakeDamage(int enemyDamage)
        {
            this.Hp -= enemyDamage*level;
        }
        public override string ToString()
        {
            return $"Name: {name}\n" +                
                $"Level: {level}\n" +
                $"Gold: {Gold}";
        }
        public int XpToLevel()
        {
            return  level * 100;
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
                maxHp += Hp * level;
                level++;
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Utilitys.PrintGreen("Congratulations you've now reached " + level + " !");
            Console.ResetColor();
        }
        public void MaxHp()
        {
            maxHp = 200*level;
            Hp = maxHp;
        }
    }
}
