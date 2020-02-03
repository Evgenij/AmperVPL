using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Components
{
    class SingleSwitch : Switch
    {
        private PictureBox handle; 
        private PictureBox contactLeft; 
        private PictureBox contactTop;  
        private PictureBox contactBottom; 

        public SingleSwitch() 
        {
            handle = new PictureBox();
            contactLeft = new PictureBox();
            contactTop = new PictureBox();
            contactBottom = new PictureBox();
        }

        public override void Switching()
        {
            base.Switching();
        }

        public override void Visualization(Form form, int x, int y)
        {
            picture.Width = 107;
            picture.Height = 103;
            picture.Left = x - picture.Width / 2;
            picture.Top = y - picture.Height / 2;
            picture.BackColor = Color.Transparent;
            picture.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\switches\s_switch0.png");
            form.Controls.Add(picture);

            handle.Width = 16;
            handle.Height = 18;
            handle.Left = 46;
            handle.Top = 36;
            handle.Cursor = Cursors.Hand;
            handle.BackColor = Color.Transparent;
            picture.Controls.Add(handle);

            // код создания контактов для подключения

            contactLeft.Width = 12;
            contactLeft.Height = 35;
            contactLeft.Left = 0;
            contactLeft.Top = 34;
            contactLeft.Cursor = Cursors.Hand;
            contactLeft.BackColor = Color.Transparent;
            picture.Controls.Add(contactLeft);

            contactTop.Width = 35;
            contactTop.Height = 12;
            contactTop.Left = 57;
            contactTop.Top = 0;
            contactTop.Cursor = Cursors.Hand;
            contactTop.BackColor = Color.Transparent;
            picture.Controls.Add(contactTop);

            contactBottom.Width = 35;
            contactBottom.Height = 12;
            contactBottom.Left = 57;
            contactBottom.Top = picture.Height - 12;
            contactBottom.Cursor = Cursors.Hand;
            contactBottom.BackColor = Color.Transparent;
            picture.Controls.Add(contactBottom);

            // распределение состовляющих компонента по слоям

            picture.SendToBack();
            contactLeft.BringToFront();
            contactTop.BringToFront();
            contactBottom.BringToFront();
            form.Controls.Add(picture);
        }
    }
}
