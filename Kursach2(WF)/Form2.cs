using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Kursach2_WF_
{
    public partial class Form2 : Form
    {
        int opt;
        double number;
        double[,] values;
        double[,] values2;
        double[,] svalues;
        public Form2(int opt, double[,] values, double[,] values2, double[,] svalues, double number)
        {
            InitializeComponent();
            this.opt = opt;
            this.number = number;
            this.values = values;
            this.values2 = values2;
            this.svalues = svalues;
        }
        public class files
        {
            public int option { get; set; }
            public double number { get; set; }
            public double[,] firstm { get; set; }
            public double[,] secondm { get; set; }
            public double[,] answer { get; set; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var save = new files();
            save.option = opt;
            save.number = number;
            int j = values.Length;

            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.ShowDialog();
        }
    }
}
