using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Components
{
    class HeatingArea : IVisualization
    {
        private Thermometr thermometr;
        private PictureBox picture;
        public Resistor[] resistors = new Resistor[2];

        public HeatingArea() 
        {
            picture = new PictureBox();
            thermometr = new Thermometr(picture, 10, 10);
            resistors[0] = new Resistor();
            resistors[1] = new Resistor();
        }

        public void Visualization(Form form, int x, int y)
        {
            resistors[0].Visualization(form, x - 15, y - 80);

            picture.Width = 284;
            picture.Height = 304;
            picture.Left = x - picture.Width / 2;
            picture.Top = y - picture.Height / 2;
            picture.BackColor = Color.Transparent;
            picture.Click += Picture_Click;
            picture.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\heating_area\area.png");

            picture.SendToBack();
            picture.Parent = form;
            form.Controls.Add(picture);
        }

        private void Picture_Click(object sender, EventArgs e)
        {
            //  
        }
    }
}
