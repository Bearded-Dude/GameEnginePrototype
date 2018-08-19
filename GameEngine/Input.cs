using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine
{
    class Input
    {
        private const int Milliseconds = 1000; // 1000 milliseconds in 1 second
        private const int CountFrames = 60; // 60fps
        private readonly string Name = "Input";
        private readonly MessageHub MessageHub = new MessageHub();
        public Input()
        {
        }

        public void CheckUserInput()
        {
            string gameStatus = MessageHub.getGameStatus();
            string message = "";
            ConsoleKeyInfo inputKey = Console.ReadKey();
            Console.OpenStandardOutput();
            if (gameStatus != "paused")
            {
                switch (inputKey.Key)
                {
                    case ConsoleKey.Escape:
                        message = "pause";
                        break;
                    case ConsoleKey.Enter:
                        message = "enter";
                        break;
                    case ConsoleKey.Spacebar:
                        message = "jump";
                        break;
                    case ConsoleKey.Tab:
                        message = "parry";
                        break;
                    case (ConsoleKey)ConsoleModifiers.Shift:
                        message = "sprint";
                        break;
                    case ConsoleKey.W:
                        message = "moveForward";
                        break;
                    case ConsoleKey.B:
                        message = "useItem";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (inputKey.Key)
                {
                    case ConsoleKey.Escape:
                        message = "running";
                        break;
                    case ConsoleKey.Enter:
                        message = "stop";
                        break;
                    case ConsoleKey.Tab:
                        message = "nextWindow";
                        break;
                    default:
                        break;
                }
            }
            MessageHub.AddMessage(message);
        }

        public void CheckMessages()
        {
            List<string> messages = MessageHub.GetMessages(Name);
            bool deleted = false;
            for(int i = 0; i < messages.Count && !deleted; i++)
            {
                switch (messages[i])
                {
                    default:
                        MessageHub.DeleteMessage(Name, i);
                        deleted = true;
                        break;
                }
            }
        }
    }
}
