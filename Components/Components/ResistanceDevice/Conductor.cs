using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Components
{
    class Conductor : Resistor
    {
        private PictureBox pictureGear;  //
        private PictureBox picturePanel; //
        private TextBox textBoxL;  //
        private TextBox textBoxD; //
        private TextBox textBoxP; //

        public Conductor()
        {
            picture = new PictureBox();
            pictureGear = new PictureBox();
            picturePanel = new PictureBox();
            labelValue = new TextBox();
            textBoxL = new TextBox();
            textBoxD = new TextBox();
            textBoxP = new TextBox();
            contactMinus = new PictureBox();
            contactPlus = new PictureBox();

            labelValue.Text = "0";
            this.resistanceValue = 0;
        }

        public override void Visualization(Form form, int x, int y)
        {
            picture.Width = 188;
            picture.Height = 103;
            picture.Left = x - picture.Width / 2;
            picture.Top = y - picture.Height / 2;
            picture.SizeMode = PictureBoxSizeMode.AutoSize;
            picture.BackColor = Color.Transparent;
            picture.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\conductor\conductor.png");

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

            pictureGear.Width = 11;
            pictureGear.Height = 12;
            pictureGear.Left = 164;
            pictureGear.Top = 9;
            pictureGear.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureGear.BackColor = Color.Transparent;
            pictureGear.Cursor = Cursors.Hand;
            pictureGear.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\conductor\gear.png");
            pictureGear.Click += PictureGear_Click;
            picture.Controls.Add(pictureGear);

            // код создания панели для ввода данных резистора

            picturePanel.Visible = false;
            picturePanel.Width = 134;
            picturePanel.Height = 161;
            picturePanel.Left = picture.Left - 15;
            picturePanel.Top = picture.Top - 61;
            picturePanel.SizeMode = PictureBoxSizeMode.AutoSize;
            picturePanel.BackColor = Color.Transparent;
            picturePanel.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\conductor\panel.png");
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
            form.Controls.Add(picture);
        }

        private void PictureGear_Click(object sender, EventArgs e)
        {
            if (picturePanel.Visible == false)
            {
                picturePanel.Visible = true;
            }
            else
            {
                if (textBoxL.Text == "0" || textBoxD.Text == "0" || textBoxP.Text == "0")
                {
                    MessageBox.Show("Введите корректные значения проводника");
                    picturePanel.Visible = true;
                }
                else if (textBoxL.Text != "" & textBoxD.Text != "" & textBoxP.Text != "")
                {
                    l = Convert.ToDouble(textBoxL.Text);
                    d = Convert.ToDouble(textBoxD.Text);
                    p = Convert.ToDouble(textBoxP.Text);

                    double S = (GlobalData.PI * Math.Pow(d, 2)) / 4;
                    this.resistanceValue = p * (l / S);
                    labelValue.Text = Convert.ToString(Math.Round(this.resistanceValue, 2));

                    GlobalData.reportManager.AddToStringChangesValueConductor(l, d, p);
                    GlobalData.reportManager.AddToStringChangesValue(
                        ReportManager.TypeComponent.Resistor,
                        ReportManager.TypeChanges.DefautChange,
                        Math.Round(this.resistanceValue, 2));

                    picturePanel.Visible = false;
                }
                else
                {
                    MessageBox.Show("Введите значения проводника"); 
                    picturePanel.Visible = true;
                }
            }
        }
    }
}
