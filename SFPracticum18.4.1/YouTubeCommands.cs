using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFPracticum18._4._1
{
    internal class Invoker
    {
        Command command;

        public void SetCommand(Command command)
        {
            this.command = command;
        }

        public void Run()
        {
            command.Execute();
        }

        public void Cancel()
        {
            command.Undo();
        }
    }
}
