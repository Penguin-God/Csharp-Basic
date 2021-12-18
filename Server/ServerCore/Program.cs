﻿using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ServerCore
{
    class Program
    {
        static void Start_NewThread()
        {
            while(true)
                Console.WriteLine("Hello Thread!!");
        }

        // ThreadPool에 넣으려면 파라미터로 object를 하나 가지고 있어야 함
        static void Start_PoolThread(object state)
        {
            Console.WriteLine("Hello Thread!!");
        }

        static void Main(string[] args)
        {
            // 쓰레드 풀은 오브젝트 풀링과 개념이 비슷함
            // 풀에 미리 생성되 있는 쓰레드를 가져와 작업을 부여하고 일을 마치면 다시 풀에 돌아가서 대기함
            // 풀에 있는 쓰레드가 제한되어 있으므로 미친듯이 많이 사용하면 이전에 쓰레드가 일을 마칠 때까지 대기 후 일을 배정함
            // 쓰레드를 새로 만드는 것은 오브젝트를 새로 만드는 것과 비슷하며 부담이 많이 듬
            // 부를때도 쓰레드풀링 이라고 부름
            ThreadPool.QueueUserWorkItem(Start_PoolThread);

            ThreadPool.SetMinThreads(1, 1); // 최소 쓰레드 1개
            ThreadPool.SetMaxThreads(5, 5); // 풀에서 최대로 사용 가능한 쓰레드 5개로 설정

            // Thread가 동작할 함수를 넘김
            // C#의 쓰레드는 기본적으로 forground 쓰레드
            // forground일 경우 Main함수가 꺼져도 동작함
            // forground가 아니라 Background일 경우 BackGround가 꺼지면 같이 꺼짐
            Thread thread_1 = new Thread(Start_NewThread);
            thread_1.Name = "My Thread";
            thread_1.Start();
            //thread_1.IsBackground = true;
            thread_1.Join(); // 쓰레드가 멈출 때까지 대기하는 함수

            // 쓰레드풀에서 갖다 쓰는거긴 하지만 특정 옵션을 추가해 별도의 쓰레드로 사용가능 등 여러가지 짓거리 가능
            // LongRunning 옵션을 넣어서 얘는 오래 걸리니 별도다. 라고 선언 근데 옵션 안넣으면 그냥 하는거랑 똑같음
            Task task_1 = new Task(() => { while (true) { } }, TaskCreationOptions.LongRunning);


            // Main함수 내에서Start_Thread()를 호출했다면 무한 루프에 막혀서 아래 코드가 실행되지 않음
            // 하지만 쓰레드를 따로 생성해서 실행하므로써 두개의 while문이 동시에 돌아감
            while (true)
                Console.WriteLine("Hello World");
        }
    }
}
