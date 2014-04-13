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
        int opt = 0;
        int M;
        int N;
        public Form1()
        {
            InitializeComponent();


        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = e.Control as TextBox;
            if (tb != null)
            {
                e.Control.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
            }
        }
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '-' && (sender as TextBox).Text.Length > 0)
            {
                e.Handled = true;
            }

        }




        private void button1_Click(object sender, EventArgs e)
        {
            N = Convert.ToInt32(textBox1.Text);
            M = Convert.ToInt32(textBox2.Text);

            if ((Convert.ToInt32(textBox1.Text) > 0) && (Convert.ToInt32(textBox2.Text) > 0))
            {
                dataGridView1.RowCount = N;
                dataGridView1.ColumnCount = M;
                int i = 0, j = 0;

                for (i = 0; i < N; i++)
                {
                    for (j = 0; j < M; j++)
                    {
                        dataGridView1.Columns[j].Width = 25;
                        dataGridView1.Rows[i].Height = 20;
                    }

                }
                if (N > 7) N = 7;

                int x, y;

                x = dataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 1;
                y = dataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + 1;

                if (x > 201) x = 202;
                if (y > 161) y = 162;

                dataGridView1.Location = new Point(this.dataGridView1.Location.X, textBox1.Location.X);
                dataGridView1.Location = new Point(this.dataGridView1.Location.Y, (400 - y) / 2);

                dataGridView1.Size = new System.Drawing.Size(x, y);

                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
                button2.Enabled = true;
            }
            else
            {
                MessageBox.Show("Размеры не могут быть равны 0");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            label3.Visible = false;
            textBox3.Visible = false;
            opt = 1;

            label2.Location = new Point(this.label2.Location.X, dataGridView1.Location.X + dataGridView1.Size.Width + 5);
            label2.Location = new Point(this.label2.Location.Y, dataGridView1.Location.Y - 10);
            label2.Text = "T";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            label3.Visible = false;
            textBox3.Visible = false;
            opt = 2;

            label2.Location = new Point(this.label2.Location.X, dataGridView1.Location.X + dataGridView1.Size.Width + 5);
            label2.Location = new Point(this.label2.Location.Y, dataGridView1.Location.Y - 10);
            label2.Text = "-1";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = true;
            textBox3.Visible = true;
            opt = 3;

            label3.Location = new Point(this.label3.Location.X, dataGridView1.Location.X - label3.Size.Width - 3);
            label3.Location = new Point(this.label3.Location.Y, dataGridView1.Location.Y + (dataGridView1.Size.Height / 2) - 7);
            textBox3.Location = new Point(this.textBox3.Location.X, dataGridView1.Location.X - textBox3.Size.Width - label3.Size.Width - 6);
            textBox3.Location = new Point(this.textBox3.Location.Y, dataGridView1.Location.Y + (dataGridView1.Size.Height / 2) - 10);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool notfin = false;
            int[,] values = new int[M, N];
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    if (dataGridView1.Rows[j].Cells[i].Value == null)
                    {
                        notfin = true;
                        break;
                    }
                    else
                    {
                        values[i, j] = Convert.ToInt32(dataGridView1.Rows[j].Cells[i].Value.ToString());
                    }
                }
                if (notfin == true)
                {
                    MessageBox.Show("Заполните матрицу");
                    break;
                }
            }
            utils.calculate(opt, values);
        }

    }



    public class utils
    {

        public static void calculate(int opt, int[,] values)
        {
            if (opt == 1)
            {



            }
            else if (opt == 2)
            {

            }
            else if (opt == 3)
            {

            }

        }



    }
}
