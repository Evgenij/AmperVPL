using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Components
{
    class Lamp : IVisualization
    {
        //компоненты формы для создания амперметра
        private PictureBox picture;
        private PictureBox contactMinus;
        private PictureBox contactPlus;

        public Lamp()
        {
            picture = new PictureBox();
            contactMinus = new PictureBox();
            contactPlus = new PictureBox();
        }

        //метод отображения компонента на форме
        public void Visualization(Form form, int x, int y)
        {
            picture.Width = 107;
            picture.Height = 103;
            picture.Left = x - picture.Width / 2;
            picture.Top = y - picture.Height / 2;
            picture.BackColor = Color.Transparent;
            picture.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\lamp\lamp_off.png");
            picture.Click += Picture_Click;
            form.Controls.Add(picture);

            // код создания контактов для подключения

            contactMinus.Width = 12;
            contactMinus.Height = 35;
            contactMinus.Left = 0;
            contactMinus.Top = 34;
            contactMinus.Cursor = Cursors.Hand;
            contactMinus.BackColor = Color.Transparent;
            picture.Controls.Add(contactMinus);

            contactPlus.Width = 12;
            contactPlus.Height = 35;
            contactPlus.Left = picture.Width - 12;
            contactPlus.Top = 34;
            contactPlus.Cursor = Cursors.Hand;
            contactPlus.BackColor = Color.Transparent;
            picture.Controls.Add(contactPlus);

            // распределение состовляющих компонента по слоям

            picture.SendToBack();
            contactMinus.BringToFront();
            contactPlus.BringToFront();
            form.Controls.Add(picture);
        }

        private void Picture_Click(object sender, EventArgs e)
        {
            picture.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\lamp\lamp_on.png");
        }
    }
}
