using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Markup;

namespace TextBasedRpgProject.Enemies
{
    public class Wizard : Enemy
    {
        

        public Wizard()
        {
            base.Name = Utilitys.RandomName();
            base.Hp = 100;        
            base.Alive = false;            
            base.MaxHp=100;
            base.Level= 1;
            base.Type = "Wizard";
        }
        

        public override bool EnemyAlive()
        {
            return base.EnemyAlive();
        }

        //public override int Attack()
        //{
        //    return base.Attack();
        //}

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
