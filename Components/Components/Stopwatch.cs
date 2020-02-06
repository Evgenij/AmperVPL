using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Components
{
    class Stopwatch : IVisualization 
    {
        //компоненты формы для создания амперметра
        private PictureBox picture;
        private TextBox labelValue;
        private CircleAnglePicker valueArrow;
        private Timer timer;
        private int seconds = 0;
        private int minuts = 0;

        public Stopwatch() 
        {
            picture = new PictureBox();
            labelValue = new TextBox();
            valueArrow = new CircleAnglePicker();
            timer = new Timer();

            valueArrow.Value = 90;
            labelValue.Text = "0";
        }

        public void Visualization(Form form, int x, int y)
        {
            picture.Width = 85;
            picture.Height = 124;
            picture.Left = x - picture.Width / 2;
            picture.Top = y - picture.Height / 2;
            picture.BackColor = Color.Transparent;
            picture.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\stopwatch\stopwatch.png");
            form.Controls.Add(picture);

            GlobalData.LoadFont(13);  //метод загрузки шрифта
            labelValue.ReadOnly = true;
            labelValue.TabStop = false;
            labelValue.Font = GlobalData.DigitalFont;
            labelValue.Left = 20;
            labelValue.Top = 23;
            labelValue.BorderStyle = BorderStyle.None;
            labelValue.BackColor = Color.Black;
            labelValue.Width = 45;
            labelValue.ForeColor = Color.DeepSkyBlue;
            labelValue.TextAlign = HorizontalAlignment.Center;
            labelValue.Cursor = Cursors.Hand;
            labelValue.MouseMove += LabelValue_MouseMove;
            labelValue.TextChanged += LabelValue_TextChanged;
            picture.Controls.Add(labelValue);

            valueArrow.Parent = picture;
            valueArrow.Enabled = false;
            valueArrow.Height = 49;
            valueArrow.Width = 49;
            valueArrow.BackColor = Color.Transparent;
            valueArrow.Left = 18;
            valueArrow.Top = 54;
            valueArrow.Parent = picture;
            valueArrow.CircleColor = Color.Transparent;
            picture.Controls.Add(valueArrow);

            timer.Interval = 1000;
            timer.Enabled = false;
            timer.Tick += Timer_Tick;

            picture.SendToBack();
            valueArrow.BringToFront();
            labelValue.BringToFront();
            form.Controls.Add(picture);
        }

        public void Start() 
        {
            timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            seconds += 1;
            valueArrow.Value -= 6;

            if (seconds == 60)
            {
                labelValue.Text = Convert.ToString(seconds) + "с";
            }
            if (seconds == 61)
            {
                minuts += 1;
                seconds = 0;
            }

            if (minuts < 1)
            {
                labelValue.Text = Convert.ToString(seconds) + "с";
            }
            else 
            {
                labelValue.Text = Convert.ToString(minuts) + "." + Convert.ToString(seconds) + "м";
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
