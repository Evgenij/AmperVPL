using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using Xceed.Words.NET;

namespace Components
{
    static class GlobalData
    {
        public static Font DigitalFont;
        public const double multiplierValues = 3.6;
        public const double PI = 3.14159265358979; 
        private const double e0 = 8.85; //значение электрической постоянной
        public enum TypeCapacitor { Flat, Cylinder }
        public enum TypeConnectionCapacitors { Sequentially, Parallel }
        public static ReportManager reportManager;

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
