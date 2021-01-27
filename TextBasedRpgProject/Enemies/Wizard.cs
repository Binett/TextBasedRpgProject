using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Markup;

namespace TextBasedRpgProject.Enemies
{
    public class Wizard : Enemy
    {
        
        Random rand = new Random();   

        public Wizard()
        {
            base.Name = "Aja vist";
            base.Hp = 100;        
            base.Dead = false;
            base.MaxHp=100;
            base.Level= 1;            
        }
      

        public override bool Alive()
        {
            return base.Alive();
        }

        public override int Attack()
        {
            return base.Attack();
        }

        public override void EnemyLevel(Player player)
        {
            base.EnemyLevel(player);
        }

        public override int GiveXp(Player player)
        {
            return base.GiveXp(player);
        }

        public override void Heal()
        {
            base.Heal();
        }

        public override void ShowChar()
        {
            Utilitys.LogoWizard();
        }
    }    
}
