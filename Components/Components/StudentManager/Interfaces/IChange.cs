using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components
{
    interface IChange
    {
        void Change(int idStudent, string password, string surname, string name, string group, string pathPhoto);
    }
}
