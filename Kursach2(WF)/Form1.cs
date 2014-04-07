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
            dataGridView1.Size = new System.Drawing.Size(N * 26, M * 21);

            dataGridView1.RowCount = N;
            dataGridView1.ColumnCount = M;
            int i = 0, j = 0;

            for (i = 0; i < N; i++)
            {
                for (j = 0; j < M; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = 0;
                    dataGridView1.Columns[i].Width = 25;
                    dataGridView1.Rows[i].Height = 20;
                }

            }
            //   dataGridView1.Location = new Point(this.dataGridView1.Location.X, 200);
            //   dataGridView1.Location = new Point(this.dataGridView1.Location.Y, 200);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            label3.Visible = false;
            textBox3.Visible = false;
            label2.Text = "T";

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            label3.Visible = false;
            textBox3.Visible = false;
            label2.Text = "-1";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = true;
            textBox3.Visible = true;
        }

    }
}
