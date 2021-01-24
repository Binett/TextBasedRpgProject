using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Markup;

namespace TextBasedRpgProject.Enemies
{
    internal class Wizard : Enemy
    {
        
        Random rand = new Random();
        
        public Wizard()
        {
            base.Name = "Aja visst";
            base.Hp = 100;            
            base.Damage = 0;
            base.Dead = false;
            base.MaxHp=100;
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


    }    
}
