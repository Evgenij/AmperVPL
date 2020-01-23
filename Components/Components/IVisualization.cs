using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Components
{
    interface IVisualization
    {
        void Visualization(Form form, int x, int y);
    }
}
