using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            calculator = new Calculator();
            UpdateForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calculator.SetNextNumber(1);
            UpdateForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            calculator.SetNextNumber(2);
            UpdateForm();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            calculator.SetNextNumber(3);
            UpdateForm();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            calculator.SetNextNumber(4);
            UpdateForm();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            calculator.SetNextNumber(5);
            UpdateForm();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            calculator.SetNextNumber(6);
            UpdateForm();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            calculator.SetNextNumber(7);
            UpdateForm();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            calculator.SetNextNumber(8);
            UpdateForm();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            calculator.SetNextNumber(9);
            UpdateForm();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            calculator.SetNextNumber(0);
            UpdateForm();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            calculator.SaveNumber();
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            calculator.LoadNumber();
            UpdateForm();
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            calculator.Clear();
            UpdateForm();
        }

        private void button_sin_Click(object sender, EventArgs e)
        {
            calculator.Sin();
            UpdateForm();
        }

        private void button_cos_Click(object sender, EventArgs e)
        {
            calculator.Cos();
            UpdateForm();
        }

        private void button_tang_Click(object sender, EventArgs e)
        {
            calculator.Tg();
            UpdateForm();
        }

        private void button_sqrt2_Click(object sender, EventArgs e)
        {
            calculator.Sqrt2();
            UpdateForm();
        }

        private void button_sqrt3_Click(object sender, EventArgs e)
        {
            calculator.Sqrt3();
            UpdateForm();
        }

        private void button_pow_Click(object sender, EventArgs e)
        {
            calculator.Pow();
            UpdateForm();
        }

        private void button_negative_Click(object sender, EventArgs e)
        {
            calculator.Negate();
            UpdateForm();
        }

        private void UpdateForm()
        {
            int w = label_number.Width;
            label_number.Text = calculator.Number.ToString();
            label_number.Location = new Point(label_number.Location.X - label_number.Width + w, label_number.Location.Y);
        }

        private Calculator calculator { get; set; }

    }
}
