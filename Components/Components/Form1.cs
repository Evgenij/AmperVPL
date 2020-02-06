using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        Resistor[] resistor = new Resistor[2];
        Conductor conductor;
        Rheostat rheostat;
        VoltageSource voltageSource;
        Capacitor capacitor;
        SingleSwitch singleSwitch;
        DoubleSwitch doubleSwitch;
        Toggle toggle;
        HeatingArea heatingArea;


        StudentManager studentManager;
        
        int x, y;

        public MainForm()
        {
            InitializeComponent();
            voltmeter = new Voltmeter();
            multimeter = new Multimeter();
            resistor[0] = new Resistor();
            resistor[1] = new Resistor();
            conductor = new Conductor();
            rheostat = new Rheostat();
            voltageSource = new VoltageSource();
            capacitor = new Capacitor();
            singleSwitch = new SingleSwitch();
            doubleSwitch = new DoubleSwitch();
            toggle = new Toggle();
            heatingArea = new HeatingArea();


            studentManager = new StudentManager();
            GlobalData.reportManager = new ReportManager("Ермоленко", "Евгений", 1);
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            label1.Text = Convert.ToString(x);
            label2.Text = Convert.ToString(y);
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
            //GlobalData.reportManager.AddActionStringToReport();
        }

        private void zeroitMetroSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (zeroitMetroSwitch1.Checked == false) 
            {
                GlobalData.reportManager.AddActionStringToReport();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            GlobalData.reportManager.AddSection("Секция 1");
            GlobalData.reportManager.AddToStringChangesValue(0.1, 0.3, 0.3, 1);
            GlobalData.reportManager.AddActionStringToReport();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            multimeter.Calculate();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            GlobalData.reportManager.AddToStringAction(ammeter, ReportManager.TypeAction.Add);
            GlobalData.reportManager.AddActionStringToReport();
            string[] pole = new string[] { "first", "second", "third" };
            int[] values = new int[] { 1, 2, 3, 4, 5 };
            GlobalData.reportManager.AddTable(pole);
            GlobalData.reportManager.AddValuesToTable(values);

            GlobalData.reportManager.AddToStringAction(ammeter, ReportManager.TypeAction.Add);
            GlobalData.reportManager.AddActionStringToReport();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            string[] questions = new string[] {
                "Вопрос №1",
                "Вопрос №2"
            };
            string[] answers = new string[] {
                "Ответ 1",
                "Ответ 2"
            };
            GlobalData.reportManager.AddSection("Контрольные вопросы:");
            GlobalData.reportManager.AddControlQuestionsToReport(questions, answers);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (ammeter != null)
            {
                MessageBox.Show("1");
            }
            else 
            {
                MessageBox.Show("0");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            resistor[0].Visualization(this, 500, 150);

            //Graphics graphics = this.CreateGraphics();
            //graphics.DrawLine(new Pen(Color.Red, 3), 0, 0, 1000, 700);
            //graphics.Dispose();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            resistor[1].Visualization(this, 500, 300);
            heatingArea.DrawHeatingArea(this, resistor);
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            if (zeroitMetroSwitch1.Checked == true)
            {
                if (radioButton1.Checked == true)
                {
                    ammeter = new Ammeter();
                    ammeter.Visualization(this, x, y);
                    GlobalData.reportManager.AddToStringAction(ammeter, ReportManager.TypeAction.Add);
                }
                else if (radioButton2.Checked == true)
                {
                    voltmeter.Visualization(this, x, y);
                    GlobalData.reportManager.AddToStringAction(voltmeter, ReportManager.TypeAction.Add);
                }
                else if (radioButton3.Checked == true)
                {
                    multimeter.Visualization(this, x, y);
                    GlobalData.reportManager.AddToStringAction(multimeter, ReportManager.TypeAction.Add);
                }
                else if (radioButton4.Checked == true)
                {
                    resistor[0].Visualization(this, x, y);
                    GlobalData.reportManager.AddToStringAction(resistor, ReportManager.TypeAction.Add);
                }
                else if (radioButton5.Checked == true)
                {
                    rheostat.Visualization(this, x, y);
                    GlobalData.reportManager.AddToStringAction(rheostat, ReportManager.TypeAction.Add);
                }
                else if (radioButton6.Checked == true)
                {
                    voltageSource.Visualization(this, x, y);
                    GlobalData.reportManager.AddToStringAction(voltageSource, ReportManager.TypeAction.Add);
                }
                else if (radioButton7.Checked == true)
                {
                    capacitor.Visualization(this, x, y);
                    GlobalData.reportManager.AddToStringAction(capacitor, ReportManager.TypeAction.Add);
                    //GlobalData.reportManager.AddToStringChangesValue(2.1, 2.3, 0.3);
                    //GlobalData.reportManager.AddToStringChangesValue(0.1, 0.3, 0.3, 1);
                }
                else if (radioButton8.Checked == true)
                {
                    singleSwitch.Visualization(this, x, y);
                }
                else if (radioButton9.Checked == true)
                {
                    doubleSwitch.Visualization(this, x, y);
                }
                else if (radioButton10.Checked == true)
                {
                    toggle.Visualization(this, x, y);
                }
                else if (radioButton11.Checked == true)
                {
                    heatingArea.DrawHeatingArea(this, resistor);
                }
                else if (radioButton12.Checked == true)
                {

                }
                else if (radioButton13.Checked == true)
                {

                }
                else if (radioButton14.Checked == true)
                {
                    conductor.Visualization(this, x, y);
                    GlobalData.reportManager.AddToStringAction(conductor, ReportManager.TypeAction.Add);
                }
            }
        }
    }
}
