using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace TextBasedRpgProject.Enemies
{
    public abstract class Enemy
    {
        protected Enemy()
        {
        }
        static Random rand = new Random();
     

        private string name;
        private bool alive;
        private int hp;
        private int damage;
        private int xp;
        private int maxHp;
        private int level;

        

        public string Name { get; set; }
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
        public int Damage { get => damage; set => damage = value; }
        public int Xp { get => xp; set => xp = value; }
        public int MaxHp { get => maxHp; set => maxHp = value; }
        public bool Alive { get => alive; set => alive = value; }
        public int Level { get => level; set => level = value; }
        public string Name1 { get => name; set => name = value; }
       

        public virtual int Attack(Player player)
        {
            Damage = rand.Next(5, 10) * player.Level;
            if (player.ArmorValue > 0)
            {
                return Damage -= 10 * player.ArmorValue;
            }
            else
            {
                return Damage;
            }            
            
        }
        public virtual void Heal()
        {
            maxHp = maxHp * level;
            hp += MaxHp;
        }
        public virtual int GiveXp(Player player)
        {
            Xp = rand.Next(20, 50);
            return Xp;
        }
        public virtual bool EnemyAlive()
        {
            if (Hp <= 0)
            {
                Alive = false;
            }
            else
            {
                Alive = true;
            }
            return Alive;            
        }
        public virtual void ShowChar()
        {
            Utilitys.LogoRandomEnemy();
        }
        public virtual void EnemyLevel(Player player)
        {
            level = player.Level;
        }
        public void MaxHpEnemy()
        {
            maxHp = 200 * Level;
            Hp = MaxHp;
        }
    }
}
