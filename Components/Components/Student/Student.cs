using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components
{
    class Student : IRegistration
    {
        private string Name { get; set; }
        private string Surname { get; set; }
        private string Group { get; set; }
        private double avgScore { get; set; }

        public void Registration() 
        {
           // GlobalData.iniManager.WriteSection(sectionName);;
        }
    }
}
