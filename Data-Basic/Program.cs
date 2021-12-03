using System;

namespace Data_Basic
{
    class Program
    {
        enum Chioce // 만약 따로 지정을 안하면 처음부터 0, 1, 2 순으로 올라감
        {
            Rock = 1,
            Paper = 2,
            Scissors = 0,
        }

        // Main 함수는 언어 불문하고 모든 프로그램 내에 하나만 있어야 하는 함수
        static void Main(string[] args)
        {
            // break point 설정 후 F10 누르면 1줄씩 넘어가면서 코그의 흐름을 볼 수 있음
            for(int i = 1; i < 200; i++)
            {
                if (i % 3 != 0) continue;

                Console.WriteLine("3으로 나눠진드아~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            }

            // 가위바위보 게임
            Random rand = new Random();
            int randomNumber = rand.Next(0, 3);

            int playerChioce = Convert.ToInt32(Console.ReadLine());

            // 스위치 문에 직접 상수를 때려박는 하드코딩은 후에 값을 바꿔야할때 힘들 수 있으므로 지양하기
            // 스위치 문에는 조건에 변수가 못들어감, 하지만 상수나(readonly) 열거형 상수처럼 값이 바뀌지 않는 건 가능 
            switch (playerChioce)
            {
                // 타입이 Chioce이므로 int로 바꿔야함
                case (int)Chioce.Scissors: Console.WriteLine("당신의 선택 : 가위"); break;
                case (int)Chioce.Rock: Console.WriteLine("당신의 선택 : 바위"); break;
                case (int)Chioce.Paper: Console.WriteLine("당신의 선택 : 보"); break;
            }

            Console.WriteLine("결과를 보고 싶으면 엔터!!");
            Console.ReadLine();

            switch (randomNumber)
            {
                case (int)Chioce.Scissors: Console.WriteLine("에너미의 선택 : 가위"); break;
                case (int)Chioce.Rock: Console.WriteLine("에너미의 선택 : 바위"); break;
                case (int)Chioce.Paper: Console.WriteLine("에너미의 선택 : 보"); break;
            }

            string text;

            // 내가 짠 버전
            //if (playerChioce == randomNumber) text = "우왕 비겼다. 서로 결혼하셈";
            //else if (playerChioce == (int)Chioce.Scissors) text = (randomNumber == (int)Chioce.Rock) ? "응 졌어~" : "오 이김.";
            //else if (playerChioce == (int)Chioce.Rock) text = (randomNumber == (int)Chioce.Paper) ? "응 졌어~" : "오 이김.";
            //else if (playerChioce == (int)Chioce.Paper) text = (randomNumber == Chioce.Scissors) ? "응 졌어~" : "오 이김.";
            //Console.WriteLine(text);

            // 강의에서 짠 버전
            if (playerChioce == randomNumber) text = "우왕 비겼다. 서로 결혼하셈";
            else if ( (playerChioce == (int)Chioce.Scissors && randomNumber == (int)Chioce.Paper) || 
                (playerChioce == (int)Chioce.Rock && randomNumber == (int)Chioce.Scissors) || 
                (playerChioce == (int)Chioce.Paper && randomNumber == (int)Chioce.Rock) )
                    text = "오 이김";
            else text = "응 졌어~";
            Console.WriteLine(text);
        }
    }
}
