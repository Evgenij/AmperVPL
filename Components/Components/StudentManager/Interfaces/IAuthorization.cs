using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components
{
    interface IAuthorization
    {
        void Authorization(string surname, string password);
    }
}
