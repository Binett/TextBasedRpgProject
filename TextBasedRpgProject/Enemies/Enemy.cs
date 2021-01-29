using System;

namespace TextBasedRpgProject.Enemies
{


    public abstract class Enemy
    {
        protected Enemy(Player player)
        {
            this.player = player;
            //generates name
            var names = new string[]
        {
                "Mantingamp","Minolpuemp","Yelpio","Suchnei","Sanavu","Wavern","Scoogriff","Bohan","Vrootc","Poadriuz","Kalphan",
            "Heophan","Gnunae","Racander","Chialsum","Qossonan","Lolasum","Loretid","Zunulid","Kalipian"
        };
            var rand = new Random();
            var index = rand.Next(names.Length);
            this.Name = names[index];
        }

        static Random rand = new Random();
        private Player player;

        private int hp = 100;

        public string Name { get; set; }
        public int Hp

        {
            get
            {
                return hp;
            }
            set
            {
                if (value > 0)
                {
                    hp = value;
                }
                else
                {
                    hp = 0;
                }
            }
        }
        public int Xp { get; set; }
        public int MaxHp { get; set; } = 100;
        public bool Alive { get { return hp > 0; } }
        public int Level { get; set; }
        public string Type { get; set; }
        public virtual int Attack()
        {
            var damage = rand.Next(5, 10) * player.Level - 3 * player.ArmorValue;
            return damage < 0 ? 0 : damage;
        }
        public virtual int GiveXp()
        {
            Xp = rand.Next(30, 50) * Level;
            return Xp;
        }
        public virtual void ShowChar()
        {
            Utilitys.LogoRandomEnemy();
        }
        public virtual void EnemyLevel()
        {
            Level = player.Level;
        }
        public void MaxHpEnenmy()
        {
            MaxHp *= Level;
            Hp = MaxHp;
        }


    }
}
