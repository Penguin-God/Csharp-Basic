using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Basic
{
    public enum MonsterType
    {
        None = 0,
        Slime = 1,
        Orc = 2,
        Skeleton = 3,
    }

    class Monster : Creature
    {
        MonsterType type = MonsterType.None;

        protected Monster(int _hp, int _damage, MonsterType _type) : base(_hp, _damage, CreatureType.Monster)
        {
            type = _type;
        }
    }

    class Slime : Monster
    {
        public Slime() : base(10, 10, MonsterType.Slime) { }
    }

    class Orc : Monster
    {
        public Orc() : base(20, 15, MonsterType.Orc) { }
    }

    class Skeleton : Monster
    {
        public Skeleton() : base(15, 25, MonsterType.Skeleton) { }
    }
}
