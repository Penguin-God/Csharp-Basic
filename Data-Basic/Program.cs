using System;

namespace Data_Basic
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager game = new GameManager();
            while (true)
            {
                game.PlayeGame();
            }
        }
    }
}
