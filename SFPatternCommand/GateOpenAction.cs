using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFPatternCommand
{
    public class GateOpenAction : Command
    {
        Gate gate;

        public GateOpenAction(Gate gate)
        {
            this.gate = gate;
        }

        public override void Close()
        {
            gate.Close();
        }

        public override void Open()
        {
            gate.Open();
        }
    }
}
