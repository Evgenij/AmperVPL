using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Components
{
    public partial class MainForm : Form
    {
        Ammeter ammeter;
        Voltmeter voltmeter;
        Multimeter multimetr;
        Resistor resistor;
        Rheostat rheostat;
        int x, y;

        public MainForm()
        {
            InitializeComponent();
            ammeter = new Ammeter();
            voltmeter = new Voltmeter();
            multimetr = new Multimeter();
            resistor = new Resistor();
            rheostat = new Rheostat();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ammeter.Visualization(this, 100, 100);
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ammeter.Calculate(50,2.5);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            voltmeter.Calculate(12,2);
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                ammeter.Visualization(this, x, y);
            }
            else if (radioButton2.Checked == true) 
            {
                voltmeter.Visualization(this, x, y);
            }
            else if (radioButton3.Checked == true)
            {
                multimetr.Visualization(this, x, y);
            }
            else if (radioButton4.Checked == true)
            {
                resistor.Visualization(this, x, y);
            }
            else if (radioButton5.Checked == true)
            {
                rheostat.Visualization(this, x, y);
            }
            else if (radioButton6.Checked == true)
            {

            }
            else if (radioButton7.Checked == true)
            {

            }
            else if (radioButton8.Checked == true)
            {

            }
            else if (radioButton9.Checked == true)
            {

            }
            else if (radioButton10.Checked == true)
            {

            }
            else if (radioButton11.Checked == true)
            {

            }
            else if (radioButton12.Checked == true)
            {

            }
            else if (radioButton13.Checked == true)
            {

            }

        }
    }
}
