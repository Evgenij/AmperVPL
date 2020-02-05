using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;

namespace Components
{
    class Ammeter : MeterDevice, IVisualization
    {
        //компоненты формы для создания амперметра
        private PictureBox picture;
        private PictureBox contactMinus;
        private PictureBox contactPlus;
        private TextBox labelValue;
        private CircleAnglePicker valueArrow;

        public Ammeter() 
        {
            picture = new PictureBox();
            labelValue = new TextBox();
            valueArrow = new CircleAnglePicker();
            contactMinus = new PictureBox();
            contactPlus = new PictureBox();

            valueArrow.Value = 180;
            labelValue.Text = "0";
        }

        //функция подсчета значения компонента
        public override double Calculate(double volt, double resist) 
        {
            Value = volt / resist;
            labelValue.Text = Convert.ToString(Math.Round(Value, 2));
            if (Value == 50)
            {
                valueArrow.Value = 0;
            }
            else if (Value == 25)
            {
                valueArrow.Value = 90;
            }
            else 
            {
                valueArrow.Value = Convert.ToInt32(180 - Value * GlobalData.multiplierValues);
            }

            GlobalData.reportManager.AddToStringChangesValue(
                ReportManager.TypeComponent.Ammeter, 
                ReportManager.TypeChanges.DefautChange, 
                Value);

            return Value;
        }

        //метод отображения компонента на форме
        public void Visualization(Form form, int x, int y) 
        {
            picture.Width = 135;
            picture.Height = 125;
            picture.Left = x - picture.Width / 2;
            picture.Top = y - picture.Height / 2;
            picture.BackColor = Color.Transparent;
            picture.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\ammeter\ammeter.png");
            form.Controls.Add(picture);

            GlobalData.LoadFont(12);  //метод загрузки шрифта
            labelValue.ReadOnly = true;
            labelValue.TabStop = false;
            labelValue.Font = GlobalData.DigitalFont;
            labelValue.Left = 43;
            labelValue.Top = 96;
            labelValue.BorderStyle = BorderStyle.None;
            labelValue.BackColor = Color.Black;
            labelValue.Width = 50;
            labelValue.ForeColor = Color.Red;
            labelValue.TextAlign = HorizontalAlignment.Center;
            labelValue.Cursor = Cursors.Hand;
            labelValue.MouseMove += LabelValue_MouseMove;
            labelValue.TextChanged += LabelValue_TextChanged;
            labelValue.Click += LabelValue_Click;
            picture.Controls.Add(labelValue);
 
            valueArrow.Parent = picture;
            valueArrow.Enabled = false;
            valueArrow.Height = 115;
            valueArrow.Width = 115;
            valueArrow.BackColor = Color.Transparent;
            valueArrow.Left = 10;
            valueArrow.Top = 9;
            valueArrow.Parent = picture;
            valueArrow.CircleColor = Color.Transparent;
            picture.Controls.Add(valueArrow);

            contactMinus.Width = 35;
            contactMinus.Height = 12;
            contactMinus.Left = 13;
            contactMinus.Top = 113;
            contactMinus.Cursor = Cursors.Hand;
            contactMinus.BackColor = Color.Transparent;
            picture.Controls.Add(contactMinus);
  
            contactPlus.Width = 35;
            contactPlus.Height = 12;
            contactPlus.Left = 85;
            contactPlus.Top = 113;
            contactPlus.Cursor = Cursors.Hand;
            contactPlus.BackColor = Color.Transparent;
            picture.Controls.Add(contactPlus);

            picture.SendToBack();
            valueArrow.BringToFront();
            labelValue.BringToFront();
            contactMinus.BringToFront();
            contactPlus.BringToFront();
            form.Controls.Add(picture);
        }

        private void LabelValue_Click(object sender, EventArgs e)
        {
            Delete(this);
        }

        public void Delete(Ammeter ammeter) 
        {
            this.picture.Dispose();
            ammeter = null;
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
