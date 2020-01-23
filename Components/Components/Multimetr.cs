using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;

namespace Components
{
    class Multimetr : MeterDevice, IVisualization
    {
        private PictureBox picture;
        private PictureBox button;
        private PictureBox status;
        private PictureBox contactMinus;
        private PictureBox contactPlus;
        private TextBox labelValue;
        private bool statusDevice; 

        public Multimetr()
        {
            picture = new PictureBox();
            button = new PictureBox();
            status = new PictureBox();
            contactMinus = new PictureBox();
            contactPlus = new PictureBox();
            labelValue = new TextBox();

            statusDevice = false;
            labelValue.Text = "0";
            labelValue.Hide();
        }

        public double Calculate()
        {
            return 10.0;
        }

        public void Visualization(Form form, int x, int y)
        {
            statusDevice = false;
            labelValue.Text = "0";
            labelValue.Hide();

            picture.Width = 120;
            picture.Height = 199;
            picture.Left = x - picture.Width / 2;
            picture.Top = y - picture.Height / 2;
            picture.SizeMode = PictureBoxSizeMode.AutoSize;
            picture.BackColor = Color.Transparent;
            picture.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\multimetr\multimetr.png");
            form.Controls.Add(picture);

            button.Width = 41;
            button.Height = 18;
            button.Left = 15;
            button.Top = 58;
            button.Cursor = Cursors.Hand;
            button.SizeMode = PictureBoxSizeMode.AutoSize;
            button.BackColor = Color.Transparent;
            button.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\multimetr\power1.png");
            button.Click += Button_Click;
            button.MouseDown += Button_MouseDown;
            button.MouseUp += Button_MouseUp;
            picture.Controls.Add(button);

            status.Width = 8;
            status.Height = 8;
            status.Left = 80;
            status.Top = 60;
            status.SizeMode = PictureBoxSizeMode.AutoSize;
            status.BackColor = Color.Transparent;
            status.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\multimetr\status_off.png");
            picture.Controls.Add(status);

            GlobalData.loadBigFont();  //метод загрузки шрифта
            labelValue.ReadOnly = true;
            labelValue.TabStop = false;
            labelValue.Font = GlobalData.DigitalFont;
            labelValue.Left = 22;
            labelValue.Top = 25;
            labelValue.BorderStyle = BorderStyle.None;
            labelValue.BackColor = Color.Black;
            labelValue.Width = 75;
            labelValue.ForeColor = Color.Silver;
            labelValue.TextAlign = HorizontalAlignment.Right;
            labelValue.Cursor = Cursors.Hand;
            labelValue.MouseMove += LabelValue_MouseMove;
            labelValue.TextChanged += LabelValue_TextChanged;
            picture.Controls.Add(labelValue);

            contactMinus.Width = 33;
            contactMinus.Height = 12;
            contactMinus.Left = 16;
            contactMinus.Top = 192;
            contactMinus.Cursor = Cursors.Hand;
            contactMinus.BackColor = Color.Transparent;
            picture.Controls.Add(contactMinus);

            contactPlus.Width = 33;
            contactPlus.Height = 12;
            contactPlus.Left = 49;
            contactPlus.Top = 192;
            contactPlus.Cursor = Cursors.Hand;
            contactPlus.BackColor = Color.Transparent;
            picture.Controls.Add(contactPlus);

            labelValue.BringToFront();
            form.Controls.Add(picture);
        }

        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            button.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\multimetr\power1.png");
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            button.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\multimetr\power2.png");
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (statusDevice == false)
            {
                status.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\multimetr\status_on.png");
                labelValue.Show();
                statusDevice = true;
            }
            else
            {
                status.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\multimetr\status_off.png");
                labelValue.Hide();
                statusDevice = false;
            }
        }

        //метод для отключения выделения текста в TextBox компонента
        private void LabelValue_TextChanged(object sender, EventArgs e)
        {
            labelValue.SelectionLength = 0;
        }

        //метод для отключения выделения текста в TextBox компонента
        private void LabelValue_MouseMove(object sender, MouseEventArgs e)
        {
            labelValue.SelectionLength = 0;
        }
    }
}
