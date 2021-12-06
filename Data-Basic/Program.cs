using System;

namespace Data_Basic
{
    // 절차(함수) 지향
    class Program
    {
        // class 생성법
        class Knight
        {
            public int hp;
            public int damage;

            public void Attack()
            {
                Console.WriteLine($"Attack!!! On {damage} damage");
            }
        }
        static void Main(string[] args)
        {
            Knight knight = new Knight();
            knight.hp = 100;
            knight.damage = 10;

            knight.Attack();
        }
    }
}
