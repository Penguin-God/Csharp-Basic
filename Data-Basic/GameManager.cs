using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Basic
{
    public enum GameMode
    {
        None,
        Lobby,
        Town,
        Field,
    }

    class GameManager
    {
        GameMode gameMode = GameMode.Lobby;

        Player player = null;
        Monster monster = null;
        Random rand = new Random();

        public void PlayeGame()
        {
            switch (gameMode)
            {
                case GameMode.Lobby: EnterLobby("직업을 선택해 주세요"); break;
                case GameMode.Town: EnterTown(); break;
                case GameMode.Field: EnterFiled(); break;
            }
        }

        private void EnterLobby(string text)
        {
            Console.WriteLine(text);
            Console.WriteLine("1 : 기사");
            Console.WriteLine("2 : 궁수");
            Console.WriteLine("3 : 마법사");

            int jobNumber = Convert.ToInt32(Console.ReadLine());
            switch (jobNumber)
            {
                case (int)PlayerJob.Knight: player = new Knight(); break;
                case (int)PlayerJob.Archer: player = new Archer(); break;
                case (int)PlayerJob.Mage: player = new Mage(); break;
                default: EnterLobby("직업을 정확히 선택해 주세요"); break;
            }

            gameMode = GameMode.Town;
        }

        private void EnterTown()
        {
            Console.WriteLine("마을에 오신것을 환영합니다. 이제 꺼지세요");
            Console.WriteLine("1 : 필드로 꺼지기");
            Console.WriteLine("2 : 로비로 꺼지기");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1": gameMode = GameMode.Field; break;
                case "2": gameMode = GameMode.Town; break;
            }
        }

        private void EnterFiled()
        {
            Console.WriteLine("필드에 입장");
            Console.WriteLine("1 : 싸우기");
            Console.WriteLine("2 : 일정 확률로 마을로 도망치는거 시도하기");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1": Fight(); break;
                case "2": TryEsccape(); break;
            }
        }

        private void Fight()
        {
            CreateMonster();

            while (true)
            {
                monster.OnDamaeg(player.GetDamage());
                if (monster.IsDead)
                {
                    Console.WriteLine("you win");
                    Console.WriteLine($"you hp : {player.GetHp()}");
                    break;
                }

                player.OnDamaeg(monster.GetDamage());
                if (player.IsDead)
                {
                    Console.WriteLine("you loss");
                    gameMode = GameMode.Lobby;
                    break;
                }
            }
        }

        private void TryEsccape()
        {
            int randNum = rand.Next(0, 100);
            if (randNum > 66)
            {
                gameMode = GameMode.Town;
                PlayeGame();
            }
            else
            {
                Console.WriteLine("빤스런 실패!! 걍 싸우셈");
                Fight();
            }
        }

        private void CreateMonster()
        {
            int randNum = rand.Next(0, 3);

            switch (randNum)
            {
                case 0: monster = new Slime(); Console.WriteLine("슬라임이 생성되었습니다."); break;
                case 1: monster = new Orc(); Console.WriteLine("오크가 생성되었습니다."); break;
                case 2: monster = new Skeleton(); Console.WriteLine("스켈레톤이 생성되었습니다.");  break;
            }
        }
    }
}
