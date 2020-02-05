using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Components
{
    class Toggle : IVisualization
    {
        private PictureBox picture;
        private PictureBox handle;
        private PictureBox contactMinus;
        private PictureBox contactPlus;
        private bool status = false;

        public Toggle()
        {
            picture = new PictureBox();
            handle = new PictureBox();
            contactMinus = new PictureBox();
            contactPlus = new PictureBox();
            status = false;
        }

        public void Visualization(Form form, int x, int y)
        {
            picture.Width = 188;
            picture.Height = 103;
            picture.Left = x - picture.Width / 2;
            picture.Top = y - picture.Height / 2;
            picture.BackColor = Color.Transparent;
            picture.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\toggle\toggle_off.png");
            form.Controls.Add(picture);

            handle.Width = 23;
            handle.Height = 19;
            handle.Left = 91;
            handle.Top = 15;
            handle.Cursor = Cursors.Hand;
            handle.BackColor = Color.Transparent;
            handle.Cursor = Cursors.PanSouth;
            handle.Click += Handle_Click;
            picture.Controls.Add(handle);

            // код создания контактов для подключения

            contactMinus.Width = 12;
            contactMinus.Height = 35;
            contactMinus.Left = 0;
            contactMinus.Top = 36;
            contactMinus.Cursor = Cursors.Hand;
            contactMinus.BackColor = Color.Transparent;
            picture.Controls.Add(contactMinus);

            contactPlus.Width = 12;
            contactPlus.Height = 35;
            contactPlus.Left = picture.Width-12;
            contactPlus.Top = 36;
            contactPlus.Cursor = Cursors.Hand;
            contactPlus.BackColor = Color.Transparent;
            picture.Controls.Add(contactPlus);

            // распределение состовляющих компонента по слоям

            picture.SendToBack();
            contactMinus.BringToFront();
            contactPlus.BringToFront();
            form.Controls.Add(picture);
        }

        private void Handle_Click(object sender, EventArgs e)
        {
            if (status == false)
            {
                picture.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\toggle\toggle_on.png");
                handle.Left = 98;
                handle.Top = 28;
                status = true;
                handle.Cursor = Cursors.PanNorth;
            }
            else
            {
                picture.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\toggle\toggle_off.png");
                handle.Left = 91;
                handle.Top = 15;
                status = false;
                handle.Cursor = Cursors.PanSouth;
            }
        }
    }
}
