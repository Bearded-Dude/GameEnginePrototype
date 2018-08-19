using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class MessageHub
    {
        public static string gameStatus = "running";
        public static Dictionary<string, List<string>> Messages = new Dictionary<string, List<string>> {
            { "GameLogic", new List<string>{ } },
            { "GUI", new List<string>{ } },
            { "Rendering", new List<string>{ } },
            { "Audio", new List<string>{ } },
            { "AI", new List<string>{ } },
            { "Input", new List<string>{ } },
            { "Scene", new List<string>{ } }
        };
        public MessageHub()
        {
        }

        public void AddMessage(string message)
        {
            if(message == "pause" || message == "stop")
            {
                gameStatus = message == "pause" ? "paused" : "stopped";
                if(gameStatus == "stopped")
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                foreach (KeyValuePair<string, List<string>> MessageList in Messages)
                {
                    MessageList.Value.Add(message);
                }
            }
        }

        public List<string> GetMessages(string Member)
        {
            return Messages[Member];
        }

        public void DeleteMessage(string member, int index)
        {
            Messages[member].RemoveAt(index);
        }

        public string getGameStatus()
        {
            return gameStatus;
        }
    }
}
