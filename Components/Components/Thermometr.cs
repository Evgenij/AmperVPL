using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Components
{
    class Thermometr
    {
        private PictureBox pictureThermometr;
        private Zeroit.Framework.Metro.ZeroitMetroProgressbar scale;


        public Thermometr(Form picture,int x, int y) 
        {
            scale = new Zeroit.Framework.Metro.ZeroitMetroProgressbar();
            pictureThermometr = new PictureBox();

            pictureThermometr.Width = 44;
            pictureThermometr.Height = 250;
            pictureThermometr.Left = x;
            pictureThermometr.Top = y;
            pictureThermometr.BackColor = Color.Transparent;
            pictureThermometr.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\heating_area\thermometr.png");

            scale.Left = pictureThermometr.Left;
            scale.Top = y + 5;
            scale.Width = 220;
            scale.Height = 7;
            scale.Maximum = 80;
            scale.Value = 40;
            scale.DefaultColor = Color.Red;
            scale.ProgressColor = Color.White;
            scale.GradientColor = Color.White;
            scale.Orientation = Orientation.Vertical;

            pictureThermometr.Controls.Add(scale);
            picture.Controls.Add(pictureThermometr);
        }
    }
}
