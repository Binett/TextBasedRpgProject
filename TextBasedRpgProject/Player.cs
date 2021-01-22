using System;
using System.Collections.Generic;
using System.Text;
using TextBasedRpgProject.Enemies;

namespace TextBasedRpgProject
{
    public class Player
    {
        static Random rand = new Random();
        public int gold;
        public string name;
        public int maxHp =200;
        public int coins=0;
       

        public int level { get; set; } = 1;
        public int Hp { get; set; }        
        public int Xp { get; set; } = 0;
        public int Damage { get; set; } = rand.Next(20,50);
        public int Gold { get; set; }
        

        public int GetGold()
        {
            coins += rand.Next(30, 50)*level;
            return coins;
        }
        public int Attack(Enemy enemy)
        {
            enemy.TakeDamage(Damage);
            return Damage;
        }
        public void TakeDamage(int enemyDamage)
        {
            this.Hp -= enemyDamage*level;
        }
        public override string ToString()
        {
            return $"Name: {name}\n" +
                $"HP: {Hp}\n" +
                $"XP: {Xp}\n" +
                $"Level: {level}\n" +
                $"Gold: {coins}";
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
            Hp = (maxHp * level);
        }
    }
}
