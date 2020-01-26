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
        //компоненты формы для создания амперметра
        private string typeCapacitor;
        private string typeConnectionCapacitors;

        private PictureBox picture;
        private TextBox labelValue;
        private PictureBox pictureValuePlus;
        private PictureBox pictureValueMinus;
        private PictureBox pictureSeq;
        private PictureBox picturePar;
        private PictureBox contactMinus;
        private PictureBox contactPlus;
        private Zeroit.Framework.Metro.ZeroitMetroCheckCircle checkCircleFlat;
        private Zeroit.Framework.Metro.ZeroitMetroCheckCircle checkCircleCylinder;
        private Zeroit.Framework.Metro.ZeroitMetroCheckCircle.MainColorScheme colorScheme;
        private int countCapacitors = 1;

        public Capacitor()
        {
            picture = new PictureBox();
            labelValue = new TextBox();
            pictureValuePlus = new PictureBox();
            pictureValueMinus = new PictureBox();
            pictureSeq = new PictureBox();
            picturePar = new PictureBox();
            contactMinus = new PictureBox();
            contactPlus = new PictureBox();
            checkCircleFlat = new Zeroit.Framework.Metro.ZeroitMetroCheckCircle();
            checkCircleCylinder = new Zeroit.Framework.Metro.ZeroitMetroCheckCircle();
            colorScheme = new Zeroit.Framework.Metro.ZeroitMetroCheckCircle.MainColorScheme();

            labelValue.Text = "1";
            typeCapacitor = "Flat";
            checkCircleFlat.Checked = true;
            checkCircleCylinder.Checked = false;
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
            pictureSeq.BringToFront();
            labelValue.BringToFront();
            contactMinus.BringToFront();
            contactPlus.BringToFront();
            form.Controls.Add(picture);
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
            if (countCapacitors != 10)
            {
                countCapacitors++;
                labelValue.Text = Convert.ToString(countCapacitors);
                if (countCapacitors >= 2) 
                {
                    pictureSeq.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\capacitors\sequentially1.png");
                    picturePar.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\capacitors\parallel0.png");
                }
            }
        }

        private void PictureValueMinus_Click(object sender, EventArgs e)
        {
            if (countCapacitors != 1)
            {
                countCapacitors--;
                labelValue.Text = Convert.ToString(countCapacitors);
                if (countCapacitors < 2) 
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
