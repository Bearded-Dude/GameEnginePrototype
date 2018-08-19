using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class GUI
    {
        private readonly MessageHub MessageHub = new MessageHub();
        private readonly string Name = "GUI";
        public GUI()
        {
            CheckMessages();
        }

        public void CheckMessages()
        {
            while (true)
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
}
