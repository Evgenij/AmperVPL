using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Components
{
    class DoubleSwitch : Switch
    {
        private PictureBox contactMinusPosLeft;
        private PictureBox contactPlusPosLeft;

        private PictureBox contactMinusPosRight;
        private PictureBox contactPlusPosRight;

        private PictureBox contactMinusPosBottom;
        private PictureBox contactPlusPosBottom;

        private Zeroit.Framework.Metro.ZeroitMetroSwitch _switch;

        public DoubleSwitch()
        {
            contactMinusPosLeft = new PictureBox();
            contactPlusPosLeft = new PictureBox();

            contactMinusPosRight = new PictureBox();
            contactPlusPosRight = new PictureBox();

            contactMinusPosBottom = new PictureBox();
            contactPlusPosBottom = new PictureBox();

            _switch = new Zeroit.Framework.Metro.ZeroitMetroSwitch();
        }

        public override void Switching()
        {
            base.Switching();
        }

        public override void Visualization(Form form, int x, int y)
        {
            picture.Width = 188;
            picture.Height = 84;
            picture.Left = x - picture.Width / 2;
            picture.Top = y - picture.Height / 2;
            picture.BackColor = Color.Transparent;
            picture.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\switches\d_switch.png");
            form.Controls.Add(picture);

            _switch.Width = 41;
            _switch.Height = 20;
            _switch.Left = 73;
            _switch.Top = 34;
            _switch.Cursor = Cursors.Hand;
            _switch.DefaultColor = Color.ForestGreen;
            _switch.CheckColor = Color.DodgerBlue;
            _switch.HoverColor = Color.DodgerBlue;
            //_switch.CheckedChanged += _switch_CheckedChanged;
            picture.Controls.Add(_switch);

            // код создания контактов для подключения

            contactMinusPosLeft.Width = 33;
            contactMinusPosLeft.Height = 12;
            contactMinusPosLeft.Left = 19;
            contactMinusPosLeft.Top = 0;
            contactMinusPosLeft.Cursor = Cursors.Hand;
            contactMinusPosLeft.BackColor = Color.Transparent;
            picture.Controls.Add(contactMinusPosLeft);

            contactPlusPosLeft.Width = 33;
            contactPlusPosLeft.Height = 12;
            contactPlusPosLeft.Left = 52;
            contactPlusPosLeft.Top = 0;
            contactPlusPosLeft.Cursor = Cursors.Hand;
            contactPlusPosLeft.BackColor = Color.Transparent;
            picture.Controls.Add(contactPlusPosLeft);

            //-----------------------------

            contactMinusPosRight.Width = 33;
            contactMinusPosRight.Height = 12;
            contactMinusPosRight.Left = 103;
            contactMinusPosRight.Top = 0;
            contactMinusPosRight.Cursor = Cursors.Hand;
            contactMinusPosRight.BackColor = Color.Transparent;
            picture.Controls.Add(contactMinusPosRight);

            contactPlusPosRight.Width = 33;
            contactPlusPosRight.Height = 12;
            contactPlusPosRight.Left = 136;
            contactPlusPosRight.Top = 0;
            contactPlusPosRight.Cursor = Cursors.Hand;
            contactPlusPosRight.BackColor = Color.Transparent;
            picture.Controls.Add(contactPlusPosRight);

            //-----------------------------

            contactMinusPosBottom.Width = 33;
            contactMinusPosBottom.Height = 12;
            contactMinusPosBottom.Left = 61;
            contactMinusPosBottom.Top = picture.Height - 12;
            contactMinusPosBottom.Cursor = Cursors.Hand;
            contactMinusPosBottom.BackColor = Color.Transparent;
            picture.Controls.Add(contactMinusPosBottom);

            contactPlusPosBottom.Width = 33;
            contactPlusPosBottom.Height = 12;
            contactPlusPosBottom.Left = 94;
            contactPlusPosBottom.Top = picture.Height - 12;
            contactPlusPosBottom.Cursor = Cursors.Hand;
            contactPlusPosBottom.BackColor = Color.Transparent;
            picture.Controls.Add(contactPlusPosBottom);

            // распределение состовляющих компонента по слоям

            picture.SendToBack();

            contactMinusPosLeft.BringToFront();
            contactPlusPosLeft.BringToFront();

            contactMinusPosRight.BringToFront();
            contactPlusPosRight.BringToFront();

            contactMinusPosBottom.BringToFront();
            contactPlusPosBottom.BringToFront();

            _switch.BringToFront();
            form.Controls.Add(picture);
        }
    }
}
