
namespace TextBasedRpgProject.Enemies
{
    class Grunt : Enemy
    {
        public Grunt(Player player)
          : base(player)
        {
            base.MaxHp = 100;
            base.Level = 1;
            base.Type = "Grunt";
        }

        public override void ShowChar()
        {
            Utilitys.LogoGrunt();
        }
    }
}
