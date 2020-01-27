using System.Drawing;
using System.Drawing.Text;

namespace Components
{
    static class GlobalData
    {
        public static Font DigitalFont;
        public const double multiplierValues = 3.6;
        public enum TypeCapacitor { Flat, Cylinder }
        public enum TypeConnectionCapacitors { Sequentially, Parallel }

        //Создание объекта, для работы с файлом
        public static INIManager iniManager = new INIManager("iniFile.ini");

        public static void LoadFont(int size)
        {
            //Добавляем шрифт из указанного файла в em.Drawing.Text.PrivateFontCollection
            PrivateFontCollection font = new PrivateFontCollection();
            font.AddFontFile("digital.ttf");
            DigitalFont = new Font(font.Families[0], size, FontStyle.Bold);
        }
    }
}
