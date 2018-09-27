using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorWindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = int.Parse(txtBox1.Text); //proses casting
            var b = Convert.ToInt32(txtBox2.Text); //proses casting 
            Double Hasil;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    Hasil = a + b;
                    textBox3.Text = Convert.ToString(Hasil);
                    break;
                case 1:
                    Hasil = a - b;
                    textBox3.Text = Convert.ToString(Hasil);
                    break;
                case 2:
                    Hasil = a * b;
                    textBox3.Text = Convert.ToString(Hasil);
                    break;
                case 3:
                    Hasil = a / b;
                    textBox3.Text = Convert.ToString(Hasil);
                    break;
            }
        }
    }
}
