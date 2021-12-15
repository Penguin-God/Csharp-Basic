using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Basic
{
    // Observer Pattern : 특정 이벤트가 발생했을 때 그 구독자들에세 메세지를 뿌리는 방식
    class Test_Event
    {
        public delegate void Click();
        public event Click EventClick;

        public void InputManager()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.A)
                {
                    // 구독한 친구들에게 A를 눌러다고 알려줌
                    // 구독자들은 EventClick() 실행 시 어떤 행동을 취할지 정의하면서 구독함
                    EventClick();
                }
            }
        }
    }
}
