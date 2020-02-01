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
        private PictureBox pictureGear;
        private PictureBox picturePanel;
        private PictureBox contactMinus;
        private PictureBox contactPlus;
        private TextBox labelValue;
        private TextBox textBoxL;
        private TextBox textBoxD;
        private TextBox textBoxP;

        public Resistor()
        {
            picture = new PictureBox();
            pictureValuePlus = new PictureBox();
            pictureValueMinus = new PictureBox();
            pictureGear = new PictureBox();
            picturePanel = new PictureBox();
            labelValue = new TextBox();
            textBoxL = new TextBox();
            textBoxD = new TextBox();
            textBoxP = new TextBox();
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

            pictureGear.Width = 11;
            pictureGear.Height = 12;
            pictureGear.Left = 164;
            pictureGear.Top = 9;
            pictureGear.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureGear.BackColor = Color.Transparent;
            pictureGear.Cursor = Cursors.Hand;
            pictureGear.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\resistor\gear.png");
            pictureGear.Click += PictureGear_Click;
            picture.Controls.Add(pictureGear);

            // код создания панели для ввода данных резистора

            picturePanel.Width = 134;
            picturePanel.Height = 161;
            picturePanel.Left = picture.Left - 15;
            picturePanel.Top = picture.Top - 61;
            picturePanel.SizeMode = PictureBoxSizeMode.AutoSize;
            picturePanel.BackColor = Color.Transparent;
            picturePanel.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\resistor\panel.png");
            form.Controls.Add(picturePanel);

                GlobalData.LoadFont(11);  //метод загрузки шрифта
                textBoxL.TabStop = false;
                textBoxL.Font = GlobalData.DigitalFont;
                textBoxL.Left = 10;
                textBoxL.Top = 27;
                textBoxL.BackColor = Color.White;
                textBoxL.Width = 62;
                textBoxL.ForeColor = Color.Black;
                textBoxL.TextAlign = HorizontalAlignment.Center;
                textBoxL.Cursor = Cursors.IBeam;
                picturePanel.Controls.Add(textBoxL);

                GlobalData.LoadFont(11);  //метод загрузки шрифта
                textBoxD.TabStop = false;
                textBoxD.Font = GlobalData.DigitalFont;
                textBoxD.Left = 78;
                textBoxD.Top = 27;
                textBoxD.BackColor = Color.White;
                textBoxD.Width = 62;
                textBoxD.ForeColor = Color.Black;
                textBoxD.TextAlign = HorizontalAlignment.Center;
                textBoxD.Cursor = Cursors.IBeam;
                picturePanel.Controls.Add(textBoxD);

                GlobalData.LoadFont(11);  //метод загрузки шрифта
                textBoxP.TabStop = false;
                textBoxP.Font = GlobalData.DigitalFont;
                textBoxP.Left = 146;
                textBoxP.Top = 27;
                textBoxP.BackColor = Color.White;
                textBoxP.Width = 62;
                textBoxP.ForeColor = Color.Black;
                textBoxP.TextAlign = HorizontalAlignment.Center;
                textBoxP.Cursor = Cursors.IBeam;
                picturePanel.Controls.Add(textBoxP);

            // код создания контактов для подключения

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

            // распределение состовляющих компонента по слоям

            picture.SendToBack();
            labelValue.BringToFront();
            contactMinus.BringToFront();
            contactPlus.BringToFront();
            pictureValueMinus.BringToFront();
            pictureValuePlus.BringToFront();
            form.Controls.Add(picture);
        }

        private void PictureGear_Click(object sender, EventArgs e)
        {
            if(picturePanel.Visible == false)
            {
                picturePanel.Visible = true;
            }
            else
            {
                picturePanel.Visible = false;
                if (textBoxL.Text != "" & textBoxD.Text != "" & textBoxP.Text != "")
                {
                    l = Convert.ToDouble(textBoxL.Text);
                    d = Convert.ToDouble(textBoxD.Text);
                    p = Convert.ToDouble(textBoxP.Text);

                    double S = (GlobalData.PI * Math.Pow(d, 2)) / 4;
                    resistanceValue = p * (l / S);
                }

                //MessageBox.Show(Convert.ToString(resistanceValue));
            }
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
