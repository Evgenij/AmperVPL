using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Components
{
    class Thermometr
    {
        private PictureBox pictureThermometr;
        private Zeroit.Framework.Metro.ZeroitMetroProgressbar scale;
        private TextBox labelValue;
        private string symbolTemp = "°С";
        private int valueTemp = 0;

        public Thermometr(Form form,int x, int y) 
        {
            scale = new Zeroit.Framework.Metro.ZeroitMetroProgressbar();
            pictureThermometr = new PictureBox();
            labelValue = new TextBox();

            pictureThermometr.Width = 44;
            pictureThermometr.Height = 250;
            pictureThermometr.Left = x;
            pictureThermometr.Top = y;
            pictureThermometr.BackColor = Color.Transparent;
            pictureThermometr.Cursor = Cursors.SizeNS;
            pictureThermometr.MouseWheel += Scale_MouseWheel;
            pictureThermometr.Image = Image.FromFile(@"C:\Users\Evgenij\Amper VPL\Components\heating_area\thermometr.png");

            scale.Left = pictureThermometr.Left + 7;
            scale.Top = pictureThermometr.Top + 15;
            scale.Width = 220;
            scale.Height = 10;
            scale.Maximum = 80;
            scale.Value = 79;
            scale.DefaultColor = Color.Red;
            scale.ProgressColor = Color.White;
            scale.GradientColor = Color.White;
            scale.Orientation = Orientation.Vertical;
            scale.Cursor = Cursors.SizeNS;
            scale.MouseWheel += Scale_MouseWheel;
            form.Controls.Add(scale);

            GlobalData.LoadFont(13);  //метод загрузки шрифта
            labelValue.TabStop = false;
            labelValue.Font = GlobalData.DigitalFont;
            labelValue.Left = pictureThermometr.Left;
            labelValue.Top = pictureThermometr.Top - 15;
            labelValue.BorderStyle = BorderStyle.None;
            labelValue.BackColor = Color.DarkOrange;
            labelValue.Width = 44;
            labelValue.TextAlign = HorizontalAlignment.Center;
            labelValue.ForeColor = Color.Black;
            labelValue.Cursor = Cursors.Hand;
            labelValue.Text = Convert.ToString(valueTemp) + symbolTemp;
            form.Controls.Add(labelValue);

            pictureThermometr.SendToBack();
            scale.BringToFront();
            form.Controls.Add(pictureThermometr);
        }

        private void Scale_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta != 0) 
            {
                if(e.Delta > 0) 
                {
                    if (labelValue.Text != "80°С") 
                    {
                        scale.Value = scale.Value - 1;
                        valueTemp = 80 - scale.Value - 1;
                        labelValue.Text = Convert.ToString(valueTemp) + symbolTemp; 
                    }
                }
                else
                {
                    if (labelValue.Text != "0°С")
                    {
                        scale.Value = scale.Value + 1;
                        valueTemp = 80 - scale.Value - 1;
                        labelValue.Text = Convert.ToString(valueTemp) + symbolTemp;
                    }
                }
            }
        }
    }
}
