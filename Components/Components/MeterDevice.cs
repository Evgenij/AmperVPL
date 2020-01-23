using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components
{
    class MeterDevice : Device, ICalculate
    {
        public int value { get; set; }
        public virtual double Calculate(double volt, double resist) 
        {
            return 0;
        }
    }
}
