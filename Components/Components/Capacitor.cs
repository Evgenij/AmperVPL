using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Components
{
    class Capacitor : IVisualization
    {
        //компоненты формы для создания конденсатора
        private string typeCapacitor;
        private string typeConnectionCapacitors;

        private PictureBox picture;
        private TextBox labelValue;
        private TextBox textBoxS;
        private TextBox textBoxFlatE;
        private TextBox textBoxCylE;
        private TextBox textBoxD;
        private TextBox textBoxR1;
        private TextBox textBoxR2;
        private TextBox textBoxL;
        private PictureBox pictureValuePlus;
        private PictureBox pictureValueMinus;
        private PictureBox pictureSeq;
        private PictureBox picturePar;
        private PictureBox pictureGearFlat;
        private PictureBox pictureGearCylinder;
        private PictureBox picturePanelFlat;
        private PictureBox picturePanelCyl;
        private PictureBox contactMinus;
        private PictureBox contactPlus;
        private Zeroit.Framework.Metro.ZeroitMetroCheckCircle checkCircleFlat;
        private Zeroit.Framework.Metro.ZeroitMetroCheckCircle checkCircleCylinder;
        private Zeroit.Framework.Metro.ZeroitMetroCheckCircle.MainColorScheme colorScheme;
        
        private int countCapacitors = 1;

        private double E; // значение относительной диэлектрической проницаемости

        //значения плоского конденсатора
        private double S; // площадь пластин конденсатора
        private double d; // расстояние между пластинами

        //значения плоского конденсатора
        private double R1; // значение внутреннего радиуса конденсатора
        private double R2; // значение внешнего радиуса конденсатора
        private double l; // значение высоты конденсатора

        public Capacitor()
        {
            picture = new PictureBox();
            labelValue = new TextBox();
            textBoxFlatE = new TextBox();
            textBoxCylE = new TextBox();
            textBoxS = new TextBox(); ;
            textBoxD = new TextBox(); ;
            textBoxR1 = new TextBox(); ;
            textBoxR2 = new TextBox(); ;
            textBoxL = new TextBox(); ;

            pictureValuePlus = new PictureBox();
            pictureValueMinus = new PictureBox();
            pictureSeq = new PictureBox();
            picturePar = new PictureBox();
            pictureGearFlat = new PictureBox();
            pictureGearCylinder = new PictureBox();
            picturePanelFlat = new PictureBox();
            picturePanelCyl = new PictureBox();
            contactMinus = new PictureBox();
            contactPlus = new PictureBox();
            checkCircleFlat = new Zeroit.Framework.Metro.ZeroitMetroCheckCircle();
            checkCircleCylinder = new Zeroit.Framework.Metro.ZeroitMetroCheckCircle();
            colorScheme = new Zeroit.Framework.Metro.ZeroitMetroCheckCircle.MainColorScheme();

            labelValue.Text = "1";
            typeCapacitor = "Flat";
            checkCircleFlat.Checked = true;
            checkCircleCylinder.Checked = false;
            picturePanelFlat.Visible = false;
            picturePanelCyl.Visible = false;
        }

        //метод отображения компонента на форме
        public void Visualization(Form form, int x, int y)
        {
            picture.Width = 186;
            picture.Height = 103;
            picture.Left = x - picture.Width / 2;
            picture.Top = y - picture.Height / 2;
            picture.SizeMode = PictureBoxSizeMode.AutoSize;
            picture.BackColor = Color.Transparent;
            picture.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\capacitors\1.png");

            GlobalData.LoadFont(14);  //метод загрузки шрифта
            labelValue.ReadOnly = true;
            labelValue.TabStop = false;
            labelValue.Font = GlobalData.DigitalFont;
            labelValue.Left = 74;
            labelValue.Top = 62;
            labelValue.BorderStyle = BorderStyle.None;
            labelValue.BackColor = Color.Black;
            labelValue.Width = 38;
            labelValue.ForeColor = Color.LimeGreen;
            labelValue.TextAlign = HorizontalAlignment.Center;
            labelValue.Cursor = Cursors.Hand;
            labelValue.MouseMove += LabelValue_MouseMove;
            labelValue.TextChanged += LabelValue_TextChanged;
            picture.Controls.Add(labelValue);

            pictureValueMinus.Width = 16;
            pictureValueMinus.Height = 16;
            pictureValueMinus.Left = 49;
            pictureValueMinus.Top = 66;
            pictureValueMinus.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureValueMinus.BackColor = Color.Transparent;
            pictureValueMinus.Cursor = Cursors.Hand;
            pictureValueMinus.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\capacitors\minus0.png");
            pictureValueMinus.MouseEnter += PictureValueMinus_MouseEnter;
            pictureValueMinus.MouseLeave += PictureValueMinus_MouseLeave;
            pictureValueMinus.Click += PictureValueMinus_Click;
            picture.Controls.Add(pictureValueMinus);

            pictureValuePlus.Width = 16;
            pictureValuePlus.Height = 16;
            pictureValuePlus.Left = 121;
            pictureValuePlus.Top = 66;
            pictureValuePlus.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureValuePlus.BackColor = Color.Transparent;
            pictureValuePlus.Cursor = Cursors.Hand;
            pictureValuePlus.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\capacitors\plus0.png");
            pictureValuePlus.MouseEnter += PictureValuePlus_MouseEnter;
            pictureValuePlus.MouseLeave += PictureValuePlus_MouseLeave;
            pictureValuePlus.Click += PictureValuePlus_Click;
            picture.Controls.Add(pictureValuePlus);

            pictureSeq.Width = 44;
            pictureSeq.Height = 9;
            pictureSeq.Left = 71;
            pictureSeq.Top = 23;
            pictureSeq.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureSeq.BackColor = Color.Transparent;
            pictureSeq.Cursor = Cursors.Hand;
            pictureSeq.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\capacitors\sequentially0.png");
            pictureSeq.Click += PictureSeq_Click;
            picture.Controls.Add(pictureSeq);

            picturePar.Width = 44;
            picturePar.Height = 9;
            picturePar.Left = 71;
            picturePar.Top = 35;
            picturePar.SizeMode = PictureBoxSizeMode.AutoSize;
            picturePar.BackColor = Color.Transparent;
            picturePar.Cursor = Cursors.Hand;
            picturePar.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\capacitors\parallel0.png");
            picturePar.Click += PicturePar_Click;
            picture.Controls.Add(picturePar);

            colorScheme.BorderColor = System.Drawing.Color.Transparent;
            colorScheme.FillColor = System.Drawing.Color.White;
            colorScheme.InnerCirclecolor = System.Drawing.Color.White;

            checkCircleFlat.CheckOnClick = true;
            checkCircleFlat.ColorScheme = colorScheme;
            checkCircleFlat.Left = 11;
            checkCircleFlat.Top = 74;
            checkCircleFlat.Size = new System.Drawing.Size(20, 20);
            checkCircleFlat.Cursor = Cursors.Hand;
            checkCircleFlat.BackColor = Color.Green;
            checkCircleFlat.Click += CheckCircle_Click;
            checkCircleFlat.DoubleClick += CheckCircle_DoubleClick;
            picture.Controls.Add(checkCircleFlat);

            checkCircleCylinder.CheckOnClick = true;
            checkCircleCylinder.ColorScheme = colorScheme;
            checkCircleCylinder.Left = 155;
            checkCircleCylinder.Top = 74;
            checkCircleCylinder.Size = new System.Drawing.Size(20, 20);
            checkCircleCylinder.Cursor = Cursors.Hand;
            checkCircleCylinder.BackColor = Color.Green;
            checkCircleCylinder.Click += CheckCircle_Click;
            checkCircleCylinder.DoubleClick += CheckCircle_DoubleClick;
            picture.Controls.Add(checkCircleCylinder);

            pictureGearFlat.Width = 11;
            pictureGearFlat.Height = 12;
            pictureGearFlat.Left = 11;
            pictureGearFlat.Top = 8;
            pictureGearFlat.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureGearFlat.BackColor = Color.Transparent;
            pictureGearFlat.Cursor = Cursors.Hand;
            pictureGearFlat.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\capacitors\gear.png");
            pictureGearFlat.Click += PictureGearFlat_Click;
            picture.Controls.Add(pictureGearFlat);

            pictureGearCylinder.Width = 11;
            pictureGearCylinder.Height = 12;
            pictureGearCylinder.Left = 165;
            pictureGearCylinder.Top = 8;
            pictureGearCylinder.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureGearCylinder.BackColor = Color.Transparent;
            pictureGearCylinder.Cursor = Cursors.Hand;
            pictureGearCylinder.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\capacitors\gear.png");
            pictureGearCylinder.Click += PictureGearCylinder_Click;
            picture.Controls.Add(pictureGearCylinder);

            // код создания панели для ввода данных ПЛОСКОГО кондесатора

            picturePanelFlat.Width = 134;
            picturePanelFlat.Height = 161;
            picturePanelFlat.Left = picture.Left - 130;
            picturePanelFlat.Top = picture.Top - 28;
            picturePanelFlat.SizeMode = PictureBoxSizeMode.AutoSize;
            picturePanelFlat.BackColor = Color.Transparent;
            picturePanelFlat.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\capacitors\panelFlat.png");
            form.Controls.Add(picturePanelFlat);

                GlobalData.LoadFont(11);  //метод загрузки шрифта
                textBoxS.TabStop = false;
                textBoxS.Font = GlobalData.DigitalFont;
                textBoxS.Left = 15;
                textBoxS.Top = 33;
                textBoxS.BackColor = Color.White;
                textBoxS.Width = 95;
                textBoxS.ForeColor = Color.Black;
                textBoxS.TextAlign = HorizontalAlignment.Left;
                textBoxS.Cursor = Cursors.IBeam;
                picturePanelFlat.Controls.Add(textBoxS);

                GlobalData.LoadFont(11);  //метод загрузки шрифта
                textBoxFlatE.TabStop = false;
                textBoxFlatE.Font = GlobalData.DigitalFont;
                textBoxFlatE.Left = 15;
                textBoxFlatE.Top = 77;
                textBoxFlatE.BackColor = Color.White;
                textBoxFlatE.Width = 95;
                textBoxFlatE.ForeColor = Color.Black;
                textBoxFlatE.TextAlign = HorizontalAlignment.Left;
                textBoxFlatE.Cursor = Cursors.IBeam;
                picturePanelFlat.Controls.Add(textBoxFlatE);

                GlobalData.LoadFont(11);  //метод загрузки шрифта
                textBoxD.TabStop = false;
                textBoxD.Font = GlobalData.DigitalFont;
                textBoxD.Left = 15;
                textBoxD.Top = 122;
                textBoxD.BackColor = Color.White;
                textBoxD.Width = 95;
                textBoxD.ForeColor = Color.Black;
                textBoxD.TextAlign = HorizontalAlignment.Left;
                textBoxD.Cursor = Cursors.IBeam;
                picturePanelFlat.Controls.Add(textBoxD);

            // код создания панели для ввода данных ЦИЛИНДРИЧЕСКОГО кондесатора

            picturePanelCyl.Width = 129;
            picturePanelCyl.Height = 200;
            picturePanelCyl.Left = picture.Left + picture.Width - 4;
            picturePanelCyl.Top = picture.Top - 47;
            picturePanelCyl.SizeMode = PictureBoxSizeMode.AutoSize;
            picturePanelCyl.BackColor = Color.Transparent;
            picturePanelCyl.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\capacitors\panelCyl.png");
            form.Controls.Add(picturePanelCyl);

                GlobalData.LoadFont(11);  //метод загрузки шрифта
                textBoxR1.TabStop = false;
                textBoxR1.Font = GlobalData.DigitalFont;
                textBoxR1.Left = 17;
                textBoxR1.Top = 29;
                textBoxR1.BackColor = Color.White;
                textBoxR1.Width = 100;
                textBoxR1.ForeColor = Color.Black;
                textBoxR1.TextAlign = HorizontalAlignment.Left;
                textBoxR1.Cursor = Cursors.IBeam;
                picturePanelCyl.Controls.Add(textBoxR1);

                GlobalData.LoadFont(11);  //метод загрузки шрифта
                textBoxR2.TabStop = false;
                textBoxR2.Font = GlobalData.DigitalFont;
                textBoxR2.Left = 17;
                textBoxR2.Top = 74;
                textBoxR2.BackColor = Color.White;
                textBoxR2.Width = 100;
                textBoxR2.ForeColor = Color.Black;
                textBoxR2.TextAlign = HorizontalAlignment.Left;
                textBoxR2.Cursor = Cursors.IBeam;
                picturePanelCyl.Controls.Add(textBoxR2);

                GlobalData.LoadFont(11);  //метод загрузки шрифта
                textBoxCylE.TabStop = false;
                textBoxCylE.Font = GlobalData.DigitalFont;
                textBoxCylE.Left = 17;
                textBoxCylE.Top = 117;
                textBoxCylE.BackColor = Color.White;
                textBoxCylE.Width = 100;
                textBoxCylE.ForeColor = Color.Black;
                textBoxCylE.TextAlign = HorizontalAlignment.Left;
                textBoxCylE.Cursor = Cursors.IBeam;
                picturePanelCyl.Controls.Add(textBoxCylE);

                GlobalData.LoadFont(11);  //метод загрузки шрифта
                textBoxL.TabStop = false;
                textBoxL.Font = GlobalData.DigitalFont;
                textBoxL.Left = 17;
                textBoxL.Top = 164;
                textBoxL.BackColor = Color.White;
                textBoxL.Width = 100;
                textBoxL.ForeColor = Color.Black;
                textBoxL.TextAlign = HorizontalAlignment.Left;
                textBoxL.Cursor = Cursors.IBeam;
                picturePanelCyl.Controls.Add(textBoxL);

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
            picturePanelFlat.BringToFront();
            pictureSeq.BringToFront();
            labelValue.BringToFront();
            contactMinus.BringToFront();
            contactPlus.BringToFront();
            form.Controls.Add(picture);
        }

        private void PictureGearCylinder_Click(object sender, EventArgs e)
        {
            if (picturePanelCyl.Visible == false)
            {
                picturePanelCyl.Visible = true;
            }
            else
            {
                if (textBoxR1.Text == "0" || textBoxR2.Text == "0" || textBoxCylE.Text == "0" || textBoxL.Text == "0")
                {
                    MessageBox.Show("Введите корректные значения цилиндрического конденсатора");
                    picturePanelCyl.Visible = true;
                }
                else if (textBoxR1.Text != "" & textBoxR2.Text != "" & textBoxCylE.Text != "" & textBoxL.Text != "")
                {
                    R1 = Convert.ToDouble(textBoxR1.Text);
                    R2 = Convert.ToDouble(textBoxR2.Text);
                    E = Convert.ToDouble(textBoxCylE.Text);
                    l = Convert.ToDouble(textBoxL.Text);

                    GlobalData.reportManager.AddToStringChangesValue(R1, R2, E, l);

                    picturePanelCyl.Visible = false;
                }
                else
                {
                    MessageBox.Show("Введите значения цилиндрического конденсатора");
                    picturePanelCyl.Visible = true;
                }
            }
        }

        private void PictureGearFlat_Click(object sender, EventArgs e)
        {
            if (picturePanelFlat.Visible == false)
            {
                picturePanelFlat.Visible = true;
            }
            else 
            {
                if (textBoxS.Text == "0" || textBoxFlatE.Text == "0" || textBoxD.Text == "0")
                {
                    MessageBox.Show("Введите корректные значения плоского конденсатора");
                    picturePanelFlat.Visible = true;
                }
                else if (textBoxS.Text != "" & textBoxFlatE.Text != "" & textBoxD.Text != "")
                {
                    S = Convert.ToDouble(textBoxS.Text);
                    E = Convert.ToDouble(textBoxFlatE.Text);
                    d = Convert.ToDouble(textBoxD.Text);

                    GlobalData.reportManager.AddToStringChangesValue(S, E, d);

                    picturePanelFlat.Visible = false;
                }
                else 
                {
                    MessageBox.Show("Введите значения плоского конденсатора");
                    picturePanelFlat.Visible = true;
                }
            }
        }

        private void PicturePar_Click(object sender, EventArgs e)
        {
            typeConnectionCapacitors = Convert.ToString(GlobalData.TypeConnectionCapacitors.Parallel);
            pictureSeq.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\capacitors\sequentially0.png");
            picturePar.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\capacitors\parallel1.png");
        }

        private void PictureSeq_Click(object sender, EventArgs e)
        {
            typeConnectionCapacitors = Convert.ToString(GlobalData.TypeConnectionCapacitors.Sequentially);
            
            pictureSeq.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\capacitors\sequentially1.png");
            picturePar.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\capacitors\parallel0.png");
        }

        private void PictureValuePlus_Click(object sender, EventArgs e)
        {
            if (this.countCapacitors != 10)
            {
                ++this.countCapacitors;
                labelValue.Text = Convert.ToString(this.countCapacitors);
                if (this.countCapacitors == 2) 
                {
                    pictureSeq.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\capacitors\sequentially1.png");
                    picturePar.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\capacitors\parallel0.png");
                }
            }
        }

        private void PictureValueMinus_Click(object sender, EventArgs e)
        {
            if (this.countCapacitors != 1)
            {
                --this.countCapacitors;
                labelValue.Text = Convert.ToString(this.countCapacitors);
                if (this.countCapacitors < 2) 
                {
                    pictureSeq.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\capacitors\sequentially0.png");
                    picturePar.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\capacitors\parallel0.png");
                }
            }
        }

        private void PictureValuePlus_MouseLeave(object sender, EventArgs e)
        {
            pictureValuePlus.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\capacitors\plus0.png");
        }

        private void PictureValuePlus_MouseEnter(object sender, EventArgs e)
        {
            pictureValuePlus.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\capacitors\plus1.png");
        }

        private void PictureValueMinus_MouseLeave(object sender, EventArgs e)
        {
            pictureValueMinus.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\capacitors\minus0.png");
        }

        private void PictureValueMinus_MouseEnter(object sender, EventArgs e)
        {
            pictureValueMinus.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\capacitors\minus1.png");
        }

        private void CheckCircle_DoubleClick(object sender, EventArgs e)
        {
            if (checkCircleFlat.Checked == true)
            {
                checkCircleFlat.Checked = false;
                typeCapacitor = Convert.ToString(GlobalData.TypeCapacitor.Cylinder);
            }
            else if (checkCircleCylinder.Checked == true)
            {
                checkCircleCylinder.Checked = false;
                typeCapacitor = Convert.ToString(GlobalData.TypeCapacitor.Flat);
            }
        }

        private void CheckCircle_Click(object sender, EventArgs e)
        {
            if (checkCircleFlat.Checked == true)
            {
                checkCircleFlat.Checked = false;
                typeCapacitor = Convert.ToString(GlobalData.TypeCapacitor.Cylinder);
            }
            else if(checkCircleCylinder.Checked == true)
            {
                checkCircleCylinder.Checked = false;             
                typeCapacitor = Convert.ToString(GlobalData.TypeCapacitor.Flat);
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
