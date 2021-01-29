using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedRpgProject.Enemies
{
    class Vampire : Enemy
    {
        public Vampire(Player player) 
            : base(player)
        {

        }

        public override int Attack()
        {
            return base.Attack()+5;
        }

        public override void ShowChar()
        {
            Utilitys.LogoVampire();
        }
    }
}
