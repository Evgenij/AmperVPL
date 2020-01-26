using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components
{
    static class GlobalData
    {
        public static Font DigitalFont;
        public const double multiplierValues = 3.6;
        public enum TypeCapacitor { Flat, Cylinder }
        public enum TypeConnectionCapacitors { Sequentially, Parallel }

        public static void LoadFont(int size)
        {
            //Добавляем шрифт из указанного файла в em.Drawing.Text.PrivateFontCollection
            PrivateFontCollection font = new PrivateFontCollection();
            font.AddFontFile("digital.ttf");
            DigitalFont = new Font(font.Families[0], size, FontStyle.Bold);
        }
    }
}
