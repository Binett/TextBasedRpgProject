using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace TextBasedRpgProject.Enemies
{
    class Grunt : Enemy
    {
        public Grunt()
        {
            base.Name = "Wizze";
            base.Hp = 100;
            base.Gold = 100;
            base.Damage = 5;
            base.Dead = false;
            base.MaxHp = 100;
        }

        public override bool Alive()
        {
            return base.Alive();
        }

        public override int Attack(Player player)
        {
            return base.Attack(player);
        }

        public override int GiveXp()
        {
            return base.GiveXp();
        }

        public override void Heal()
        {
            base.Heal();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
