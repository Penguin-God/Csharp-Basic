using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Basic
{
    public enum PlayerJob
    {
        None = 0,
        Knight = 1,
        Archer = 2,
        Mage = 3,
    }

    class Player : Creature
    {
        protected PlayerJob job = PlayerJob.None;

        protected Player(int _hp, int _damage, PlayerJob _job) : base(_hp, _damage, CreatureType.Player)
        {
            job = _job;
        }

        public PlayerJob GetJob() { return job; }
    }

    class Knight : Player
    {
        public Knight() : base(100, 10, PlayerJob.Knight) { }
    }

    class Archer : Player
    {
        public Archer() : base(75, 12, PlayerJob.Archer){ }
    }
    class Mage : Player
    {
        public Mage() : base(50, 15, PlayerJob.Mage) { }
    }
}
