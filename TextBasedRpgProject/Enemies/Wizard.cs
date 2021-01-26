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
        }

        public override bool Alive()
        {
            return base.Alive();
        }

        public override int GiveXp()
        {
            return base.GiveXp();
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
