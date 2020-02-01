using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components
{
    class ResistanceDevice : Device, IChangeResistance
    {
        protected double resistanceValue { get; set; }
        protected double l { get; set; }
        protected double d { get; set; }
        protected double p { get; set; }
        protected double S { get; set; }
        public void ChangeResistance(int resistance) 
        {
            resistanceValue = resistance;
        }
    }
}
