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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

 
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int N = Convert.ToInt32(textBox1.Text);
            int M = Convert.ToInt32(textBox2.Text);
            dataGridView1.Size = new System.Drawing.Size(N * 100, M * 100);

            dataGridView1.RowCount = N;
            dataGridView1.ColumnCount = M;
            int i, j;

            int[,] a = new int[N, M];
            Random r = new Random(10);

            for (i = 0; i < N; i++)
            {
                for (j = 0; j < M; j++)
                {
                    a[i, j] = r.Next(10);
                    dataGridView1.Rows[i].Cells[j].Value = a[i, j].ToString();
                }

            }

        }
    }
}
