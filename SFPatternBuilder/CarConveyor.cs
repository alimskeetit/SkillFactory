using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFPatternBuilder
{
    internal class CarConveyor : Conveyor
    {
        public CarConveyor()
        {
            _product = new Product("Автомобиль");
        }

        public override void BuildDoors()
        {
            _product["doors"] = "4";
        }

        public override void BuildEngine()
        {
            _product["engine"] = "150 л.с.";
        }

        public override void BuildFrame()
        {
            _product["frame"] = "Рама автомобиля";
        }

        public override void BuildWheels()
        {
            _product["wheels"] = "4";
        }
    }
}
