using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedRpgProject.Enemies
{
    public abstract class Enemy

    {
        public bool Dead;
        private int hp;
        private int damage;
        private int xp;
        private int gold;
        private int maxHp;

        public string Name { get; set; }
        public int Hp { get => hp; set => hp = value; }
        public int Damage { get => damage; set => damage = value; }
        public int Xp { get => xp; set => xp = value; }
        public int Gold { get => gold; set => gold = value; }
        public int MaxHp { get => maxHp; set => maxHp = value; }

        

        protected Enemy()
        {
        }
        public virtual void Heal()
        {
            hp+=maxHp;
        }

        public virtual int Attack(Player player)
        {
            player.TakeDamage(damage);
            return damage;
        }

        public virtual int GiveXp()
        {
            Random rand = new Random();
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
        public void TakeDamage(int damage)
        {
            this.Hp -= damage;
        }     
    }
}
