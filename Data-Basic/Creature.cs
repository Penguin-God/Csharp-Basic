using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Basic
{
    public enum CreatureType
    {
        None = 0,
        Player = 1,
        Monster = 2,
    }

    class Creature
    {
        CreatureType type = CreatureType.None;

        protected int hp = 0;
        protected int damage = 0;

        protected Creature(int _hp, int _damage, CreatureType _type)
        {
            hp = _hp;
            damage = _damage;
            type = _type;
        }

        public int GetHp() { return hp; }
        public int GetDamage() { return damage; }
        public bool IsDead { get { return hp <= 0; } }

        public void OnDamaeg(int damage)
        {
            hp -= damage;
            if (IsDead) hp = 0;
        }
    }
}
