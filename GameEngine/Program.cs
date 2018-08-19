using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            Input input = new Input();
            GUI gui = new GUI();
            GameLogic gameLogic = new GameLogic();
            Console.WriteLine("test1");
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    input.CheckUserInput();
                }
                gui.CheckMessages();
                input.CheckMessages();
                gameLogic.CheckMessages();
            }
        }
    }
}
