using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach2_WF_
{
    public partial class Form2 : Form
    {
        int opt;
        double[,] values;
        double[,] values2;
        double[,] svalues;
        public Form2(int opt, double[,] values, double[,] values2, double[,] svalues)
        {
            InitializeComponent();
            this.opt =opt;
            this.values=values;
            this.values2=values2;
            this.svalues = svalues;
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
