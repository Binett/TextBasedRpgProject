using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace TextBasedRpgProject.Enemies
{
    class Grunt : Enemy
    {
        Random rand = new Random();
        public Grunt()
        {
            base.Name = "Gurgel";
            base.Hp = 100;            
            base.Dead = false;
            base.MaxHp = 100;
            base.Level = 1;
        }

        public override bool Alive()
        {
            return base.Alive();
        }

        public override int GiveXp(Player player)
        {
            return base.GiveXp(player);
        }

        public override void Heal()
        {
            base.Heal();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override int Attack()
        {
            return base.Attack();
        }

        public override void ShowChar()
        {
            Utilitys.LogoGrunt();
        }


        public override void EnemyLevel(Player player)
        {
            base.EnemyLevel(player);
        }
       
    }
}
