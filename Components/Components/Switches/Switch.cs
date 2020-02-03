using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Components
{
    class Switch : ISwitching, IVisualization
    {
        protected enum Position { First, Second }
        public virtual void Switching() { }

        //компоненты формы для создания амперметра
        protected PictureBox picture;

        protected Switch() 
        {
            picture = new PictureBox();
        }

        //метод отображения компонента на форме
        public virtual void Visualization(Form form, int x, int y)
        {
            picture.Width = 107;
            picture.Height = 103;
            picture.Left = x - picture.Width / 2;
            picture.Top = y - picture.Height / 2;
            picture.BackColor = Color.Transparent;
            picture.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\switches\s_switch0.png");
            form.Controls.Add(picture);

            // распределение состовляющих компонента по слоям

            picture.SendToBack();
            form.Controls.Add(picture);
        }
    }
}
