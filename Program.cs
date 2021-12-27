using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Data_Basic
{
    class Program
    {

        delegate void Del_Test(int a);

        static void OnCilcked(Action action)
        {
            Console.WriteLine("Hello Delegate");
            action();
        }

        static void TestDel()
        {
            Console.WriteLine("1");
        }

        static void TestDel2()
        {
            Console.WriteLine("2");
        }

        class MainPlayer
        {
            int hp  = 100;
            public int Hp
            {
                get { return hp; }
                set { hp = value; }
            }

            public long GameID { get; }
            public bool IsDead { get { return hp <= 0; } }

            // 자동 구현 및 초기화 위에 Hp와 완전히 똑같음 기본은 public
            public int HP { get; set; } = 100;

            // 하나 없애는 것도 가능
            public int NoChangeHP { get; } = 100;
        }

        static void Main(string[] args)
        {
            Action act_test = null;
            act_test += TestDel;
            act_test += TestDel2;

            OnCilcked(act_test);
        }
    }
}