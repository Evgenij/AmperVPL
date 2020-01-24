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

        public static void LoadFont()
        {
            //Добавляем шрифт из указанного файла в em.Drawing.Text.PrivateFontCollection
            PrivateFontCollection font = new PrivateFontCollection();
            font.AddFontFile("digital.ttf");
            DigitalFont = new Font(font.Families[0], 12, FontStyle.Bold);
        }
        public static void LoadBigFont()
        {
            //Добавляем шрифт из указанного файла в em.Drawing.Text.PrivateFontCollection
            PrivateFontCollection font = new PrivateFontCollection();
            font.AddFontFile("digital.ttf");
            DigitalFont = new Font(font.Families[0], 18, FontStyle.Bold);
        }
    }
}
