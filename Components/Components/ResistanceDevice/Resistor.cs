using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Components
{
    class Resistor : ResistanceDevice, IVisualization
    {
        //компоненты формы для создания резистора
        private PictureBox picture;
        private PictureBox pictureValuePlus;
        private PictureBox pictureValueMinus;
        private PictureBox contactMinus;
        private PictureBox contactPlus;
        private TextBox labelValue;

        public Resistor()
        {
            picture = new PictureBox();
            pictureValuePlus = new PictureBox();
            pictureValueMinus = new PictureBox();
            labelValue = new TextBox();
            contactMinus = new PictureBox();
            contactPlus = new PictureBox();

            labelValue.Text = "0";
            resistanceValue = 0;
        }

        public void Visualization(Form form, int x, int y) 
        {
            picture.Width = 188;
            picture.Height = 103;
            picture.Left = x - picture.Width / 2;
            picture.Top = y - picture.Height / 2;
            picture.SizeMode = PictureBoxSizeMode.AutoSize;
            picture.BackColor = Color.Transparent;
            picture.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\resistor\resistor.png");

            GlobalData.LoadFont(12);  //метод загрузки шрифта
            labelValue.ReadOnly = true;
            labelValue.TabStop = false;
            labelValue.Font = GlobalData.DigitalFont;
            labelValue.Left = 75;
            labelValue.Top = 15;
            labelValue.BorderStyle = BorderStyle.None;
            labelValue.BackColor = Color.Black;
            labelValue.Width = 39;
            labelValue.ForeColor = Color.Orange;
            labelValue.TextAlign = HorizontalAlignment.Center;
            labelValue.Cursor = Cursors.Hand;
            labelValue.MouseMove += LabelValue_MouseMove;
            labelValue.TextChanged += LabelValue_TextChanged;
            picture.Controls.Add(labelValue);

            pictureValueMinus.Width = 12;
            pictureValueMinus.Height = 12;
            pictureValueMinus.Left = 55;
            pictureValueMinus.Top = 19;
            pictureValueMinus.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureValueMinus.BackColor = Color.Transparent;
            pictureValueMinus.Cursor = Cursors.Hand;
            pictureValueMinus.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\resistor\minus0.png");
            pictureValueMinus.MouseEnter += PictureValueMinus_MouseEnter;
            pictureValueMinus.MouseLeave += PictureValueMinus_MouseLeave;
            pictureValueMinus.Click += PictureValueMinus_Click;
            picture.Controls.Add(pictureValueMinus);

            pictureValuePlus.Width = 12;
            pictureValuePlus.Height = 12;
            pictureValuePlus.Left = 119;
            pictureValuePlus.Top = 19;
            pictureValuePlus.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureValuePlus.BackColor = Color.Transparent;
            pictureValuePlus.Cursor = Cursors.Hand;
            pictureValuePlus.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\resistor\plus0.png");
            pictureValuePlus.MouseEnter += PictureValuePlus_MouseEnter;
            pictureValuePlus.MouseLeave += PictureValuePlus_MouseLeave;
            pictureValuePlus.Click += PictureValuePlus_Click;
            picture.Controls.Add(pictureValuePlus);

            contactMinus.Width = 34;
            contactMinus.Height = 12;
            contactMinus.Left = 60;
            contactMinus.Top = 92;
            contactMinus.Cursor = Cursors.Hand;
            contactMinus.BackColor = Color.Transparent;
            picture.Controls.Add(contactMinus);

            contactPlus.Width = 34;
            contactPlus.Height = 12;
            contactPlus.Left = 94;
            contactPlus.Top = 92;
            contactPlus.Cursor = Cursors.Hand;
            contactPlus.BackColor = Color.Transparent;
            picture.Controls.Add(contactPlus);

            picture.SendToBack();
            labelValue.BringToFront();
            contactMinus.BringToFront();
            contactPlus.BringToFront();
            pictureValueMinus.BringToFront();
            pictureValuePlus.BringToFront();
            form.Controls.Add(picture);
        }

        private void PictureValuePlus_Click(object sender, EventArgs e)
        {
            if (resistanceValue != 10)
            {
                resistanceValue++;
                labelValue.Text = Convert.ToString(resistanceValue);
                GlobalData.reportManager.AddToStringChangesValue(
                    ReportManager.TypeComponent.Resistor,
                    ReportManager.TypeChanges.Plus,
                    resistanceValue);
            }
        }

        private void PictureValueMinus_Click(object sender, EventArgs e)
        {
            if (resistanceValue != 0) 
            {
                resistanceValue--;
                labelValue.Text = Convert.ToString(resistanceValue);
                GlobalData.reportManager.AddToStringChangesValue(
                    ReportManager.TypeComponent.Resistor,
                    ReportManager.TypeChanges.Minus,
                    resistanceValue);
            }
        }

        private void PictureValuePlus_MouseLeave(object sender, EventArgs e)
        {
            pictureValuePlus.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\resistor\plus0.png");
        }

        private void PictureValuePlus_MouseEnter(object sender, EventArgs e)
        {
            pictureValuePlus.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\resistor\plus1.png");
        }

        private void PictureValueMinus_MouseLeave(object sender, EventArgs e)
        {
            pictureValueMinus.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\resistor\minus0.png");
        }

        private void PictureValueMinus_MouseEnter(object sender, EventArgs e)
        {
            pictureValueMinus.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\resistor\minus1.png");
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
