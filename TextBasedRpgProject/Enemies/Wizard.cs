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
            base.Name = "Wizze";
            base.Hp = 100;
            base.Gold = 100;
            base.Damage = 5;
            base.Dead = false;
            base.MaxHp=100;
        }

        public override bool Alive()
        {
            return base.Alive();
        }

        public override int GiveXp()
        {
            return base.GiveXp();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }


}
