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
        Multimeter multimeter;
        Resistor resistor;
        Rheostat rheostat;
        VoltageSource voltageSource;
        Capacitor capacitor;
        StudentManager studentManager;
        
        int x, y;

        public MainForm()
        {
            InitializeComponent();
            ammeter = new Ammeter();
            voltmeter = new Voltmeter();
            multimeter = new Multimeter();
            resistor = new Resistor();
            rheostat = new Rheostat();
            voltageSource = new VoltageSource();
            capacitor = new Capacitor();
            studentManager = new StudentManager();
            GlobalData.reportManager = new ReportManager("Ермоленко", "Евгений", 1);
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ammeter.Calculate(50,2.5);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            voltmeter.Calculate(12,2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Записать значение по ключу age и name в секции main
            for (int i = 1; i <= 5; i++)
            {
                GlobalData.iniManager.WriteString("Student_id" + Convert.ToString(i), "surname", "null");
                GlobalData.iniManager.WriteString("Student_id" + Convert.ToString(i), "name", "null");
                GlobalData.iniManager.WriteString("Student_id" + Convert.ToString(i), "group", "null");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!GlobalData.iniManager.KeyExists("Section3", "name"))
            {
                MessageBox.Show("key not found...");
            }
            else 
            {
                MessageBox.Show(GlobalData.iniManager.ReadString("Section3", "name"));
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GlobalData.iniManager.DeleteKey("Section3", "name");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GlobalData.iniManager.DeleteSection("Section3");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            studentManager.Registration("123","Ермоленко", "Евгений", "ИВТ-7", @"C:\...");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            studentManager.Authorization("Ермоленко", "123");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            studentManager.Deleting(studentManager.GetId());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            studentManager.Change(studentManager.GetId(),"null", "null", "null", "null", "null");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            GlobalData.reportManager.AddHeader("Ермоленко", "Евгений", "ИВТ-7");
            GlobalData.reportManager.AddFooter();
            GlobalData.reportManager.AddReportHead("1", GlobalData.reportManager.GetLabTheme(1), GlobalData.reportManager.GetLabTarget(1));
            GlobalData.reportManager.AddСonclusion("Текст вывода аолтоаыволтаолдвытповатямлоав...");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            GlobalData.reportManager.AddChangingValue(GlobalData.TypeComponent.Ammeter, 29);
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                ammeter.Visualization(this, x, y);
                GlobalData.reportManager.AddComponent(ammeter);
                GlobalData.reportManager.AddComponent(ammeter);
            }
            else if (radioButton2.Checked == true) 
            {
                voltmeter.Visualization(this, x, y);
            }
            else if (radioButton3.Checked == true)
            {
                multimeter.Visualization(this, x, y);
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
                voltageSource.Visualization(this, x, y);
            }
            else if (radioButton7.Checked == true)
            {
                capacitor.Visualization(this, x, y);
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
