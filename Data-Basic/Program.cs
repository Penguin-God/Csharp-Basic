using System;
using System.Collections.Generic;

namespace Data_Basic
{
    class Program
    {
        static void Main(string[] args)
        {
            // 일반화
            // var는 컴파일러가 값을 보고 때려 맞춰서 선언하는것 int, string과 같은 자료형을 앞에 붙이는 것과 똑같음
            var var1 = 3;
            var var2 = "hi";

            // 오브젝트는 말 그대로 object라는 독립적인 타입 각각의 타입으로 알아서 변환해주는 var와 완전히 다른 개념
            // 이렇게 사용할 수 있는 이유는 C#의 모든 자료형이 object를 상속받기 때문에 다형성을 이용한 것
            // 대신 오브젝트는 참조 타입으로 힙에 저장됨
            object obj1 = 3;
            object obj2 = "hi";

            MyList<int> myIntList = new MyList<int>();
            myIntList.GetItem(0);

            Kni kni = new Kni();
            kni.Hp = 300;
            //kni.HP = 2013;
            Console.WriteLine(kni.HP);



            // 예외 처리
            // 게임에서는 에러를 놔두고 Crash나면 빠르게 고치는게 나은 경우가 많음. 이건 경험상으로도 맞는 듯 로그가 뜨는게 고치기 쉬움
            // 하지만 네트워크, 멀티 접속 실패 등은 재시도를 위해 쓰기도 함

            int c = -1;
            try
            {
                // 1. null을 참조했다
                // 2. 무한 루프를 돈다(오버 플로우)
                // 3. 어떠한 값을 0으로 나눴다.
                int a1 = 0;
                int b = 22;

                c = b / a1;
            }
            catch (DivideByZeroException)
            {
                c = 0;
            }
            catch(Exception e) // 모든 에러의 대가리 하위 에러 순서 위에 쓰면 에러 뜸
            {
                
            }
            finally // 마지막에 무조건 실행하는 문법 else, defualt와 같은 느낌
            {

            }
            Console.WriteLine(c);

            // Nullable : ?를 붙이면 널이된다. null이 되지않는 값 타입들도 null로 만들어버림
            int? number = null;
            // Nullable은 바로 변환 못하고 캐스팅하거나 .Value를 붙여야 됨
            int a = number.Value;

            int t = a + number.Value;

            // 만약 number가 null이라면 123을 넣고 아니라면 number.Value를 넣어라
            int aaa = number ?? 123;
        }

        // 일반화 문법 : 모든 타입에 대응 및 실행됨
        class MyList<T>
        {
            public T[] list = new T[10];

            public T GetItem(int index)
            {
                return list[index];
            }

            // 함수에서의 사용
            public void Test<Ty>(Ty item)
            {

            }
        }

        // 프로퍼티
        class Kni
        {
            protected int hp = 100;
            //bool isGod = false;
            public int Hp
            {
                get { return hp; }
                set { hp = value; }
            }

            // 자동 구현 및 초기화 위에 Hp와 완전히 똑같음 기본은 public
            public int HP { get; set; } = 100;

            // 하나 없애는 것도 가능
            public int NoChangeHP { get; } = 100;
        }
    }
}
