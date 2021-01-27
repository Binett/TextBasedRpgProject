using System;

namespace TextBasedRpgProject.Enemies
{
    class Grunt : Enemy
    {
            

        public Grunt()
        {
            base.Name = Utilitys.RandomName();
            base.Hp = 100;            
            base.Alive = false;
            base.MaxHp = 100;
            base.Level = 1;
            base.Type = "Grunt";
        }

        public override bool EnemyAlive()
        {
            return base.EnemyAlive();
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

        public override int Attack(Player player)
        {
            return base.Attack(player);
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
