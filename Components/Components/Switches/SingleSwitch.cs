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
        private PictureBox contactLeft; 
        private PictureBox contactTop;  
        private PictureBox contactBottom;

        public SingleSwitch() 
        {
            contactLeft = new PictureBox();
            contactTop = new PictureBox();
            contactBottom = new PictureBox();
            position = Position.Center;
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
            picture.MouseMove += Picture_MouseMove;
            picture.Click += Picture_Click;
            picture.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\switches\s_switch0.png");
            form.Controls.Add(picture);

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

        private void Picture_Click(object sender, EventArgs e)
        {
            if (position == Position.Top)
            {
                position = Position.Center;
                picture.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\switches\s_switch0.png");
            }
            else if (position == Position.Bottom)
            {
                position = Position.Center;
                picture.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\switches\s_switch0.png");
            }
            else
            {
                if (picture.Cursor == Cursors.PanNorth)
                {
                    position = Position.Top;
                    picture.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\switches\s_switch1.png");
                }
                else if (picture.Cursor == Cursors.PanSouth)
                {
                    position = Position.Bottom;
                    picture.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\switches\s_switch2.png");
                }
            }
        }

        private void Picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Y <= 40)
            {
                if (position == Position.Top)
                {
                    picture.Cursor = Cursors.PanSouth;
                }
                else if (position == Position.Center)
                {
                    picture.Cursor = Cursors.PanNorth;
                }
                else 
                {
                    picture.Cursor = Cursors.PanNorth;
                }
            }
            else if (e.Y <= 63)
            {
                if (position == Position.Center)
                {
                    picture.Cursor = Cursors.NoMoveVert;
                }
                else if (position == Position.Top)
                {
                    picture.Cursor = Cursors.PanSouth;
                }
                else 
                {
                    picture.Cursor = Cursors.PanNorth;
                }
            }
            else 
            {
                if (position == Position.Bottom)
                {
                    picture.Cursor = Cursors.PanNorth;
                }
                else if (position == Position.Center)
                {
                    picture.Cursor = Cursors.PanSouth;
                }
                else 
                {
                    picture.Cursor = Cursors.PanSouth;
                }
            }
        }
    }
}
