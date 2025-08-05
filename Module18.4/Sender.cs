using System;

namespace Module18._4
{
    class Sender
    {
        Command _command;

        public void SetCommand(Command command)
        {
            _command = command;
        }
        public void Run()
        {
            _command.Run();
        }
    }
}
