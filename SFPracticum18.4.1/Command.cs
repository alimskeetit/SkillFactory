using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFPracticum18._4._1
{
    abstract public class Command
    {
        public abstract void Execute();
        public abstract void Undo();
    }
}
