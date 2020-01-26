using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Components 
{
    class Rheostat : ResistanceDevice, IVisualization
    {
        //компоненты формы для создания резистора
        private PictureBox picture;
        private PictureBox tablo;
        private PictureBox probe;
        private PictureBox contactMinus;
        private PictureBox contactPlus;
        private TextBox labelValue;
        private Zeroit.Framework.Metro.ZeroitMetroTrackbar slider; 

        public Rheostat()
        {
            picture = new PictureBox();
            labelValue = new TextBox();
            contactMinus = new PictureBox();
            contactPlus = new PictureBox();
            slider = new Zeroit.Framework.Metro.ZeroitMetroTrackbar();
            tablo = new PictureBox();
            probe = new PictureBox();

            labelValue.Text = "1";
            resistanceValue = 1;
        }

        public void Visualization(Form form, int x, int y)
        {
            picture.Width = 188;
            picture.Height = 103;
            picture.Left = x - picture.Width / 2;
            picture.Top = y - picture.Height / 2;
            picture.SizeMode = PictureBoxSizeMode.AutoSize;
            picture.BackColor = Color.Transparent;
            picture.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\rheostat\rheostat.png");
 
            slider.Top = 36;
            slider.Left = 37;
            slider.Minimum = 1;
            slider.Maximum = 50;
            slider.Value = 0;
            slider.BorderColor = Color.DimGray;
            slider.RailWidth = 3;
            slider.SliderWidth = 17;
            slider.LeftColor = Color.Silver;
            slider.RightColor = Color.Silver;
            slider.HoverColor = Color.DimGray;
            slider.GradientColor = Color.Silver;
            slider.SliderColor = Color.DimGray;
            slider.Cursor = Cursors.Hand;
            slider.Width = 113;
            slider.Height = 9;
            slider.Scroll += Slider_Scroll;
            picture.Controls.Add(slider);

            tablo.Top = 10;
            tablo.SizeMode = PictureBoxSizeMode.AutoSize;
            tablo.Left = slider.Left - 15 + slider.Value;
            tablo.BackColor = Color.Transparent;
            tablo.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\rheostat\tablo.png");
            picture.Controls.Add(tablo);

            probe.Top = 42;
            probe.Width = 7;
            probe.SizeMode = PictureBoxSizeMode.AutoSize;
            probe.Left = tablo.Left + tablo.Width/2 - probe.Width/2 - 1;
            probe.BackColor = Color.Transparent;
            probe.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\rheostat\probe.png");
            picture.Controls.Add(probe);

            GlobalData.LoadFont(12);  //метод загрузки шрифта
            labelValue.ReadOnly = true;
            labelValue.TabStop = false;
            labelValue.Font = GlobalData.DigitalFont;
            labelValue.Left = tablo.Left + 5;
            labelValue.Top = 14;
            labelValue.BorderStyle = BorderStyle.None;
            labelValue.BackColor = Color.Black;
            labelValue.Width = 37;
            labelValue.ForeColor = Color.Orange;
            labelValue.TextAlign = HorizontalAlignment.Center;
            labelValue.Cursor = Cursors.Hand;
            labelValue.MouseMove += LabelValue_MouseMove;
            labelValue.TextChanged += LabelValue_TextChanged;
            picture.Controls.Add(labelValue);

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
            form.Controls.Add(picture);
        }

        private void Slider_Scroll(object sender, Zeroit.Framework.Metro.ZeroitMetroTrackbar.TrackbarEventArgs e)
        {
            tablo.Left = Convert.ToInt32((slider.Left - 16 + slider.Value * 2) - 1.4);
            probe.Left = Convert.ToInt32(tablo.Left + tablo.Width / 2 - probe.Width / 2 - 1);
            labelValue.Left = tablo.Left + 5;
            labelValue.Text = Convert.ToString(slider.Value);
            resistanceValue = slider.Value;
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
