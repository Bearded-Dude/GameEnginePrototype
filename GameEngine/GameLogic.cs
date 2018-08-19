using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class GameLogic
    {
        private readonly MessageHub MessageHub = new MessageHub();
        private readonly string Name = "GameLogic";
        public GameLogic()
        {
        }

        public void CheckMessages()
        {
            List<string> messages = MessageHub.GetMessages(Name);
            bool deleted = false;
            for (int i = 0; i < messages.Count && !deleted; i++)
            {
                switch (messages[i])
                {
                    case "moveForward":
                        break;
                    default:
                        MessageHub.DeleteMessage(Name, i);
                        deleted = true;
                        break;
                }
            }
        }
    }
}
