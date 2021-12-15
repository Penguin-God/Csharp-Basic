using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Data_Basic
{
    class Program
    {
        // delegate는 하나의 함수 타입을 만드는 느낌
        // delegate와 비슷한 형식의 함수는 인자로도 사용 가능함
        // c++의 함수 포인터와 유사한 느낌으로 사용됨
        delegate void Del_Test();

        static void OnCilcked(Del_Test testFuc)
        {
            testFuc();
        }

        static void TestDel()
        {
            Console.WriteLine("sadasd");
        }

        static void TestDel2()
        {
            Console.WriteLine("adeqgafa3424124");
        }


        static List<Item> items = new List<Item>();

        static void Main(string[] args)
        {
            Del_Test del_test = null;
            del_test += TestDel;
            del_test += TestDel2;
            del_test();

            // 델리게이트 클리어 하는법 null로 만들기
            del_test = null;
            if (del_test == null) Console.WriteLine("HaHaHa");
            else Console.WriteLine("FUCKING");

            // 에러 뜸
            //del_test();

            // 이벤트
            Test_Event test_Event = new Test_Event();
            test_Event.EventClick += () => Console.WriteLine("Click A");
            
            // 이벤트는 델리게이트와 다르게 외부에서 호출이 불가능하며 구독 혹은 구독 취소만 가능
            // test_Event.EventClick(); // 에러 뜸

            //while (true)
            //{
            //    test_Event.InputManager();
            //}

            // Lambda : 일회용 함수를 만드는 문법

            // 중괄호 쳐서 바로 대입하는것도 가능
            items.Add(new Item { ItemType = ItemType.Weapon, Rarity = Rarity.Normal});
            items.Add(new Item { ItemType = ItemType.Heart, Rarity = Rarity.Unique });
            items.Add(new Item { ItemType = ItemType.Ring, Rarity = Rarity.Epic });

            FindItem(IsWeapon);
            // 익명 함수 문법 : 인자값으로 받는  delegate의 형식에 맞춰서 인자값으로 넘겨줌
            FindItem(delegate (Item item) { return item.ItemType == ItemType.Weapon; });
            FindItem((Item item) => { return item.ItemType == ItemType.Weapon; }); // 얘는 람다식

            // delegate를 직접 만들지 않아도 C#에서 만들어둔 애들을 사용 가능
            // 반환값이 있으면 Func, 없으면 Action 사용

            // Reflection : X-Ray 찍는거, 클래스 내부 정보등을 가져올 수 있음, 디버깅하면서 로그 찍을 때 유용할듯
            Game game = new Game();
            // 모든 객체들은 Object를 상속받기 때문에 기본적으로 가지고 있는 함수가 몇개씩 있음
            Type type = game.GetType();
            var fields = type.GetFields(BindingFlags.Public
                | BindingFlags.NonPublic
                | BindingFlags.Instance);
            foreach (FieldInfo field in fields)
            {
                string access = "Protected"; // IsProtected는 없음
                if (field.IsPublic) access = "Public";
                else if (field.IsPrivate) access = "Private";

                Console.WriteLine($"보호 수준 : {access} \n타입 : {field.FieldType.Name} \n이름 : {field.Name}");
            }

            // type에 점 붙이면 이벤트, 인터페이스, 함수 별의별걸 다 가져올 수 있음
            // type.

            // Reflection은 런타임 중에 스크립트의 필드 정보를 가져올 수 있음.
            // 그렇기에 가져온 필드 정보를 바탕으로 유니티와 같이 변수를 동적으로 조절하는 툴을 만들 때 굉장히 유용함
            // 위에 대괄호 쓰는 []도 어튜리뷰트라는 문법

            // 그지같이 귀찮은 언어인 C++을 쓰는 언리얼은 정말 슬프게도 리플렉션이 없어서
            // 외부 툴을 써서 필드 읽기용 파일을 만드는 등 굉장히 열심히 살고 계심
        }

        class Game
        {
            public string name;
            protected int price;
            private string code;

            void Attack() { }
        }

        // 델리게이트는 타입 그 인자값에 넘길때가 아규먼트 값을 정의하지 않아도 사용 시 정의하면 되므로
        // 인자값 없이 사용 가능
        delegate bool ItemSelector(Item item);

        static bool IsWeapon(Item item)
        {
            return item.ItemType == ItemType.Weapon;
        }

        static Item FindItem(ItemSelector selector)
        {
            foreach(Item item in items)
            {
                if (selector(item)) return item;
            }
            return null;
        }

        enum ItemType
        {
            Weapon,
            Armor,
            Ring,
            Heart,
        } 

        enum Rarity
        {
            Normal,
            Rare,
            Epic,
            Unique,
        }

        class Item
        {
            public ItemType ItemType;
            public Rarity Rarity;
        }
    }
}
