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
        



        private bool dead;
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
        public bool Dead { get => dead; set => dead = value; }
        public int Level { get => level; set => level = value; }

        public virtual int Attack()
        {
            Damage = rand.Next(5, 10)*level;
            return Damage;
        }
        public virtual void Heal()
        {
            hp += maxHp;
        }
        public virtual int GiveXp(Player player)
        {            
            Xp = rand.Next(20, 50);
            return Xp;
        }
        public virtual bool Alive()
        {
            if (Hp <= 0)
            {
                Dead = false;
            }
            else
            {
                Dead = true;
            }
            return Dead;
        }
        public virtual void ShowChar()
        {
            Utilitys.LogoRandomEnemy();
        }
        public virtual void EnemyLevel(Player player)
        {
            level = player.Level;
        }
    }
}
