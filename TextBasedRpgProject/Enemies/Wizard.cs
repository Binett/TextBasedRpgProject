

namespace TextBasedRpgProject.Enemies
{
    public class Wizard : Enemy
    {
        public Wizard(Player player)
           : base(player)
        {
            base.Hp = base.MaxHp -= 20;
            base.Type = "Wizard";
        }

        public override int Attack()
        {
            return base.Attack() + 10;
        }

        public override void ShowChar()
        {
            Utilitys.LogoWizard();
        }
    }    
}
