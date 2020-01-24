using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components
{
    class ResistanceDevice : Device, IChangeResistance
    {
        protected int resistanceValue { get; set; }
        public void ChangeResistance(int resistance) 
        {
            resistanceValue = resistance;
        }
    }
}
